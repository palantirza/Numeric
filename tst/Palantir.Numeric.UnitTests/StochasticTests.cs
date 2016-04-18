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
        public void StochasticSubtract_ShouldMinusMeansAndVarianceStdDev()
        {
            var s1 = new Stochastic(2, 0.82);
            var s3 = new Stochastic(5.8, 2.63104541960035);
            
            var s2 = s3 - s1;
            
            s2.Mean.Should().Be(3.8);
            s2.StandardDeviation.Should().Be(2.5);
        }
    }
}