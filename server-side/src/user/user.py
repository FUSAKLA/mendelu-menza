
from datetime import datetime, time
from src.beacon_hit import BeaconHit


class User(object):
    def __init__(self, user_id: int):
        self.user_id = user_id

    def last_hit_time(self) -> datetime:
        return BeaconHit.get_last_hit_for_user(user_id=self.user_id)

    def get_hits_in_time_interval(self, start_time: datetime, end_time: datetime) -> list:
        return BeaconHit.get_hits_in_time_interval(self.user_id, start_time, end_time)

    def get_most_frequent_hit_hour(self, start_time: datetime, end_time: datetime) -> time:
        hits_in_interval = self.get_hits_in_time_interval(start_time, end_time)
        # logic goes here
        return datetime.now().time

