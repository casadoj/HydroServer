from odmdata import SessionFactory
from odmdata import Site
from odmdata import Variable
from odmdata import Unit
from odmdata import Series
from odmdata import DataValue
from odmdata import QualityControlLevel
from odmdata import Qualifier

from series_service import SeriesService

import sqlite3

class EditService():
    # Mutual exclusion: cursor, or connection_string
    def __init__(self, series_id, connection=None, connection_string="",  debug=False):
        # print "Series id: ", series_id
        self._connection = connection
        self._series_id = series_id
        self._filter_from_selection = False
        self._debug = debug

        if (connection_string is not ""):
            self._session_factory = SessionFactory(connection_string, debug)
            self._series_service = SeriesService(connection_string, debug)
        elif (factory is not None):
            self._session_factory = factory
            service_manager = ServiceManager()
            self._series_service = service_manager.get_series_service()
        else:
            # One or the other must be set
            print "Must have either a connection string or session factory"
            # TODO throw an exception
        
        self._edit_session = self._session_factory.get_session()

        if self._connection == None:
            series_service = SeriesService(connection_string, False)
            DataValues = series_service.get_data_values_by_series_id(series_id)
            self._connection = sqlite3.connect(":memory:", detect_types= sqlite3.PARSE_DECLTYPES)
            tmpCursor = self._connection.cursor()
            self.init_table(tmpCursor)
            tmpCursor.executemany("INSERT INTO DataValuesEdit VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", DataValues)

        self._connection.commit()
        self._cursor = self._connection.cursor()

        self._populate_series()

    def _populate_series(self):
        # [(ID, value, datetime), ...]
        self._cursor.execute("SELECT ValueID, DataValue, LocalDateTime FROM DataValuesEdit ORDER BY LocalDateTime")
        results = self._cursor.fetchall()

        self._active_series = results
        self._active_points = []

    ###################
    # Filters    
    ###################
    # operator is a character, either '<' or '>'
    def filter_value(self, value, operator):
        filter_set = self.get_filter_set()
        if operator == '<': # less than
            tmp = []
            for x in filter_set:
                if x[1] < value:
                    tmp.append(x)
            self._active_points = tmp
        if operator == '>': # greater than
            tmp = []
            for x in filter_set:
                if x[1] > value:
                    tmp.append(x)
            self._active_points = tmp

    def filter_date(self, before, after):
        previous_date_filter = False
        filter_set = self.get_filter_set()
        if before != None:
            tmp = []
            for x in filter_set:
                if x[2] < before:
                    tmp.append(x)
            self._active_points = tmp
            previous_date_filter = True        # We've done a previous date filter, so we've got to decide which set use
        if after != None:
            tmp = []
            if previous_date_filter:
                filter_set = self._active_points
            for x in filter_set:
                if x[2] > after:
                    tmp.append(x)
            self._active_points = tmp

    # Data Gaps
    def data_gaps(self, value, time_period):
        filter_set = self.get_filter_set()
        points = []
        length = len(self._active_points)

        value_sec = 0

        if time_period == 'second':
            value_sec = value
        if time_period == 'minute':
            value_sec = value * 60
        if time_period == 'hour':
            value_sec = value * 60 * 60
        if time_period == 'day':
            value_sec = value * 60 * 60 * 24

        for i in xrange(length):
            if i + 1 < length:      # make sure we stay in bounds
                point1 = filter_set[i]
                point2 = filter_set[i+1]
                interval = point2[2] - point1[2]
                interval__total_sec = interval.total_seconds()

                if interval__total_sec >= value_sec:
                    points.append(point1)
                    points.append(point2)

        self._active_points = points

    def value_change_threshold(self, value):
        filter_set = self.get_filter_set()
        points = []
        length = len(self._active_points)
        for i in xrange(length):
            if i + 1 < length:         # make sure we stay in bounds
                point1 = filter_set[i]
                point2 = filter_set[i+1]
                if abs(point1[1] - point2[1]) >= value:
                    points.append(point1)
                    points.append(point2)

        self._active_points = points

    def change_values(self, value, operator):
        print "in change values"
        print value
        print operator
        if operator == '+':
            for point in self._active_points:
                point[1] += value

        if operator == '-':
            for point in self._active_points:
                point[1] -= value

        if operator == '*':
            for point in self._active_points:
                point[1] *= value

        if operator == '=':
            for point in self._active_points:
                point[1] = value

    def reset_filter(self):
        self._active_points = self._active_series

    def toggle_filter_previous(self):
        if self._filter_from_selection:
            self._filter_from_selection = False
        else:
            self._filter_from_selection = True

    def restore(self):
        self._connection.rollback()
        self._populate_series()

    def save(self):
        # Save to sqlite memory DB, not real DB
        self._connection.commit()

    def write_to_db(self):
        # Save to real DB
        pass

    def get_active_series(self):
        return self._active_series

    def get_active_points(self):
        return self._active_points

    def get_filter_set(self):
        if self._filter_from_selection:
            return self._active_points
        else:
            return self._active_series

    def get_plot_list(self):
        dv_list = [False] * len(self._active_series)
        if self._active_points != self._active_series:
            id_list = [x[0] for x in self._active_points]
            for i in range(len(self._active_series)):
                if self._active_series[i][0] in id_list:
                    dv_list[i] = True

        return dv_list
        if len(self._active_points)==len(self._active_series):
            return []

    def add_point(self, point):
        # add to active_series
        # save to sqlite DB
        pass

    def delete_points(self):
        #TODO delete selected points from cursor
        execute_string = "DELETE FROM DataValuesEdit WHERE ValueID IN ("
        num_active_points = len(self._active_points)
        if num_active_points > 0:
            for i in range(num_active_points-1):        # loop through the second-to-last active point
                execute_string += "%s," % (self._active_points[i][0])   # append its ID
            execute_string += "%s)" % (self._active_points[-1][0])  # append the final point's ID and close the set

            # Delete the points from the cursor
            self._cursor.execute(execute_string)

            tmp = [x for x in self._active_series if x not in self._active_points]
            self._active_series = tmp
            self._active_points = []       # clear the filter


    def select_points(self, id_list=[], datetime_list=[]):
        pass

    def reconcile_dates(self, parent_series_id):
        # append new data to this series
        pass

    def init_table(self, cursor):
        cursor.execute("""CREATE TABLE DataValuesEdit
                (ValueID INTEGER NOT NULL,
                DataValue FLOAT NOT NULL,
                ValueAccuracy FLOAT,
                LocalDateTime TIMESTAMP NOT NULL,
                UTCOffset FLOAT NOT NULL,
                DateTimeUTC TIMESTAMP NOT NULL,
                SiteID INTEGER NOT NULL,
                VariableID INTEGER NOT NULL,
                OffsetValue FLOAT,
                OffsetTypeID INTEGER,
                CensorCode VARCHAR(50) NOT NULL,
                QualifierID INTEGER,
                MethodID INTEGER NOT NULL,
                SourceID INTEGER NOT NULL,
                SampleID INTEGER,
                DerivedFromID INTEGER,
                QualityControlLevelID INTEGER NOT NULL,

                PRIMARY KEY (ValueID),
                UNIQUE (DataValue, LocalDateTime, SiteID, VariableID, MethodID, SourceID, QualityControlLevelID))
               """)