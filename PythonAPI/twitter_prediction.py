from tweet import Tweetpy
from twitter_classifier import TwitterClassifier

import re
from collections import Counter

class TwitterPrediction:
    def get_predictions(self, text_tweets):
        classifier = TwitterClassifier()
        
        text_tweets['tokenized'] = classifier.preprocess(text_tweets.Text.values)
        text_tweets['prediction'] = classifier.predict(text_tweets.tokenized.values, preprocess=False)
        text_tweets['class'] = text_tweets.prediction.apply(lambda x: 'Positive' if x > 0.5 else 'Negative')
    
        print(text_tweets)

        words = classifier.preprocess([' '.join(text_tweets.Text.values)]).flatten()
        score = classifier.predict(words).flatten()
        res = list(zip(words, score))

        negative = list(filter(lambda x: x[1] <= 0.25, res))
        positive = list(filter(lambda x: x[1] > 0.75, res))
        top_neg = sorted(Counter(negative).items(), key=lambda item: -item[1])[:10]
        top_pos = sorted(Counter(positive).items(), key=lambda item: -item[1])[:10]

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
