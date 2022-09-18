printf "Enter n: "
let n = int (System.Console.ReadLine ())
let mutable x = 0
for i in 1 .. n do
    x <- x + 1
    for j in 1 .. n do
        x <- x + 1
printfn "%A" x