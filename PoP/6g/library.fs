module library
open Canvas
type pos = int * int
type value = Red | Green | Blue | Yellow | Black //piece values
type piece = value*pos
type state = piece list

//functions for the game 2048

let fromValue (v : value) : Canvas.color =
    match v with
    | Red -> fromRgb(255,0,0)
    | Green -> fromRgb(0,255,0)
    | Blue -> fromRgb(0,0,255)
    | Yellow -> fromRgb(255,255,0)
    | Black -> fromRgb(0,0,0)

let nextColor (c : value) : value =
    match c with
    | Red -> Green
    | Green -> Blue
    | Blue -> Yellow
    | Yellow -> Black
    | Black -> Black
//ignore unused values with "_"
let filter (k: int) (s : state) : state =
    s |> List.filter (fun (_, (_, column)) -> k = column) 

let transpose (s : state) : state =
    s |> List.map (fun (pieceValue: value, (row: int, column: int)) -> (pieceValue, (column, row)))


(* 

let flipUD (s : state) : state =

let shiftUp (s : state) : state = 
    //s |> List.map (fun (pieceValue: value, (row: int, column: int)) -> (pieceValue, (row - 1, column)))

let addRandom (c : value) (s : state) : state option = 

let empty (s : state) : pos list =
    let allPositions = [for i in 0..2 do for j in 0..2 do yield (i, j)]
    allPositions |> List.filter (fun pos -> not (List.contains pos occupiedPositions)) 
    let occupiedPositions = s |> List.map (fun (_, pos) -> pos) 
    
*)
