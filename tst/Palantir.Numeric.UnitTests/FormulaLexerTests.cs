namespace Palantir.Numeric.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using FluentAssertions;
    using Palantir.Numeric;
    using Parser;

    public class FormulaLexerTests
    {
        private formulaLexer lexer;
        
        #region Unit Lexer
        [Fact]
        public void ReadSimpleUnits_ShouldOutputCorrectTokens() 
        {
            Read("50kg");
            ExpectToken(formulaLexer.UNIT, "50kg");
            Read("50rad/s²");
            ExpectToken(formulaLexer.UNIT, "50rad/s²");
            Read("50e10kg");
            ExpectToken(formulaLexer.UNIT, "50e10kg");
            Read("50e10rad/s²");
            ExpectToken(formulaLexer.UNIT, "50e10rad/s²");
            Read("50.1kg");
            ExpectToken(formulaLexer.UNIT, "50.1kg");
            Read("50.1rad/s²");
            ExpectToken(formulaLexer.UNIT, "50.1rad/s²");

            // With spaces
            /* TODO: Get this working
            Read("50 kg");
            ExpectToken(formulaLexer.UNIT, "50 kg");
            Read("50 rad/s²");
            ExpectToken(formulaLexer.UNIT, "50 rad/s²");*/
            Read("50.1 kg");
            ExpectToken(formulaLexer.UNIT, "50.1 kg");
            Read("50.1 rad/s²");
            ExpectToken(formulaLexer.UNIT, "50.1 rad/s²");
        }
        #endregion
        
        #region Currency Lexer
        [Fact]
        public void ReadSimpleCurrencies_ShouldOutputCorrectTokens() 
        {
            Read("$50");
            ExpectToken(formulaLexer.CURRENCY, "$50");
            Read("Lek50");
            ExpectToken(formulaLexer.CURRENCY, "Lek50");
            Read("؋50");
            ExpectToken(formulaLexer.CURRENCY, "؋50");
            Read("$50.1");
            ExpectToken(formulaLexer.CURRENCY, "$50.1");
            Read("Lek50.1");
            ExpectToken(formulaLexer.CURRENCY, "Lek50.1");
            Read("؋50.1");
            ExpectToken(formulaLexer.CURRENCY, "؋50.1");

            // With spaces
            Read("$ 50");
            ExpectToken(formulaLexer.CURRENCY, "$ 50");
            Read("Lek 50");
            ExpectToken(formulaLexer.CURRENCY, "Lek 50");
            Read("؋ 50");
            ExpectToken(formulaLexer.CURRENCY, "؋ 50");
            Read("$ 50.1");
            ExpectToken(formulaLexer.CURRENCY, "$ 50.1");
            Read("Lek 50.1");
            ExpectToken(formulaLexer.CURRENCY, "Lek 50.1");
            Read("؋ 50.1");
            ExpectToken(formulaLexer.CURRENCY, "؋ 50.1");
        }
        #endregion
        
        #region Number Lexer
        [Fact]
        public void ReadSimpleIntegers_ShouldOutputCorrectTokens() 
        {
            Read("5");
            ExpectToken(formulaLexer.INTEGER, "5");

            Read("53");
            ExpectToken(formulaLexer.INTEGER, "53");

            Read("5362");
            ExpectToken(formulaLexer.INTEGER, "5362");

            Read("53628549");
            ExpectToken(formulaLexer.INTEGER, "53628549");
        }
        
        [Fact]
        public void ReadSimpleFloats_ShouldOutputCorrectTokens() 
        {
            Read("5.3");
            ExpectToken(formulaLexer.FLOAT, "5.3");

            Read("53.3");
            ExpectToken(formulaLexer.FLOAT, "53.3");

            Read("5362.3");
            ExpectToken(formulaLexer.FLOAT, "5362.3");

            Read("53628549.3");
            ExpectToken(formulaLexer.FLOAT, "53628549.3");

            Read("5e3");
            ExpectToken(formulaLexer.FLOAT, "5e3");

            Read("53e3");
            ExpectToken(formulaLexer.FLOAT, "53e3");

            Read("5362e3");
            ExpectToken(formulaLexer.FLOAT, "5362e3");

            Read("53628549e3");
            ExpectToken(formulaLexer.FLOAT, "53628549e3");

            Read("5e+3");
            ExpectToken(formulaLexer.FLOAT, "5e+3");

            Read("53e+3");
            ExpectToken(formulaLexer.FLOAT, "53e+3");

            Read("5362e+3");
            ExpectToken(formulaLexer.FLOAT, "5362e+3");

            Read("53628549e+3");
            ExpectToken(formulaLexer.FLOAT, "53628549e+3");

            Read("5e-3");
            ExpectToken(formulaLexer.FLOAT, "5e-3");

            Read("53e-3");
            ExpectToken(formulaLexer.FLOAT, "53e-3");

            Read("5362e-3");
            ExpectToken(formulaLexer.FLOAT, "5362e-3");

            Read("53628549e-3");
            ExpectToken(formulaLexer.FLOAT, "53628549e-3");

            Read("5.3e3");
            ExpectToken(formulaLexer.FLOAT, "5.3e3");

            Read("53.3e3");
            ExpectToken(formulaLexer.FLOAT, "53.3e3");

            Read("5362.3e3");
            ExpectToken(formulaLexer.FLOAT, "5362.3e3");

            Read("53628549.3e3");
            ExpectToken(formulaLexer.FLOAT, "53628549.3e3");
        }
        
        #endregion
        
        #region Simple Calcs // A lot of simple and basic logic tests, many duplications
        [Fact]
        public void ReadSimpleEquationMUL_ShouldOutputCorrectTokens() 
        {
            Read("5 * 3");

            ExpectToken(formulaLexer.INTEGER, "5");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.MULT);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.INTEGER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumEquationMUL_ShouldOutputCorrectTokens() 
        {
            Read("56 * 376");

            ExpectToken(formulaLexer.INTEGER, "56");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.MULT);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.INTEGER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumCompressedEquationMUL_ShouldOutputCorrectTokens() 
        {
            Read("56*376");

            ExpectToken(formulaLexer.INTEGER, "56");
            ExpectToken(formulaLexer.MULT);
            ExpectToken(formulaLexer.INTEGER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleCompressedEquationMUL_ShouldOutputCorrectTokens() 
        {
            Read("5*3");

            ExpectToken(formulaLexer.INTEGER, "5");
            ExpectToken(formulaLexer.MULT);
            ExpectToken(formulaLexer.INTEGER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleEquationDIV_ShouldOutputCorrectTokens() 
        {
            Read("5 / 3");

            ExpectToken(formulaLexer.INTEGER, "5");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.DIV);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.INTEGER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumEquationDIV_ShouldOutputCorrectTokens() 
        {
            Read("56 / 376");

            ExpectToken(formulaLexer.INTEGER, "56");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.DIV);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.INTEGER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumCompressedEquationDIV_ShouldOutputCorrectTokens() 
        {
            Read("56/376");

            ExpectToken(formulaLexer.INTEGER, "56");
            ExpectToken(formulaLexer.DIV);
            ExpectToken(formulaLexer.INTEGER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleCompressedEquationDIV_ShouldOutputCorrectTokens() 
        {
            Read("5/3");

            ExpectToken(formulaLexer.INTEGER, "5");
            ExpectToken(formulaLexer.DIV);
            ExpectToken(formulaLexer.INTEGER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleEquationPLUS_ShouldOutputCorrectTokens() 
        {
            Read("5 + 3");

            ExpectToken(formulaLexer.INTEGER, "5");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.PLUS);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.INTEGER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumEquationPLUS_ShouldOutputCorrectTokens() 
        {
            Read("56 + 376");

            ExpectToken(formulaLexer.INTEGER, "56");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.PLUS);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.INTEGER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumCompressedEquationPLUS_ShouldOutputCorrectTokens() 
        {
            Read("56+376");

            ExpectToken(formulaLexer.INTEGER, "56");
            ExpectToken(formulaLexer.PLUS);
            ExpectToken(formulaLexer.INTEGER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleCompressedEquationPLUS_ShouldOutputCorrectTokens() 
        {
            Read("5+3");

            ExpectToken(formulaLexer.INTEGER, "5");
            ExpectToken(formulaLexer.PLUS);
            ExpectToken(formulaLexer.INTEGER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleEquationMINUS_ShouldOutputCorrectTokens() 
        {
            Read("5 - 3");

            ExpectToken(formulaLexer.INTEGER, "5");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.MINUS);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.INTEGER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumEquationMINUS_ShouldOutputCorrectTokens() 
        {
            Read("56 - 376");

            ExpectToken(formulaLexer.INTEGER, "56");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.MINUS);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.INTEGER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumCompressedEquationMINUS_ShouldOutputCorrectTokens() 
        {
            Read("56-376");

            ExpectToken(formulaLexer.INTEGER, "56");
            ExpectToken(formulaLexer.MINUS);
            ExpectToken(formulaLexer.INTEGER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleCompressedEquationMINUS_ShouldOutputCorrectTokens() 
        {
            Read("5-3");

            ExpectToken(formulaLexer.INTEGER, "5");
            ExpectToken(formulaLexer.MINUS);
            ExpectToken(formulaLexer.INTEGER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        #endregion
        
        private void Read(string text) 
        {
            var input = new Antlr.Runtime.ANTLRStringStream(text);
            lexer = new formulaLexer(input);
        }
        
        private void ExpectToken(int type, string text = null)
        {
            var token = lexer.NextToken();
            token.Type.Should().Be(type);
            if (text != null)
            {
                token.Text.Should().Be(text);
            }
        }
    }
}