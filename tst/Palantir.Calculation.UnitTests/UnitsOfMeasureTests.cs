namespace Palantir.Calculation.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using FluentAssertions;
    using Palantir.Calculation;

    public class UnitsOfMeasureTests
    {
        [Fact]
        public void CreateSimpleUnit_ShouldSetProperties() 
        {
            var g = new Unit("g", "Gram");
            g.Abbreviation.Should().Be("g");
            g.Name.Should().Be("Gram");
        }
        
        [Fact]
        public void AddUnitConversion_ShouldEnableConversion() 
        {
            var kg = new Unit("kg", "Kilogram");
            var g = new Unit("g", "Gram");
            
            kg.AddConversion(g, x => x * 1000);
            kg.CanConvertTo(g).Should().BeTrue();
        }
        
        [Fact]
        public void CreateSimpleMeasure_ShouldSetProperties()
        {
            var kg = new Unit("kg");
            var weight = new Measure(110, kg);
            weight.Value.Should().Be(110);
            weight.Unit.Should().Be(kg);
        }
        
        [Fact]
        public void MeasureConvertUnit_WhenConvertible_ShouldProduceResult()
        {
            var kg = new Unit("kg");
            var g = new Unit("g");
            kg.AddConversion(g, x => x * 1000);
            
            var weight = new Measure(110, kg);
            var result = weight.ConvertTo(g);
            result.Value.Should().Be(110000);
            result.Unit.Should().Be(g);
        }
        
        [Fact]
        public void MeasureConvertUnit_WhenNotConvertible_ShouldError()
        {
            var kg = new Unit("kg");
            var g = new Unit("g");
            var weight = new Measure(110, kg);
            Action action = () => weight.ConvertTo(g);
            action.ShouldThrow<IncompatibleUnitException>();
        }
        
        [Fact]
        public void MeasureAddition_WithSameUnit_ShouldProduceResult()
        {
            var kg = new Unit("kg");
            var weight1 = new Measure(110, kg);
            var weight2 = new Measure(10, kg);
            var result = weight1 + weight2;
            result.Value.Should().Be(120);
            result.Unit.Should().Be(kg);
        }
        
        [Fact]
        public void MeasureAddition_WithOrthogonalUnit_ShouldError()
        {
            var kg = new Unit("kg");
            var kph = new Unit("kph");
            var weight = new Measure(110, kg);
            var speed = new Measure(10, kph);
            Action action = () => Add(weight, speed);
            action.ShouldThrow<IncompatibleUnitException>()
                .WithMessage("Cannot add 'kg' and 'kph' units");
        }
        
        [Fact]
        public void MeasureAddition_WithConvertibleUnit_ShouldProduceResult()
        {
            var kg = new Unit("kg");
            var g = new Unit("g");
            kg.AddConversion(g, x => x * 1000);
            var weight1 = new Measure(110, kg);
            var weight2 = new Measure(100, g);
            var result = weight1 + weight2;
            result.Value.Should().Be(110100);
            result.Unit.Should().Be(g);
        }
        
        private Measure Add(Measure lhs, Measure rhs)
        {
            return lhs + rhs;
        }
        
        private Measure Subtract(Measure lhs, Measure rhs)
        {
            return lhs - rhs;
        }
        
        private Measure Divide(Measure lhs, Measure rhs)
        {
            return lhs / rhs;
        }
        
        private Measure Multiply(Measure lhs, Measure rhs)
        {
            return lhs * rhs;
        }
        
        [Fact]
        public void MeasureSubtraction_WithSameUnit_ShouldProduceResult()
        {
            var kg = new Unit("kg");
            var weight1 = new Measure(110, kg);
            var weight2 = new Measure(10, kg);
            var result = weight1 - weight2;
            result.Value.Should().Be(100);
            result.Unit.Should().Be(kg);
        }
        
        [Fact]
        public void MeasureSubtraction_WithOrthogonalUnit_ShouldError()
        {
            var kg = new Unit("kg");
            var kph = new Unit("kph");
            var weight = new Measure(110, kg);
            var speed = new Measure(10, kph);
            Action action = () => Subtract(weight, speed);
            action.ShouldThrow<IncompatibleUnitException>()
                .WithMessage("Cannot subtract 'kg' and 'kph' units");
        }
        
        [Fact]
        public void MeasureDivision_WithSameUnit_ShouldProduceResult()
        {
            var kg = new Unit("kg");
            var weight1 = new Measure(110, kg);
            var weight2 = new Measure(10, kg);
            var result = weight1 / weight2;
            result.Value.Should().Be(11);
            result.Unit.Should().Be(kg);
        }
        
        [Fact]
        public void MeasureDivision_WithOrthogonalUnit_ShouldError()
        {
            var kg = new Unit("kg");
            var kph = new Unit("kph");
            var weight = new Measure(110, kg);
            var speed = new Measure(10, kph);
            Action action = () => Divide(weight, speed);
            action.ShouldThrow<IncompatibleUnitException>()
                .WithMessage("Cannot divide 'kg' and 'kph' units");
        }
        
        [Fact]
        public void MeasureMultiplication_WithSameUnit_ShouldProduceResult()
        {
            var kg = new Unit("kg");
            var weight1 = new Measure(110, kg);
            var weight2 = new Measure(10, kg);
            var result = weight1 * weight2;
            result.Value.Should().Be(1100);
            result.Unit.Should().Be(kg);        }
        
        [Fact]
        public void MeasureMultiplication_WithOrthogonalUnit_ShouldError()
        {
            var kg = new Unit("kg");
            var kph = new Unit("kph");
            var weight = new Measure(110, kg);
            var speed = new Measure(10, kph);
            Action action = () => Multiply(weight, speed);
            action.ShouldThrow<IncompatibleUnitException>()
                .WithMessage("Cannot multiply 'kg' and 'kph' units");
        }
        
        /*
        
        [Fact]
        public void MeasureSubtraction_WithConvertibleUnit_ShouldProduceResult()
        {
            throw new NotImplementedException();
        }
        
        [Fact]
        public void MeasureDivision_WithConvertibleUnit_ShouldProduceResult()
        {
            throw new NotImplementedException();
        }
        
        [Fact]
        public void MeasureMultiplication_WithConvertibleUnit_ShouldProduceResult()
        {
            throw new NotImplementedException();
        }*/
    }
}
