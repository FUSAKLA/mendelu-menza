import sys
sys.path.append("..")

from flask import Flask
from entities import entity


app = Flask(__name__)


@app.route('/')
def hello_world():
    return 'Hello World!'


if __name__ == '__main__':
    app.run()
    app.register_blueprint(entity.bp, url_prefix='/entity')
