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
        /// <param name="minorUnit">The minor unit to round to.</param>
        /// <returns>The rounded currency.</returns>
        public static Money RoundHalfUp(Money value, decimal minorUnit)
        {
            return new Money(RoundHalfUp(value.Amount, minorUnit), value.Currency, minorUnit);
        }
        
        /// <summary>
        /// Rounds the value up if it is halfway to the minor unit or above.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The rounded currency.</returns>
        public static Money RoundHalfUp(MoneyQuotient value)
        {
            return new Money(RoundHalfUp(value.Amount, value.MinorUnit), value.Currency, value.MinorUnit);
        }
        
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
        /// Rounds the value down if it is halfway to the minor unit or above.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minorUnit">The minor unit to round to.</param>
        /// <returns>The rounded currency.</returns>
        public static Money RoundHalfDown(Money value, decimal minorUnit)
        {
            return new Money(RoundHalfDown(value.Amount, minorUnit), value.Currency, minorUnit);
        }
        
        /// <summary>
        /// Rounds the value down if it is halfway to the minor unit or above.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The rounded currency.</returns>
        public static Money RoundHalfDown(MoneyQuotient value)
        {
            return new Money(RoundHalfDown(value.Amount, value.MinorUnit), value.Currency, value.MinorUnit);
        }
        

        /// <summary>
        /// Rounds the value down if it is halfway to the minor unit or above.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minorUnit">The minor unit.</param>
        /// <returns>The rounded value.</returns>
        public static decimal RoundHalfDown(decimal value, decimal minorUnit)
        {
            if (value == 0)
                return 0;

            var multiple = 1 / minorUnit;
            value *= multiple;
            var rounded = Math.Floor(value);
            if (value > rounded + 0.5M)
                rounded++;
            
            return rounded / multiple;
        }
        
        /// <summary>
        /// Rounds the value to the nearest even value if it is halfway to the
        /// minor unit or above.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minorUnit">The minor unit to round to.</param>
        /// <returns>The rounded currency.</returns>
        public static Money RoundHalfEven(Money value, decimal minorUnit)
        {
            return new Money(RoundHalfEven(value.Amount, minorUnit), value.Currency, minorUnit);
        }
        
        /// <summary>
        /// Rounds the value to the nearest even value if it is halfway to the
        /// minor unit or above.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The rounded currency.</returns>
        public static Money RoundHalfEven(MoneyQuotient value)
        {
            return new Money(RoundHalfEven(value.Amount, value.MinorUnit), value.Currency, value.MinorUnit);
        }

        /// <summary>
        /// Rounds the value to the nearest even value if it is halfway to the
        /// minor unit or above.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minorUnit">The minor unit.</param>
        /// <returns>The rounded value.</returns>
        public static decimal RoundHalfEven(decimal value, decimal minorUnit)
        {
            if (value == 0)
                return 0;

            var multiple = 1 / minorUnit;
            value *= multiple;
            var rounded = Math.Floor(value);
            if (value > rounded + 0.5M)
                rounded++;

            if (value == rounded + 0.5M)
            {
                // Multiply both out 
                var up = (rounded + 1) / multiple;
                var down = rounded / multiple;
                
                // Make last significant digit in unit column, e.g. 100,05 to 10005
                var digits = Math.Max(GetDecimalDigits(up), GetDecimalDigits(down));
                multiple = (decimal)Math.Pow(10, digits);
                
                up *= multiple;
                down *= multiple;
                
                // Decide on last significant digit, and return back to correct scale
                if (up % 2 == 0)
                    return up / multiple;
                else
                    return down / multiple;
            }
            
            return rounded / multiple;
        }
        
        /// <summary>
        /// Rounds the value up if is above a minor unit;
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minorUnit">The minor unit to round to.</param>
        /// <returns>The rounded currency.</returns>
        public static Money RoundUp(Money value, decimal minorUnit)
        {
            return new Money(RoundUp(value.Amount, minorUnit), value.Currency, minorUnit);
        }
        
        /// <summary>
        /// Rounds the value up if is above a minor unit;
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The rounded currency.</returns>
        public static Money RoundUp(MoneyQuotient value)
        {
            return new Money(RoundUp(value.Amount, value.MinorUnit), value.Currency, value.MinorUnit);
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
        
        /// <summary>
        /// Rounds the value down if is above a minor unit;
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minorUnit">The minor unit to round to.</param>
        /// <returns>The rounded currency.</returns>
        public static Money RoundDown(Money value, decimal minorUnit)
        {
            return new Money(RoundDown(value.Amount, minorUnit), value.Currency, minorUnit);
        }

        /// <summary>
        /// Rounds the value down if is above a minor unit;
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The rounded currency.</returns>
        public static Money RoundDown(MoneyQuotient value)
        {
            return new Money(RoundDown(value.Amount, value.MinorUnit), value.Currency, value.MinorUnit);
        }
        
        /// <summary>
        /// Rounds the value down if is above a minor unit;
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minorUnit">The minor unit.</param>
        /// <returns>The rounded value.</returns>
        public static decimal RoundDown(decimal value, decimal minorUnit)
        {
            if (value == 0)
                return 0;

            var multiple = 1 / minorUnit;
            value *= multiple;
            var rounded = Math.Floor(value);
            
            return rounded / multiple;
        }
        
        private static int GetDecimalDigits(decimal value)
        {
            return BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
        }
    }
}