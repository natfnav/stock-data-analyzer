using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Namespace that organizes classes and methods utilized by the Stock Viewer application
namespace COP_4365_Project_2
{
    /// <summary>
    /// Class for the Stock Loader form, which derives from the Windows Form class
    /// </summary>
    public partial class Form_StockLoader : Form
    {
        /// <summary>
        /// Constructor for the Stock Loader form
        /// </summary>
        public Form_StockLoader()
        {
            // Initialize components of the form
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the "Load" button on click; implements filters in the OpenFileDialog
        /// and opens it
        /// </summary>
        /// <param name="sender">Object that triggered the event</param>
        /// <param name="e">Event arguments associated with the event</param>
        private void button_Load_Click(object sender, EventArgs e)
        {
            // Set filter for OpenFileDialog to restrict displayed file types
            openFileDialog_StockSelector.Filter = "All files|*.*|AAPL|AAPL-*.csv|GOOG|GOOG-*.csv|" +
                                                  "IBM|IBM-*.csv|MSFT|MSFT-*.csv|" +
                                                  "Daily|*-Day.csv|Weekly|*-Week.csv|" +
                                                  "Monthly|*-Month.csv";

            // Open the file dialog
            openFileDialog_StockSelector.ShowDialog();
        }

        /// <summary>
        /// Event handler for when the user selects file(s) from the OpenFileDialog; creates
        /// a new Stock Viewer for each selected file based on a file's info and the dates
        /// selected in each DateTimePicker
        /// </summary>
        /// <param name="sender">Object that triggered the event</param>
        /// <param name="e">Event arguments associated with the event</param>
        private void openFileDialog_StockSelector_FileOk(object sender, CancelEventArgs e)
        {
            // Get start date from left DateTimePicker
            DateTime startDate = dateTimePicker_StartDate.Value;
            // Get end date from right DateTimePicker
            DateTime endDate = dateTimePicker_EndDate.Value;

            // Get number of files selected in OpenFileDialog
            int numOfFiles = openFileDialog_StockSelector.FileNames.Count();

            // Traverse each selected file
            for (int i = 0; i < numOfFiles; i++)
            {
                // Get path name of the current file
                string pathName = openFileDialog_StockSelector.FileNames[i];
                // Get file name of the current file (w/o extension)
                string ticker = Path.GetFileNameWithoutExtension(pathName);

                // Create a new Stock Viewer form for current file
                Form_StockViewer stockViewer = new Form_StockViewer(pathName, startDate, endDate);

                // Set the text of the Stock Viewer form to the current file name
                stockViewer.Text = ticker;

                // Display the Stock Viewer form for current file
                stockViewer.Show();
            }
        }
    }
}
