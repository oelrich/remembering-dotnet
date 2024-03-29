module Tests.Arithmetics

open Xunit
open Swensen.Unquote
open Hedgehog

open ParserLib.Arithmetics

[<Fact>]
let ``Zero is Zero`` () = test <@ equal Zero Zero @>

[<Fact>]
let ``Zero is not Next(Zero)`` () =
    test <@ not (equal Zero (Next(Zero))) @>

[<Fact>]
let ``Zero is 0`` () = test <@ value Zero = 0 @>

[<Fact>]
let ``Successor`` () = test <@ Zero |> s |> s |> value = 2 @>

[<Fact>]
let ``Sum`` () =
    let a = Next(Zero)
    let b = Next(Next(Zero))
    test <@ sum a b |> value = 3 @>

[<Fact>]
let ``Sum equal`` () =
    let a = Next(Zero)
    let b = Next(Next(Zero))
    test <@ equal (sum a b) (Next(Next(Next(Zero)))) @>
