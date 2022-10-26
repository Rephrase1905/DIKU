module library
type pos = int * int
type value = Red | Green | Blue | Yellow | Black //piece values
type piece = value*pos
type state = piece list
type color = {r:byte;g:byte;b:byte;a:byte}

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

//let filter (k: int) (s : state) : state =

let shiftUp (s : state) : state = 
    