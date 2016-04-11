namespace Palantir.Calculation
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
        private readonly int scale;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        /// <param name="code">The currency code.</param>
        /// <param name="symbol">The currency symbol.</param>
        /// <param name="scale">The currency scale.</param>
        public Currency(string code, string symbol, int scale)
        {
            Contract.Requires(!string.IsNullOrEmpty(code));
            Contract.Requires(!string.IsNullOrEmpty(symbol));
            
            this.code = code;
            this.symbol = symbol;
            this.scale = scale;
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
        /// The currency scale.
        /// </summary>
        public int Scale => scale;
    }
}