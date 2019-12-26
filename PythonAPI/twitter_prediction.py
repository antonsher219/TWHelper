from tweet import Tweetpy
from twitter_classifier import TwitterClassifier, SentimentClassifier
from response_dto import ResponseDTO

import re
from collections import Counter
import json

class TwitterPrediction:
    async def get_predictions(self, text_tweets, websocket):
        binary_classifier = TwitterClassifier()
        sentiment_classifier = SentimentClassifier()
        await websocket.send(ResponseDTO("status", "message", "data parsed").to_json())
        np.random.seed(42)
        text_tweets = pd.read_csv(tweets_path, delimiter='\t')
        text_tweets['tokenized'] = binary_classifier.preprocess(text_tweets.Text.values)
        text_tweets['prediction'] = binary_classifier.predict(text_tweets.tokenized.values, preprocess=False)
        text_tweets['class'] = text_tweets.prediction.apply(lambda x: 'Positive' if x > 0.5 else 'Negative')
        text_tweets['sentiment'] = sentiment_classifier.predict(text_tweets.Text)
        # text_tweets.to_csv(f'{output_path}/predictions.csv', sep='\t', index=False)

        examples = text_tweets.sort_values('prediction').iloc[[0, -1]]
        sentiments = ['love', 'sadness', 'anger', 'happiness', 'neutral']
        for sentiment in sentiments:
            example = text_tweets.loc[text_tweets.sentiment == sentiment]
            if example.shape[0] > 0:
                examples = examples.append(example.iloc[0])

        examples.drop_duplicates('Text', inplace=True)
        # examples.to_csv(f'{output_path}/examples.csv', sep='\t', index=False)

        worst_tweet = {
            'text': examples['Text'].iloc[0],
            'date': str(examples['Date'].iloc[0]),
            'prediction': str(examples['prediction'].iloc[0]),
            'class': str(examples['class'].iloc[0]),
            'sentiment': str(examples['sentiment'].iloc[0]),
        }
        
        best_tweet = {
            'text': text_tweets_sorted['Text'].iloc[1], 
            'date': str(text_tweets_sorted['Date'].iloc[1]), 
            'prediction': str(text_tweets_sorted['prediction'].iloc[1]),
            'class': str(examples['class'].iloc[1]),
            'sentiment': str(examples['sentiment'].iloc[1]),
        }

        await websocket.send(ResponseDTO("data", "top_negative_tweet", json.dumps(worst_tweet)).to_json())
        await websocket.send(ResponseDTO("data", "top_positive_tweet", json.dumps(best_tweet)).to_json())

        words = binary_classifier.preprocess([' '.join(text_tweets.Text.values)]).flatten()
        score = binary_classifier.predict(words).flatten()
        res = list(zip(words, score))

        negative = list(filter(lambda x: x[1] <= 0.25, res))   
        positive = list(filter(lambda x: x[1] > 0.75, res))
        top_neg = sorted(Counter(negative).items(), key=lambda item: -item[1])
        top_pos = sorted(Counter(positive).items(), key=lambda item: -item[1])
       
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
