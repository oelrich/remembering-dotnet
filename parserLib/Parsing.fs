namespace ParserLib

module Program =
    type Expression =
        | Number of int
        | Add of Expression * Expression

    let rec evaluate =
        function
        | Number (value) -> value
        | Add (lhs, rhs) -> evaluate lhs + evaluate rhs

module Parsing =
    open FParsec

    let expr, exprImpl = createParserForwardedToRef ()
    let exprElement = expr .>> eof
    let parseNumber = pint32 |>> Program.Number

    let lhExpression = choice [ parseNumber ]

    let parseAdd =
        lhExpression
        >>=? fun operandL ->
                 pchar '+'
                 >>=? fun _op ->
                          expr
                          >>=? fun operandR -> preturn (operandL, operandR) |>> Program.Add

    do
        exprImpl
        := choice [ attempt parseAdd; parseNumber ]

    let parse (program: string) =
        match run expr program with
        | Success (ast, _, _) -> Result.Ok ast
        | Failure (errMsg, _, _) -> Result.Error errMsg
