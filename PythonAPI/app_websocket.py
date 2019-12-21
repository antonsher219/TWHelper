import asyncio
import websockets
import json

from tweet import Tweetpy
from twitter_prediction import TwitterPrediction
from twitter_plots import TwitterPlots
from response_dto import ResponseDTO

async def prediction(websocket, path):
    while True:
        analysis_data = await websocket.recv()
        analysis_data = json.loads(analysis_data)
        
        twitter_nick = analysis_data["twitter_nick"]
        count = analysis_data["count"]

        print(twitter_nick)
        print(count)

        try:
            await websocket.send(ResponseDTO("status", "message", "downloading data").to_json())
            twitter_api = Tweetpy()
            twitter_data = twitter_api.get_tweets(twitter_nick, count)
            
            await websocket.send(ResponseDTO("status", "message", "analysing data").to_json())
            prediction = TwitterPrediction()
            twitter_data = await prediction.get_predictions(twitter_data, websocket)

            await websocket.send(ResponseDTO("status", "message", "creating reports").to_json())
            twitter_plots = TwitterPlots()
            twitter_plots.make_plots(twitter_data, twitter_nick)
            await websocket.send(ResponseDTO("status", "done", twitter_nick).to_json())

        except Exception:
            await websocket.send(ResponseDTO("error", "message", "shit happens").to_json())
            

start_server = websockets.serve(prediction, "0.0.0.0", 5000)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()


