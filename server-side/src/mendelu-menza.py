import sys
sys.path.append("..")

from flask import Flask, g
import beacon_hit
import user
import level
import traffic
from pymongo import MongoClient

app = Flask(__name__)
app.register_blueprint(beacon_hit.bp, url_prefix='/beacon_hit')
app.register_blueprint(user.bp, url_prefix='/user')
app.register_blueprint(level.bp, url_prefix='/level')
app.register_blueprint(traffic.bp, url_prefix='/traffic')


@app.before_request
def set_mongo_db(host: str="", port: int=0) -> None:
    """Opens a new database connection if there is none yet for the
    current application context.
    """
    if not hasattr(g, 'mongo_db'):
        conn_str = "mongodb://mendelu-menza-db:JnW6X1JqFO5BcakziIQBvi5H2CSOmLcYYcDDP4zcFjYxFsuJqu7RWPpKOJOtxX6VkCA" \
                   "0Hn44dpNIUJRLQraKTg==@mendelu-menza-db.documents.azure.com:10250/?ssl=true&ssl_cert_reqs=CERT_NONE"
        g.mongo_db = MongoClient(conn_str)


@app.teardown_appcontext
def close_mongo_conn(error):
    """Closes the mongo database again at the end of the request."""
    if hasattr(g, 'mongo_db'):
        g.mongo_db.close()


if __name__ == '__main__':
    app.run("0.0.0.0")

