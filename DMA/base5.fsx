//base 5 expansion
let rec base5 n =
    if n < 5 then
        [n]
    else
        (base5 (n / 5)) @ [n % 5]
printfn "%A" (base5 158)