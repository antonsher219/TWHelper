import re
import random

from tweet import Tweetpy
from twitter_prediction import TwitterPrediction

import numpy as np
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt
import multidict as multidict
from wordcloud import WordCloud, STOPWORDS, ImageColorGenerator


def blue_color_func(word, font_size, position, orientation, random_state=None,
                    **kwargs):
    return 'hsl(%d, %d%%, %d%%)' % (220, random.randint(60, 100), random.randint(20, 70))


def yellow_color_func(word, font_size, position, orientation, random_state=None,
                    **kwargs):
    return 'hsl(%d, %d%%, %d%%)' % (50, random.randint(60, 100), random.randint(20, 70))


def getFrequencyDictForText(df):
    fullTermsDict = multidict.MultiDict()
    tmpDict = {}

    # making dict for counting frequencies
    for _, row in df.iterrows():
        text = row["word"]
        val = tmpDict.get(text, 0)
        tmpDict[text.lower()] = val + 1
    for key in tmpDict:
        fullTermsDict.add(key, tmpDict[key])
    return fullTermsDict


class TwitterPlots:
    def make_plots(self, twitter_data, twitter_nick):
        calendar = {
            1: 'January',
            2: 'February',
            3: 'March',
            4: 'April',
            5: 'May',
            6: 'June',
            7: 'July',
            8: 'August',
            9: 'September',
            10: 'October',
            11: 'November',
            12: 'December'    
        }

        binary_classes = ['Positive', 'Negative']
        classes = ['love', 'sadness', 'anger', 'happiness', 'neutral']
        tweets_df = twitter_data
        tweets_df["Date"] = pd.to_datetime(tweets_df["Date"])
        tweets_df.drop(columns="Likes", inplace=True)
        tweets_df.drop(columns="Retweets", inplace=True)

        sentiment_count = tweets_df.groupby([tweets_df["Date"].dt.year, tweets_df["Date"].dt.month, 'sentiment']).count().loc[:, ["class"]]
        sentiment_score = tweets_df.groupby([tweets_df["Date"].dt.year, tweets_df["Date"].dt.month, 'sentiment']).mean()

        emotion_score = tweets_df.groupby([tweets_df["Date"].dt.year, tweets_df["Date"].dt.month]).mean()
        emotion_score.reset_index(level=0, inplace=True)
        emotion_score['Year'] = emotion_score['Date']
        emotion_score.drop(columns="Date", inplace=True)
        emotion_score.reset_index(level=0, inplace=True)
        emotion_score['Month'] = emotion_score['Date']
        emotion_score.drop(columns="Date", inplace=True)
        emotion_score.index = emotion_score.apply(lambda x: f"{int(x['Year'])} {calendar[x['Month']]}", axis=1)
        emotion_score.drop(columns=["Year", "Month"], inplace=True)

        df = tweets_df.groupby([tweets_df["Date"].dt.year, tweets_df["Date"].dt.month]).count()
        df.drop(columns="Date", inplace=True)
        df.drop(columns="class", inplace=True)
        df.drop(columns="Text", inplace=True)
        df.drop(columns="tokenized", inplace=True)
        df.drop(columns="prediction", inplace=True)
        # df.drop(columns="sentiment", inplace=True)
        df.rename(columns={'sentiment': 'count'}, inplace=True)

        max_count = df['count'].max()
        for i, row in sentiment_count.iterrows():
            year, month, sentiment = i
            df.loc[(year, month), sentiment] = int(row['class']) / max_count

        df.fillna(0, inplace=True)
        df.reset_index(level=0, inplace=True)
        df['Year'] = df['Date']
        df.drop(columns="Date", inplace=True)
        df.reset_index(level=0, inplace=True)
        df['Month'] = df['Date']
        df.drop(columns="Date", inplace=True)
        df.index = df.apply(lambda x: f"{int(x['Year'])} {calendar[x['Month']]}", axis=1)
        df.drop(columns=["Year", "Month"], inplace=True)

        # VISUALISATION
        size = (11.7,8.27)
        sns.set(rc={'figure.figsize':size})
        sns.set_style("white")
        sns.set_context("paper")
        pal = ["lightpink", "skyblue", "tomato", "gold", "lavender"]

        # BARCHART DIAGRAM (ACTIVITY)
            
        activity_diagram = df.loc[:, classes].plot.bar(stacked=True, color=pal)
        plt.plot(emotion_score, color='navy', marker='o')
        plt.legend(['Happiness rate', *classes])
        plt.title('Activity diagram')
        plt.xticks(rotation=45);
        plt.savefig(f'../TWHelp/wwwroot/output/activity_{twitter_nick}.png')

        # PIECHART DIAGRAM
            
        pal = ["tomato", "gold","lightpink", "lavender", "skyblue"]
        class_distr = tweets_df.groupby(['sentiment']).count().loc[:, ["class"]].plot(
            kind="pie",
            subplots=True,
            autopct='%1.1f%%',
            colors=pal
        );
        plt.title('Sentiment classes distribution');
        plt.savefig(f'../TWHelp/wwwroot/output/piechart_{twitter_nick}.png')

        # VIOLIN DIAGRAM
        
        plt.figure(figsize=size)
        sns.violinplot(
            x="sentiment", 
            y="prediction",
            hue="class", 
            palette=["skyblue", "orange"],
            data=tweets_df,
        );
        plt.title("Polarity distribution");
        plt.savefig(f'../TWHelp/wwwroot/output/violin_{twitter_nick}.png')        

        # TOP WORDS DIAGRAMS
        
        top_neg = pd.read_csv('output/top_negative.csv')
        top_pos = pd.read_csv('output/top_positive.csv')
        
        wc = WordCloud(background_color="white", max_words=1000)
        wc.generate_from_frequencies(getFrequencyDictForText(top_neg))

        plt.figure(figsize=size)
        plt.imshow(
            wc.recolor(color_func=blue_color_func, random_state=3),
            interpolation="spline16",
        )
        plt.axis("off")
        plt.savefig(f'../TWHelp/wwwroot/output/top_neg_{twitter_nick}.png')        

        wc = WordCloud(background_color="white", max_words=1000)
        wc.generate_from_frequencies(getFrequencyDictForText(top_pos))

        plt.figure(figsize=size)
        plt.imshow(
            wc.recolor(color_func=yellow_color_func, random_state=3),
            interpolation="spline16",
        )
        plt.axis("off")
        plt.savefig(f'../TWHelp/wwwroot/output/top_pos_{twitter_nick}.png')        

        # Тут был happiness_rate. Хз зачем ты его возращаешь
        return emotion_score


if __name__ == "__main__":
    twitter_api = Tweetpy()
    data = twitter_api.get_tweets("realmenofilters", 200) 

    prediction = TwitterPrediction()
    data = prediction.get_predictions(data)

    twitter_plots = TwitterPlots()
    twitter_plots.make_plots(data, "realmenofilters")

