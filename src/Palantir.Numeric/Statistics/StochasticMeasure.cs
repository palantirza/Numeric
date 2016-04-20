namespace Palantir.Numeric.Statistics
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Represents a stochastic Measure, a combination of unit, mean, and standard deviation.
    /// </summary>
    [DebuggerDisplay("{Mean}σ{StandardDeviation} {Unit.Abbreviation}")]
	public struct StochasticMeasure
	{
		#region Declarations

		/// <summary>
		/// The stochastic.
		/// </summary>
		private readonly Stochastic stochastic;
		
		/// <summary>
		/// The unit information.
		/// </summary>
		private readonly Unit unit;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="StochasticMeasure"/> struct.
		/// </summary>
		/// <param name="mean">
		/// The amount.
		/// </param>
		/// <param name="sigma">
		/// The standard deviation.
		/// </param>
		/// <param name="unit">
		/// The unit.
		/// </param>
		public StochasticMeasure(decimal mean, decimal sigma, Unit unit)
		{
			Contract.Requires(unit != null);

			this.stochastic = new Stochastic((double)mean, (double)sigma);
			this.unit = unit;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StochasticMeasure"/> struct.
		/// </summary>
		/// <param name="value">
		/// The stochastic value.
		/// </param>
		/// <param name="unit">
		/// The unit.
		/// </param>
		public StochasticMeasure(Stochastic value, Unit unit)
		{
			Contract.Requires(unit != null);

			this.stochastic = value;
			this.unit = unit;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the unit.
		/// </summary>
		public Unit Unit => unit;

		/// <summary>
		/// Gets the mean measure amount.
		/// </summary>
		public decimal Mean => (decimal)stochastic.Mean;

		/// <summary>
		/// Gets the standard deviation measure amount.
		/// </summary>
		public decimal StandardDeviation => (decimal)stochastic.StandardDeviation;

		/// <summary>
		/// Gets a value indicating whether the StochasticMeasure instance is Empty or not.
		/// </summary>
		public bool IsEmpty => unit == null;

		#endregion

		#region Methods

		/// <summary>
		/// Asserts that two StochasticMeasure instances are compatible.
		/// </summary>
		/// <param name="lhs">The first StochasticMeasure instance.</param>
		/// <param name="rhs">The second StochasticMeasure instance.</param>
		public static void AssertCompatible(StochasticMeasure lhs, StochasticMeasure rhs)
		{
			if (!lhs.IsCompatibleWith(rhs))
				throw new IncompatibleUnitException($"Unit {lhs.Unit.Name} is not compatible with {rhs.Unit.Name}");
		}

		/// <summary>
		/// Indicates whether the two StochasticMeasure instances are compatible or not.
		/// </summary>
		/// <param name="that">The StochasticMeasure instance to compare with.</param>
		/// <returns>true if the two StochasticMeasure instances are compatible, false otherwise.</returns>
		[Pure]
		public bool IsCompatibleWith(StochasticMeasure that)
		{
			if (IsEmpty || that.IsEmpty)
				return false;

			return unit.Name == that.Unit.Name;
		}

		/// <summary>
		/// Asserts that a StochasticMeasure instance is compatible with a Measure.
		/// </summary>
		/// <param name="lhs">The first StochasticMeasure instance.</param>
		/// <param name="rhs">The second Measure instance.</param>
		public static void AssertCompatible(StochasticMeasure lhs, Measure rhs)
		{
			if (!lhs.IsCompatibleWith(rhs))
				throw new IncompatibleUnitException($"Unit {lhs.Unit.Name} is not compatible with {rhs.Unit.Name}");
		}

		/// <summary>
		/// Indicates whether that a StochasticMeasure instance is compatible with a Measure.
		/// </summary>
		/// <param name="that">The Measure instance to compare with.</param>
		/// <returns>true if the StochasticMeasure and Measure instances are compatible, false otherwise.</returns>
		[Pure]
		public bool IsCompatibleWith(Measure that)
		{
			if (IsEmpty || that.IsEmpty)
				return false;

			return unit.Name == that.Unit.Name;
		}

		/// <summary>
		/// Compares the StochasticMeasure for equality.
		/// </summary>
		/// <param name="obj">The object to compare to.</param>
		/// <returns>true if the objects are equal, false otherwise.</returns>
		public override bool Equals(object obj)
		{
			// STEP 1: Check for null
			if (obj == null)
				return false;

			// STEP 3: equivalent data types
			if (this.GetType() != obj.GetType())
				return false;

			return Equals((StochasticMeasure)obj);
		}

		/// <summary>
		/// Compares the StochasticMeasure for equality.
		/// </summary>
		/// <param name="obj">The object to compare to.</param>
		/// <returns>true if the objects are equal, false otherwise.</returns>
		public bool Equals(StochasticMeasure obj)
		{
			// STEP 1: Check for null if nullable (e.g., a reference type)
			// STEP 2: Check for ReferenceEquals if this is a reference type

			// STEP 4: Possibly check for equivalent hash codes

			// STEP 5: Check base.Equals if base overrides Equals()

			// STEP 6: Compare identifying fields for equality.
			return this.stochastic.Equals(obj.stochastic)
				&& (Equals(this.unit, obj.unit));
		}

		/// <summary>
		/// Fetches the hash code for the StochasticMeasure.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				var hash = 17;
				hash *= 23 + stochastic.GetHashCode();
				hash *= 23 + unit.GetHashCode();

				return hash;
			}
		}

		#endregion

        #region Operators
		/// <summary>
		/// Adds two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator +(StochasticMeasure lhs, StochasticMeasure rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMeasure(lhs.stochastic + rhs.stochastic, lhs.unit);
		}

		/// <summary>
		/// Adds two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator +(StochasticMeasure lhs, Measure rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMeasure(lhs.stochastic + (double)rhs.Value, lhs.unit);
		}

		/// <summary>
		/// Adds two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator +(Measure lhs, StochasticMeasure rhs)
		{
			AssertCompatible(rhs, lhs);
			
			return new StochasticMeasure((double)lhs.Value + rhs.stochastic, lhs.Unit);
		}

		/// <summary>
		/// Subtracts two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator -(StochasticMeasure lhs, StochasticMeasure rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMeasure(lhs.stochastic - rhs.stochastic, lhs.unit);
		}

		/// <summary>
		/// Subtracts two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator -(StochasticMeasure lhs, Measure rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMeasure(lhs.stochastic - (double)rhs.Value, lhs.unit);
		}

		/// <summary>
		/// Subtracts two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator -(Measure lhs, StochasticMeasure rhs)
		{
			AssertCompatible(rhs, lhs);
			
			return new StochasticMeasure((double)lhs.Value + rhs.stochastic, lhs.Unit);
		}
		
		/// <summary>
		/// Multiplies two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator *(StochasticMeasure lhs, StochasticMeasure rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMeasure(lhs.stochastic * rhs.stochastic, lhs.unit);
		}

		/// <summary>
		/// Multiplies two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator *(StochasticMeasure lhs, Measure rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMeasure(lhs.stochastic * (double)rhs.Value, lhs.unit);
		}

		/// <summary>
		/// Multiplies two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator *(Measure lhs, StochasticMeasure rhs)
		{
			AssertCompatible(rhs, lhs);
			
			return new StochasticMeasure((double)lhs.Value * rhs.stochastic, lhs.Unit);
		}
		
		/// <summary>
		/// Divides two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator /(StochasticMeasure lhs, StochasticMeasure rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMeasure(lhs.stochastic / rhs.stochastic, lhs.unit);
		}

		/// <summary>
		/// Divides two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator /(StochasticMeasure lhs, Measure rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMeasure(lhs.stochastic / (double)rhs.Value, lhs.unit);
		}

		/// <summary>
		/// Divides two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMeasure operator /(Measure lhs, StochasticMeasure rhs)
		{
			AssertCompatible(rhs, lhs);
			
			return new StochasticMeasure((double)lhs.Value / rhs.stochastic, lhs.Unit);
		}
        #endregion
        
		#region Overrides

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="StochasticMeasure"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="StochasticMeasure"/>.</returns>
		public override string ToString()
		{
			if (IsEmpty)
				return "0";
			else
				return string.Format("{0}σ{1} {2}", Mean, StandardDeviation, Unit.Abbreviation);
		}

		#endregion
	}
}