namespace Palantir.Numeric.UnitTests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public sealed class FormulaParserTests
	{
        [Fact]
        public void SimpleFormula_IsValid_ShouldParse()
        {
            var expression = Formula.Parse("y = x * 3");
        }
    }
}