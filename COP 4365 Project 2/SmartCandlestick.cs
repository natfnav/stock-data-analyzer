using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

// Namespace that organizes classes and methods utilized by the Stock Viewer application
namespace COP_4365_Project_2
{
    /// <summary>
    /// Class representing a SmartCandlestick: a derivation of a Candlestick that includes extra
    /// measurement and pattern properties
    /// </summary>
    public class SmartCandlestick : Candlestick
    {
        // Range of a candlestick
        public Decimal Range { get; set; }
        // Body range of a candlestick
        public Decimal BodyRange { get; set; }
        // Top price of a candlestick
        public Decimal TopPrice { get; set; }
        // Bottom price of a candlestick
        public Decimal BottomPrice { get; set; }
        // Top tail of a candlestick
        public Decimal TopTail { get; set; }
        // Bottom tail of a candlestick
        public Decimal BottomTail { get; set; }
        // Dictionary containing single candlestick patterns and whether these patterns are detected
        public Dictionary<string, bool> Patterns = new Dictionary<string, bool>
        {
            // Bullish pattern entry
            { "Bullish", false },
            // Bearish pattern entry
            { "Bearish", false },
            // Neutral pattern entry
            { "Neutral", false },
            // Maribozu pattern entry
            { "Maribozu", false },
            // Hammer pattern entry
            { "Hammer", false },
            // Doji pattern entry
            { "Doji", false },
            // Dragonfly Doji pattern entry
            { "Dragonfly Doji", false },
            // Gravestone Doji pattern entry
            { "Gravestone Doji", false },
            // Bullish Engulfing pattern entry
            { "Bullish Engulfing", false },
            // Bearish Engulfing pattern entry
            { "Bearish Engulfing", false },
            // Bullish Harami pattern entry
            { "Bullish Harami", false },
            // Bearish Harami pattern entry
            { "Bearish Harami", false },
            // Peak pattern entry
            { "Peak", false },
            // Valley pattern entry
            { "Valley", false }
        };

        /// <summary>
        /// Default constructor that creates a SmartCandlestick object
        /// </summary>
        public SmartCandlestick() { }

        /// <summary>
        /// Constructor that creates a SmartCandlestick object
        /// </summary>
        /// <param name="rowOfData">Comma-separated string containing candlestick data</param>
        public SmartCandlestick(string rowOfData) : base(rowOfData)
        {
            // Set value of properties based on data in rowOfData 
            computeProperties();
        }

        /// <summary>
        /// Constructor that creates a SmartCandlestick object
        /// </summary>
        /// <param name="cs">Candlestick object containing candlestick data</param>
        public SmartCandlestick(Candlestick cs)
        {
            // Set value of properties based on candlestick data
            computeProperties(cs);
        }

        /// <summary>
        /// Updates the value of the Range, BodyRange, TopPrice, BottomPrice, TopTail, and
        /// BottomTail
        /// </summary>
        public void computeProperties()
        {
            // Calculate range
            Range = High - Low;
            // Calculate body range
            BodyRange = Math.Abs(Open - Close);
            // Calculate top price
            TopPrice = Math.Max(Open, Close);
            // Calculate bottom price
            BottomPrice = Math.Min(Open, Close);
            // Calculate top tail
            TopTail = High - TopPrice;
            // Calculate bottom tail
            BottomTail = BottomPrice - Low;
        }

        /// <summary>
        /// Updates the value of the Range, BodyRange, TopPrice, BottomPrice, TopTail, and
        /// BottomTail
        /// </summary>
        /// <param name="cs">Candlestick object containing candlestick data</param>
        public void computeProperties(Candlestick cs)
        {
            // Calculate range
            Range = cs.High - cs.Low;
            // Calculate body range
            BodyRange = Math.Abs(cs.Open - cs.Close);
            // Calculate top price
            TopPrice = Math.Max(cs.Open, cs.Close);
            // Calculate bottom price
            BottomPrice = Math.Min(cs.Open, cs.Close);
            // Calculate top tail
            TopTail = cs.High - TopPrice;
            // Calculate bottom tail
            BottomTail = BottomPrice - cs.Low;
        }
    }
}
