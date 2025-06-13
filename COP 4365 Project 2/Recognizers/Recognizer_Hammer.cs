using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace that organizes classes and methods utilized by the Stock Viewer application within the Recognizers folder
namespace COP_4365_Project_2.Recognizers
{
    /// <summary>
    /// Class representing a Hammer pattern recognizer; a derivation of a Recognizer tailored for
    /// identifying Hammer candlesticks
    /// </summary>
    class Recognizer_Hammer : Recognizer
    {
        /// <summary>
        /// Constructor that creates a Recognizer_Hammer object and initializes its respective
        /// pattern name and length
        /// </summary>
        public Recognizer_Hammer() : base("Hammer", 1) { }

        /// <summary>
        /// Method that overrides the abstract Recognize method to tailor it towards identifying
        /// Hammer patterns
        /// </summary>
        /// <param name="scsList">List of SmartCandlesticks</param>
        /// <param name="currIndex">Current index of candlestick being analyzed</param>
        /// <returns>
        /// A boolean value for the current candlestick; returns true if a Hammer pattern is detected
        /// and false otherwise
        /// </returns>
        public override bool Recognize(List<SmartCandlestick> scsList, int currIndex)
        {
            // Initialize current candlestick
            SmartCandlestick scs = scsList[currIndex];
            // Check for Hammer pattern
            bool r = (scs.TopTail < 0.2M * scs.Range) && (scs.BodyRange >= 0.1M * scs.Range) && 
                     (scs.BodyRange <= 0.3M * scs.Range);

            // Return result of Hammer check
            return r;
        }
    }
}
