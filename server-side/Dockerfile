FROM ubuntu

RUN apt-get update && apt-get install -y \
            python3 \
            python3-flask \
            python3-pymongo


COPY ./ /mendelu-menza

WORKDIR /mendelu-menza/src

ENTRYPOINT python3 mendelu-menza.py
