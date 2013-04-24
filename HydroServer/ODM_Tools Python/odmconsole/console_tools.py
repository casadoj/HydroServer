# This class is intended for users to simplify console interaction

import wx.py.crust
from odmservices import RecordService
from wx.lib.pubsub import Publisher


class ConsoleTools(object):

    def __init__(self, ribbon, record_service=None):
        self._edit_error = "no series selected for editing"

        self._ribbon = ribbon
        self._record_service = record_service
    

    ################
    # Set methods
    ################
    def set_record_service(self, rec_serv):
        self._record_service = rec_serv

    def toggle_recording(self):
        if self._record_service:
            self._record_service.toggle_record()
        else:
            return "Cannot record: %s" % (self._edit_error)

    ################
    # Edit methods
    ################
    def filter_value(self, value, operator):
        if self._record_service:
            self._record_service.filter_value(value, operator)
            self.refresh_plot()
        else:
            return "Cannot filter: %s" % (self._edit_error)

    def filter_dates(self, before, after):
        if self._record_service:
            self._record_service.filter_dates(before, after)
            self.refresh_plot()
        else:
            return "Cannot filter: %s" % (self._edit_error)

    ###############
    # UI methods
    ###############
    def refresh_plot(self):
        Publisher().sendMessage(("changePlotSelection"), self._record_service.get_plot_list())