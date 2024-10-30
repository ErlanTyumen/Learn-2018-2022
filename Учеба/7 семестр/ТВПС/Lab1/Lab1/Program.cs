/*Identifier*/using/*Spaces*/ /*Identifier*/System/*Punctuator*/;/*Spaces*/
/*Identifier*/using/*Spaces*/ /*Identifier*/System/*Punctuator*/./*Identifier*/Collections/*Punctuator*/./*Identifier*/Generic/*Punctuator*/;/*Spaces*/
/*Identifier*/using/*Spaces*/ /*Identifier*/System/*Punctuator*/./*Identifier*/Linq/*Punctuator*/;/*Spaces*/
/*Identifier*/using/*Spaces*/ /*Identifier*/System/*Punctuator*/./*Identifier*/Text/*Punctuator*/;/*Spaces*/
/*Identifier*/using/*Spaces*/ /*Identifier*/System/*Punctuator*/./*Identifier*/Threading/*Punctuator*/./*Identifier*/Tasks/*Punctuator*/;/*Spaces*/
/*Identifier*/using/*Spaces*/ /*Identifier*/System/*Punctuator*/./*Identifier*/Text/*Punctuator*/./*Identifier*/RegularExpressions/*Punctuator*/;/*Spaces*/
/*Identifier*/using/*Spaces*/ /*Identifier*/System/*Punctuator*/./*Identifier*/IO/*Punctuator*/;/*Spaces*/

