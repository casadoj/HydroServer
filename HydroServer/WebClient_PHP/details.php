<html>
<head>
<title>HydroServer Lite Web Client</title>
<link href="styles/main_css.css" rel="stylesheet" type="text/css" media="screen" />

<link rel="stylesheet" href="jqwidgets/styles/jqx.base.css" type="text/css" />
<link rel="stylesheet" href="jqwidgets/styles/jqx.classic.css" type="text/css" />
<link rel="stylesheet" href="jqwidgets/styles/jqx.darkblue.css" type="text/css" />
<script type="text/javascript" src="scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="jqwidgets/jqxcore.js"></script>
<script type="text/javascript" src="jqwidgets/jqxbuttons.js"></script>
<script type="text/javascript" src="jqwidgets/jqxscrollbar.js"></script>
<script type="text/javascript" src="jqwidgets/jqxdata.js"></script>
<script type="text/javascript" src="jqwidgets/jqxlistbox.js"></script>
<script type="text/javascript" src="jqwidgets/jqxdropdownlist.js"></script>
 <script type="text/javascript" src="jqwidgets/jqxdropdownbutton.js"></script>
<script type="text/javascript" src="jqwidgets/jqxpanel.js"></script>
<script type="text/javascript" src="scripts/gettheme.js"></script> 
<script type="text/javascript" src="jqwidgets/jqxdatetimeinput.js"></script>
<script type="text/javascript" src="jqwidgets/jqxcalendar.js"></script>
<script type="text/javascript" src="jqwidgets/jqxtooltip.js"></script>
<script type="text/javascript" src="jqwidgets/globalization/jquery.global.js"></script>
<script src="js/highcharts.js" type="text/javascript"></script>
<script src="js/modules/exporting.js" type="text/javascript"></script>
<script type="text/javascript" src="jqwidgets/jqxtabs.js"></script>
<script type="text/javascript" src="jqwidgets/jqxcheckbox.js"></script>
<script type="text/javascript" src="jqwidgets/jqxmenu.js"></script>
<script type="text/javascript" src="jqwidgets/jqxgrid.js"></script>
<script type="text/javascript" src="jqwidgets/jqxgrid.selection.js"></script>  
<script type="text/javascript" src="jqwidgets/jqxgrid.columnsresize.js"></script> 
<script type="text/javascript" src="jqwidgets/jqxgrid.pager.js"></script>
<script type="text/javascript" src="jqwidgets/jqxgrid.sort.js"></script>

<!--Main Script to display the data-->

<script type="text/javascript">


var siteid=<?php echo $_GET['siteid'];?>;
var date_to;
var date_from;
var date_select_to;
var date_select_from;
var varid;
var date_from_sql;
var date_to_sql;
var varname;
var datatype;
var sitename;
var flag=0;
//Populate the Drop Down list with values from the JSON output of the php page

    $(document).ready(function () {

//Create Tabs for Table Chart Switching
$('#jqxtabs').jqxTabs({ width: 710, height: 450, theme: 'darkblue', collapsible: true });
$('#jqxtabs').jqxTabs('disable');
var selectedItem = $('#jqxtabs').jqxTabs('selectedItem');
$('#jqxtabs').jqxTabs('enableAt', selectedItem);
			

//Defining the Variable List
var source =
        {
            datatype: "json",
            datafields: [
                { name: 'variableid' },
                { name: 'variablename' },
            ],
            url: 'detail.php?siteid='+siteid
        };
//Defining the Data adapter
var dataAdapter = new $.jqx.dataAdapter(source);
//Creating the Drop Down list
        $("#dropdownlist").jqxDropDownList(
        {
            source: dataAdapter,
            theme: 'classic',
            width: 200,
            height: 25,
            selectedIndex: 0,
            displayMember: 'variablename',
            valueMember: 'variableid'
        });

$('#dropdownlist').bind('select', function (event) {
var args = event.args;
var item = $('#dropdownlist').jqxDropDownList('getItem', args.index);
//Check if a valid value is selected and process futher to display dates
if ((item != null)&&(item.label != "Please select a variable")) {		

//Clear the Box
$('#daterange').empty();	


varname=item.label;
//varid=item.value;

//Going to the next function that will generate a list of data types available for that variable
create_var_list()

}
});

});
//End of Document Ready Function

