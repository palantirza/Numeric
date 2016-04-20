namespace Palantir.Numeric.Statistics
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Represents a stochastic Money, a combination of currency, mean, minor unit and standard deviation.
    /// Rounding is strict, and remainders are always returned for handling.
    /// </summary>
    [DebuggerDisplay("{Mean}σ{StandardDeviation} {Currency.Code}")]
	public struct StochasticMoney
	{
		#region Declarations

		/// <summary>
		/// The stochastic.
		/// </summary>
		private readonly Stochastic stochastic;
		
		/// <summary>
		/// The money minor unit.
		/// </summary>
		private readonly decimal minorUnit;

		/// <summary>
		/// The currency information.
		/// </summary>
		private readonly Currency currency;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="StochasticMoney"/> struct.
		/// </summary>
		/// <param name="mean">
		/// The amount.
		/// </param>
		/// <param name="sigma">
		/// The standard deviation.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		public StochasticMoney(decimal mean, decimal sigma, Currency currency)
		{
			Contract.Requires(currency != null);
			Contract.Requires(mean % currency.MinorUnit == 0);
            Contract.Requires(sigma % currency.MinorUnit == 0);

			this.stochastic = new Stochastic((double)mean, (double)sigma);
			this.currency = currency;
			this.minorUnit = currency.MinorUnit;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StochasticMoney"/> struct.
		/// </summary>
		/// <param name="value">
		/// The stochastic value.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		public StochasticMoney(Stochastic value, Currency currency)
		{
			Contract.Requires(currency != null);

			this.stochastic = value;
			this.currency = currency;
			this.minorUnit = currency.MinorUnit;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StochasticMoney"/> struct,
		/// with a specified minor unit.
		/// </summary>
		/// <param name="mean">
		/// The amount.
		/// </param>
		/// <param name="sigma">
		/// The standard deviation.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		/// <param name="minorUnit">
		/// The minor unit for this money, overriding the <see cref="Currency"/>
		/// setting.
		/// </param>
		public StochasticMoney(decimal mean, decimal sigma, Currency currency, double minorUnit)
			: this(mean, sigma, currency, (decimal)minorUnit)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="StochasticMoney"/> struct,
		/// with a specified minor unit.
		/// </summary>
		/// <param name="value">
		/// The stochastic value.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		/// <param name="minorUnit">
		/// The minor unit for this money, overriding the <see cref="Currency"/>
		/// setting.
		/// </param>
		public StochasticMoney(Stochastic value, Currency currency, double minorUnit)
			: this(value, currency, (decimal)minorUnit)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="StochasticMoney"/> struct,
		/// with a specified minor unit.
		/// </summary>
		/// <param name="mean">
		/// The amount.
		/// </param>
		/// <param name="sigma">
		/// The standard deviation.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		/// <param name="minorUnit">
		/// The minor unit for this money, overriding the <see cref="Currency"/>
		/// setting.
		/// </param>
		public StochasticMoney(decimal mean, decimal sigma, Currency currency, decimal minorUnit)
			: this(new Stochastic((double)mean, (double)sigma), currency, minorUnit)
		{
			Contract.Requires(mean % currency.MinorUnit == 0);
            Contract.Requires(sigma % currency.MinorUnit == 0);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StochasticMoney"/> struct,
		/// with a specified minor unit.
		/// </summary>
		/// <param name="mean">
		/// The amount.
		/// </param>
		/// <param name="sigma">
		/// The standard deviation.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		public StochasticMoney(double mean, double sigma, Currency currency)
			: this(new Stochastic(mean, sigma), currency)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StochasticMoney"/> struct,
		/// with a specified minor unit.
		/// </summary>
		/// <param name="mean">
		/// The amount.
		/// </param>
		/// <param name="sigma">
		/// The standard deviation.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		/// <param name="minorUnit">
		/// The minor unit for this money, overriding the <see cref="Currency"/>
		/// setting.
		/// </param>
		public StochasticMoney(double mean, double sigma, Currency currency, double minorUnit)
			: this(new Stochastic(mean, sigma), currency, minorUnit)
		{
			Contract.Requires((decimal)mean % currency.MinorUnit == 0);
            Contract.Requires((decimal)sigma % currency.MinorUnit == 0);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StochasticMoney"/> struct,
		/// with a specified minor unit.
		/// </summary>
		/// <param name="value">
		/// The stochastic value.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		/// <param name="minorUnit">
		/// The minor unit for this money, overriding the <see cref="Currency"/>
		/// setting.
		/// </param>
		public StochasticMoney(Stochastic value, Currency currency, decimal minorUnit)
		{
			Contract.Requires(currency != null);
			Contract.Requires(minorUnit > 0);

			this.stochastic = value;
			this.currency = currency;
			this.minorUnit = minorUnit;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the currency.
		/// </summary>
		public Currency Currency => currency;

		/// <summary>
		/// Gets the mean money amount.
		/// </summary>
		public decimal Mean => (decimal)stochastic.Mean;

		/// <summary>
		/// Gets the standard deviation money amount.
		/// </summary>
		public decimal StandardDeviation => (decimal)stochastic.StandardDeviation;

		/// <summary>
		/// Gets the money minor unit, or denomination.
		/// </summary>
		public decimal MinorUnit => minorUnit;

		/// <summary>
		/// Gets a value indicating whether the Money instance is Empty or not.
		/// </summary>
		public bool IsEmpty => currency == null;

		#endregion

		#region Methods

		/// <summary>
		/// Asserts that two StochasticMoney instances are compatible.
		/// </summary>
		/// <param name="lhs">The first StochasticMoney instance.</param>
		/// <param name="rhs">The second StochasticMoney instance.</param>
		public static void AssertCompatible(StochasticMoney lhs, StochasticMoney rhs)
		{
			if (!lhs.IsCompatibleWith(rhs))
				throw new IncompatibleUnitException($"Currency {lhs.Currency.Code} is not compatible with {rhs.Currency.Code}");
		}

		/// <summary>
		/// Indicates whether the two StochasticMoney instances are compatible or not.
		/// </summary>
		/// <param name="that">The StochasticMoney instance to compare with.</param>
		/// <returns>true if the two StochasticMoney instances are compatible, false otherwise.</returns>
		[Pure]
		public bool IsCompatibleWith(StochasticMoney that)
		{
			if (IsEmpty || that.IsEmpty)
				return false;

			return currency.Code == that.Currency.Code && minorUnit == that.minorUnit;
		}

		/// <summary>
		/// Asserts that a StochasticMoney instance is compatible with a Money.
		/// </summary>
		/// <param name="lhs">The first StochasticMoney instance.</param>
		/// <param name="rhs">The second Money instance.</param>
		public static void AssertCompatible(StochasticMoney lhs, Money rhs)
		{
			if (!lhs.IsCompatibleWith(rhs))
				throw new IncompatibleUnitException($"Currency {lhs.Currency.Code} is not compatible with {rhs.Currency.Code}");
		}

		/// <summary>
		/// Indicates whether that a StochasticMoney instance is compatible with a Money.
		/// </summary>
		/// <param name="that">The Money instance to compare with.</param>
		/// <returns>true if the two StochasticMoney instances are compatible, false otherwise.</returns>
		[Pure]
		public bool IsCompatibleWith(Money that)
		{
			if (IsEmpty || that.IsEmpty)
				return false;

			return currency.Code == that.Currency.Code && minorUnit == that.MinorUnit;
		}

		/// <summary>
		/// Compares the StochasticMoney for equality.
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

			return Equals((StochasticMoney)obj);
		}

		/// <summary>
		/// Compares the StochasticMoney for equality.
		/// </summary>
		/// <param name="obj">The object to compare to.</param>
		/// <returns>true if the objects are equal, false otherwise.</returns>
		public bool Equals(StochasticMoney obj)
		{
			// STEP 1: Check for null if nullable (e.g., a reference type)
			// STEP 2: Check for ReferenceEquals if this is a reference type

			// STEP 4: Possibly check for equivalent hash codes

			// STEP 5: Check base.Equals if base overrides Equals()

			// STEP 6: Compare identifying fields for equality.
			return this.stochastic.Equals(obj.stochastic)
				&& (Equals(this.currency, obj.currency));
		}

		/// <summary>
		/// Fetches the hash code for the Money.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				var hash = 17;
				hash *= 23 + stochastic.GetHashCode();
				hash *= 23 + currency.GetHashCode();

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
		public static StochasticMoney operator +(StochasticMoney lhs, StochasticMoney rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMoney(lhs.stochastic + rhs.stochastic, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Adds two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator +(StochasticMoney lhs, Money rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMoney(lhs.stochastic + (double)rhs.Amount, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Adds two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator +(Money lhs, StochasticMoney rhs)
		{
			AssertCompatible(rhs, lhs);
			
			return new StochasticMoney((double)lhs.Amount + rhs.stochastic, lhs.Currency, lhs.MinorUnit);
		}

		/// <summary>
		/// Subtracts two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator -(StochasticMoney lhs, StochasticMoney rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMoney(lhs.stochastic - rhs.stochastic, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Subtracts two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator -(StochasticMoney lhs, Money rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMoney(lhs.stochastic - (double)rhs.Amount, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Subtracts two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator -(Money lhs, StochasticMoney rhs)
		{
			AssertCompatible(rhs, lhs);
			
			return new StochasticMoney((double)lhs.Amount + rhs.stochastic, lhs.Currency, lhs.MinorUnit);
		}
		
		/// <summary>
		/// Multiplies two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator *(StochasticMoney lhs, StochasticMoney rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMoney(lhs.stochastic * rhs.stochastic, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Multiplies two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator *(StochasticMoney lhs, Money rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMoney(lhs.stochastic * (double)rhs.Amount, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Multiplies two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator *(Money lhs, StochasticMoney rhs)
		{
			AssertCompatible(rhs, lhs);
			
			return new StochasticMoney((double)lhs.Amount * rhs.stochastic, lhs.Currency, lhs.MinorUnit);
		}
		
		/// <summary>
		/// Divides two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator /(StochasticMoney lhs, StochasticMoney rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMoney(lhs.stochastic / rhs.stochastic, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Divides two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator /(StochasticMoney lhs, Money rhs)
		{
			AssertCompatible(lhs, rhs);
			
			return new StochasticMoney(lhs.stochastic / (double)rhs.Amount, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Divides two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static StochasticMoney operator /(Money lhs, StochasticMoney rhs)
		{
			AssertCompatible(rhs, lhs);
			
			return new StochasticMoney((double)lhs.Amount / rhs.stochastic, lhs.Currency, lhs.MinorUnit);
		}
        #endregion
        
		#region Overrides

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="StochasticMoney"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="StochasticMoney"/>.</returns>
		public override string ToString()
		{
			if (IsEmpty)
				return "0";
			else
				return string.Format("{0}σ{1} {2}", Mean, StandardDeviation, Currency.Code);
		}

		#endregion
	}
}