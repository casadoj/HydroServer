#Boa:Frame:frmDBConfig

import wx

def create(parent):
    return frmDBConfig(parent)

[wxID_FRMDBCONFIG, wxID_FRMDBCONFIGBOXCONNECTION, wxID_FRMDBCONFIGBTNCANCEL, 
 wxID_FRMDBCONFIGBTNSAVE, wxID_FRMDBCONFIGBTNTEST, wxID_FRMDBCONFIGCOMBOBOX1, 
 wxID_FRMDBCONFIGLBLDBNAME, wxID_FRMDBCONFIGLBLDBTYPE, wxID_FRMDBCONFIGPNLMAIN,
 wxID_FRMDBCONFIGLBLPASS, wxID_FRMDBCONFIGLBLSERVER, wxID_FRMDBCONFIGLBLUSER, 
 wxID_FRMDBCONFIGPNLCONNECTION, wxID_FRMDBCONFIGPNLMAIN, wxID_FRAME1BOXCONNECTION,
 wxID_FRMDBCONFIGTXTDBNAME, wxID_FRMDBCONFIGTXTPASS, wxID_FRAME1LBLUSER, 
 wxID_FRMDBCONFIGTXTSERVER, wxID_FRMDBCONFIGTXTUSER, wxID_FRAME1TXTPASS,
 wxID_FRAME1LBLDBNAME, wxID_FRAME1TXTSERVER, wxID_FRAME1BOXCONNECTION,
] = [wx.NewId() for _init_ctrls in range(24)]

