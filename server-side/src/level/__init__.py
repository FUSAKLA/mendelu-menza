from flask import Blueprint, request, jsonify
from src.db_helpers.beacon_hit import get_ordered_user_hits_per_last_n_minutes


bp = Blueprint('level', __name__)


@bp.route("/actual/<minutes>", methods=["GET"])
def get_actual_level(minutes):
    #hits_per_user = get_ordered_user_hits_per_last_n_minutes(int(minutes))
    #print(hits_per_user)
    return jsonify({"level": 1})


@bp.route("/today", methods=["GET"])
def get_today_levels():
    res = {
        "intervals": [
            {
                "start_time": "12:00",
                "level": 2
            },
            {
                "start_time": "12:30",
                "level": 3
            },
            {
                "start_time": "13:00",
                "level": 2
            },
            {
                "start_time" : "13:30",
                "level": 1
            }
        ]
    }
    return jsonify(res)


@bp.route("/history/<start_time>", methods=["GET"])
def get_level_history(start_time):
    res = {
        "history": [
            {
                "week_id": 1,
                "level": 1,
                "queue_time": 3
            },
            {
                "week_id": 2,
                "level": 2,
                "queue_time": 8
            },
            {
                "week_id": 3,
                "level": 3,
                "queue_time": 15
            },
            {
                "week_id": 4,
                "level": 2,
                "queue_time": 6
            }
        ]
    }
    return jsonify(res)