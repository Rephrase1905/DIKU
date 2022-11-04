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

let shiftUp (s: state): state = 
    let row0Sorted: state = s |> List.filter(fun (_, (row: int, _)) -> row = 0) |> List.sortBy (fun (_, (_,coloumn: int)) -> coloumn)
    let row1Sorted: state = s |> List.filter(fun (_, (row: int, _)) -> row = 1) |> List.sortBy (fun (_, (_,coloumn: int)) -> coloumn)
    let row2Sorted: state = s |> List.filter(fun (_, (row: int, _)) -> row = 2) |> List.sortBy (fun (_, (_,coloumn: int)) -> coloumn)
    let shiftedLeft0: state = row0Sorted|>List.mapi (fun x (y,(row,coloumn)) -> ( y,(row, x)))
    let shiftedLeft1: state = row1Sorted|>List.mapi (fun x (y,(row,coloumn)) -> ( y,(row, x)))
    let shiftedLeft2: state = row2Sorted|>List.mapi (fun x (y,(row,coloumn)) -> ( y,(row, x)))
    let checkNeighbor (s: state): state =
        match s with
            [] -> []
            | (x,(y, z))::(xs,(y',z'))::(xs',(y'',z''))::[] ->
                if x = xs then
                    [(nextColor x, (y , z)); (xs', (y', z'))]
                elif xs = xs' then
                    [(x,(y, z)); (nextColor xs, (y',z'))]
                else
                    [(x,(y, z));(xs,(y',z'));(xs',(y'',z''))]
            | (x,(y,z))::(xs,(y',z'))::[] ->
                if x = xs then
                    [(nextColor x,(y,z))]
                else
                    [(x,(y,z)); (xs,(y',z'))]
            | x -> x
    (checkNeighbor shiftedLeft0)@(checkNeighbor shiftedLeft1)@(checkNeighbor shiftedLeft2)

let flipUD (s: state): state =
    s |> List.map (fun (x,(i,j)) -> (x,(2-i,j)))

let transpose (s: state): state =
    s |> List.map (fun (x,(i: int,j: int)) -> (x,(j,i)))

let empty (s: state): pos list =
    let allPos: pos list = [(0,0);(0,1);(0,2);(1,0);(1,1);(1,2);(2,0);(2,1);(2,2)]
    let currentPos: pos list = s |> List.map (fun (x: value,(i: int,j: int)) -> (i,j))
    List.except currentPos allPos

let addRandom (c: value) (s: state): state option =
    let rnd =  System.Random ()
    let randomCoordinate = empty s
    let chosenPlace = rnd.Next(randomCoordinate.Length)
    let final = List.item chosenPlace randomCoordinate
    Some (s@[(c, final)])

let draw (w: int)  (h: int) (s: state): canvas =
    let C = create w h
    let xAxis = w/3
    let yAxis = h/3
    let boxZeroZero (v: Canvas.color) = do setFillBox C v (0, 0) (xAxis,yAxis)
    let boxZeroOne (v: Canvas.color) = do setFillBox C v (xAxis, xAxis) (2*xAxis,yAxis)
    let boxZeroTwo (v: Canvas.color) = do setFillBox C v (2*xAxis, 2*xAxis) (3*xAxis,yAxis)
    let boxOneZero (v: Canvas.color) = do setFillBox C v (0, yAxis) (xAxis,2*yAxis)
    let boxOneOne (v: Canvas.color) = do setFillBox C v (xAxis, yAxis) (2*xAxis,2*yAxis)
    let boxOneTwo (v: Canvas.color) = do setFillBox C v (2*xAxis,yAxis) (3*xAxis,2*yAxis)
    let boxTwoZero (v: Canvas.color) = do setFillBox C v (0, 2*yAxis) (xAxis,3*yAxis)
    let boxTwoOne (v: Canvas.color) = do setFillBox C v (xAxis,2*yAxis) (2*xAxis,3*yAxis)
    let boxTwoTwo (v: Canvas.color) = do setFillBox C v (2*xAxis,2*yAxis) (3*xAxis,3*yAxis)
    let checkingPiece (p: piece) =
        match p with
            (v: value,(0,0)) -> boxZeroZero (fromValue v)
            | (v: value,(0,1)) -> boxZeroOne (fromValue v)
            | (v: value,(0,2)) -> boxZeroTwo (fromValue v)
            | (v: value,(1,0)) -> boxOneZero (fromValue v)
            | (v: value,(1,1)) -> boxOneOne (fromValue v)
            | (v: value,(1,2)) -> boxOneTwo (fromValue v)
            | (v: value,(2,0)) -> boxTwoZero (fromValue v)
            | (v: value,(2,1)) -> boxTwoOne (fromValue v)
            | (v: value,(2,2)) -> boxTwoTwo (fromValue v)
    s |> List.iter checkingPiece
    C
