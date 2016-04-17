using System;

namespace Palantir.Numeric
{
    /// <summary>
    /// Rounding options for Numeric.
    /// </summary>
    /// <remarks>
    /// http://www.eetimes.com/document.asp?doc_id=1274485
    /// http://www.clivemaxfield.com/diycalculator/sp-round.shtml
    /// </remarks>
    public static class Round 
    {
        /// <summary>
        /// Rounds the value up if it is halfway to the minor unit or above.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minorUnit">The minor unit.</param>
        /// <returns>The rounded value.</returns>
        public static decimal RoundHalfUp(decimal value, decimal minorUnit)
        {
            if (value == 0)
                return 0;

            var multiple = 1 / minorUnit;
            value *= multiple;
            var rounded = Math.Floor(value);
            if (value >= rounded + 0.5M)
                rounded++;
            
            return rounded / multiple;
        }
                
        /// <summary>
        /// Rounds the value up if is above a minor unit;
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minorUnit">The minor unit.</param>
        /// <returns>The rounded value.</returns>
        public static decimal RoundUp(decimal value, decimal minorUnit)
        {
            if (value == 0)
                return 0;

            var multiple = 1 / minorUnit;
            value *= multiple;
            var rounded = Math.Floor(value);
            if (value > rounded)
                rounded++;
            
            return rounded / multiple;
        }
        
    }
}