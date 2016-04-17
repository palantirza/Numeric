		
namespace Palantir.Numeric.UnitTests
{
    using System;
    using FluentAssertions;
    using Xunit;

		// 0.01, up down and nearest
		// 0.05, up down and nearest
		// 0.10, up down and nearest
		// 0.50, up down and nearest
		// 1.00, up down and nearest
		// 10.00, up down and nearest
    public sealed class RoundingTests
	{
        private Currency usd = new Currency("USD", "$", 0.01M);
        
        [Fact]
        public void RoundUp_With1MinorUnit_ShouldRoundCorrectly()
        {
            Round.RoundUp(1.01M, 0.01M).Should().Be(1.01M);
            Round.RoundUp(1.06M, 0.01M).Should().Be(1.06M);
            Round.RoundUp(1.014M, 0.01M).Should().Be(1.02M);
            Round.RoundUp(1.015M, 0.01M).Should().Be(1.02M);
            Round.RoundUp(1.016M, 0.01M).Should().Be(1.02M);
        }
        
        [Fact]
        public void RoundUp_With5MinorUnit_ShouldRoundCorrectly()
        {
            Round.RoundUp(1.05M, 0.05M).Should().Be(1.05M);
            Round.RoundUp(1.01M, 0.05M).Should().Be(1.05M);
            Round.RoundUp(1.001M, 0.05M).Should().Be(1.05M);
            Round.RoundUp(1.051M, 0.05M).Should().Be(1.10M);
        }
        
        [Fact]
        public void RoundDown_With1MinorUnit_ShouldRoundCorrectly()
        {
            Round.RoundDown(1.01M, 0.01M).Should().Be(1.01M);
            Round.RoundDown(1.06M, 0.01M).Should().Be(1.06M);
            Round.RoundDown(1.014M, 0.01M).Should().Be(1.01M);
            Round.RoundDown(1.015M, 0.01M).Should().Be(1.01M);
            Round.RoundDown(1.016M, 0.01M).Should().Be(1.01M);
        }
        
        [Fact]
        public void RoundDown_With5MinorUnit_ShouldRoundCorrectly()
        {
            Round.RoundDown(1.05M, 0.05M).Should().Be(1.05M);
            Round.RoundDown(1.01M, 0.05M).Should().Be(1.00M);
            Round.RoundDown(1.001M, 0.05M).Should().Be(1.00M);
            Round.RoundDown(1.051M, 0.05M).Should().Be(1.05M);
        }

        [Fact]
        public void RoundHalfUp_With1MinorUnit_ShouldRoundCorrectly()
        {
            Round.RoundHalfUp(1.01M, 0.01M).Should().Be(1.01M);
            Round.RoundHalfUp(1.06M, 0.01M).Should().Be(1.06M);
            Round.RoundHalfUp(1.014M, 0.01M).Should().Be(1.01M);
            Round.RoundHalfUp(1.015M, 0.01M).Should().Be(1.02M);
            Round.RoundHalfUp(1.016M, 0.01M).Should().Be(1.02M);
        }
        
        [Fact]
        public void RoundHalfUp_With5MinorUnit_ShouldRoundCorrectly()
        {
            Round.RoundHalfUp(1.05M, 0.05M).Should().Be(1.05M);
            Round.RoundHalfUp(1.01M, 0.05M).Should().Be(1.00M);
            Round.RoundHalfUp(1.001M, 0.05M).Should().Be(1.00M);
            Round.RoundHalfUp(1.051M, 0.05M).Should().Be(1.05M);
            Round.RoundHalfUp(1.074M, 0.05M).Should().Be(1.05M);
            Round.RoundHalfUp(1.075M, 0.05M).Should().Be(1.10M);
        }
        
