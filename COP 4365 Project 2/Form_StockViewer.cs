using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Linq;
using COP_4365_Project_2.Recognizers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

// Namespace that organizes classes and methods utilized by the Stock Viewer application
namespace COP_4365_Project_2
{
    /// <summary>
    /// Class for the Stock Viewer form, which derives from the Windows Form class
    /// </summary>
    public partial class Form_StockViewer : Form
    {
        // List containing all candlestick data
        List<SmartCandlestick> candlesticks = new List<SmartCandlestick>();
        // BindingList containing filtered candlestick data
        BindingList<SmartCandlestick> boundCandlesticks = new BindingList<SmartCandlestick>();
        // List containing recognizers for candlestick pattern detection
        List<Recognizer> recognizers = new List<Recognizer>
        {
            // Bullish recognizer
            new Recognizer_Bullish(),
            // Bearish recognizer
            new Recognizer_Bearish(),
            // Neutral recognizer
            new Recognizer_Neutral(),
            // Maribozu recognizer
            new Recognizer_Maribozu(),
            // Hammer recognizer
            new Recognizer_Hammer(),
            // Doji recognizer
            new Recognizer_Doji(),
            // Dragonfly Doji recognizer
            new Recognizer_DragonflyDoji(),
            // Gravestone Doji recognizer
            new Recognizer_GravestoneDoji(),
            // Bullish Engulfing recognizer
            new Recognizer_BullishEngulfing(),
            // Bearish Engulfing recognizer
            new Recognizer_BearishEngulfing(),
            // Bullish Engulfing recognizer
            new Recognizer_BullishHarami(),
            // Bearish Harami recognizer
            new Recognizer_BearishHarami(),
            // Peak recognizer
            new Recognizer_Peak(),
            // Valley recognizer
            new Recognizer_Valley()
        };

        /// <summary>
        /// Constructor for the Stock Viewer form
        /// </summary>
        public Form_StockViewer()
        {
            // Initialize components of the form
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for the Stock Viewer form
        /// </summary>
        /// <param name="pathName">Name of a file</param>
        /// <param name="startDate">Starting date of data</param>
        /// <param name="endDate">Ending date of data</param>
        public Form_StockViewer(string pathName, DateTime startDate, DateTime endDate)
        {
            // Initialize components of the form
            InitializeComponent();
            // Read data from a .csv file
            ReadCandlestickDataFromFile(pathName);
            // Set start date picker to value of startDate
            dateTimePicker_StartDate.Value = startDate;
            // Set end date picker to value of endDate
            dateTimePicker_EndDate.Value = endDate;
            // Filter candlestick data
            filterCandlesticks();
            // Update ComboBox filter options
            updateCSFilters();
            // Modify chart properties
            normalizeChart();
            // Display data on chart
            displayChart();
        }

        /// <summary>
        /// Reads a .csv file that contains stock data
        /// </summary>
        /// <param name="fileName">Name of the file to be read</param>
        private void ReadCandlestickDataFromFile(string fileName)
        {
            // String to reference the format of the first line in a .csv file
            const string referenceString = "Date,Open,High,Low,Close,Adj Close,Volume";

            // Open a stream reader to read data from selected file
            using (StreamReader sr = new StreamReader(fileName))
            {
                // Clear old data from List
                candlesticks.Clear();

                // Read first line from file
                string line = sr.ReadLine();

                // Continue to read if first line matches referenceString
                if (line == referenceString)
                {
                    // Read the next line
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Initialize candlestick using data represented by the current line
                        SmartCandlestick scs = new SmartCandlestick(line);
                        // Round Open price to nearest cent
                        scs.Open = Math.Round(scs.Open, 2);
                        // Round High price to nearest cent
                        scs.High = Math.Round(scs.High, 2);
                        // Round Low price to nearest cent
                        scs.Low = Math.Round(scs.Low, 2);
                        // Round Close price to nearest cent
                        scs.Close = Math.Round(scs.Close, 2);
                        // Add candlestick to List
                        candlesticks.Add(scs);
                    }
                }
                // If first line doesn't match referenceString
                else
                {
                    // Display error message for incorrect file format
                    Text = "Bad File" + fileName;
                }
            }
        }

