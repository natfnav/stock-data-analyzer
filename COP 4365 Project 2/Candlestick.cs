using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace that organizes classes and methods utilized by the Stock Viewer application
namespace COP_4365_Project_2
{
    /// <summary>
    /// Class representing a Candlestick: a data structure used for stock market information
    /// </summary>
    public class Candlestick
    {
        // Date of a candlestick
        public DateTime Date { get; set; }
        // Opening price of a candlestick
        public decimal Open { get; set; }
        // High price of a candlestick
        public decimal High { get; set; }
        // Low price of a candlestick
        public decimal Low { get; set; }
        // Closing price of a candlestick
        public decimal Close { get; set; }
        // Stock volume of a candlestick
        public ulong Volume { get; set; }

        /// <summary>
        /// Default constructor that creates a Candlestick object
        /// </summary>
        public Candlestick() { }

        /// <summary>
        /// Constructor that creates a Candlestick object
        /// </summary>
        /// <param name="rowOfData">Comma-separated string containing candlestick data</param>
        public Candlestick(string rowOfData)
        {
            // Array of separators used to split the input string
            char[] separators = new char[] { ',', ' ', '"' };
            // Split the input string based on the defined separators
            string[] subs = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Obtain information of first substring 
            string dateString = subs[0];
            // Set Candlestick date to the obtained information (converts string to DateTime)
            Date = DateTime.Parse(dateString);

            // Temporarily store decimal values
            decimal temp;

            // Returns true/false if string to decimal conversion of second substring succeeds/fails
            bool success = decimal.TryParse(subs[1], out temp);
            // If conversion succeded, set Candlestick opening price to value of temp
            if (success) Open = temp;

            // Returns true/false if string to decimal conversion of third substring succeeds/fails
            success = decimal.TryParse(subs[2], out temp);
            // If conversion succeded, set Candlestick high price to value of temp
            if (success) High = temp;

            // Returns true/false if a string to decimal conversion of fourth substring succeeds/fails
            success = decimal.TryParse(subs[3], out temp);
            // If conversion succeded, set Candlestick low price to value of temp
            if (success) Low = temp;

            // Returns true/false if a string to decimal conversion of fifth substring succeeds/fails
            success = decimal.TryParse(subs[4], out temp);
            // If conversion succeded, set Candlestick closing price to value of temp
            if (success) Close = temp;

            // Temporarily store unsigned long values
            ulong tempVol;

            // Returns true/false if a string to ulong conversion of seventh substring succeeds/fails
            success = ulong.TryParse(subs[6], out tempVol);
            // If conversion succeded, set Candlestick stock volume to value of tempVol
            if (success) Volume = tempVol;
        }
    }
}
