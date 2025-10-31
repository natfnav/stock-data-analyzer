using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace that organizes classes and methods utilized by the Stock Viewer application within the Recognizers folder
namespace COP_4365_Project_2.Recognizers
{
    /// <summary>
    /// Class representing a Gravestone Doji pattern recognizer; a derivation of a Recognizer tailored for
    /// identifying Gravestone Doji candlesticks
    /// </summary>
    class Recognizer_GravestoneDoji : Recognizer
    {
        /// <summary>
        /// Constructor that creates a Recognizer_GravestoneDoji object and initializes its respective
        /// pattern name and length
        /// </summary>
        public Recognizer_GravestoneDoji() : base("Gravestone Doji", 1) { }

        /// <summary>
        /// Method that overrides the abstract Recognize method to tailor it towards identifying
        /// Gravestone Doji patterns
        /// </summary>
        /// <param name="scsList">List of SmartCandlesticks</param>
        /// <param name="currIndex">Current index of candlestick being analyzed</param>
        /// <returns>
        /// A boolean value for the current candlestick; returns true if a Gravestone Doji pattern is detected
        /// and false otherwise
        /// </returns>
        public override bool Recognize(List<SmartCandlestick> scsList, int currIndex)
        {
            // Initialize current candlestick
            SmartCandlestick scs = scsList[currIndex];
            // Check for Gravestone Doji pattern
            bool r = (scs.BodyRange < 0.1M * scs.Range) && (scs.BottomTail <= 0.1M * scs.Range) && 
                     (scs.TopTail >= 2 * scs.BottomTail);

            // Return result of Gravestone Doji check
            return r;
        }
    }
}
