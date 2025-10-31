using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace that organizes classes and methods utilized by the Stock Viewer application within the Recognizers folder
namespace COP_4365_Project_2.Recognizers
{
    /// <summary>
    /// Class representing a Bullish Engulfing pattern recognizer; a derivation of a Recognizer tailored for
    /// identifying Bullish Engulfing candlesticks
    /// </summary>
    class Recognizer_BullishEngulfing : Recognizer
    {
        /// <summary>
        /// Constructor that creates a Recognizer_BullishEngulfing object and initializes its respective
        /// pattern name and length
        /// </summary>
        public Recognizer_BullishEngulfing() : base("Bullish Engulfing", 2) { }

        /// <summary>
        /// Method that overrides the abstract Recognize method to tailor it towards identifying
        /// Bullish Engulfing patterns
        /// </summary>
        /// <param name="scsList">List of SmartCandlesticks</param>
        /// <param name="currIndex">Current index of candlestick being analyzed</param>
        /// <returns>
        /// A boolean value for the current candlestick; returns true if a Bullish Engulfing pattern is detected
        /// and false otherwise
        /// </returns>
        public override bool Recognize(List<SmartCandlestick> scsList, int currIndex)
        {
            // Check for potential index out of range error
            if (currIndex == 0) 
            {
                // Return false if error is detected
                return false;
            }

            // Previous candlestick
            SmartCandlestick prevCS = scsList[currIndex - 1];
            // Current candlestick
            SmartCandlestick currCS = scsList[currIndex];
            // Set recognizer boolean value to false by default
            bool r = false;

            // Check for Bullish Engulfing pattern
            if ((prevCS.Open > prevCS.Close && currCS.Open < prevCS.Close) && (currCS.Open <= prevCS.Close) && 
                (currCS.Close > prevCS.Open) && (currCS.BodyRange > prevCS.BodyRange))
            {
                // Set previous candlestick pattern entry to true
                prevCS.Patterns[PatternName] = true;
                // Set recognizer boolean to true
                r = true;

                // Return recognizer boolean value
                return r;
            }

            // Return recognizer boolean value
            return r;
        }
    }
}
