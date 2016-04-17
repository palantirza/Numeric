namespace Palantir.Numeric.UnitTests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public sealed class MoneyTests
	{
        private Currency zar = new Currency("ZAR", "R", 0.01);
        private Currency usd = new Currency("USD", "$", 0.01);
        
		[Fact]
		public void MoneyWithDifferentCurrencies_ShouldNotBeCompatible()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, usd);

			money1.IsCompatibleWith(money2).Should().BeFalse();
		}

		[Fact]
		public void MoneyWithDifferentMinorUnits_ShouldNotBeCompatible()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, new Currency("ZAR", "R", 0.001));

			money1.IsCompatibleWith(money2).Should().BeFalse();
			
			money1 = new Money(10, zar);
			money2 = new Money(20, zar, 0.001);

			money1.IsCompatibleWith(money2).Should().BeFalse();
		}

		[Fact]
		public void MoneyWithSameMinorUnitAndCurrency_ShouldBeCompatible()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, zar);

			money1.IsCompatibleWith(money2).Should().BeTrue();
			
			money1 = new Money(10, zar, 0.001);
			money2 = new Money(20, zar, 0.001);

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
			result.Currency.MinorUnit.Should().Be(0.01M);
			result.Currency.Code.Should().Be("ZAR");
		}

		[Fact]
		public void AddMoneyToEmpty_ShouldNotChangeResult()
		{
			var money1 = new Money(10, zar);

			Money result = (money1 + Money.Empty);
			result.Amount.Should().Be(10);
			result.Currency.MinorUnit.Should().Be(0.01M);
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
		public void AddTwoIncompatibleMinorUnitMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, new Currency("ZAR", "R", 0.001));

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
			result.Currency.MinorUnit.Should().Be(0.01M);
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
		public void SubtractTwoIncompatibleMinorUnitMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, new Currency("ZAR", "R", 0.001));

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
			result.Currency.MinorUnit.Should().Be(0.01M);
			result.IsPure.Should().BeTrue();
			result.Currency.Code.Should().Be("ZAR");
		}

		[Fact]
		public void DivideTwoCompatibleMonies_ShouldHaveCorrectQuotient()
		{
			var money1 = new Money(49, zar);
			var money2 = new Money(19, zar);

			var result = (money1 / money2);
			result.Amount.Should().Be(2.5789473684210526315789473684M);
			result.IsPure.Should().BeFalse();
			result.Currency.MinorUnit.Should().Be(0.01M);
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
		public void DivideTwoIncompatibleMinorUnitMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, new Currency("ZAR", "R", 0.001));

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
			result.Currency.MinorUnit.Should().Be(0.01M);
			result.IsPure.Should().BeTrue();
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
		public void MultiplyTwoIncompatibleMinorUnitMonies_ShouldThrowException()
		{
			var money1 = new Money(10, zar);
			var money2 = new Money(20, new Currency("ZAR", "R", 0.001));

			Action action = () => { var result = money1 * money2; };
			action.ShouldThrow<IncompatibleUnitException>();
		}

		[Fact]
		public void RoundDown_WithMinorUnit_ShouldRoundToMinorUnit()
		{
			var value = 0.015M;
			
		}
	}
}