from keras import backend as K 
from keras.applications import VGG19
from keras.applications.vgg19 import preprocess_input,decode_predictions
from keras.preprocessing import image
from keras.preprocessing.image import ImageDataGenerator, load_img, img_to_array
from keras.models import load_model
from keras.layers import Dense,GlobalAveragePooling2D
from keras.engine import Model
import tensorflow as tf
import numpy as np
from PIL import Image
import os
import io
import json
import falcon

graph = tf.Graph()
with graph.as_default():
    pass

class GetImageVector:

    def on_post(self, req, res):
        file = req.stream.read()
        raw_image = Image.open(io.BytesIO(file))
        ready_image = self.prepare_image(raw_image,target=(224, 224))   
        
        #https://stackoverflow.com/questions/40785224/tensorflow-cannot-interpret-feed-dict-key-as-tensor
        #or use graph instead of it
        K.clear_session()

        model = self.get_model()
        pred = model.predict(ready_image)
        print(pred)
        pred = pred.ravel()

        res.status = falcon.HTTP_200
        res.body = json.dumps(pred.tolist())	


    def prepare_image(self,image_input, target):
        if image_input.mode != "RGB":
            image_input = image.convert("RGB")
        
        # resize the input image and preprocess it
        image_input = image_input.resize(target)
        image_input = img_to_array(image_input)
        image_input = np.expand_dims(image_input, axis=0)
        image_input = preprocess_input(image_input)
        
        return image_input


    # get VGG19 model without last layers
    def get_model(self):
        base_model=VGG19(weights='imagenet',include_top=False)

        x=base_model.output
        x=GlobalAveragePooling2D()(x)
        
        x=Dense(1024,activation='relu')(x) 
        x=Dense(1024,activation='relu')(x) 
        x=Dense(512,activation='relu')(x)
    
        model=Model(inputs=base_model.input,outputs=x)
        return model


app = falcon.API()
app.add_route("/upload/", GetImageVector())

#waitress-serve --port=5000 Falcon:app

from waitress import serve
serve(app, host='127.0.0.1', port=5000, channel_timeout=10000)

#if __name__ == "__main__":
#    get_image = GetImageVector();
