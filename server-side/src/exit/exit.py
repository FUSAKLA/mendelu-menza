
from datetime import datetime
from src.db_helpers.exit import *


class Exit(object):
    def __init__(self, user_id: int, exit_time: datetime, queue_time: int) -> None:
        self.user_id = user_id
        self.exit_time = exit_time
        self.queue_time = queue_time

    def add_exit(self) -> None:
        insert_exit(self.user_id, self.exit_time, self.queue_time)

    @staticmethod
    def get_all_exits():
        return select_all_exits()