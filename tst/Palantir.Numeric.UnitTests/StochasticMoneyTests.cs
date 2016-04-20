namespace Palantir.Numeric.UnitTests
{
    using Xunit;
    using FluentAssertions;
    using Palantir.Numeric.Statistics;
    using System;

    public sealed class StochasticMoneyTests
    {
        private Currency usd = new Currency("USD", "$", 0.01M); 
        
        [Fact]
        public void StochasticMoneyAdd_ShouldSumMeansAndVarianceStdDev()
        {
            var s1 = new StochasticMoney(2, 0.82, usd);
            var s2 = new StochasticMoney(3.8, 2.5, usd);
            
            var s3 = s1 + s2;
            
            s3.Mean.Should().Be(5.8M);
            Math.Round(s3.StandardDeviation, 3).Should().Be(2.631M);
        }
        
        [Fact]
        public void StochasticMoneyAddExample_ShouldSumMeansAndVarianceStdDev()
        {
            // From http://www.rit.edu/~w-uphysi/uncertainties/Uncertaintiespart2.html#addsub
            var w = new StochasticMoney(4.52, 0.02, usd);
            var x = new StochasticMoney(2, 0.2, usd);
            var y = new StochasticMoney(3, 0.6, usd);
            
            var z = x + y - w;
            
            Math.Round(z.Mean, 1).Should().Be(0.5M);
            Math.Round(z.StandardDeviation, 1).Should().Be(0.6M);
        }
        
        [Fact]
        public void StochasticMoneyAddInt_ShouldSumMeans()
        {
            var s1 = new StochasticMoney(2, 0.82, usd);
            
            var s3 = s1 + new Money(2, usd);
            
            s3.Mean.Should().Be(4);
            s3.StandardDeviation.Should().Be(0.82M);
        }
        
        [Fact]
        public void StochasticMoneyAddDouble_ShouldSumMeans()
        {
            var s1 = new StochasticMoney(2, 0.82, usd);
            
            var s3 = s1 + new Money(2.1M, usd);
            
            s3.Mean.Should().Be(4.1M);
            s3.StandardDeviation.Should().Be(0.82M);
        }
        
        [Fact]
        public void StochasticMoneySubtract_ShouldMinusMeansAndVarianceStdDev()
        {
            var s1 = new StochasticMoney(2, 0.82, usd);
            var s3 = new StochasticMoney(5.8, 2.63104541960035, usd);
            
            var s2 = s3 - s1;
            
            s2.Mean.Should().Be(3.8M);
            Math.Round(s2.StandardDeviation, 1).Should().Be(2.5M);
        }
        
        [Fact]
        public void StochasticMoneySubtractInt_ShouldMinusMean()
        {
            var s1 = new StochasticMoney(2, 0.82, usd);
            var s2 = s1 - new Money(1, usd);
            
            s2.Mean.Should().Be(1);
            s2.StandardDeviation.Should().Be(0.82M);
        }
        
        [Fact]
        public void StochasticMoneySubtractDouble_ShouldMinusMean()
        {
            var s1 = new StochasticMoney(2, 0.82, usd);
            var s2 = s1 - new Money(1.1M, usd);
            
            Math.Round(s2.Mean, 1).Should().Be(0.9M);
            s2.StandardDeviation.Should().Be(0.82M);
        }
        
        [Fact]
        public void StochasticMoneyMultiply_ShouldMultiplyMeansAndAddStdDev()
        {
            // From http://www.rit.edu/~w-uphysi/uncertainties/Uncertaintiespart2.html#muldiv
            var w = new StochasticMoney(4.52, 0.02, usd);
            var x = new StochasticMoney(2.0, 0.2, usd);
            
            var z = w * x;
            
            z.Mean.Should().Be(9.04M);
            Math.Round(z.StandardDeviation, 3).Should().Be(0.944M);
        }
        
        [Fact]
        public void StochasticMoneyDivide_ShouldMultiplyMeansAndAddStdDev()
        {
            // From http://www.rit.edu/~w-uphysi/uncertainties/Uncertaintiespart2.html#muldiv
            var x = new StochasticMoney(2, 0.2, usd);
            var y = new StochasticMoney(3, 0.6, usd);
            
            var z = x / y;
            
            Math.Round(z.Mean, 3).Should().Be(0.667M);
            Math.Round(z.StandardDeviation, 1).Should().Be(0.2M);
        }
        
        [Fact]
        public void StochasticMoneyMultiplyInt_ShouldMultiplyMeansAndStdDev()
        {
            var s1 = new StochasticMoney(2, 0.82, usd);
            
            var s3 = s1 * new Money(5, usd);
            
            s3.Mean.Should().Be(10);
            Math.Round(s3.StandardDeviation, 3).Should().Be(4.1M);
        }
        
        [Fact]
        public void StochasticMoneyMultiplyDouble_ShouldMultiplyMeansAndStdDev()
        {
            var s1 = new StochasticMoney(2, 0.82, usd);
            
            var s3 = s1 * new Money(5.1M, usd);
            
            s3.Mean.Should().Be(10.2M);
            Math.Round(s3.StandardDeviation, 3).Should().Be(4.182M);
        }
        
        [Fact]
        public void StochasticMoneyDivideInt_ShouldDivideMeansAndStdDev()
        {
            var s1 = new StochasticMoney(10, 4.1, usd);
            
            var s3 = s1 / new Money(5, usd);
            
            s3.Mean.Should().Be(2);
            Math.Round(s3.StandardDeviation, 3).Should().Be(0.82M);
        }
        
        [Fact]
        public void StochasticMoneyDivideDouble_ShouldDivideMeansAndStdDev()
        {
            var s1 = new StochasticMoney(10.2, 4.182, usd);
            
            var s3 = s1 / new Money(5.1M, usd);
            
            s3.Mean.Should().Be(2);
            Math.Round(s3.StandardDeviation, 2).Should().Be(0.82M);
        }
    }
}