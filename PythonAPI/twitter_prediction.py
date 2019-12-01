from tweet import Tweetpy
from twitter_classifier import TwitterClassifier
from response_dto import ResponseDTO

import re
from collections import Counter
import json

class TwitterPrediction:
    async def get_predictions(self, text_tweets, websocket):
        classifier = TwitterClassifier()
        await websocket.send(ResponseDTO("status", "message", "data parsed").to_json())
        
        text_tweets['tokenized'] = classifier.preprocess(text_tweets.Text.values)
        text_tweets['prediction'] = classifier.predict(text_tweets.tokenized.values, preprocess=False)
        text_tweets['class'] = text_tweets.prediction.apply(lambda x: 'Positive' if x > 0.5 else 'Negative')
            
        text_tweets_sorted = text_tweets.sort_values('prediction')
        worst_tweet = {
            'text': text_tweets_sorted['Text'][0],
            'date': str(text_tweets_sorted['Date'][0]),
            'prediction': str(text_tweets_sorted['prediction'][0])
        };
        
        best_tweet = {
            'text': text_tweets_sorted['Text'].iloc[-1], 
            'date': str(text_tweets_sorted['Date'].iloc[-1]), 
            'prediction': str(text_tweets_sorted['prediction'].iloc[-1])
        }

        await websocket.send(ResponseDTO("data", "top_negative_tweet", json.dumps(worst_tweet)).to_json())
        await websocket.send(ResponseDTO("data", "top_positive_tweet", json.dumps(best_tweet)).to_json())
    
        print(text_tweets)

        words = classifier.preprocess([' '.join(text_tweets.Text.values)]).flatten()
        score = classifier.predict(words).flatten()
        res = list(zip(words, score))

        negative = list(filter(lambda x: x[1] <= 0.25, res))
        positive = list(filter(lambda x: x[1] > 0.75, res))
        top_neg = sorted(Counter(negative).items(), key=lambda item: -item[1])[:10]
        top_pos = sorted(Counter(positive).items(), key=lambda item: -item[1])[:10]

        top_pos_json = []
        for item in top_pos:
            top_pos_json.append({'term': item[0][0], 'rate': str(item[0][1]), 'count': item[1]})

        top_neg_json = []
        for item in top_neg:
            top_neg_json.append( {'term': item[0][0], 'rate': str(item[0][1]), 'count': item[1]} )   

        await websocket.send(ResponseDTO("data", "top_negative_words", json.dumps(top_neg_json)).to_json())
        await websocket.send(ResponseDTO("data", "top_positive_words", json.dumps(top_pos_json)).to_json())

        print('Top negative words:')
        print(*top_neg, sep='\n', end='\n\n')
        print('Top positive words:')
        print(*top_pos, sep='\n')

        return text_tweets



if __name__ == '__main__':
    twitter_api = Tweetpy()
    twitter_data = twitter_api.get_tweets("realmenofilters", 200)

    prediction = TwitterPrediction()
    prediction.get_predictions(twitter_data)
