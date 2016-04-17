namespace Palantir.Numeric
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Represents Money, a combination of currency, amount, and scale.
    /// Rounding is strict, and remainders are always returned for handling.
    /// </summary>
    [DebuggerDisplay("{Amount} {Currency.Code}")]
	public struct Money : IEquatable<Money>
	{
		#region Declarations

		/// <summary>
		/// The empty money.
		/// </summary>
		public static readonly Money Empty = new Money();

		/// <summary>
		/// The amount.
		/// </summary>
		private readonly decimal amount;
		
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
		/// Initializes a new instance of the <see cref="Money"/> struct.
		/// </summary>
		/// <param name="amount">
		/// The amount.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		public Money(decimal amount, Currency currency)
		{
			Contract.Requires(currency != null);
			Contract.Requires(amount % currency.MinorUnit == 0);

			this.amount = amount;
			this.currency = currency;
			this.minorUnit = currency.MinorUnit;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Money"/> struct,
		/// with a specified minor unit.
		/// </summary>
		/// <param name="amount">
		/// The amount.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		/// <param name="minorUnit">
		/// The minor unit for this money, overriding the <see cref="Currency"/>
		/// setting.
		/// </param>
		public Money(decimal amount, Currency currency, double minorUnit)
			: this(amount, currency, (decimal)minorUnit)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Money"/> struct,
		/// with a specified minor unit.
		/// </summary>
		/// <param name="amount">
		/// The amount.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		/// <param name="minorUnit">
		/// The minor unit for this money, overriding the <see cref="Currency"/>
		/// setting.
		/// </param>
		public Money(decimal amount, Currency currency, decimal minorUnit)
		{
			Contract.Requires(currency != null);
			Contract.Requires(minorUnit > 0);
			Contract.Requires(amount % minorUnit == 0);

			this.amount = amount;
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
		/// Gets the money amount.
		/// </summary>
		public decimal Amount => amount;

		/// <summary>
		/// Gets the money minor unit, or denomination.
		/// </summary>
		public decimal MinorUnit => minorUnit;

		/// <summary>
		/// Gets a value indicating whether the Money instance is Empty or not.
		/// </summary>
		public bool IsEmpty => currency == null;

		#endregion

		#region Operators

		/// <summary>
		/// Adds two money instances together.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Money operator +(Money lhs, Money rhs)
		{
			if (lhs.IsEmpty)
				return rhs;
			if (rhs.IsEmpty)
				return lhs;

			AssertCompatible(lhs, rhs);

			return new Money(lhs.amount + rhs.amount, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Adds two money instances together.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Money operator -(Money lhs, Money rhs)
		{
			if (lhs.IsEmpty)
				return rhs;
			if (rhs.IsEmpty)
				return lhs;

			AssertCompatible(lhs, rhs);

			return new Money(lhs.amount - rhs.amount, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Divides money by a value.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static MoneyQuotient operator /(Money lhs, decimal rhs)
		{
			if (lhs.IsEmpty)
				return lhs;

			return new MoneyQuotient(lhs.amount / rhs, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Divides money by a value.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static MoneyQuotient operator /(Money lhs, double rhs)
		{
			if (lhs.IsEmpty)
				return lhs;

			return new MoneyQuotient(lhs.amount / (decimal)rhs, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Divides money by a value.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static MoneyQuotient operator /(Money lhs, int rhs)
		{
			if (lhs.IsEmpty)
				return lhs;

			return new MoneyQuotient(lhs.amount / rhs, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Divides two money instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static MoneyQuotient operator /(Money lhs, Money rhs)
		{
			if (lhs.IsEmpty)
				return rhs;
			if (rhs.IsEmpty)
				return lhs;

			AssertCompatible(lhs, rhs);

			return new MoneyQuotient(lhs.amount / rhs.amount, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Multiplies money by a value.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static MoneyQuotient operator *(Money lhs, decimal rhs)
		{
			if (lhs.IsEmpty)
				return lhs;

			return new MoneyQuotient(lhs.amount * rhs, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Multiplies money by a value.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static MoneyQuotient operator *(Money lhs, double rhs)
		{
			if (lhs.IsEmpty)
				return lhs;

			return new MoneyQuotient(lhs.amount * (decimal)rhs, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Multiplies money by a value.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static MoneyQuotient operator *(Money lhs, int rhs)
		{
			if (lhs.IsEmpty)
				return lhs;

			return new MoneyQuotient(lhs.amount * rhs, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Multiplies two money instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static MoneyQuotient operator *(Money lhs, Money rhs)
		{
			if (lhs.IsEmpty)
				return rhs;
			if (rhs.IsEmpty)
				return lhs;

			AssertCompatible(lhs, rhs);

			return new MoneyQuotient(lhs.amount * rhs.amount, lhs.currency, lhs.minorUnit);
		}

		/// <summary>
		/// Compares two Money types for equality.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>true if the operands are equal, false otherwise.</returns>
		public static bool operator ==(Money lhs, Money rhs)
		{
			return Equals(lhs, rhs);
		}

		/// <summary>
		/// Compares two Money types for inequality.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>true if the operands are not equal, false otherwise.</returns>
		public static bool operator !=(Money lhs, Money rhs)
		{
			return !Equals(lhs, rhs);
		}

		#endregion

		#region Methods

		/// <summary>
		/// Asserts that two Money instances are compatible.
		/// </summary>
		/// <param name="lhs">The first Money instance.</param>
		/// <param name="rhs">The second Money instance.</param>
		public static void AssertCompatible(Money lhs, Money rhs)
		{
			if (!lhs.IsCompatibleWith(rhs))
				throw new IncompatibleUnitException($"Currency {lhs.Currency.Code} is not compatible with {rhs.Currency.Code}");
		}

		/// <summary>
		/// Indicates whether the two Money instances are compatible or not.
		/// </summary>
		/// <param name="that">The Money instance to compare with.</param>
		/// <returns>true if the two Money instances are compatible, false otherwise.</returns>
		[Pure]
		public bool IsCompatibleWith(Money that)
		{
			if (IsEmpty || that.IsEmpty)
				return false;

			return currency.Code == that.Currency.Code && minorUnit == that.minorUnit;
		}

		/// <summary>
		/// Sets the sign.
		/// </summary>
		/// <param name="sign">
		/// The sign to set. Can be -1, or 1.
		/// </param>
		/// <returns>
		/// The <see cref="Money"/>.
		/// </returns>
		public Money SetSign(int sign)
		{
			Contract.Requires(sign == 1 || sign == -1);

			return new Money(amount * sign, currency, minorUnit);
		}

		/// <summary>
		/// Compares the Money for equality.
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

			return Equals((Money)obj);
		}

		/// <summary>
		/// Compares the Money for equality.
		/// </summary>
		/// <param name="obj">The object to compare to.</param>
		/// <returns>true if the objects are equal, false otherwise.</returns>
		public bool Equals(Money obj)
		{
			// STEP 1: Check for null if nullable (e.g., a reference type)
			// STEP 2: Check for ReferenceEquals if this is a reference type

			// STEP 4: Possibly check for equivalent hash codes

			// STEP 5: Check base.Equals if base overrides Equals()

			// STEP 6: Compare identifying fields for equality.
			return this.Amount.Equals(obj.Amount)
				&& (Equals(this.currency, obj.currency)
				|| ((this.Amount == 0 && obj.IsEmpty)
				|| (this.IsEmpty && obj.Amount == 0)));
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
				hash *= 23 + amount.GetHashCode();
				hash *= 23 + currency.GetHashCode();

				return hash;
			}
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Money"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="Money"/>.</returns>
		public override string ToString()
		{
			if (IsEmpty)
				return "0";
			else
				return string.Format("{0} {1}", Amount, Currency.Code);
		}

		#endregion
	}
}