        /// <summary>
        /// Returns a list containing candlestick data that are within a specified date range
        /// </summary>
        /// <param name="unfilteredList">List of all candlesticks</param>
        /// <param name="startDate">Start date of desired date range</param>
        /// <param name="endDate">End date of desired date range</param>
        /// <returns>
        /// A filtered list of candlesticks
        /// </returns>
        private List<SmartCandlestick> filterCandlesticks(List<SmartCandlestick> unfilteredList, DateTime startDate, DateTime endDate)
        {
            // List to store filtered candlesticks
            List<SmartCandlestick> filteredList = new List<SmartCandlestick>();

            // Iterate through unfiltered list
            foreach (SmartCandlestick scs in unfilteredList)
            {
                // If the start date hasn't been reached
                if (scs.Date < startDate)
                    // Skip and continue to next candlestick
                    continue;
                // If the end date has been exceeded
                if (scs.Date > endDate)
                    // Stop exploring unfiltered list
                    break;

                // Add candlestick to filtered list
                filteredList.Add(scs);
            }

            // Return the filtered list
            return filteredList;
        }

        /// <summary>
        /// Updates BindingList to contain filtered candlestick data
        /// </summary>
        private void filterCandlesticks()
        {
            // Clear old data from BindingList
            boundCandlesticks.Clear();
            // Copy the candlestick list
            List<SmartCandlestick> unfilteredList = new List<SmartCandlestick>(candlesticks);
            // Copy start and end dates from time picker
            DateTime startDate = dateTimePicker_StartDate.Value, endDate = dateTimePicker_EndDate.Value;
            // Generate candlesticks into filtered list
            List<SmartCandlestick> filteredList = filterCandlesticks(unfilteredList, startDate, endDate);
            // Copy elements of filtered list to BindingList
            boundCandlesticks = new BindingList<SmartCandlestick>(filteredList);
        }

        /// <summary>
        /// Event handler for "Update" button on click; updates BindingList, filter options,
        /// and the chart
        /// </summary>
        /// <param name="sender">Object that triggered the event</param>
        /// <param name="e">Event arguments associated with the event</param>
        private void button_Update_Click(object sender, EventArgs e)
        {
            // Update BindingList to contain filtered data
            filterCandlesticks();

            // Update ComboBox filter options
            updateCSFilters();

            // Normalize chart based on updated BindingList data
            normalizeChart();

            // Update chart based in updated BindingList data
            displayChart();

            // Clear annotations after updating BindingList data
            chart_StockData.Annotations.Clear();

            // Set filter to default (none)
            comboBox_Filter.SelectedIndex = 0;
        }

        /// <summary>
        /// Event handler for combobox when the selected index/item is changed; 
        /// </summary>
        /// <param name="sender">Object that triggered the event</param>
        /// <param name="e">Event arguments associated with the event</param>
        private void comboBox_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if item is selected in combobox
            if (comboBox_Filter.SelectedItem != null)
            {
                // Obtain and convert selected item to a string
                string selectedPattern = comboBox_Filter.SelectedItem.ToString();

                // Annotate the chart based on the selected pattern
                updateAnnotations(selectedPattern);
            }
        }

        /// <summary>
        /// Modifies the various properties of each chart to ensure a clean and organized appearance
        /// </summary>
        private void normalizeChart()
        {
            // Configure properties of the candlestick chart
            formatCandlestickChart();
            // Configure properties of the column chart
            formatColumnChart();
        }

