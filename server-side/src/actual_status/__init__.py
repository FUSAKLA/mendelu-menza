from flask import Blueprint, request, jsonify
from src.db_helpers.beacon_hit import get_ordered_user_hits_per_last_n_minutes


bp = Blueprint('actual_status', __name__)


@bp.route("/<minutes>", methods=["GET"])
def get_actual_status(minutes):
    hits_per_user = get_ordered_user_hits_per_last_n_minutes(int(minutes))
    print(hits_per_user)
    return jsonify(hits_per_user)
