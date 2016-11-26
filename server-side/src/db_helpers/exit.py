
from datetime import datetime, timedelta
from flask import g


def get_exit_collection():
    client = g.mongo_db
    return client.mendelu_menza.exit


def insert_exit(user_id: int, exit_time: datetime, queue_time: int):
    exit = get_exit_collection()
    exit.insert(
        {
            "user_id": user_id,
            "exit_time": exit_time,
            "queue_time": queue_time
        }
    )


def select_all_exits():
    exit = get_exit_collection()
    return exit.find({}, {"user_id": 1, "exit_time": 1, "queue_time": 1, "_id": -1})