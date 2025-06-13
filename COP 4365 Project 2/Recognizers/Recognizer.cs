using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace that organizes classes and methods utilized by the Stock Viewer application within the Recognizers folder
namespace COP_4365_Project_2.Recognizers
{
    /// <summary>
    /// Abstract class that defines the template for candlestick pattern recognizers
    /// </summary>
    abstract class Recognizer
    {
        // Name of the pattern
        public string PatternName;
        // Length of the pattern (# of candlesticks that make up pattern)
        public int PatternLength;

        /// <summary>
        /// Constructor that initializes a Recognizer
        /// </summary>
        /// <param name="pN">Name of pattern</param>
        /// <param name="pL">Length of pattern</param>
        public Recognizer(string pN, int pL) 
        {
            // Set PatternName = parameter value corresponding to pN
            PatternName = pN;
            // Set PatternLength = parameter value corresponding to pL
            PatternLength = pL;
        }

        /// <summary>
        /// Abstract method for subclasses to recognize patterns
        /// </summary>
        /// <param name="scsList">List of SmartCandlesticks</param>
        /// <param name="currIndex">Index of the current candlestick being analyzed</param>
        /// <returns>
        /// Boolean value for the current candlestick based on whether a pattern is detected
        /// (true if pattern is detected, false otherwise)
        /// </returns>
        public abstract bool Recognize(List<SmartCandlestick>scsList, int currIndex);
    }
}
