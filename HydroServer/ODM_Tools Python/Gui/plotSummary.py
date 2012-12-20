#Boa:FramePanel:plotSummary

import wx
import wx.grid
import numpy
import math

[wxID_PLOTSUMMARY, wxID_PLOTSUMMARYGRDSUMMARY, 
] = [wx.NewId() for _init_ctrls in range(2)]

class plotSummary(wx.Panel):
    def _init_coll_boxSizer1_Items(self, parent):
        # generated method, don't edit

        parent.AddWindow(self.grdSummary, 100, border=0, flag=wx.GROW)

    def _init_sizers(self):
        # generated method, don't edit
        self.boxSizer1 = wx.BoxSizer(orient=wx.VERTICAL)

        self._init_coll_boxSizer1_Items(self.boxSizer1)

        self.SetSizer(self.boxSizer1)

    def _init_ctrls(self, prnt):
        # generated method, don't edit
        wx.Panel.__init__(self, id=wxID_PLOTSUMMARY, name=u'plotSummary',
              parent=prnt, pos=wx.Point(747, 267), size=wx.Size(437, 477),
              style=wx.TAB_TRAVERSAL)
        self.SetClientSize(wx.Size(421, 439))

        self.grdSummary = wx.grid.Grid(id=wxID_PLOTSUMMARYGRDSUMMARY,
              name=u'grdSummary', parent=self, pos=wx.Point(0, 0),
              size=wx.Size(421, 439), style=wx.HSCROLL | wx.VSCROLL)
        self.grdSummary.SetLabel(u'')
        self.grdSummary.EnableEditing(False)
        self.initPlot()
        self._init_sizers()

    def addPlot(self, datavalues, series):
        
        self.grdSummary.AppendCols(numCols = 1, updateLabels = True)
        count = self.grdSummary.GetNumberCols()
        self.grdSummary.SetColLabelValue(count-1, series.site_name +"-"+ series.variable_name)
        self.fillValues(datavalues, series.id, count-1)
        
    def remPlot(self, id):
        self.grdSummary.DeleteCols(pos = 0, numCols = 1,  updateLabels = True)
        
    def initPlot(self):
        self.grdSummary.AutoSize()    
        self.grdSummary.CreateGrid (15,0) 
        self.grdSummary.SetRowLabelSize(160)
        self.grdSummary.SetRowLabelValue(0, "Series ID")
        self.grdSummary.SetRowLabelValue(1, "# of Observations")
        self.grdSummary.SetRowLabelValue(2, "# of censored Obs.")
        self.grdSummary.SetRowLabelValue(3, "Arithmetic Mean")
        self.grdSummary.SetRowLabelValue(4, "Geometric Mean")
        self.grdSummary.SetRowLabelValue(5, "Maximum")
        self.grdSummary.SetRowLabelValue(6, "Minimum")
        self.grdSummary.SetRowLabelValue(7, "Standard Deviation")
        self.grdSummary.SetRowLabelValue(8, "Coefficiant of Variation")
        self.grdSummary.SetRowLabelValue(9, "Percentiles:")
        self.grdSummary.SetRowLabelValue(10, "10%")
        self.grdSummary.SetRowLabelValue(11, "25%")
        self.grdSummary.SetRowLabelValue(12, "(Median) 50%")
        self.grdSummary.SetRowLabelValue(13, "75%")
        self.grdSummary.SetRowLabelValue(14, "90%")
        
        
    def fillValues(self, dataValues, sID, col):
        #SetCellValue(int row, int col, const wxString& s)  

        data= sorted(dataValues)
        count=len(data)
        self.grdSummary.SetCellValue(0, col, repr(sID))  
        self.grdSummary.SetCellValue(1, col, repr(count))        
        self.grdSummary.SetCellValue(2, col, repr(0))
        self.grdSummary.SetCellValue(3, col, repr(numpy.mean(data)))  

        

       
        sumval = 0 
        sign = 1 
        for dv in data:
            if dv == 0:
                sumval = sumval+ numpy.log2(1)
            else:
                if dv < 0:
                    sign = sign * -1
                sumval = sumval+ numpy.log2(numpy.absolute(dv))    

                
        self.grdSummary.SetCellValue(4, col, repr((sign * 2) ** float(sumval / float(count))))
        self.grdSummary.SetCellValue(5, col, repr(max(data)))  
        self.grdSummary.SetCellValue(6, col, repr(min(data))) 
        self.grdSummary.SetCellValue(7, col, repr(numpy.std(data)))  
        self.grdSummary.SetCellValue(8, col, repr(numpy.var(data)))


        ##Percentiles
        self.grdSummary.SetCellValue(10, col, repr(data[int(math.floor(count/10))]))  
        self.grdSummary.SetCellValue(11, col, repr(data[int(math.floor(count/4))]))

        if count % 2 == 0 :
            self.grdSummary.SetCellValue(12, col, repr((data[int(math.floor((count/2)-1))]+ data[int(count/2)])/2))  
        else:
            self.grdSummary.SetCellValue(12, col, repr(data[int(numpy.ceil(count/2))]))    

        self.grdSummary.SetCellValue(13, col, repr(data[int(math.floor(count/4*3))]))         
        self.grdSummary.SetCellValue(14, col, repr(data[int(math.floor(count/10*9))]))

        

    def __init__(self, parent, id, pos, size, style, name):
        self._init_ctrls(parent)