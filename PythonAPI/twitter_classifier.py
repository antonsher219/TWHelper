import re
from collections import Counter

import joblib
import numpy as np
import pandas as pd
import nltk
from nltk.corpus import stopwords
from tensorflow.keras.preprocessing.text import Tokenizer
from tensorflow.keras.preprocessing.sequence import pad_sequences
from tensorflow.keras.layers import Embedding
from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Dense,LSTM,Dropout
from tensorflow.keras.callbacks import ModelCheckpoint, EarlyStopping
from sklearn.preprocessing import LabelEncoder


class TwitterClassifier:

    def __init__(self, tokenizer_path='data/tokenizer.pkl'):
        nltk.download('stopwords')
        self.stop_words = set(stopwords.words('english'))
        self.stop_words.remove('not')
        self.tokenizer = joblib.load(tokenizer_path)
        self.prepare_model()

    def prepare_embeddings(self, embedding_path):
        w2v_model = joblib.load(embedding_path)
        vocab_size=len(self.tokenizer.word_index) + 1
        embedding_matrix = np.zeros((vocab_size, 300))
        for word, i in self.tokenizer.word_index.items():
            if word in w2v_model.wv:
                embedding_matrix[i - 1] = w2v_model.wv[word]

        return Embedding(
            vocab_size, 300, weights=[embedding_matrix],
            input_length=300, trainable=False
        )

    def prepare_model(self, embedding_path='data/word2vec.pkl', model_weights='data/best.hdf5'):
        embedding_layer = self.prepare_embeddings(embedding_path)
        model = Sequential()
        model.add(embedding_layer)
        model.add(Dropout(0.5))
        model.add(LSTM(50, dropout=0.2, recurrent_dropout=0.2))
        model.add(Dense(1, activation='sigmoid'))
        model.compile(
            loss='binary_crossentropy',
            optimizer='adam',
            metrics=['accuracy']
        )
        model.load_weights(model_weights)

        self.model = model

    def preprocess(self, text_array):
        result = []
        for text in text_array:
            tweet = re.sub('@\S+|https?:\S+|http?:\S|[^A-Za-z0-9]+', ' ', text)
            tweet = tweet.lower()
            tweet = tweet.split()
            result.append([word for word in tweet if not word in self.stop_words])

        return np.array(result)

    def to_vector(self, text_array):
        return pad_sequences(self.tokenizer.texts_to_sequences(text_array), maxlen=300)

    def predict(self, text_array, preprocess=True):
        if preprocess:
            text = self.preprocess(text_array)

        return self.model.predict(self.to_vector(text_array))


if __name__ == '__main__':
    classifier = TwitterClassifier()