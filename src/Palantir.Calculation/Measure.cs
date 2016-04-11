namespace Palantir.Calculation
{
    using System.Diagnostics.Contracts;
    
    /// <summary>
    /// Represents a measure, a value associated with a particular <see cref="Unit" />.
    /// </summary>
    public sealed class Measure
    {
        private readonly Unit unit;
        private readonly decimal value;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Measure" />.
        /// </summary>
        /// <param name="value">The measure value.</param>
        /// <param name="unit">The unit type.</param>
        public Measure(decimal value, Unit unit)
        {
            Contract.Requires(unit != null);
            
            this.value = value;
            this.unit = unit;
        }
        
        /// <summary>
        /// The unit the measure is represented in.
        /// </summary>
        public Unit Unit => unit;
        
        /// <summary>
        /// The value of the measure.
        /// </summary>
        public decimal Value => value;
        
        /// <summary>
        /// Adds two Measure's together.
        /// </summary>
        /// <param name="lhs">The left hand side of the operation.</param>
        /// <param name="rhs">The right hand side of the operation.</param>
        /// <returns>The resultant measure.</returns>
        public static Measure operator+(Measure lhs, Measure rhs)
        {
            if (lhs.Unit != rhs.Unit)
                throw new IncompatibleUnitException($"Cannot add '{lhs.Unit.Abbreviation}' and '{rhs.Unit.Abbreviation}' units");
                
            return new Measure(lhs.Value + rhs.Value, lhs.Unit);
        }
        
        /// <summary>
        /// Subtracts <paramref name="rhs" /> from <paramref name="lhs" />.
        /// </summary>
        /// <param name="lhs">The left hand side of the operation.</param>
        /// <param name="rhs">The right hand side of the operation.</param>
        /// <returns>The resultant measure.</returns>
        public static Measure operator-(Measure lhs, Measure rhs)
        {
            if (lhs.Unit != rhs.Unit)
                throw new IncompatibleUnitException($"Cannot subtract '{lhs.Unit.Abbreviation}' and '{rhs.Unit.Abbreviation}' units");
                
            return new Measure(lhs.Value - rhs.Value, lhs.Unit);
        }
        
        /// <summary>
        /// Divides <paramref name="lhs" /> by <paramref name="rhs" />.
        /// </summary>
        /// <param name="lhs">The left hand side of the operation.</param>
        /// <param name="rhs">The right hand side of the operation.</param>
        /// <returns>The resultant measure.</returns>
        public static Measure operator/(Measure lhs, Measure rhs)
        {
            if (lhs.Unit != rhs.Unit)
                throw new IncompatibleUnitException($"Cannot divide '{lhs.Unit.Abbreviation}' and '{rhs.Unit.Abbreviation}' units");
                
            return new Measure(lhs.Value / rhs.Value, lhs.Unit);
        }
        
        /// <summary>
        /// Multiplies <paramref name="lhs" /> by <paramref name="rhs" />.
        /// </summary>
        /// <param name="lhs">The left hand side of the operation.</param>
        /// <param name="rhs">The right hand side of the operation.</param>
        /// <returns>The resultant measure.</returns>
        public static Measure operator*(Measure lhs, Measure rhs)
        {
            if (lhs.Unit != rhs.Unit)
                throw new IncompatibleUnitException($"Cannot multiply '{lhs.Unit.Abbreviation}' and '{rhs.Unit.Abbreviation}' units");
                
            return new Measure(lhs.Value * rhs.Value, lhs.Unit);
        }
    }
}