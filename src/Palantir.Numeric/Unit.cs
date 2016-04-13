namespace Palantir.Numeric
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    
    /// <summary>
    /// Represents a Unit for a Unit of Measure calculation.
    /// </summary>
    public sealed class Unit 
    {
        private readonly string abbreviation;
        private readonly string name;
        private readonly Dictionary<Unit, Func<decimal, decimal>> conversions = new Dictionary<Unit, Func<decimal, decimal>>();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Unit" /> class.
        /// </summary>
        /// <param name="abbreviation">The unit abbreviation.</param>
        /// <param name="name">The unit name.</param>
        public Unit(string abbreviation, string name = null)
        {
            Contract.Requires(!string.IsNullOrEmpty(abbreviation));
            
            this.abbreviation = abbreviation;
            this.name = name;
        }
        
        /// <summary>
        /// The unit abbreviation.
        /// </summary>
        public string Abbreviation => abbreviation;
        
        /// <summary>
        /// The unit name.
        /// </summary>
        public string Name => name;
        
        /// <summary>
        /// Indicates if the Unit can be converted to another unit type.
        /// </summary>
        /// <param name="unit">The unit type to convert to.</param>
        /// <param name="conversion">The conversion function that returns the converted units.</param>
        public void AddConversion(Unit unit, Func<decimal, decimal> conversion) 
        {
            Contract.Requires(unit != null);
            Contract.Requires(conversion != null);
            
            conversions.Add(unit, conversion);
        }
        
        /// <summary>
        /// Indicates if the Unit can be converted to another unit type.
        /// </summary>
        /// <param name="unit">The unit type to convert to.</param>
        /// <returns>true if the indicated unit type can be converted to.</returns>
        public bool CanConvertTo(Unit unit) 
        {
            return (unit == this || conversions.ContainsKey(unit));
        }
        
        internal Func<decimal, decimal> GetConversion(Unit unit) 
        {
            if (unit == this)
                return x => x;
            
            return conversions[unit]; 
        }
    }
}