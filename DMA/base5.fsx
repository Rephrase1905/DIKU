//base 5 expansion
printfn "Enter a number to be expanded in base 5"
let c : int = int (System.Console.ReadLine())
printfn "base 5 expansion of %A" c
let rec base5 n =
    if n < 5 then
        [n]
    else
        (base5 (n / 5)) @ [n % 5]
printfn "%A" (base5 c)

//runtime of base5 is O(log5(n))