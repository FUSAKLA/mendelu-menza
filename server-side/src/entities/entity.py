

from flask import Blueprint


bp = Blueprint("entity", __name__)


@bp.route('/', methods=["GET"])
def test():
    return "OK"