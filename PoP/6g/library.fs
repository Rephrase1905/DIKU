module library
type pos = int * int
type value = Red | Green | Blue | Yellow | Black //piece values
type piece = value*pos
type state = piece list

//functions for the game 2048

let fromValue (v : value) : Canvas.color =
    match v with
    | Red -> { r = 255uy; g = 0uy; b = 0uy; a = 255uy }
    | Green -> { r = 0uy; g = 255uy; b = 0uy; a = 255uy }
    | Blue -> { r = 0uy; g = 0uy; b = 255uy; a = 255uy }
    | Yellow -> { r = 255uy; g = 255uy; b = 0uy; a = 255uy }
    | Black -> { r = 0uy; g = 0uy; b = 0uy; a = 255uy }

let nextColor (c : value) : value =
    match c with
    | Red -> Green
    | Green -> Blue
    | Blue -> Yellow
    | Yellow -> Black
    | Black -> Black

//return the list of pieces on a column k on board
let filter (k: int) (s : state) : state =
    List.filter (fun (v: value, (x: int, y: int)) -> x = k) s
// tilt all pieces on the board s to the left ( towards zero on
// the first coordinate ), e.g. ,
// > shiftUp [( Blue , (1 , 0)); (Red , (2 , 0)); (Black , (1 ,1))];;
// val it: state = [( Blue , (0 , 0)); (Red , (1 , 0)); (Black , (0 , 1))]
let shiftUp (s : state) : state = 

let flipUD (s : state) : state =

let transpose (s : state) : state =

let empty (s : state) : pos list =

let addRandom (c : value) (s : state) : state option =
