from flask import Blueprint, request, jsonify
from src.entry.entry import Entry
from src.exit.exit import Exit

bp = Blueprint('traffic', __name__)


@bp.route("", methods=["GET"])
def get_traffic():
    all_entries = Entry.get_all_entries()
    out_all_entries = [{"user_id": x["user_id"], "queue_time": x["queue_time"], "entry_time": str(x["entry_time"])} for x in all_entries]
    all_exits = Exit.get_all_exits()
    out_all_exits = [{"user_id": x["user_id"], "queue_time": x["queue_time"], "exit_time": str(x["exit_time"])} for x in all_exits]

    res = {
        "total_entries": len(out_all_entries),
        "total_exits": len(out_all_exits),
        "entries": out_all_entries,
        "exits": out_all_exits
    }
    return jsonify(res)
