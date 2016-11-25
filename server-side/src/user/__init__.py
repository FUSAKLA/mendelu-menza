from flask import Blueprint

bp = Blueprint('user', __name__)


@bp.route("/<user_id>", methods=["get"])
def get_user_hits(user_id):
    return "OK {}".format(user_id)
