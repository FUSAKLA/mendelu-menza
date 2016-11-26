
from datetime import datetime, timedelta
from flask import g


def get_entry_collection():
    client = g.mongo_db
    return client.mendelu_menza.entry


def insert_entry(user_id: int, entry_time: datetime, queue_time: int):
    entry = get_entry_collection()
    entry.insert(
        {
            "user_id": user_id,
            "entry_time": entry_time,
            "queue_time": queue_time
        }
    )


def select_all_entries():
    entry = get_entry_collection()
    return entry.find({}, {"user_id": 1, "entry_time": 1, "queue_time": 1, "_id": -1})
