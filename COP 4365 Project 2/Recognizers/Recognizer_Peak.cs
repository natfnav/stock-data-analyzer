using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

// Namespace that organizes classes and methods utilized by the Stock Viewer application within the Recognizers folder
namespace COP_4365_Project_2.Recognizers
{
    /// <summary>
    /// Class representing a Peak pattern recognizer; a derivation of a Recognizer tailored for
    /// identifying Peak candlesticks
    /// </summary>
    class Recognizer_Peak : Recognizer
    {
        /// <summary>
        /// Constructor that creates a Recognizer_Peak object and initializes its respective
        /// pattern name and length
        /// </summary>
        public Recognizer_Peak() : base("Peak", 3) { }

        /// <summary>
        /// Method that overrides the abstract Recognize method to tailor it towards identifying
        /// Peak patterns
        /// </summary>
        /// <param name="scsList">List of SmartCandlesticks</param>
        /// <param name="currIndex">Current index of candlestick being analyzed</param>
        /// <returns>
        /// A boolean value for the current candlestick; returns true if a Peak pattern is detected
        /// and false otherwise
        /// </returns>
        public override bool Recognize(List<SmartCandlestick> scsList, int currIndex)
        {
            // Check for potential index out of range errors
            if (currIndex == 0 || currIndex >= scsList.Count - 1)
            {
                // Return false if error is detected
                return false;
            }

            // Previous candlestick
            SmartCandlestick prevCS = scsList[currIndex - 1];
            // Current candlestick
            SmartCandlestick currCS = scsList[currIndex];
            // Next candlestick
            SmartCandlestick nextCS = scsList[currIndex + 1];
            // Set recognizer boolean value to false by default
            bool r = false;
            
            // Checks if previous candlestick is already involved in a Peak pattern
            if (prevCS.Patterns[PatternName] == true)
                // Maintain true value for Peak pattern entry
                prevCS.Patterns[PatternName] = true;
            // Checks if current candlestick is already involved in a Peak pattern
            if (currCS.Patterns[PatternName] == true)
                // Set recognizer boolean value to true
                r = true;
            // Checks if next candlestick is ready involved in a Peak pattern
            if (nextCS.Patterns[PatternName] == true)
                // Maintain true value for Peak pattern entry
                nextCS.Patterns[PatternName] = true;
            
            // Check for Peak pattern
            if ((prevCS.High < currCS.High) && (currCS.High > nextCS.High))
            {
                // Set previous candlestick Peak pattern entry to true
                prevCS.Patterns[PatternName] = true;
                // Set next candlestick Peak pattern entry to true
                nextCS.Patterns[PatternName] = true;
                // Set recognizer boolean value to true
                r = true;
            }

            // Return the recognizer boolean value
            return r;
        }
    }
}
