namespace Palantir.Calculation
{
    using System.Diagnostics.Contracts;
    
    /// <summary>
    /// Represents a Unit for a Unit of Measure calculation.
    /// </summary>
    public sealed class Unit 
    {
        private readonly string abbreviation;
        private readonly string name;
        
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
    }
}