grammar formula;

options
{
    output=AST;
    ASTLabelType=CommonTree;
    language=CSharp3;
}


tokens {
    PLUS    = '+' ;
    MINUS   = '-' ;
    MULT    = '*' ;
    DIV = '/' ;
}
@lexer::namespace {Palantir.Numeric.Parser}

@parser::namespace {Palantir.Numeric.Parser}

@header {
using System;
}

@members {
}

@init {
}

/*------------------------------------------------------------------
 * PARSER RULES
 *------------------------------------------------------------------*/
 
expr    : term ( ( PLUS | MINUS )  term )* ;

term    : factor ( ( MULT | DIV ) factor )* ;
 
factor  : INTEGER ;


/*------------------------------------------------------------------
 * LEXER RULES
 *------------------------------------------------------------------*/
 
INTEGER  : (DIGIT)+ ;

FLOAT 
	:	DIGIT* '.' DIGIT+ EXP?
	|	DIGIT+ EXP
	;

fragment DIGIT: '1'..'9' '0'..'9'*;
fragment OCTAL_DIGIT: '0' '0'..'7'+;
fragment HEX_DIGIT: '0x' ('0'..'9' | 'a'..'f' | 'A'..'F')+;

EXP	:	('E'|'e') ('+'|'-')? DIGIT+ 
	;
	
WHITESPACE : ( '\t' | ' ' | '\r' | '\n'| '\u000C' )+    { $channel = Hidden; } ;