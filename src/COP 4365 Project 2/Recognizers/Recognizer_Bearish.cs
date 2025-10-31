using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace that organizes classes and methods utilized by the Stock Viewer application within the Recognizers folder
namespace COP_4365_Project_2.Recognizers
{
    /// <summary>
    /// Class representing a Bearish pattern recognizer; a derivation of a Recognizer tailored for
    /// identifying Bearish candlesticks
    /// </summary>
    class Recognizer_Bearish : Recognizer
    {
        /// <summary>
        /// Constructor that creates a Recognizer_Bearish object and initializes its respective
        /// pattern name and length
        /// </summary>
        public Recognizer_Bearish() : base("Bearish", 1) { }

        /// <summary>
        /// Method that overrides the abstract Recognize method to tailor it towards identifying
        /// Bearish patterns
        /// </summary>
        /// <param name="scsList">List of SmartCandlesticks</param>
        /// <param name="currIndex">Current index of candlestick being analyzed</param>
        /// <returns>
        /// A boolean value for the current candlestick; returns true if a Bearish pattern is detected
        /// and false otherwise
        /// </returns>
        public override bool Recognize(List<SmartCandlestick> scsList, int currIndex)
        {
            // Initialize the current candlestick
            SmartCandlestick scs = scsList[currIndex];
            // Check for Bearish pattern
            bool r = scs.Open > scs.Close;

            // Return result of Bearish check
            return r;
        }
    }
}
