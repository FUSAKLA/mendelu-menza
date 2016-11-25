import sys
sys.path.append("..")

from flask import Flask, g
import beacon_hit
import user
import actual_status
from pymongo import MongoClient

app = Flask(__name__)
app.register_blueprint(beacon_hit.bp, url_prefix='/beacon_hit')
app.register_blueprint(user.bp, url_prefix='/user')
app.register_blueprint(actual_status.bp, url_prefix='/actual_status')


@app.before_request
def set_mongo_db(host: str="", port: int=0) -> None:
    """Opens a new database connection if there is none yet for the
    current application context.
    """
    if not hasattr(g, 'mongo_db'):
        g.mongo_db = MongoClient("localhost", 27017)


@app.teardown_appcontext
def close_mongo_conn(error):
    """Closes the mongo database again at the end of the request."""
    if hasattr(g, 'mongo_db'):
        g.mongo_db.close()


if __name__ == '__main__':
    app.run()

