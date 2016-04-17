namespace Palantir.Numeric
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Represents MoneyQuotient, a result of a Money operation that could result
    /// in a remainder.
    /// </summary>
    [DebuggerDisplay("{Amount} {Currency.Code}")]
	public struct MoneyQuotient
	{
		#region Declarations

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
		/// Initializes a new instance of the <see cref="MoneyQuotient"/> struct.
		/// </summary>
		/// <param name="amount">
		/// The amount.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		internal MoneyQuotient(decimal amount, Currency currency)
		{
			Contract.Requires(currency != null);

			this.amount = amount;
			this.currency = currency;
			this.minorUnit = currency.MinorUnit;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MoneyQuotient"/> struct,
		/// with a specified minor unit.
		/// </summary>
		/// <param name="amount">
		/// The amount.
		/// </param>
		/// <param name="currency">
		/// The currency.
		/// </param>
		/// <param name="minorUnit">
		/// The minor unit for this quotient, overriding the <see cref="Currency"/>
		/// setting.
		/// </param>
		internal MoneyQuotient(decimal amount, Currency currency, decimal minorUnit)
		{
			Contract.Requires(currency != null);
			Contract.Requires(minorUnit > 0);

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
		/// Gets the money quotient amount.
		/// </summary>
		public decimal Amount => amount;

		/// <summary>
		/// Gets the money minor unit.
		/// </summary>
		public decimal MinorUnit => minorUnit;
        
        /// <summary>
        /// Whether the quotient is "pure", in that it will have no remainder,
        /// and thus can be easily converted to a <see cref="Money" />
        /// </summary>
        public bool IsPure => amount % minorUnit == 0;

		#endregion

		#region Methods

		/// <summary>
		/// Fetches the hash code for the MoneyQuotient.
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

        #region Operators
        /// <summary>
        /// Converts a <see cref="Money"> into a <see cref="MoneyQuotient" />.
        /// </summary>
        /// <param name="money">The money to convert.</param>
        public static implicit operator MoneyQuotient(Money money)
        {
            return new MoneyQuotient(money.Amount, money.Currency, money.MinorUnit);
        }
        #endregion

		#region Overrides

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Money"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="Money"/>.</returns>
		public override string ToString()
		{
			if (currency == null)
				return "0";
			else
				return string.Format("{0} {1}", Amount, Currency.Code);
		}

		#endregion
	}
}