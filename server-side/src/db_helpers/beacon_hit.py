
from datetime import datetime, timedelta
from flask import g


def get_beacon_hit_collection():
    client = g.mongo_db
    return client.mendelu_menza.beacon_hits


def insert_beacon_hit(user_id: int, beacon_id: str, hit_time: datetime):
    beacon_hits = get_beacon_hit_collection()
    beacon_hits.insert(
        {
            "user_id": user_id,
            "beacon_id": beacon_id,
            "hit_time": hit_time
        }
    )


def get_user_last_hit(user_id: int):
    beacon_hits = get_beacon_hit_collection()
    res = beacon_hits.find(
        {
            "user_id": user_id
        }
    )
    return res


def delete_hits_by_user_id(user_id):
    beacon_hits = get_beacon_hit_collection()
    beacon_hits.remove(
        {
            "user_id": user_id
        }
    )


def get_ordered_user_hits_per_last_n_minutes(minutes: int) -> dict:
    beacon_hits = get_beacon_hit_collection()
    limit_time = datetime.now() - timedelta(minutes=minutes)
    aggregated_data = beacon_hits.aggregate(
        [
            {
                "$match": {"hit_time": {"$gt": limit_time}}
            },
                {
                "$group": {
                    "_id": "$user_id",
                    "hits": {"$push": {"beacon_id": "$beacon_id", "hit_time": "$hit_time"}}
                }
            },
            {
                "$sort": {
                        "hit_time": -1
                }
            }
        ]
    )
    return aggregated_data


def delete_db():
    g.mongo_db.mendelu_menza.drop_collection('beacon_hits')
    g.mongo_db.mendelu_menza.drop_collection('entry')
    g.mongo_db.mendelu_menza.drop_collection('exit')