function create_var_list()
{ 

//Generate data types available for that varname

        var source =
        {
            datatype: "json",
            datafields: [
                { name: 'dataid' },
                { name: 'dataname' },
            ],
            url: 'datavalue.php?siteid='+siteid+'&varname='+varname
        };
//Defining the Data adapter
var dataAdapter = new $.jqx.dataAdapter(source);
//Creating the Drop Down list
        $("#typelist").jqxDropDownList(
        {
            source: dataAdapter,
            theme: 'classic',
            width: 200,
            height: 25,
            selectedIndex: 0,
            displayMember: 'dataname',
            valueMember: 'dataid'
        });

//Binding an Event in case of Selection of Drop Down List to update the varid according to the selection

$('#typelist').bind('select', function (event) {
var args = event.args;
var item = $('#typelist').jqxDropDownList('getItem', args.index);
//Check if a valid value is selected and process futher to display dates
if (item != null) {		
datatype=item.label;
//Update Var ID

update_var_id();

//Call Function to set default dates and plot

}

});


}

//End of create_var_list function	

function update_var_id()
{	
$.ajax({
  type: "GET",
  url: "db_update_varid.php?siteid="+siteid+"&varname="+varname+"&type="+datatype,
 // dataType: "xml",
//Processing The Dates
    success: function(data) {
varid=data;
//Now We have the VariableID, We call the dates function
get_dates();
	}
});


}

//Function to get dates and plot a default plot


function get_dates()
{

//Clear the Box
$('#daterange').empty();	


var url="get_date.php?siteid="+siteid+"&varid=" + varid;
$.ajax({
        type: "GET",
	url: url,
	dataType: "xml",
	success: function(xml) {

//Displaying the Available Dates	
$(xml).find("dates").each(function()
{
//Displaying the Available Dates
sitename=String($(this).attr("sitename"));	
date_from=String($(this).attr("date_from"));
date_to=String($(this).attr("date_to"));		
//Call the next function to display the data

$('#daterange').empty();	
$('#daterange').prepend('<p>Dates Available From ' + date_from + ' to ' + date_to +'</p>');

//Restricting the Calendar to those available dates
var year = parseInt(date_from.slice(0,4));
var month = parseInt(date_from.slice(5,7),10);
var day = parseInt(date_from.slice(8,10),10);
month=month-1;
var date1 = new Date();
date1.setFullYear(year, month, day);

$("#fromdatedrop").jqxDropDownButton({ width: 250, height: 25});

$("#todatedrop").jqxDropDownButton({ width: 250, height: 25});


$("#jqxDateTimeInput").jqxDateTimeInput({ width: '250px', height: '25px'});
$('#jqxDateTimeInput').jqxDateTimeInput('setDate', date1);
$("#jqxDateTimeInput").jqxDateTimeInput({ formatString: 'd' });
$("#jqxDateTimeInputto").jqxDateTimeInput({ width: '250px', height: '25px'});
$("#jqxDateTimeInputto").jqxDateTimeInput({ formatString: 'd' });

$("#jqxDateTimeInput").jqxDateTimeInput('setMinDate', new Date(year, month, day));
var year_to = parseInt(date_to.slice(0,4));		
var month_to = parseInt(date_to.slice(5,7),10);
var day_to = parseInt(date_to.slice(8,10),10);	
//month_to=month_to-1;
var date2 = new Date();
date2.setFullYear(year_to, month_to-1, day_to);
$('#jqxDateTimeInputto').jqxDateTimeInput('setDate', date2);

$("#jqxDateTimeInput").jqxDateTimeInput('setMaxDate', new Date(year_to, month_to, day_to)); 
$("#jqxDateTimeInputto").jqxDateTimeInput('setMaxDate', new Date(year_to, month_to, day_to)); 
//Plot the Chart with default limits

date_from_sql=date1.getFullYear() + '-' + add_zero((date1.getMonth()+1)) + '-' + add_zero(date1.getDate()) + ' 00:00:00';
date_to_sql=date2.getFullYear() + '-' + add_zero((date2.getMonth()+1)) + '-' + add_zero(date2.getDate()) + ' 00:00:00';
$("#fromdatedrop").jqxDropDownButton('setContent', "Please enter from date");
$("#todatedrop").jqxDropDownButton('setContent', "Please enter to date");
plot_chart();
//Binding An Event to the first calender
$('#jqxDateTimeInput').bind('valuechanged', function (event) 
{
	

var date = event.args.date;
date_select_from=new Date(date);
//Converting to SQL Format for Searching
date_from_sql=date_select_from.getFullYear() + '-' + add_zero((date_select_from.getMonth()+1)) + '-' + add_zero(date_select_from.getDate()) + ' 00:00:00';
//Setting the Second calendar's min date to be the date of the first calendar
$("#jqxDateTimeInputto").jqxDateTimeInput('setMinDate', date);
var tempdate=add_zero((date_select_from.getMonth()+1))+'/'+add_zero(date_select_from.getDate())+'/'+date_select_from.getFullYear();
$("#fromdatedrop").jqxDropDownButton('setContent', tempdate);

plot_chart();				
});
//Binding An Event To the Second Calendar
$('#jqxDateTimeInputto').bind('valuechanged', function (event) {
var date = event.args.date;
date_select_to=new Date(date);
var tempdate=add_zero((date_select_to.getMonth()+1))+'/'+add_zero(date_select_to.getDate())+'/'+date_select_to.getFullYear();
$("#todatedrop").jqxDropDownButton('setContent', tempdate);
date_to_sql=date_select_to.getFullYear() + '-' + add_zero((date_select_to.getMonth()+1)) + '-' + add_zero(date_select_to.getDate()) + ' 00:00:00';
plot_chart();
});



});
	}
});


} //End of function get_dates
	
