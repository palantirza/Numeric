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

CURRENCY 
	:	CURR_SYM ' '? DIGIT* '.' DIGIT+
	|	CURR_SYM ' '? DIGIT+
	;

/* From http://www.xe.com/symbols.php */
fragment CURR_SYM
    :   (CURR_ALL|CURR_AFN|CURR_USD|CURR_AWG|CURR_AZN|CURR_BYR|CURR_BZD
    |CURR_BOB|CURR_BAM|CURR_BWP|CURR_BGN|CURR_BRL|CURR_KHR|CURR_CRC
    |CURR_HRK|CURR_CUP|CURR_CZK|CURR_DKK|CURR_DOP|CURR_GBP|CURR_EUR|CURR_GHS
    |CURR_GTQ|CURR_HNL|CURR_HUF|CURR_IDR|CURR_IRR|CURR_ILS|CURR_JMD|CURR_JPY
    |CURR_LAK|CURR_MKD|CURR_MYR|CURR_MNT|CURR_MZN|CURR_NIO|CURR_NGN|CURR_PAB
    |CURR_PYG|CURR_PEN|CURR_PLN|CURR_RON|CURR_RUB|CURR_RSD|CURR_SOS|CURR_ZAR
    |CURR_CHF|CURR_TWD|CURR_THB|CURR_TTD|CURR_UAH|CURR_UYU|CURR_VEF|CURR_VND
    |CURR_ZWD|CURR_XBT);

fragment CURR_ALL: 'Lek';                   // Albania Lek
fragment CURR_AFN: '\u060B';                // Afghanistan Afghani
fragment CURR_USD: '$';                     // US Dollar, Argeninian Peso,
                                            // Australia Dollar, Bahamas Dollar,
                                            // Barbados Dollar, Bermuda Dollar,
                                            // Brunei Darussalam Dollar, Canada Dollar,
                                            // Cayman Islands Dollar, Chile Peso,
                                            // Colombia Peso, East Caribbean Dollar,
                                            // El Salvador Colon, Fiji Dollar,
                                            // Guyana Dollar, Hong Kong Dollar,
                                            // Liberia Dollar, Mexico Peso,
                                            // Namibia Dollar, New Zealand Dollar,
                                            // Singapore Dollar, Solomon Islands Dollar,
                                            // Suriname Dollar, Tuvalu Dollar
fragment CURR_AWG: '\u0192';                // Aruba Guilder, Netherlands Antilles Guilder
fragment CURR_AZN: '\u043c\u0430\u043d';    // Azerbaijan New Manat
fragment CURR_BYR: 'p.';                    // Belorus Ruble
fragment CURR_BZD: 'BZ$';                   // Belize Dollar
fragment CURR_BOB: '$b';                    // Bolivia Bolíviano
fragment CURR_BAM: 'KM';                    // Bosnia and Herzegovina Convertible Marka
fragment CURR_BWP: 'P';                     // Botswana Pula
fragment CURR_BGN: '\u043b\u0432';          // Bulgaria Lev, Kazakhstan Tenge,
                                            // Kyrgyzstan Som, Uzbekistan Som
fragment CURR_BRL: 'R$';                    // Brazil Real
fragment CURR_KHR: '\u17db';                // Cambodia Riel
fragment CURR_JPY: '¥';                     // Japan Yen, China Yuan Renminbi
fragment CURR_CRC: '\u20a1';                // Costa Rica Colon
fragment CURR_HRK: 'kn';                    // Croatia Kuna
fragment CURR_CUP: '\u20b1';                // Cuba Peso, Philippines Peso
fragment CURR_CZK: 'K\u010d';               // Czech Republic Koruna
fragment CURR_DKK: 'kr';                    // Denmark Krone, Iceland Krona,
                                            // Norway Krone, Sweden Krona
fragment CURR_DOP: 'RD$';                   // Dominican Republic Peso
fragment CURR_GBP: '£';                     // United Kingdom Pound, Egypt Pound,
                                            // Falkland Islands (Malvinas) Pound,
                                            // Gibraltar Pound, Guernsey Pound,
                                            // Isle of Man Pound, Jersey Pound,
                                            // Lebanon Pound, Saint Helena Pound,
                                            // Syria Pound
fragment CURR_EUR: '€';                     // Euro Member Countries
fragment CURR_GHS: '\u00a2';                // Ghana Cedi
fragment CURR_GTQ: 'Q';                     // Guatemala Quetzal
fragment CURR_HNL: 'L';                     // Honduras Lempira
fragment CURR_HUF: 'Ft';                    // Hungary Forint
fragment CURR_IDR: 'Rp';                    // Indonesia Rupiah
fragment CURR_IRR: '\ufdfc';                // Iran Rial, Oman Rial, Qatar Riyal,
                                            // Saudi Arabia Riyal, Yemen Rial
fragment CURR_ILS: '\u20aa';                // Israel Shekel
fragment CURR_JMD: 'J$';                    // Jamaica Dollar
fragment CURR_KPW: '\u20a9';                // Korea (South) Won, Korea (North) Won
fragment CURR_LAK: '\u20ad';                // Laos Kip
fragment CURR_MKD: '\u0434\u0435\u043d';    // Macedonia Denar
fragment CURR_MYR: 'RM';                    // Malaysia Ringgit
fragment CURR_MUR: '\u20a8';                // Mauritius Rupee, Nepal Rupee,
                                            // Pakistan Rupee, Seychelles Rupee,
                                            // Sri Lanka Rupee
fragment CURR_MNT: '\u20ae';                // Mongolia Tughrik
fragment CURR_MZN: 'MT';                    // Mozambique Metical
fragment CURR_NIO: 'C$';                    // Nicaragua Cordoba
fragment CURR_NGN: '\u20a6';                // Nigeria Naira
fragment CURR_PAB: 'B\/\.';                 // Panama Balboa
fragment CURR_PYG: 'Gs';                    // Paraguay Guarani
fragment CURR_PEN: 'S/.';                   // Peru Sol
fragment CURR_PLN: 'z\u0142';               // Poland Zloty
fragment CURR_RON: 'lei';                   // Romania New Leu
fragment CURR_RUB: '\u0440\u0443\u0431';    // Russia Ruble
fragment CURR_RSD: '\u0414\u0438\u043d\.';  // Serbia Dinar
fragment CURR_SOS: 'S';                     // Somalia Shilling
fragment CURR_ZAR: 'R';                     // South Africa Rand
fragment CURR_CHF: 'CHF';                   // Switzerland Franc
fragment CURR_TWD: 'NT$';                   // Taiwan New Dollar
fragment CURR_THB: '\u0e3f';                // Thailand Baht
fragment CURR_TTD: 'TT$';                   // Trinidad and Tobago Dollar
fragment CURR_UAH: '\u20b4';                // Ukraine Hryvnia
fragment CURR_UYU: '$U';                    // Uruguay Peso
fragment CURR_VEF: 'Bs';                    // Venezuela Bolivar
fragment CURR_VND: '\u20ab';                // Viet Nam Dong
fragment CURR_ZWD: 'Z$';                    // Zimbabwe Dollar

fragment CURR_XBT: '\u20bf';                // Bitcoin

fragment DIGIT: '1'..'9' '0'..'9'*;
fragment OCTAL_DIGIT: '0' '0'..'7'+;
fragment HEX_DIGIT: '0x' ('0'..'9' | 'a'..'f' | 'A'..'F')+;

EXP	:	('E'|'e') ('+'|'-')? DIGIT+ 
	;
	
WHITESPACE : ( '\t' | ' ' | '\r' | '\n'| '\u000C' )+    { $channel = Hidden; } ;