        [Fact]
        public void RoundHalfDown_With1MinorUnit_ShouldRoundCorrectly()
        {
            Round.RoundHalfDown(1.01M, 0.01M).Should().Be(1.01M);
            Round.RoundHalfDown(1.06M, 0.01M).Should().Be(1.06M);
            Round.RoundHalfDown(1.014M, 0.01M).Should().Be(1.01M);
            Round.RoundHalfDown(1.015M, 0.01M).Should().Be(1.01M);
            Round.RoundHalfDown(1.016M, 0.01M).Should().Be(1.02M);
        }
        
        [Fact]
        public void RoundHalfDown_With5MinorUnit_ShouldRoundCorrectly()
        {
            Round.RoundHalfDown(1.05M, 0.05M).Should().Be(1.05M);
            Round.RoundHalfDown(1.01M, 0.05M).Should().Be(1.00M);
            Round.RoundHalfDown(1.001M, 0.05M).Should().Be(1.00M);
            Round.RoundHalfDown(1.051M, 0.05M).Should().Be(1.05M);
            Round.RoundHalfDown(1.074M, 0.05M).Should().Be(1.05M);
            Round.RoundHalfDown(1.075M, 0.05M).Should().Be(1.05M);
            Round.RoundHalfDown(1.076M, 0.05M).Should().Be(1.10M);
        }
        
        [Fact]
        public void RoundHalfEven_With1MinorUnit_ShouldRoundCorrectly()
        {
            Round.RoundHalfEven(1.01M, 0.01M).Should().Be(1.01M);
            Round.RoundHalfEven(1.06M, 0.01M).Should().Be(1.06M);
            Round.RoundHalfEven(1.014M, 0.01M).Should().Be(1.01M);
            Round.RoundHalfEven(1.015M, 0.01M).Should().Be(1.02M);
            Round.RoundHalfEven(1.025M, 0.01M).Should().Be(1.02M);
            Round.RoundHalfEven(1.016M, 0.01M).Should().Be(1.02M);
        }
        
        [Fact]
        public void RoundHalfEven_With5MinorUnit_ShouldRoundCorrectly()
        {
            Round.RoundHalfEven(1.05M, 0.05M).Should().Be(1.05M);
            Round.RoundHalfEven(1.01M, 0.05M).Should().Be(1.00M);
            Round.RoundHalfEven(1.001M, 0.05M).Should().Be(1.00M);
            Round.RoundHalfEven(1.051M, 0.05M).Should().Be(1.05M);
            Round.RoundHalfEven(1.074M, 0.05M).Should().Be(1.05M);
            Round.RoundHalfEven(1.075M, 0.05M).Should().Be(1.10M);
            Round.RoundHalfEven(1.175M, 0.05M).Should().Be(1.20M);
            Round.RoundHalfEven(1.076M, 0.05M).Should().Be(1.10M);
        }
        
        [Fact]
        public void RoundQuotient_ShouldRoundCorrectly()
        {
            var quotient = new Money(2.05M, usd) / 2;
            Round.RoundUp(quotient).Amount.Should().Be(1.03M);
            Round.RoundDown(quotient).Amount.Should().Be(1.02M);
            Round.RoundHalfUp(quotient).Amount.Should().Be(1.03M);
            Round.RoundHalfDown(quotient).Amount.Should().Be(1.02M);
            Round.RoundHalfEven(quotient).Amount.Should().Be(1.02M);
        }
        
        [Fact]
        public void RoundMoney_ShouldRoundCorrectly()
        {
            var value = new Money(1.025M, usd, 0.001M);
            Round.RoundUp(value, 0.01M).Amount.Should().Be(1.03M);
            Round.RoundDown(value, 0.01M).Amount.Should().Be(1.02M);
            Round.RoundHalfUp(value, 0.01M).Amount.Should().Be(1.03M);
            Round.RoundHalfDown(value, 0.01M).Amount.Should().Be(1.02M);
            Round.RoundHalfEven(value, 0.01M).Amount.Should().Be(1.02M);
        }
        
     
    }
}