function plot_chart()
{

var unit_yaxis="unit";

//Defining The Chart Options
var chart=new Highcharts.Chart({
    chart: {
		width: 700,
        renderTo: 'container',
        type: 'line',
		 zoomType: 'x'
    },
    title: {
        text: 'Data of '+sitename+' from '+ date_from_sql + ' to ' + date_to_sql,
		style: {
                fontSize: '12px'
            }
    },
	
	
        credits: {
            enabled: false
        },
	
	 subtitle: {
        text: 'Click and Drag to Zoom a certain Portion'
    },
	
   xAxis: {
            type: 'datetime',
            dateTimeLabelFormats: { // don't display the dummy year
                 month: '%e.%b / %Y',
                year: '%b.%Y'
            },
			title: {
                text: 'Time',
				margin: 30
            },
			
        },
  yAxis: {
            title: {
                text: unit_yaxis,
				margin: 40
            },
			
        },
	
	   legend: {
            margin: 40
        },
	
	 exporting: {
            enabled: true,
			width: 5000
        },	
		
		loading: {
            hideDuration: 1000,
            showDuration: 1000
        },
	
     series: [{
            data: [],
			name: varname +'('+datatype+')'     
        }]
    
});
    

var url='db_get_data.php?siteid='+siteid+'&varid='+varid+'&startdate='+date_from_sql+'&enddate='+date_to_sql;
$.get(url, function(data) {

// Split the lines
var lines = data.split('\n');
//Iterate over the lines and add categories or series
$.each(lines, function(lineNo, line)
{	
var items = line.split(',');        
// header line containes categories
if (lineNo == 0) {}
// the rest of the lines contain data with their name in the first position
else {
var data_to_push1=0;
var data_to_push2=0;
$.each(items, function(itemno, part)
{
if (itemno==1)
{data_to_push1=parseFloat(part);
}
if (itemno==2){
var date_st=String(part);
var returndate=timeconvert(date_st);
data_to_push2=Date.UTC(returndate.getFullYear(),returndate.getMonth(),returndate.getDate(),returndate.getHours(),returndate.getMinutes(),returndate.getSeconds(),0);
}
if (itemno==3){
//Unit
	unit_yaxis=part;
}
});
chart.series[0].addPoint([data_to_push2,data_to_push1]);
 }
    });

// Redraw the chart the chart
chart.yAxis[0].setTitle({
            text: unit_yaxis
        });

 chart.redraw();
});
make_grid();
$('#jqxtabs').jqxTabs('enable');

}

function add_zero(value)
{
var ret;
if (value<10)
{
ret='0'+value;
}
else
{ret=value;
}
return ret;
}
	
function timeconvert(timestamp) {
var year = parseInt(timestamp.slice(0,4));
var month = parseInt(timestamp.slice(5,7),10);
var day = parseInt(timestamp.slice(8,10),10);
month=month-1;
var hour = parseInt(timestamp.slice(11,13),10);
var minute = parseInt(timestamp.slice(14,16),10);
var sec = parseInt(timestamp.slice(17,19),10); 
return new Date(year,month,day,hour,minute,sec);
}

