using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace that organizes classes and methods utilized by the Stock Viewer application within the Recognizers folder
namespace COP_4365_Project_2.Recognizers
{
    /// <summary>
    /// Class representing a Maribozu pattern recognizer; a derivation of a Recognizer tailored for
    /// identifying Maribozu candlesticks
    /// </summary>
    class Recognizer_Maribozu : Recognizer
    {
        /// <summary>
        /// Constructor that creates a Recognizer_Maribozu object and initializes its respective
        /// pattern name and length
        /// </summary>
        public Recognizer_Maribozu() : base("Maribozu", 1) { }

        /// <summary>
        /// Method that overrides the abstract Recognize method to tailor it towards identifying
        /// Maribozu patterns
        /// </summary>
        /// <param name="scsList">List of SmartCandlesticks</param>
        /// <param name="currIndex">Current index of candlestick being analyzed</param>
        /// <returns>
        /// A boolean value for the current candlestick; returns true if a Maribozu pattern is detected
        /// and false otherwise
        /// </returns>
        public override bool Recognize(List<SmartCandlestick> scsList, int currIndex)
        {
            // Initialize current candlestick
            SmartCandlestick scs = scsList[currIndex];
            // Check for Maribozu pattern
            bool r = scs.BodyRange >= (scs.Range * 0.9M);

            // Return result of Maribozu check
            return r;
        }
    }
}
