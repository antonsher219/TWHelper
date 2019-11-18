import asyncio
import websockets
import json

from tweet import Tweetpy
from twitter_prediction import TwitterPrediction
from twitter_plots import TwitterPlots

async def prediction(websocket, path):
    while True:
        analysis_data = await websocket.recv()
        analysis_data = json.loads(analysis_data)
        
        twitter_nick = analysis_data["twitter_nick"]
        count = analysis_data["count"]

        print(twitter_nick)
        print(count)

        try:
            await websocket.send("downloading data")
            twitter_api = Tweetpy()
            twitter_data = twitter_api.get_tweets(twitter_nick, count)
            
            await websocket.send("analysing data")
            prediction = TwitterPrediction()
            twitter_data = prediction.get_predictions(twitter_data)

            await websocket.send("creating reports")
            twitter_plots = TwitterPlots()
            happiness_rate = twitter_plots.make_plots(twitter_data, twitter_nick)
            await websocket.send("done")

            await websocket.send(happiness_rate[0].to_json())

        except Exception:
            await websocket.send("prediction error")


start_server = websockets.serve(prediction, "localhost", 5000)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()


