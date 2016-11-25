
from datetime import datetime
from src.db_helpers.beacon_hit import insert_beacon_hit


class BeaconHit(object):
    def __init__(self, beacon_id: str, user_id: int, hit_time: datetime) -> None:
        self.beacon_id = beacon_id
        self.user_id = user_id
        self.hit_time = hit_time

    def add_beacon_hit(self) -> None:
        insert_beacon_hit(self.beacon_id, self.user_id, self.hit_time)

    def get_last_hit_for_user(self, user_id: int):
        pass

    def get_hits_in_time_interval(self,user_id: int, start_time: datetime, end_time: datetime) -> list:
        pass