        /// <summary>
        /// Displays data for both the candlestick and column chart
        /// </summary>
        private void displayChart()
        {
            // Clear existing data points in candlestick chart
            chart_StockData.Series["Series_OHLC"].Points.Clear();

            // Set x-value of candlestick chart to date data
            chart_StockData.Series["Series_OHLC"].XValueMember = "Date";
            // Set y-value members of candlestick chart to high, low, open, and close price data
            chart_StockData.Series["Series_OHLC"].YValueMembers = "High,Low,Open,Close";
            // Set data source for candlestick chart to the BindingSource
            chart_StockData.Series["Series_OHLC"].Points.DataBind(boundCandlesticks, "Date", "High,Low,Open,Close", "");

            // Clear existing data points in column chart
            chart_StockData.Series["Series_Volume"].Points.Clear();

            // Set x-value of column chart to date data
            chart_StockData.Series["Series_Volume"].XValueMember = "Date";
            // Set y-value members of column chart to volume data
            chart_StockData.Series["Series_Volume"].YValueMembers = "Volume";
            // Set data source for column chart to the BindingSource
            chart_StockData.Series["Series_Volume"].Points.DataBind(boundCandlesticks, "Date", "Volume", "");
        }

        /// <summary>
        /// Formats the candlestick Chart; sets the y-axis scale and rounds the
        /// y-axis values in which they displays cents (2 decimal places)
        /// </summary>
        private void formatCandlestickChart()
        {
            // Set minPrice and maxPrice to values that can be easily changed
            int minPrice = int.MaxValue, maxPrice = 0;
            // Set minDate and maxDate to current time value of each DateTimePicker respectively
            DateTime minDate = dateTimePicker_StartDate.Value, maxDate = dateTimePicker_EndDate.Value;

            // Iterate through bounded candlesticks BindingList
            foreach (SmartCandlestick scs in boundCandlesticks)
            {
                // Store the different price values of each candlestick in an array
                decimal[] prices = { scs.Open, scs.High, scs.Low, scs.Close };

                // Iterate through prices array
                foreach (double price in prices)
                {
                    // Set minPrice to the smallest price in the entire data set
                    minPrice = (int)Math.Min(minPrice, price);
                    // Set maxPrice to the largest price in the entire data set
                    maxPrice = (int)Math.Max(maxPrice, price);
                }
            }

            // Set y-axis minimum scale by subtracting 10% to the minimum price
            chart_StockData.ChartAreas["ChartArea_OHLC"].AxisY.Minimum = minPrice - (minPrice * 0.10);
            // Set y-axis maximum scale by adding 10% to the maximum price
            chart_StockData.ChartAreas["ChartArea_OHLC"].AxisY.Maximum = maxPrice + (maxPrice * 0.10);
            // Display y-axis values with dollar and cent value (2 decimal places)
            chart_StockData.ChartAreas["ChartArea_OHLC"].AxisY.LabelStyle.Format = "0.00";
        }

        /// <summary>
        /// Formats the column Chart; sets the y-axis scale and rounds the
        /// y-axis values in which they are shown as integers
        /// </summary>
        private void formatColumnChart()
        {
            // Set maxVol to a value that can easily be changed
            ulong maxVol = 0;

            // Set minDate and maxDate to current time value of each DateTimePicker respectively
            DateTime minDate = dateTimePicker_StartDate.Value, maxDate = dateTimePicker_EndDate.Value;

            // Iterate through bounded candlesticks BindingList
            foreach (SmartCandlestick scs in boundCandlesticks)
            {
                // Set maxVol to the largest volume in the entire data set
                maxVol = Math.Max(maxVol, scs.Volume);
            }

            // Set y-axis minimum scale to 0
            chart_StockData.ChartAreas["ChartArea_Volume"].AxisY.Minimum = 0;
            // Set y-axis maximum scale by adding 10% to the maximum volume
            chart_StockData.ChartAreas["ChartArea_Volume"].AxisY.Maximum = maxVol + (maxVol * 0.10);
            // Display y-axis values as integers
            chart_StockData.ChartAreas["ChartArea_Volume"].AxisY.LabelStyle.Format = "0";
        }

