
from datetime import datetime
from src.db_helpers.entry import *


class Entry(object):
    def __init__(self, user_id: int, entry_time: datetime, queue_time: int) -> None:
        self.user_id = user_id
        self.entry_time = entry_time
        self.queue_time = queue_time

    def add_entry(self) -> None:
        insert_entry(self.user_id, self.entry_time, self.queue_time)

    @staticmethod
    def get_all_entries():
        return select_all_entries()


