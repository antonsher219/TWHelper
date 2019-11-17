import re
import csv
import sys
import json
import tweepy
import pandas
import random

class Tweetpy:
    def get_tweets(self, twitter_nick, count):

        with open('data/twitter_keys.json') as src:
          keys = json.load(src)
          src.close()

        auth = tweepy.OAuthHandler(keys['consumer_key'], keys['consumer_secret'])
        auth.set_access_token(keys['access_key'], keys['access_secret'])

        try:
          api = tweepy.API(auth, wait_on_rate_limit=True)
        except tweepy.error.TweepError:
          pass
  
  
        random.seed(42)
        fields = ['Text', 'Date', 'Likes', 'Retweets']
        data = []

        for stuff in tweepy.Cursor(
            api.user_timeline, 
            twitter_nick,
            tweet_mode="extended", 
            exclude_replies=True,
            include_rts = False).items(count):

            text = re.sub(r'http\S+', '', stuff.full_text)
            text = text.replace('\n', ' ').replace('\r', ' ')

            if len(text) < 15:
              continue

            data.append([
                text, 
                stuff.created_at,
                stuff.favorite_count,
                stuff.retweet_count])

        return pandas.DataFrame(data, columns = fields) 



if __name__ == "__main__":
    twitter_api = Tweetpy()
    print(twitter_api.get_tweets("realmenofilters", 200))