        /// <summary>
        /// Updates filter pattern options in the ComboBox by checking if at least one smart candlestick in the
        /// filtered data contains a pattern
        /// </summary>
        private void updateCSFilters()
        {
            // Remove items from combo box if there are any
            comboBox_Filter.Items.Clear();
            // Add default filter that removes all annotations if selected
            comboBox_Filter.Items.Add("(None)");

            // Copy BindingList elements to a new candlestick list
            List<SmartCandlestick> scsList = new List<SmartCandlestick>(boundCandlesticks);
            // Perform pattern detection for each candlestick in scsList
            scsList = detectPatterns(scsList);

            // Iterate through recognizers
            foreach (Recognizer r in recognizers)
            {
                // Iterate through scsList
                foreach (SmartCandlestick scs in scsList)
                {
                    // If a candlestick contains a pattern that relates to a recognizer's pattern name
                    if (scs.Patterns.TryGetValue(r.PatternName, out bool isPattern) && isPattern)
                    {
                        // Add the pattern to the ComboBox
                        comboBox_Filter.Items.Add(r.PatternName);
                        // Proceed to next recognizer
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Updates annotations in the chart
        /// </summary>
        /// <param name="pattern">Name of the candlestick pattern</param>
        private void updateAnnotations(string pattern)
        {
            // Clear existing annotations in chart
            chart_StockData.Annotations.Clear();

            // Copy BindingList elements to a new candlestick list
            List<SmartCandlestick> scsList = new List<SmartCandlestick>(boundCandlesticks);
            // Perform pattern detection for each candlestick in scsList
            scsList = detectPatterns(scsList);

            // Traverse each point (candlestick) on the chart
            for (int i = 0; i < chart_StockData.Series["Series_OHLC"].Points.Count; i++)
            {
                // Obtain smart candlestick that corresponds to current point on graph
                SmartCandlestick scs = scsList[i];

                // Check if current smart candlestick has the specified pattern
                if (scs.Patterns.TryGetValue(pattern, out bool isPattern) && isPattern)
                {
                    // Create new ArrowAnnotation
                    ArrowAnnotation aa = new ArrowAnnotation // Was var type
                    {
                        // Set point to which annotation will be anchored
                        AnchorDataPoint = chart_StockData.Series["Series_OHLC"].Points[i],
                        // Set size of arrow
                        ArrowSize = 2,
                        // Set background color of arrow
                        BackColor = Color.Blue,
                        // Set foreground color of arrow
                        ForeColor = Color.Black,
                        // Set width of arrow
                        Width = 0,
                        // Set height (length) and orientation of arrow
                        Height = -7,
                        // Set vertical position of arrow
                        Y = chart_StockData.Series["Series_OHLC"].Points[i].YValues[0] + 10
                    };
                   
                    // Add arrow annotation to chart
                    chart_StockData.Annotations.Add(aa);
                    
                }
            }

            // Update the chart data
            chart_StockData.Update();
        }

        /// <summary>
        /// Updates patterns for candlestick data
        /// </summary>
        /// <param name="scsList">List of SmartCandlesticks</param>
        /// <returns>
        /// A list of SmartCandlesticks that contains updated pattern info for each candlestick
        /// </returns>
        private List<SmartCandlestick> detectPatterns(List<SmartCandlestick> scsList)
        {
            // Copy elements in scsList into a new candlestick list
            List<SmartCandlestick> updatedList = new List<SmartCandlestick>(scsList);
            // Copy elements in recognizers into a new recognizer list
            List<Recognizer> rList = new List<Recognizer>(recognizers);

            // Traverse updatedList
            for (int i = 0; i < updatedList.Count; i++)
            {
                // Traverse recognizers in rList
                foreach (Recognizer r in rList)
                {
                    // Update every pattern entry for each candlestick in updatedList
                    updatedList[i].Patterns[r.PatternName] = r.Recognize(updatedList, i);
                }
            }

            // Return the updated list
            return updatedList;
        }
    }
}
