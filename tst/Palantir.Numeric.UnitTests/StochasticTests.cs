namespace Palantir.Numeric.UnitTests
{
    using Xunit;
    using FluentAssertions;
    using Palantir.Numeric.Statistics;
    using System;

    public sealed class StochasticTests
    {
        [Fact]
        public void StochasticAdd_ShouldSumMeansAndVarianceStdDev()
        {
            var s1 = new Stochastic(2, 0.82);
            var s2 = new Stochastic(3.8, 2.5);
            
            var s3 = s1 + s2;
            
            s3.Mean.Should().Be(5.8);
            Math.Round(s3.StandardDeviation, 3).Should().Be(2.631);
        }
        
        [Fact]
        public void StochasticAddExample_ShouldSumMeansAndVarianceStdDev()
        {
            // From http://www.rit.edu/~w-uphysi/uncertainties/Uncertaintiespart2.html#addsub
            var w = new Stochastic(4.52, 0.02);
            var x = new Stochastic(2, 0.2);
            var y = new Stochastic(3, 0.6);
            
            var z = x + y - w;
            
            Math.Round(z.Mean, 1).Should().Be(0.5);
            Math.Round(z.StandardDeviation, 1).Should().Be(0.6);
        }
        
        [Fact]
        public void StochasticAddInt_ShouldSumMeans()
        {
            var s1 = new Stochastic(2, 0.82);
            
            var s3 = s1 + 2;
            
            s3.Mean.Should().Be(4);
            s3.StandardDeviation.Should().Be(0.82);
        }
        
        [Fact]
        public void StochasticAddDouble_ShouldSumMeans()
        {
            var s1 = new Stochastic(2, 0.82);
            
            var s3 = s1 + 2.1;
            
            s3.Mean.Should().Be(4.1);
            s3.StandardDeviation.Should().Be(0.82);
        }
        
        [Fact]
        public void StochasticSubtract_ShouldMinusMeansAndVarianceStdDev()
        {
            var s1 = new Stochastic(2, 0.82);
            var s3 = new Stochastic(5.8, 2.63104541960035);
            
            var s2 = s3 - s1;
            
            s2.Mean.Should().Be(3.8);
            Math.Round(s2.StandardDeviation, 1).Should().Be(2.5);
        }
        
        [Fact]
        public void StochasticSubtractInt_ShouldMinusMean()
        {
            var s1 = new Stochastic(2, 0.82);
            var s2 = s1 - 1;
            
            s2.Mean.Should().Be(1);
            s2.StandardDeviation.Should().Be(0.82);
        }
        
        [Fact]
        public void StochasticSubtractDouble_ShouldMinusMean()
        {
            var s1 = new Stochastic(2, 0.82);
            var s2 = s1 - 1.1;
            
            Math.Round(s2.Mean, 1).Should().Be(0.9);
            s2.StandardDeviation.Should().Be(0.82);
        }
        
        [Fact]
        public void StochasticMultiply_ShouldMultiplyMeansAndAddStdDev()
        {
            // From http://www.rit.edu/~w-uphysi/uncertainties/Uncertaintiespart2.html#muldiv
            var w = new Stochastic(4.52, 0.02);
            var x = new Stochastic(2.0, 0.2);
            
            var z = w * x;
            
            z.Mean.Should().Be(9.04);
            Math.Round(z.StandardDeviation, 3).Should().Be(0.944);
        }
        
        [Fact]
        public void StochasticMultiplyEx_ShouldMultiplyMeansAndAddStdDev()
        {
            // From http://www.rit.edu/~w-uphysi/uncertainties/Uncertaintiespart2.html#muldiv
            var x = new Stochastic(3.0, 0.2);
            
            var c = 2 * Math.PI * x;
            
            Math.Round(c.Mean, 1).Should().Be(18.8);
            Math.Round(c.StandardDeviation, 1).Should().Be(1.3);
        }
        
        [Fact]
        public void StochasticDivide_ShouldMultiplyMeansAndAddStdDev()
        {
            // From http://www.rit.edu/~w-uphysi/uncertainties/Uncertaintiespart2.html#muldiv
            var x = new Stochastic(2, 0.2);
            var y = new Stochastic(3, 0.6);
            
            var z = x / y;
            
            Math.Round(z.Mean, 3).Should().Be(0.667);
            Math.Round(z.StandardDeviation, 1).Should().Be(0.2);
        }
        
        [Fact]
        public void StochasticMultiplyInt_ShouldMultiplyMeansAndStdDev()
        {
            var s1 = new Stochastic(2, 0.82);
            
            var s3 = s1 * 5;
            
            s3.Mean.Should().Be(10);
            Math.Round(s3.StandardDeviation, 3).Should().Be(4.1);
        }
        
        [Fact]
        public void StochasticMultiplyDouble_ShouldMultiplyMeansAndStdDev()
        {
            var s1 = new Stochastic(2, 0.82);
            
            var s3 = s1 * 5.1;
            
            s3.Mean.Should().Be(10.2);
            Math.Round(s3.StandardDeviation, 3).Should().Be(4.182);
        }
        
        [Fact]
        public void StochasticDivideInt_ShouldDivideMeansAndStdDev()
        {
            var s1 = new Stochastic(10, 4.1);
            
            var s3 = s1 / 5;
            
            s3.Mean.Should().Be(2);
            Math.Round(s3.StandardDeviation, 3).Should().Be(0.82);
        }
        
        [Fact]
        public void StochasticDivideDouble_ShouldDivideMeansAndStdDev()
        {
            var s1 = new Stochastic(10.2, 4.182);
            
            var s3 = s1 / 5.1;
            
            s3.Mean.Should().Be(2);
            Math.Round(s3.StandardDeviation, 2).Should().Be(0.82);
        }
    }
}