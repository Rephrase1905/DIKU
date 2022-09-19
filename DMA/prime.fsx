let isprime n =
    let rec loop i =
        if i * i > n then true
        elif n % i = 0 then false
        else loop (i + 1)
    loop 2
printfn "%A" (isprime 16)