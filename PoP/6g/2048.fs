open library
open Canvas

(* Test the library functions *)
let test1 = fromValue Red = fromRgb(255,0,0)
let test2 = fromValue Green = fromRgb(0,255,0)
let test3 = fromValue Blue = fromRgb(0,0,255)
let test4 = fromValue Yellow = fromRgb(255,255,0)
let test5 = fromValue Black = fromRgb(0,0,0)
let test6 = nextColor Red = Green
let test7 = nextColor Green = Blue
let test8 = nextColor Blue = Yellow
let test9 = nextColor Yellow = Black
let test10 = nextColor Black = Black


let test11 = filter 0 [( Blue , (1 , 0)); (Red , (0 , 0))] = [(Blue, (1,0)); (Red , (0 , 0))]
let test12 = filter 1 [( Blue , (1 , 0)); (Red , (0 , 0))] = []

let test13 = transpose [( Blue , (1 , 0)); (Red , (0 , 1))] = [( Blue , (0 , 1)); (Red , (1 , 0))]
let test14 = transpose [( Blue , (1 , 0)); (Red , (0 , 1)); (Yellow, (2, 3))] = [( Blue , (0 , 1)); (Red , (1 , 0)); (Yellow, (3, 2))]

printfn "Test 1: %A" test1
printfn "Test 2: %A" test2
printfn "Test 3: %A" test3
printfn "Test 4: %A" test4
printfn "Test 5: %A" test5
printfn "Test 6: %A" test6
printfn "Test 7: %A" test7
printfn "Test 8: %A" test8
printfn "Test 9: %A" test9
printfn "Test 10: %A" test10
printfn "Test 11: %A" test11
printfn "Test 12: %A" test12
printfn "Test 13: %A" test13

printfn "All tests passed: %A" (
    test1 && 
    test2 && 
    test3 && 
    test4 && 
    test5 && 
    test6 && 
    test7 && 
    test8 && 
    test9 && 
    test10 && 
    test11 && 
    test12 && 
    test13 && 
    test14)
