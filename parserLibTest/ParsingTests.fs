module Tests.Parsing

open Xunit
open Swensen.Unquote
open Hedgehog

open ParserLib.Program
open ParserLib.Parsing

[<Fact>]
let ``Evaluation`` () =
    let program = Add((Number 1), (Number 2))
    test <@ evaluate program = 3 @>


[<Fact>]
let ``Parse 42`` () =
    let number = 42

    test
        <@ match parse (sprintf "%i" number) with
           | Ok program -> evaluate program = number
           | Error err -> err = "parsing failed" @>

[<Fact>]
let ``Parse 23`` () =
    let number = 23

    test
        <@ match parse (sprintf "%i" number) with
           | Ok program -> evaluate program = number
           | Error err -> err = "parsing failed" @>

let propNumber: Property<Unit> =
    property {
        let! number = Gen.int (Range.constantBounded ())
        return parse (sprintf "%i" number) = Result.Ok(Number number)
    }

[<Fact>]
let ``Parse Number`` () = Property.check propNumber

[<Fact>]
let ``Evaluate program 2+3`` () =
    test
        <@ match parse "2+3" with
           | Ok program -> evaluate program = 5
           | Error err -> err = "parsing failed" @>


[<Fact>]
let ``Evaluate program 1+2+3+4`` () =
    test
        <@ match parse "1+2+3+4" with
           | Ok program -> evaluate program = 10
           | Error err -> err = "parsing failed" @>
