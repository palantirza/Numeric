namespace Palantir.Numeric
{
    using System.Globalization;
    using System.Diagnostics.Contracts;
    
    /// <summary>
    /// Represents a currency.
    /// </summary>
    public sealed class Currency
    {
        private readonly string code;
        private readonly string symbol;
        private readonly decimal minorUnit;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        /// <param name="code">The currency code.</param>
        /// <param name="symbol">The currency symbol.</param>
        /// <param name="minorUnit">The currency minor unit.</param>
        public Currency(string code, string symbol, double minorUnit)
            : this(code, symbol, (decimal)minorUnit) 
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        /// <param name="code">The currency code.</param>
        /// <param name="symbol">The currency symbol.</param>
        /// <param name="minorUnit">The currency minor unit.</param>
        public Currency(string code, string symbol, decimal minorUnit)
        {
            Contract.Requires(!string.IsNullOrEmpty(code));
            Contract.Requires(!string.IsNullOrEmpty(symbol));
            Contract.Requires(minorUnit > 0);
            
            this.code = code;
            this.symbol = symbol;
            this.minorUnit = minorUnit;
        }
        
        /// <summary>
        /// The currency code.
        /// </summary>
        public string Code => code;
        
        /// <summary>
        /// The currency symbol.
        /// </summary>
        public string Symbol => symbol;
        
        /// <summary>
        /// The currency minor unit size, the smallest denomination available.
        /// </summary>
        public decimal MinorUnit => minorUnit;
    }
}