module Tests.Arithmetics

open Xunit
open Swensen.Unquote
open Hedgehog

open ParserLib.Arithmetics

[<Fact>]
let ``Zero is 0`` () = test <@ value Zero = 0 @>

[<Fact>]
let ``Successor`` () = test <@ Zero |> s |> s |> value = 2 @>

[<Fact>]
let ``Sum`` () =
    let a = Next(Zero)
    let b = Next(Next(Zero))
    test <@ sum a b |> value = 3 @>
