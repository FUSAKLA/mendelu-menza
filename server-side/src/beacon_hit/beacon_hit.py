
from datetime import datetime
from src.db_helpers.beacon_hit import *
from src.entry.entry import Entry
from src.exit.exit import Exit


BEACON_1_ID = "1"
BEACON_2_ID = "2"


class BeaconHit(object):
    def __init__(self, beacon_id: str, user_id: int, hit_time: datetime) -> None:
        self.beacon_id = beacon_id
        self.user_id = user_id
        self.hit_time = datetime.strptime(hit_time, "%Y-%m-%d %H:%M:%S")

    def add_beacon_hit(self) -> None:
        print("=================")
        last_hits = get_user_last_hit(self.user_id)
        if last_hits.count() == 0:
            insert_beacon_hit(self.user_id, self.beacon_id, self.hit_time)
            return
        last_hit = last_hits[0]
        print(last_hits.count())
        print(last_hit)
        if last_hit["beacon_id"] != self.beacon_id:
            last_hit_time = last_hit["hit_time"]
            queue_time = (self.hit_time - last_hit_time).total_seconds()
            print("$$$$$$$$$")
            print(self.beacon_id)
            if self.beacon_id == BEACON_1_ID:
                print("!!! EXIT ADDED")
                new_exit = Exit(self.user_id, last_hit["hit_time"], queue_time)
                new_exit.add_exit()
            elif self.beacon_id == BEACON_2_ID:
                print("!!! ENTRY ADDED")
                new_entry = Entry(self.user_id, last_hit["hit_time"], queue_time)
                new_entry.add_entry()
            delete_hits_by_user_id(self.user_id)
        elif last_hit["beacon_id"] != self.beacon_id and self.beacon_id == BEACON_1_ID:
            delete_hits_by_user_id(self.user_id)
            insert_beacon_hit(self.user_id, self.beacon_id, self.hit_time)

    @staticmethod
    def delete_db():
        delete_db()



