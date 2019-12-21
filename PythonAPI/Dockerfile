FROM python:3.6.8

ENV PYTHONDONTWRITEBYTECODE=1
ENV FLASK_APP="app.py"
ENV FLASK_NEW="development"
ENV FLASK_DEBUG=True

RUN  mkdir /app
WORKDIR /app

COPY ./requirements.txt /app/requirements.txt

RUN pip install -r requirements.txt

ADD . /app

EXPOSE 5000

ENTRYPOINT [ "python" ]

CMD [ "app.py" ]
