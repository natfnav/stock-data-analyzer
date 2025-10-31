using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

// Namespace that organizes classes and methods utilized by the Stock Viewer application within the Recognizers folder
namespace COP_4365_Project_2.Recognizers
{
    /// <summary>
    /// Class representing a Bullish pattern recognizer; a derivation of a Recognizer tailored for
    /// identifying Bullish candlesticks
    /// </summary>
    class Recognizer_Bullish : Recognizer
    {
        /// <summary>
        /// Constructor that creates a Recognizer_Bullish object and initializes its respective
        /// pattern name and length
        /// </summary>
        public Recognizer_Bullish() : base("Bullish", 1) { }

        /// <summary>
        /// Method that overrides the abstract Recognize method to tailor it towards identifying
        /// Bullish patterns
        /// </summary>
        /// <param name="scsList">List of SmartCandlesticks</param>
        /// <param name="currIndex">Current index of candlestick being analyzed</param>
        /// <returns>
        /// A boolean value for the current candlestick; returns true if a Bullish pattern is detected
        /// and false otherwise
        /// </returns>
        public override bool Recognize(List<SmartCandlestick> scsList, int currIndex)
        {
            // Initialize the current candlestick
            SmartCandlestick scs = scsList[currIndex];
            // Check for Bullish pattern
            bool r = scs.Open < scs.Close;

            // Return result of Bullish check
            return r;
        }
    }
}
