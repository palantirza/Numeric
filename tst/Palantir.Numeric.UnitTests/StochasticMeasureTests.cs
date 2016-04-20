namespace Palantir.Numeric.UnitTests
{
    using Xunit;
    using FluentAssertions;
    using Palantir.Numeric.Statistics;
    using System;

    public sealed class StochasticMeasureTests
    {
        private Unit kg = new Unit("kg"); 
        
        [Fact]
        public void StochasticMeasureAdd_ShouldSumMeansAndVarianceStdDev()
        {
            var s1 = new StochasticMeasure(2, 0.82M, kg);
            var s2 = new StochasticMeasure(3.8M, 2.5M, kg);
            
            var s3 = s1 + s2;
            
            s3.Mean.Should().Be(5.8M);
            Math.Round(s3.StandardDeviation, 3).Should().Be(2.631M);
        }
        
        [Fact]
        public void StochasticMeasureAddExample_ShouldSumMeansAndVarianceStdDev()
        {
            // From http://www.rit.edu/~w-uphysi/uncertainties/Uncertaintiespart2.html#addsub
            var w = new StochasticMeasure(4.52M, 0.02M, kg);
            var x = new StochasticMeasure(2, 0.2M, kg);
            var y = new StochasticMeasure(3, 0.6M, kg);
            
            var z = x + y - w;
            
            Math.Round(z.Mean, 1).Should().Be(0.5M);
            Math.Round(z.StandardDeviation, 1).Should().Be(0.6M);
        }
        
        [Fact]
        public void StochasticMeasureAddInt_ShouldSumMeans()
        {
            var s1 = new StochasticMeasure(2, 0.82M, kg);
            
            var s3 = s1 + new Measure(2, kg);
            
            s3.Mean.Should().Be(4);
            s3.StandardDeviation.Should().Be(0.82M);
        }
        
        [Fact]
        public void StochasticMeasureAddDouble_ShouldSumMeans()
        {
            var s1 = new StochasticMeasure(2, 0.82M, kg);
            
            var s3 = s1 + new Measure(2.1M, kg);
            
            s3.Mean.Should().Be(4.1M);
            s3.StandardDeviation.Should().Be(0.82M);
        }
        
        [Fact]
        public void StochasticMeasureSubtract_ShouldMinusMeansAndVarianceStdDev()
        {
            var s1 = new StochasticMeasure(2, 0.82M, kg);
            var s3 = new StochasticMeasure(5.8M, 2.63104541960035M, kg);
            
            var s2 = s3 - s1;
            
            s2.Mean.Should().Be(3.8M);
            Math.Round(s2.StandardDeviation, 1).Should().Be(2.5M);
        }
        
        [Fact]
        public void StochasticMeasureSubtractInt_ShouldMinusMean()
        {
            var s1 = new StochasticMeasure(2, 0.82M, kg);
            var s2 = s1 - new Measure(1, kg);
            
            s2.Mean.Should().Be(1);
            s2.StandardDeviation.Should().Be(0.82M);
        }
        
        [Fact]
        public void StochasticMeasureSubtractDouble_ShouldMinusMean()
        {
            var s1 = new StochasticMeasure(2, 0.82M, kg);
            var s2 = s1 - new Measure(1.1M, kg);
            
            Math.Round(s2.Mean, 1).Should().Be(0.9M);
            s2.StandardDeviation.Should().Be(0.82M);
        }
        
        [Fact]
        public void StochasticMeasureMultiply_ShouldMultiplyMeansAndAddStdDev()
        {
            // From http://www.rit.edu/~w-uphysi/uncertainties/Uncertaintiespart2.html#muldiv
            var w = new StochasticMeasure(4.52M, 0.02M, kg);
            var x = new StochasticMeasure(2.0M, 0.2M, kg);
            
            var z = w * x;
            
            z.Mean.Should().Be(9.04M);
            Math.Round(z.StandardDeviation, 3).Should().Be(0.944M);
        }
        
        [Fact]
        public void StochasticMeasureDivide_ShouldMultiplyMeansAndAddStdDev()
        {
            // From http://www.rit.edu/~w-uphysi/uncertainties/Uncertaintiespart2.html#muldiv
            var x = new StochasticMeasure(2, 0.2M, kg);
            var y = new StochasticMeasure(3, 0.6M, kg);
            
            var z = x / y;
            
            Math.Round(z.Mean, 3).Should().Be(0.667M);
            Math.Round(z.StandardDeviation, 1).Should().Be(0.2M);
        }
        
        [Fact]
        public void StochasticMeasureMultiplyInt_ShouldMultiplyMeansAndStdDev()
        {
            var s1 = new StochasticMeasure(2, 0.82M, kg);
            
            var s3 = s1 * new Measure(5, kg);
            
            s3.Mean.Should().Be(10);
            Math.Round(s3.StandardDeviation, 3).Should().Be(4.1M);
        }
        
        [Fact]
        public void StochasticMeasureMultiplyDouble_ShouldMultiplyMeansAndStdDev()
        {
            var s1 = new StochasticMeasure(2, 0.82M, kg);
            
            var s3 = s1 * new Measure(5.1M, kg);
            
            s3.Mean.Should().Be(10.2M);
            Math.Round(s3.StandardDeviation, 3).Should().Be(4.182M);
        }
        
        [Fact]
        public void StochasticMeasureDivideInt_ShouldDivideMeansAndStdDev()
        {
            var s1 = new StochasticMeasure(10, 4.1M, kg);
            
            var s3 = s1 / new Measure(5, kg);
            
            s3.Mean.Should().Be(2);
            Math.Round(s3.StandardDeviation, 3).Should().Be(0.82M);
        }
        
        [Fact]
        public void StochasticMeasureDivideDouble_ShouldDivideMeansAndStdDev()
        {
            var s1 = new StochasticMeasure(10.2M, 4.182M, kg);
            
            var s3 = s1 / new Measure(5.1M, kg);
            
            s3.Mean.Should().Be(2);
            Math.Round(s3.StandardDeviation, 2).Should().Be(0.82M);
        }
    }
}