class frmDBConfig(wx.Frame):
    def _init_coll_boxSizer3_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.lblDbType, 25, border=5, flag=wx.ALL | wx.GROW)
        parent.AddWindow(self.comboBox1, 75, border=5, flag=wx.GROW | wx.ALL)

    def _init_coll_boxSizer1_Items(self, parent):
        # generated method, don't edit

        parent.AddSizer(self.boxSizer3, 17, border=5, flag=wx.GROW | wx.ALL)
        parent.AddWindow(self.pnlConnection, 66, border=5,
              flag=wx.GROW | wx.ALL)
        parent.AddSizer(self.boxSizer2, 17, border=5, flag=wx.ALL | wx.GROW)

    def _init_coll_boxSizer2_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.btnTest, 33, border=5, flag=wx.GROW | wx.ALL)
        parent.AddWindow(self.btnSave, 33, border=5, flag=wx.ALL | wx.GROW)
        parent.AddWindow(self.btnCancel, 33, border=5, flag=wx.GROW | wx.ALL)

    def _init_sizers(self):
        # generated method, don't edit
        self.boxSizer1 = wx.BoxSizer(orient=wx.VERTICAL)

        self.boxSizer2 = wx.BoxSizer(orient=wx.HORIZONTAL)

        self.boxSizer3 = wx.BoxSizer(orient=wx.HORIZONTAL)

        self._init_coll_boxSizer1_Items(self.boxSizer1)
        self._init_coll_boxSizer2_Items(self.boxSizer2)
        self._init_coll_boxSizer3_Items(self.boxSizer3)

        self.pnlMain.SetSizer(self.boxSizer1)

    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Frame.__init__(self, id=wxID_FRMDBCONFIG, name=u'frmDBConfig',
              parent=prnt, pos=wx.Point(685, 312), size=wx.Size(476, 310),
              style=wx.DEFAULT_FRAME_STYLE, title=u'Database Configuration')
        self.SetClientSize(wx.Size(460, 272))

        self.pnlMain = wx.Panel(id=wxID_FRMDBCONFIGPNLMAIN, name=u'pnlMain',
              parent=self, pos=wx.Point(0, 0), size=wx.Size(460, 272),
              style=wx.TAB_TRAVERSAL)

        self.lblDbType = wx.StaticText(id=wxID_FRMDBCONFIGLBLDBTYPE,
              label=u'Connection Type:', name=u'lblDbType', parent=self.pnlMain,
              pos=wx.Point(10, 10), size=wx.Size(102, 26), style=0)

        self.comboBox1 = wx.ComboBox(choices=[], id=wxID_FRMDBCONFIGCOMBOBOX1,
              name='comboBox1', parent=self.pnlMain, pos=wx.Point(122, 10),
              size=wx.Size(328, 21), style=0,
              value=u'Microsoft SQL Server\nMySQL')
        self.comboBox1.SetLabel(u'Microsoft SQL Server')

        self.btnTest = wx.Button(id=wxID_FRMDBCONFIGBTNTEST,
              label=u'Test Connection', name=u'btnTest', parent=self.pnlMain,
              pos=wx.Point(10, 235), size=wx.Size(140, 27), style=0)

        self.btnSave = wx.Button(id=wxID_FRMDBCONFIGBTNSAVE,
              label=u'Save Connection', name=u'btnSave', parent=self.pnlMain,
              pos=wx.Point(160, 235), size=wx.Size(140, 27), style=0)

        self.btnCancel = wx.Button(id=wxID_FRMDBCONFIGBTNCANCEL,
              label=u'Cancel', name=u'btnCancel', parent=self.pnlMain,
              pos=wx.Point(310, 235), size=wx.Size(140, 27), style=0)

        self.pnlConnection = wx.Panel(id=wxID_FRMDBCONFIGPNLCONNECTION,
              name=u'pnlConnection', parent=self.pnlMain, pos=wx.Point(5, 51),
              size=wx.Size(450, 169), style=wx.TAB_TRAVERSAL)

        self.boxConnection = wx.StaticBox(id=wxID_FRAME1BOXCONNECTION,
              label=u'Microsoft SQL Server', name=u'boxConnection',
              parent=self.pnlConnection, pos=wx.Point(8, 8), size=wx.Size(432,
              152), style=0)

        self.lblUser = wx.StaticText(id=wxID_FRAME1LBLUSER,
              label=u'Server User ID:', name=u'lblUser',
              parent=self.pnlConnection, pos=wx.Point(64, 104), size=wx.Size(76,
              13), style=0)

        self.txtPass = wx.TextCtrl(id=wxID_FRAME1TXTPASS,
              name=u'txtPass', parent=self.pnlConnection, pos=wx.Point(160,
              128), size=wx.Size(248, 21), style=0, value=u'')

        self.txtDBName = wx.TextCtrl(id=wxID_FRMDBCONFIGTXTDBNAME,
              name=u'txtDBName', parent=self.pnlConnection, pos=wx.Point(160,
              64), size=wx.Size(248, 21), style=0, value=u'')

        self.lblDBName = wx.StaticText(id=wxID_FRAME1LBLDBNAME,
              label=u'Database Name:', name=u'lblDBName',
              parent=self.pnlConnection, pos=wx.Point(64, 72), size=wx.Size(81,
              13), style=0)

        self.txtServer = wx.TextCtrl(id=wxID_FRAME1TXTSERVER,
              name=u'txtServer', parent=self.pnlConnection, pos=wx.Point(160,
              32), size=wx.Size(248, 21), style=0, value=u'')

        self.lblServer = wx.StaticText(id=wxID_FRMDBCONFIGLBLSERVER,
              label=u'Server Address:', name=u'lblServer',
              parent=self.pnlConnection, pos=wx.Point(64, 40), size=wx.Size(79,
              16), style=0)

        self.lblPass = wx.StaticText(id=wxID_FRMDBCONFIGLBLPASS,
              label=u'Server Password:', name=u'lblPass',
              parent=self.pnlConnection, pos=wx.Point(56, 136), size=wx.Size(86,
              13), style=0)

        self.txtUser = wx.TextCtrl(id=wxID_FRMDBCONFIGTXTUSER, name=u'txtUser',
              parent=self.pnlConnection, pos=wx.Point(160, 96),
              size=wx.Size(248, 21), style=0, value=u'')

        self._init_sizers()

    def __init__(self, parent):
        self._init_ctrls(parent)



if __name__ == '__main__':
    app = wx.PySimpleApp()
    frame = create(None)
    frame.Show()

    app.MainLoop()
