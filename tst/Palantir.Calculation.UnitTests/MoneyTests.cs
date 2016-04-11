namespace Palantir.Calculation.UnitTests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public sealed class MoneyTests
	{
        private Currency zar = new Currency("ZAR", "R", 2);
        private Currency usd = new Currency("USD", "$", 2);
        
		[Fact]
		public void MoneyWithDifferentCurrencies_ShouldNotBeCompatible()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, usd);

			money1.IsCompatibleWith(money2).Should().BeFalse();
		}

		[Fact]
		public void MoneyWithDifferentScales_ShouldNotBeCompatible()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, new Currency("ZAR", "R", 3));

			money1.IsCompatibleWith(money2).Should().BeFalse();
		}

		[Fact]
		public void MoneyWithSameScaleAndCurrency_ShouldBeCompatible()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, zar);

			money1.IsCompatibleWith(money2).Should().BeTrue();
		}

		[Fact]
		public void MoneyEmpty_ShouldNotBeCompatibleWithNewMoney()
		{
			var money1 = new Money();

			money1.IsCompatibleWith(Money.Empty).Should().BeFalse();
		}

		[Fact]
		public void AddTwoCompatibleMonies_ShouldHaveCorrectResult()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, zar);

			Money result = (money1 + money2);
			result.Amount.Should().Be(30);
			result.Currency.Scale.Should().Be(2);
			result.Currency.Code.Should().Be("ZAR");
		}

		[Fact]
		public void AddMoneyToEmpty_ShouldNotChangeResult()
		{
			var money1 = new Money(10, zar);

			Money result = (money1 + Money.Empty);
			result.Amount.Should().Be(10);
			result.Currency.Scale.Should().Be(2);
			result.Currency.Code.Should().Be("ZAR");
		}

		[Fact]
		public void AddTwoIncompatibleCurrencyMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, usd);

			Action action = () => { Money result = money1 + money2; };
			action.ShouldThrow<IncompatibleUnitException>();
		}

		[Fact]
		public void AddTwoIncompatibleScaleMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, new Currency("ZAR", "R", 3));

			Action action = () => { Money result = money1 + money2; };
			action.ShouldThrow<IncompatibleUnitException>();
		}

		[Fact]
		public void SubtractTwoCompatibleMonies_ShouldHaveCorrectResult()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, zar);

			Money result = (money1 - money2);
			result.Amount.Should().Be(-10);
			result.Currency.Scale.Should().Be(2);
			result.Currency.Code.Should().Be("ZAR");
		}

		[Fact]
		public void SubtractTwoIncompatibleCurrencyMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, usd);

			Action action = () => { Money result = money1 - money2; };
			action.ShouldThrow<IncompatibleUnitException>();
		}

		[Fact]
		public void SubtractTwoIncompatibleScaleMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, new Currency("ZAR", "R", 3));

			Action action = () => { Money result = money1 - money2; };
			action.ShouldThrow<IncompatibleUnitException>();
		}

		[Fact]
		public void DivideTwoCompatibleMonies_ShouldHaveCorrectResult()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, zar);

			var result = (money1 / money2);
			result.Amount.Should().Be(0.5M);
			result.Currency.Scale.Should().Be(2);
			result.Currency.Code.Should().Be("ZAR");
		}

		[Fact]
		public void DivideTwoCompatibleMonies_ShouldHaveCorrectRemainder()
		{
			var money1 = new Money(49, zar);
			var money2 = new Money(19, zar);

			var result = (money1 / money2);
			result.Amount.Should().Be(2.5789473684210526315789473684M);
			result.Currency.Scale.Should().Be(2);
			result.Currency.Code.Should().Be("ZAR");
		}

		[Fact]
		public void DivideTwoIncompatibleCurrencyMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, usd);

			Action action = () => { var result = money1 / money2; };
			action.ShouldThrow<IncompatibleUnitException>();
		}

		[Fact]
		public void DivideTwoIncompatibleScaleMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, new Currency("ZAR", "R", 3));

			Action action = () => { var result = money1 / money2; };
			action.ShouldThrow<IncompatibleUnitException>();
		}

		[Fact]
		public void MultiplyTwoCompatibleMonies_ShouldHaveCorrectResult()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, zar);

			var result = (money1 * money2);
			result.Amount.Should().Be(200);
			result.Currency.Scale.Should().Be(2);
			result.Currency.Code.Should().Be("ZAR");
		}

		[Fact]
		public void MultiplyTwoIncompatibleCurrencyMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, usd);

			Action action = () => { var result = money1 * money2; };
			action.ShouldThrow<IncompatibleUnitException>();
		}

		[Fact]
		public void MultiplyTwoIncompatibleScaleMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, new Currency("ZAR", "R", 3));

			Action action = () => { var result = money1 * money2; };
			action.ShouldThrow<IncompatibleUnitException>();
		}
	}
}