function make_grid()
{


var url='db_get_data2.php?siteid='+siteid+'&varid='+varid+'&startdate='+date_from_sql+'&enddate='+date_to_sql;

var source12 =
            {
                datatype: "csv",
                datafields: [
                    { name: 'ValueID'},
                    { name: 'Value'},
                    { name: 'date'}
                ],
                url: url
            };
var dataAdapter12 = new $.jqx.dataAdapter(source12);   

if (flag==1)    
{


 
 $("#jqxgrid").jqxGrid(
            {
                width: 670,
                source: dataAdapter12,
           
                columns: [
                  { text: 'ValueID', datafield: 'ValueID', width: 250},
                  { text: 'Value', datafield: 'Value', width: 200},
                  { text: 'Date', datafield: 'date', width: 200 }         
                ]
            });		
 
 

}
if(flag!=1)
{


            $("#jqxgrid").jqxGrid(
            {
                width: 705,
                source: dataAdapter12,
                theme: 'darkblue',   
                columnsresize: true,
				sortable: true,
                pageable: true,
                autoheight: true,
                columns: [
                  { text: 'Date', datafield: 'date', width: 352 },
	              { text: 'Value', datafield: 'Value', width: 353}                     
                ]
            });		
		flag=1;		
			
	}

$("#export").jqxButton({ width: '250', height: '25', theme: 'classic'});
$("#export").bind('click', function () {

var url='data_export.php?siteid='+siteid+'&varid='+varid+'&startdate='+date_from_sql+'&enddate='+date_to_sql;

window.open(url,'_blank');

                });
	
}



</script>

</head>

<body background="images/bkgrdimage.jpg">
<table width="960" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="3"><img src="images/WebClientBanner.png" width="960" height="200" alt="Adventure Learning banner" /></td>
  </tr>
  <tr>
    <td colspan="3" bgcolor="#3c3c3c">&nbsp;</td>
  </tr>
  <tr>
    <td width="240" rowspan="3" valign="top" bgcolor="#f2e6d6"><?php //echo "$nav"; ?></td>
    <td colspan="2" valign="top" bgcolor="#FFFFFF">
    <br/>
<div id="dropdownlist"></div>
<div id='typelist'></div>
<div id='daterange'></div> <br/>
   </td>
  </tr>
  
  <tr>
    <td width="408" valign="top" bgcolor="#FFFFFF">
  <div id='fromdatedrop'><div id='jqxDateTimeInput'></div></div> 
      <br/><br/>
    </td>
    <td width="312" valign="top" bgcolor="#FFFFFF"><div id='todatedrop'><div id='jqxDateTimeInputto'></div></div> </td>
  <br/><br/>
  </tr>
  
   <tr>
    <td colspan="2" valign="top" bgcolor="#FFFFFF">
  <div id='jqxtabs'>
    <ul style='margin-left: 20px;'>
      <li>Site Information</li>
      <li>Data Plot</li>
      <li>Data Table</li>
      </ul>
    <div>
<?php  
//Function to paste out metadata

$siteid=$_GET['siteid'];

require_once 'db_config.php';
// get data and store in a json array
$query = "SELECT DISTINCT SiteName, SiteType, Latitude, Longitude FROM sites";
$siteid = $_GET['siteid'];
$query .= " WHERE SiteID=".$siteid;

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());
$row = mysql_fetch_array($result, MYSQL_ASSOC);
echo("SiteName: ".$row['SiteName']."<br/>"."SiteType: ".$row['SiteType']."<br/>Latitude: ".$row['Latitude']."<br/>Longitude: ".$row['Longitude']);

$query = "SELECT DISTINCT VariableName FROM seriescatalog";
$siteid = $_GET['siteid'];
$query .= " WHERE SiteID=".$siteid;

$result = mysql_query($query) or die("SQL Error 1: " . mysql_error());
echo("<br/>Measurements made on this site: ");
$num_rows = mysql_num_rows($result);
$count=1;
while($row = mysql_fetch_array($result, MYSQL_ASSOC))
{
	echo($row['VariableName']);
	if($count!=$num_rows)
	{echo "; ";}
  $count=$count+1;
	}
mysql_close($connect);
?>    
<br/><br/>Please select the variable and other details from the above options<br/><br/>
Selected the wrong site? No worries! Click <a href="view_main.php">here</a> to go back to the map </div>
    <div>
      <div id="container" style="height: 400px"></div>
      </div>
    <div>
      <div id="jqxgrid"></div>
      <br/>
      <div style="alignment-adjust: middle; float:right;">
        <input type="button" value="Download the above data" id='export' /></div>
      </div>
    
    </div>
      
    </td>
  </tr>
</table>

</body>
</html>