/*Identifier*/namespace/*Spaces*/ /*Identifier*/Lab1/*Spaces*/
/*Punctuator*/{/*Spaces*/
    /*Identifier*/class/*Spaces*/ /*Identifier*/Program/*Spaces*/
    /*Punctuator*/{/*Spaces*/
        Match match;ada';
        /*Identifier*/static/*Spaces*/ /*Identifier*/string/*Spaces*/ /*Identifier*/EscapeCsvValue/*Punctuator*/(/*Identifier*/string/*Spaces*/ /*Identifier*/s/*Punctuator*/)/*Spaces*/ /*Punctuator*/=>/*Spaces*/ /*StringLiteral*/@""""/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*Identifier*/s/*Punctuator*/./*Identifier*/Replace/*Punctuator*/(/*StringLiteral*/@""""/*Punctuator*/,/*Spaces*/ /*StringLiteral*/@""""""/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@""""/*Punctuator*/;/*Spaces*/
        /*Identifier*/static/*Spaces*/ /*Identifier*/void/*Spaces*/ /*Identifier*/Main/*Punctuator*/(/*Identifier*/string/*Punctuator*/[/*Punctuator*/]/*Spaces*/ /*Identifier*/args/*Punctuator*/)/*Spaces*/
        /*Punctuator*/{/*Spaces*/
            /*Identifier*/int/*Spaces*/ /*Identifier*/k/*Spaces*/ /*Punctuator*/=/*Spaces*/ /*NumberLiteral*/0/*Punctuator*/;/*Spaces*/
            /*Identifier*/var/*Spaces*/ /*Identifier*/s/*Spaces*/ /*Punctuator*/=/*Spaces*/ /*Identifier*/File/*Punctuator*/./*Identifier*/ReadAllText/*Punctuator*/(/*StringLiteral*/@"..\..\Regex.txt"/*Punctuator*/)/*Punctuator*/;/*Spaces*/
            /*Identifier*/var/*Spaces*/ /*Identifier*/p/*Spaces*/ /*Punctuator*/=/*Spaces*/ /*Identifier*/File/*Punctuator*/./*Identifier*/ReadAllText/*Punctuator*/(/*StringLiteral*/@"..\..\Text.txt"/*Punctuator*/)/*Punctuator*/;/*Spaces*/
            /*Identifier*/List/*Punctuator*/</*Identifier*/string/*Punctuator*/>/*Spaces*/ /*Identifier*/output/*Spaces*/ /*Punctuator*/=/*Spaces*/ /*Identifier*/new/*Spaces*/ /*Identifier*/List/*Punctuator*/</*Identifier*/string/*Punctuator*/>/*Punctuator*/(/*Punctuator*/)/*Punctuator*/;/*Spaces*/
            /*Identifier*/output/*Punctuator*/./*Identifier*/Add/*Punctuator*/(/*Identifier*/EscapeCsvValue/*Punctuator*/(/*StringLiteral*/@"Номер"/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Spaces*/
                /*Punctuator*/+/*Spaces*/ /*Identifier*/EscapeCsvValue/*Punctuator*/(/*StringLiteral*/@"Группа 1"/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Spaces*/
                /*Punctuator*/+/*Spaces*/ /*Identifier*/EscapeCsvValue/*Punctuator*/(/*StringLiteral*/@"Группа 2"/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Spaces*/
                /*Punctuator*/+/*Spaces*/ /*Identifier*/EscapeCsvValue/*Punctuator*/(/*StringLiteral*/@"Группа 3"/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Spaces*/
                /*Punctuator*/+/*Spaces*/ /*Identifier*/EscapeCsvValue/*Punctuator*/(/*StringLiteral*/@"Группа 4"/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Spaces*/
                /*Punctuator*/+/*Spaces*/ /*Identifier*/EscapeCsvValue/*Punctuator*/(/*StringLiteral*/@"Группа 5"/*Punctuator*/)/*Punctuator*/)/*Punctuator*/;/*Spaces*/
            /*Identifier*/var/*Spaces*/ /*Identifier*/rx/*Spaces*/ /*Punctuator*/=/*Spaces*/ /*Identifier*/new/*Spaces*/ /*Identifier*/Regex/*Punctuator*/(/*Identifier*/s/*Punctuator*/)/*Punctuator*/;/*Spaces*/
            /*Identifier*/foreach/*Spaces*/ /*Punctuator*/(/*Identifier*/Match/*Spaces*/ /*Identifier*/match/*Spaces*/ /*Identifier*/in/*Spaces*/ /*Identifier*/rx/*Punctuator*/./*Identifier*/Matches/*Punctuator*/(/*Identifier*/p/*Punctuator*/)/*Punctuator*/)/*Spaces*/
            /*Punctuator*/{/*Spaces*/
                /*Identifier*/k/*Punctuator*/++/*Punctuator*/;/*Spaces*/
                /*Identifier*/output/*Punctuator*/./*Identifier*/Add/*Punctuator*/(/*Identifier*/EscapeCsvValue/*Punctuator*/(/*StringLiteral*/@"строка "/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*Identifier*/k/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Spaces*/ /*Punctuator*/+/*Spaces*/
                     /*Identifier*/EscapeCsvValue/*Punctuator*/(/*Identifier*/match/*Punctuator*/./*Identifier*/Groups/*Punctuator*/[/*NumberLiteral*/1/*Punctuator*/]/*Punctuator*/./*Identifier*/Value/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Spaces*/ /*Punctuator*/+/*Spaces*/
                     /*Identifier*/EscapeCsvValue/*Punctuator*/(/*Identifier*/match/*Punctuator*/./*Identifier*/Groups/*Punctuator*/[/*NumberLiteral*/2/*Punctuator*/]/*Punctuator*/./*Identifier*/Value/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Spaces*/ /*Punctuator*/+/*Spaces*/
                     /*Identifier*/EscapeCsvValue/*Punctuator*/(/*Identifier*/match/*Punctuator*/./*Identifier*/Groups/*Punctuator*/[/*NumberLiteral*/3/*Punctuator*/]/*Punctuator*/./*Identifier*/Value/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Spaces*/ /*Punctuator*/+/*Spaces*/
                     /*Identifier*/EscapeCsvValue/*Punctuator*/(/*Identifier*/match/*Punctuator*/./*Identifier*/Groups/*Punctuator*/[/*NumberLiteral*/4/*Punctuator*/]/*Punctuator*/./*Identifier*/Value/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Spaces*/ /*Punctuator*/+/*Spaces*/
                     /*Identifier*/EscapeCsvValue/*Punctuator*/(/*Identifier*/match/*Punctuator*/./*Identifier*/Groups/*Punctuator*/[/*NumberLiteral*/5/*Punctuator*/]/*Punctuator*/./*Identifier*/Value/*Punctuator*/)/*Spaces*/ /*Punctuator*/+/*Spaces*/ /*StringLiteral*/@";"/*Punctuator*/)/*Punctuator*/;/*Spaces*/
            /*Punctuator*/}/*Spaces*/
            /*Identifier*/File/*Punctuator*/./*Identifier*/WriteAllLines/*Punctuator*/(/*StringLiteral*/@"..\..\Output.csv"/*Punctuator*/,/*Spaces*/ /*Identifier*/output/*Punctuator*/,/*Spaces*/ /*Identifier*/Encoding/*Punctuator*/./*Identifier*/Default/*Punctuator*/)/*Punctuator*/;/*Spaces*/
        /*Punctuator*/}/*Spaces*/
    /*Punctuator*/}/*Spaces*/
/*Punctuator*/}