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
        
        #region Simple Tests // A lot of simple and basic logic tests, many duplications
        [Fact]
        public void ReadSimpleEquationMUL_ShouldOutputCorrectTokens() 
        {
            Read("5 * 3");

            ExpectToken(formulaLexer.NUMBER, "5");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.MULT);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.NUMBER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumEquationMUL_ShouldOutputCorrectTokens() 
        {
            Read("56 * 376");

            ExpectToken(formulaLexer.NUMBER, "56");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.MULT);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.NUMBER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumCompressedEquationMUL_ShouldOutputCorrectTokens() 
        {
            Read("56*376");

            ExpectToken(formulaLexer.NUMBER, "56");
            ExpectToken(formulaLexer.MULT);
            ExpectToken(formulaLexer.NUMBER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleCompressedEquationMUL_ShouldOutputCorrectTokens() 
        {
            Read("5*3");

            ExpectToken(formulaLexer.NUMBER, "5");
            ExpectToken(formulaLexer.MULT);
            ExpectToken(formulaLexer.NUMBER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleEquationDIV_ShouldOutputCorrectTokens() 
        {
            Read("5 / 3");

            ExpectToken(formulaLexer.NUMBER, "5");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.DIV);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.NUMBER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumEquationDIV_ShouldOutputCorrectTokens() 
        {
            Read("56 / 376");

            ExpectToken(formulaLexer.NUMBER, "56");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.DIV);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.NUMBER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumCompressedEquationDIV_ShouldOutputCorrectTokens() 
        {
            Read("56/376");

            ExpectToken(formulaLexer.NUMBER, "56");
            ExpectToken(formulaLexer.DIV);
            ExpectToken(formulaLexer.NUMBER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleCompressedEquationDIV_ShouldOutputCorrectTokens() 
        {
            Read("5/3");

            ExpectToken(formulaLexer.NUMBER, "5");
            ExpectToken(formulaLexer.DIV);
            ExpectToken(formulaLexer.NUMBER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleEquationPLUS_ShouldOutputCorrectTokens() 
        {
            Read("5 + 3");

            ExpectToken(formulaLexer.NUMBER, "5");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.PLUS);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.NUMBER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumEquationPLUS_ShouldOutputCorrectTokens() 
        {
            Read("56 + 376");

            ExpectToken(formulaLexer.NUMBER, "56");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.PLUS);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.NUMBER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumCompressedEquationPLUS_ShouldOutputCorrectTokens() 
        {
            Read("56+376");

            ExpectToken(formulaLexer.NUMBER, "56");
            ExpectToken(formulaLexer.PLUS);
            ExpectToken(formulaLexer.NUMBER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleCompressedEquationPLUS_ShouldOutputCorrectTokens() 
        {
            Read("5+3");

            ExpectToken(formulaLexer.NUMBER, "5");
            ExpectToken(formulaLexer.PLUS);
            ExpectToken(formulaLexer.NUMBER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleEquationMINUS_ShouldOutputCorrectTokens() 
        {
            Read("5 - 3");

            ExpectToken(formulaLexer.NUMBER, "5");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.MINUS);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.NUMBER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumEquationMINUS_ShouldOutputCorrectTokens() 
        {
            Read("56 - 376");

            ExpectToken(formulaLexer.NUMBER, "56");
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.MINUS);
            ExpectToken(formulaLexer.WHITESPACE);
            ExpectToken(formulaLexer.NUMBER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleBigNumCompressedEquationMINUS_ShouldOutputCorrectTokens() 
        {
            Read("56-376");

            ExpectToken(formulaLexer.NUMBER, "56");
            ExpectToken(formulaLexer.MINUS);
            ExpectToken(formulaLexer.NUMBER, "376");
            ExpectToken(formulaLexer.EOF);
        }
        
        [Fact]
        public void ReadSimpleCompressedEquationMINUS_ShouldOutputCorrectTokens() 
        {
            Read("5-3");

            ExpectToken(formulaLexer.NUMBER, "5");
            ExpectToken(formulaLexer.MINUS);
            ExpectToken(formulaLexer.NUMBER, "3");
            ExpectToken(formulaLexer.EOF);
        }
        #endregion1
        
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