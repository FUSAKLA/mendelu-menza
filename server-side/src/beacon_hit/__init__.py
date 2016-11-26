from flask import Blueprint, request, jsonify
from src.beacon_hit.beacon_hit import BeaconHit

bp = Blueprint('beacon_hit', __name__)


@bp.route("", methods=["PUT"])
def put_beacon_hit():
    data = request.get_json()
    beacon_hit = BeaconHit(data["beacon_id"], data["user_id"], data["hit_time"])
    beacon_hit.add_beacon_hit()
    return jsonify({"res": "OK"})


@bp.route("/deleteDB", methods=["GET"])
def delete_db():
    BeaconHit.delete_db()
    return jsonify("DB ereased")