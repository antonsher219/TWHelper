from tweet import Tweetpy
from twitter_prediction import TwitterPrediction
from twitter_plots import TwitterPlots

from flask import Flask, render_template, request, g, session
import json
import socket

app = Flask(__name__)

@app.route('/api/analytics', methods=['POST'])
def on_post():
    twitter_nick = request.args.get('twitter_nick', type=str)
    count = request.args.get('count', type=int)

    print(twitter_nick)
    print(count)

    twitter_api = Tweetpy()
    twitter_data = twitter_api.get_tweets(twitter_nick, count)

    prediction = TwitterPrediction()
    twitter_data = prediction.get_predictions(twitter_data)

    twitter_plots = TwitterPlots()
    happiness_rate = twitter_plots.make_plots(twitter_data, twitter_nick)

    return happiness_rate[0].to_json()

#waitress-serve --port=5000 Falcon:app

from waitress import serve
serve(app, host='127.0.0.1', port=5000, channel_timeout=10000)

if __name__ == "__main__":
    print('sd')
