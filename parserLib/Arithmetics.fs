namespace ParserLib

module Arithmetics =
    type Number =
        | Zero
        | Next of Number

    let rec value number =
        match number with
        | Zero -> 0
        | Next (prev_number) -> 1 + value prev_number

    let s number = Next(number)

    let rec equal a b =
        match a, b with
        | Zero, Zero -> true
        | Next (p_a), Next (p_b) -> equal p_a p_b
        | _ -> false

    let rec sum a b =
        match a with
        | Zero -> b
        | Next (p_a) -> s b |> sum p_a
