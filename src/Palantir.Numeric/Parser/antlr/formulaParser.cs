//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from formula.g4 by ANTLR 4.5.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.3")]
[System.CLSCompliant(false)]
public partial class formulaParser : Parser {
	public const int
		LPAREN=1, RPAREN=2, PLUS=3, MINUS=4, TIMES=5, DIV=6, GT=7, LT=8, EQ=9, 
		POINT=10, E=11, POW=12, LETTER=13, DIGIT=14, WS=15;
	public const int
		RULE_equation = 0, RULE_expression = 1, RULE_multiplyingExpression = 2, 
		RULE_powExpression = 3, RULE_atom = 4, RULE_scientific = 5, RULE_relop = 6, 
		RULE_number = 7, RULE_variable = 8;
	public static readonly string[] ruleNames = {
		"equation", "expression", "multiplyingExpression", "powExpression", "atom", 
		"scientific", "relop", "number", "variable"
	};

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'+'", "'-'", "'*'", "'/'", "'>'", "'<'", "'='", "'.'", 
		null, "'^'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "LPAREN", "RPAREN", "PLUS", "MINUS", "TIMES", "DIV", "GT", "LT", 
		"EQ", "POINT", "E", "POW", "LETTER", "DIGIT", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "formula.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public formulaParser(ITokenStream input)
		: base(input)
	{
		Interpreter = new ParserATNSimulator(this,_ATN);
	}
	public partial class EquationContext : ParserRuleContext {
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public RelopContext relop() {
			return GetRuleContext<RelopContext>(0);
		}
		public EquationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_equation; } }
		public override void EnterRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.EnterEquation(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.ExitEquation(this);
		}
	}

	[RuleVersion(0)]
	public EquationContext equation() {
		EquationContext _localctx = new EquationContext(Context, State);
		EnterRule(_localctx, 0, RULE_equation);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 18; expression();
			State = 19; relop();
			State = 20; expression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		public MultiplyingExpressionContext[] multiplyingExpression() {
			return GetRuleContexts<MultiplyingExpressionContext>();
		}
		public MultiplyingExpressionContext multiplyingExpression(int i) {
			return GetRuleContext<MultiplyingExpressionContext>(i);
		}
		public ITerminalNode[] PLUS() { return GetTokens(formulaParser.PLUS); }
		public ITerminalNode PLUS(int i) {
			return GetToken(formulaParser.PLUS, i);
		}
		public ITerminalNode[] MINUS() { return GetTokens(formulaParser.MINUS); }
		public ITerminalNode MINUS(int i) {
			return GetToken(formulaParser.MINUS, i);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
		public override void EnterRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.EnterExpression(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.ExitExpression(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		ExpressionContext _localctx = new ExpressionContext(Context, State);
		EnterRule(_localctx, 2, RULE_expression);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 22; multiplyingExpression();
			State = 27;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,0,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.InvalidAltNumber ) {
				if ( _alt==1 ) {
					{
					{
					State = 23;
					_la = TokenStream.La(1);
					if ( !(_la==PLUS || _la==MINUS) ) {
					ErrorHandler.RecoverInline(this);
					}
					else {
					    Consume();
					}
					State = 24; multiplyingExpression();
					}
					} 
				}
				State = 29;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,0,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MultiplyingExpressionContext : ParserRuleContext {
		public PowExpressionContext[] powExpression() {
			return GetRuleContexts<PowExpressionContext>();
		}
		public PowExpressionContext powExpression(int i) {
			return GetRuleContext<PowExpressionContext>(i);
		}
		public ITerminalNode[] TIMES() { return GetTokens(formulaParser.TIMES); }
		public ITerminalNode TIMES(int i) {
			return GetToken(formulaParser.TIMES, i);
		}
		public ITerminalNode[] DIV() { return GetTokens(formulaParser.DIV); }
		public ITerminalNode DIV(int i) {
			return GetToken(formulaParser.DIV, i);
		}
		public MultiplyingExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_multiplyingExpression; } }
		public override void EnterRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.EnterMultiplyingExpression(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.ExitMultiplyingExpression(this);
		}
	}

	[RuleVersion(0)]
	public MultiplyingExpressionContext multiplyingExpression() {
		MultiplyingExpressionContext _localctx = new MultiplyingExpressionContext(Context, State);
		EnterRule(_localctx, 4, RULE_multiplyingExpression);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 30; powExpression();
			State = 35;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.InvalidAltNumber ) {
				if ( _alt==1 ) {
					{
					{
					State = 31;
					_la = TokenStream.La(1);
					if ( !(_la==TIMES || _la==DIV) ) {
					ErrorHandler.RecoverInline(this);
					}
					else {
					    Consume();
					}
					State = 32; powExpression();
					}
					} 
				}
				State = 37;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PowExpressionContext : ParserRuleContext {
		public AtomContext atom() {
			return GetRuleContext<AtomContext>(0);
		}
		public ITerminalNode POW() { return GetToken(formulaParser.POW, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public PowExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_powExpression; } }
		public override void EnterRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.EnterPowExpression(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.ExitPowExpression(this);
		}
	}

	[RuleVersion(0)]
	public PowExpressionContext powExpression() {
		PowExpressionContext _localctx = new PowExpressionContext(Context, State);
		EnterRule(_localctx, 6, RULE_powExpression);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 38; atom();
			State = 41;
			_la = TokenStream.La(1);
			if (_la==POW) {
				{
				State = 39; Match(POW);
				State = 40; expression();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AtomContext : ParserRuleContext {
		public ScientificContext scientific() {
			return GetRuleContext<ScientificContext>(0);
		}
		public VariableContext variable() {
			return GetRuleContext<VariableContext>(0);
		}
		public ITerminalNode LPAREN() { return GetToken(formulaParser.LPAREN, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode RPAREN() { return GetToken(formulaParser.RPAREN, 0); }
		public AtomContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_atom; } }
		public override void EnterRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.EnterAtom(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.ExitAtom(this);
		}
	}

	[RuleVersion(0)]
	public AtomContext atom() {
		AtomContext _localctx = new AtomContext(Context, State);
		EnterRule(_localctx, 8, RULE_atom);
		try {
			State = 49;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 43; scientific();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 44; variable();
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 45; Match(LPAREN);
				State = 46; expression();
				State = 47; Match(RPAREN);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ScientificContext : ParserRuleContext {
		public NumberContext[] number() {
			return GetRuleContexts<NumberContext>();
		}
		public NumberContext number(int i) {
			return GetRuleContext<NumberContext>(i);
		}
		public ITerminalNode E() { return GetToken(formulaParser.E, 0); }
		public ScientificContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_scientific; } }
		public override void EnterRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.EnterScientific(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.ExitScientific(this);
		}
	}

	[RuleVersion(0)]
	public ScientificContext scientific() {
		ScientificContext _localctx = new ScientificContext(Context, State);
		EnterRule(_localctx, 10, RULE_scientific);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 51; number();
			State = 54;
			_la = TokenStream.La(1);
			if (_la==E) {
				{
				State = 52; Match(E);
				State = 53; number();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RelopContext : ParserRuleContext {
		public ITerminalNode EQ() { return GetToken(formulaParser.EQ, 0); }
		public ITerminalNode GT() { return GetToken(formulaParser.GT, 0); }
		public ITerminalNode LT() { return GetToken(formulaParser.LT, 0); }
		public RelopContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_relop; } }
		public override void EnterRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.EnterRelop(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.ExitRelop(this);
		}
	}

	[RuleVersion(0)]
	public RelopContext relop() {
		RelopContext _localctx = new RelopContext(Context, State);
		EnterRule(_localctx, 12, RULE_relop);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 56;
			_la = TokenStream.La(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << GT) | (1L << LT) | (1L << EQ))) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class NumberContext : ParserRuleContext {
		public ITerminalNode MINUS() { return GetToken(formulaParser.MINUS, 0); }
		public ITerminalNode[] DIGIT() { return GetTokens(formulaParser.DIGIT); }
		public ITerminalNode DIGIT(int i) {
			return GetToken(formulaParser.DIGIT, i);
		}
		public ITerminalNode POINT() { return GetToken(formulaParser.POINT, 0); }
		public NumberContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_number; } }
		public override void EnterRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.EnterNumber(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.ExitNumber(this);
		}
	}

	[RuleVersion(0)]
	public NumberContext number() {
		NumberContext _localctx = new NumberContext(Context, State);
		EnterRule(_localctx, 14, RULE_number);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 59;
			_la = TokenStream.La(1);
			if (_la==MINUS) {
				{
				State = 58; Match(MINUS);
				}
			}

			State = 62;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			do {
				{
				{
				State = 61; Match(DIGIT);
				}
				}
				State = 64;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			} while ( _la==DIGIT );
			State = 72;
			_la = TokenStream.La(1);
			if (_la==POINT) {
				{
				State = 66; Match(POINT);
				State = 68;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
				do {
					{
					{
					State = 67; Match(DIGIT);
					}
					}
					State = 70;
					ErrorHandler.Sync(this);
					_la = TokenStream.La(1);
				} while ( _la==DIGIT );
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VariableContext : ParserRuleContext {
		public ITerminalNode[] LETTER() { return GetTokens(formulaParser.LETTER); }
		public ITerminalNode LETTER(int i) {
			return GetToken(formulaParser.LETTER, i);
		}
		public ITerminalNode MINUS() { return GetToken(formulaParser.MINUS, 0); }
		public ITerminalNode[] DIGIT() { return GetTokens(formulaParser.DIGIT); }
		public ITerminalNode DIGIT(int i) {
			return GetToken(formulaParser.DIGIT, i);
		}
		public VariableContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_variable; } }
		public override void EnterRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.EnterVariable(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IformulaListener typedListener = listener as IformulaListener;
			if (typedListener != null) typedListener.ExitVariable(this);
		}
	}

	[RuleVersion(0)]
	public VariableContext variable() {
		VariableContext _localctx = new VariableContext(Context, State);
		EnterRule(_localctx, 16, RULE_variable);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 75;
			_la = TokenStream.La(1);
			if (_la==MINUS) {
				{
				State = 74; Match(MINUS);
				}
			}

			State = 77; Match(LETTER);
			State = 81;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while (_la==LETTER || _la==DIGIT) {
				{
				{
				State = 78;
				_la = TokenStream.La(1);
				if ( !(_la==LETTER || _la==DIGIT) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
				    Consume();
				}
				}
				}
				State = 83;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static string _serializedATN = _serializeATN();
	private static string _serializeATN()
	{
	    StringBuilder sb = new StringBuilder();
	    sb.Append("\x3\x430\xD6D1\x8206\xAD2D\x4417\xAEF1\x8D80\xAADD\x3\x11");
		sb.Append("W\x4\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4");
		sb.Append("\a\t\a\x4\b\t\b\x4\t\t\t\x4\n\t\n\x3\x2\x3\x2\x3\x2\x3\x2\x3");
		sb.Append("\x3\x3\x3\x3\x3\a\x3\x1C\n\x3\f\x3\xE\x3\x1F\v\x3\x3\x4\x3\x4");
		sb.Append("\x3\x4\a\x4$\n\x4\f\x4\xE\x4\'\v\x4\x3\x5\x3\x5\x3\x5\x5\x5");
		sb.Append(",\n\x5\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x5\x6\x34\n\x6\x3");
		sb.Append("\a\x3\a\x3\a\x5\a\x39\n\a\x3\b\x3\b\x3\t\x5\t>\n\t\x3\t\x6\t");
		sb.Append("\x41\n\t\r\t\xE\t\x42\x3\t\x3\t\x6\tG\n\t\r\t\xE\tH\x5\tK\n");
		sb.Append("\t\x3\n\x5\nN\n\n\x3\n\x3\n\a\nR\n\n\f\n\xE\nU\v\n\x3\n\x2\x2");
		sb.Append("\v\x2\x4\x6\b\n\f\xE\x10\x12\x2\x6\x3\x2\x5\x6\x3\x2\a\b\x3");
		sb.Append("\x2\t\v\x3\x2\xF\x10Y\x2\x14\x3\x2\x2\x2\x4\x18\x3\x2\x2\x2");
		sb.Append("\x6 \x3\x2\x2\x2\b(\x3\x2\x2\x2\n\x33\x3\x2\x2\x2\f\x35\x3\x2");
		sb.Append("\x2\x2\xE:\x3\x2\x2\x2\x10=\x3\x2\x2\x2\x12M\x3\x2\x2\x2\x14");
		sb.Append("\x15\x5\x4\x3\x2\x15\x16\x5\xE\b\x2\x16\x17\x5\x4\x3\x2\x17");
		sb.Append("\x3\x3\x2\x2\x2\x18\x1D\x5\x6\x4\x2\x19\x1A\t\x2\x2\x2\x1A\x1C");
		sb.Append("\x5\x6\x4\x2\x1B\x19\x3\x2\x2\x2\x1C\x1F\x3\x2\x2\x2\x1D\x1B");
		sb.Append("\x3\x2\x2\x2\x1D\x1E\x3\x2\x2\x2\x1E\x5\x3\x2\x2\x2\x1F\x1D");
		sb.Append("\x3\x2\x2\x2 %\x5\b\x5\x2!\"\t\x3\x2\x2\"$\x5\b\x5\x2#!\x3\x2");
		sb.Append("\x2\x2$\'\x3\x2\x2\x2%#\x3\x2\x2\x2%&\x3\x2\x2\x2&\a\x3\x2\x2");
		sb.Append("\x2\'%\x3\x2\x2\x2(+\x5\n\x6\x2)*\a\xE\x2\x2*,\x5\x4\x3\x2+");
		sb.Append(")\x3\x2\x2\x2+,\x3\x2\x2\x2,\t\x3\x2\x2\x2-\x34\x5\f\a\x2.\x34");
		sb.Append("\x5\x12\n\x2/\x30\a\x3\x2\x2\x30\x31\x5\x4\x3\x2\x31\x32\a\x4");
		sb.Append("\x2\x2\x32\x34\x3\x2\x2\x2\x33-\x3\x2\x2\x2\x33.\x3\x2\x2\x2");
		sb.Append("\x33/\x3\x2\x2\x2\x34\v\x3\x2\x2\x2\x35\x38\x5\x10\t\x2\x36");
		sb.Append("\x37\a\r\x2\x2\x37\x39\x5\x10\t\x2\x38\x36\x3\x2\x2\x2\x38\x39");
		sb.Append("\x3\x2\x2\x2\x39\r\x3\x2\x2\x2:;\t\x4\x2\x2;\xF\x3\x2\x2\x2");
		sb.Append("<>\a\x6\x2\x2=<\x3\x2\x2\x2=>\x3\x2\x2\x2>@\x3\x2\x2\x2?\x41");
		sb.Append("\a\x10\x2\x2@?\x3\x2\x2\x2\x41\x42\x3\x2\x2\x2\x42@\x3\x2\x2");
		sb.Append("\x2\x42\x43\x3\x2\x2\x2\x43J\x3\x2\x2\x2\x44\x46\a\f\x2\x2\x45");
		sb.Append("G\a\x10\x2\x2\x46\x45\x3\x2\x2\x2GH\x3\x2\x2\x2H\x46\x3\x2\x2");
		sb.Append("\x2HI\x3\x2\x2\x2IK\x3\x2\x2\x2J\x44\x3\x2\x2\x2JK\x3\x2\x2");
		sb.Append("\x2K\x11\x3\x2\x2\x2LN\a\x6\x2\x2ML\x3\x2\x2\x2MN\x3\x2\x2\x2");
		sb.Append("NO\x3\x2\x2\x2OS\a\xF\x2\x2PR\t\x5\x2\x2QP\x3\x2\x2\x2RU\x3");
		sb.Append("\x2\x2\x2SQ\x3\x2\x2\x2ST\x3\x2\x2\x2T\x13\x3\x2\x2\x2US\x3");
		sb.Append("\x2\x2\x2\r\x1D%+\x33\x38=\x42HJMS");
	    return sb.ToString();
	}

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}