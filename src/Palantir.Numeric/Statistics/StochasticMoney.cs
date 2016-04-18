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
		/// Initializes a new instance of the <see cref="StochasticMoneyMoney"/> struct,
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
		/// Initializes a new instance of the <see cref="StochasticMoneyMoney"/> struct,
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
		{
			Contract.Requires(currency != null);
			Contract.Requires(minorUnit > 0);
			Contract.Requires(mean % currency.MinorUnit == 0);
            Contract.Requires(sigma % currency.MinorUnit == 0);

			this.stochastic = new Stochastic((double)mean, (double)sigma);
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