//Opgave a
//addvec :: Vector -> Vector -> Vector
let addvec v1 v2
    printfn "Enter the first vector: 
    let x1 : int = (System.Console.ReadLine()) |> int
    let x2 : int = (System.Console.ReadLine()) |> int
    printfn "Enter the second vector: "
    let y1 : int = (System.Console.ReadLine()) |> int
    let y2 : int = (System.Console.ReadLine()) |> int

    let v1 = (x1,x2)
    let v2 = (y1,y2)

    let addvecopgave v1 v2 = (x1+y1,x2+y2)
    printfn "addvec (1,2) (3,4) = %A" (addvec (v1) (v2))

//Opgave b
//multiplication of a vector and a constant
printfn "Enter the vector: "
