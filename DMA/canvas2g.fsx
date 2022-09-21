#r "nuget:DIKU.Canvas, 1.0"
type vec = float * float
let Vektor1 : vec = (5.0,5.0)
let Vektor2 : vec = (3.0,3.0)

let addition (vec1 : vec) (vec2 : vec) =
  let (a: float,b: float) = vec1
  let (c: float,d: float) = vec2
  (a+c, b+d)
let v3: float * float = addition Vektor1 Vektor2


let toInt (v: float * float) =
    let (x: float, y: float) = v 
    (int x, int y) 
printfn "%A" (toInt (Vektor1))


open Canvas
let w: int = 500
let h: int = 500
let C = create w h
let setVektor (C : canvas) (color) (nyVektor : vec) (punkt1 : vec) =
  let color: color = blue //definerer farven
  let punkt1Int = toInt punkt1 //Vi ændrer vores Punkt 1 til int
  let nyVektorInt = toInt nyVektor //Vi ændrer vores vektor 1 til int

  let (x1: int, y1: int) = nyVektorInt  //vi deler vektoren op i kordinater 
  let (x2: int, y2: int) = punkt1Int    // vi deler punkt1 op i kordinater

  let punkt2: int * int = (x1 + x2, y1 + y2)  //Vi finder vores punkt2 ved at plusse midterpunktet (punkt1) med vores vektor

  let (x3: int, y3: int) = punkt2 
  do setLine C color (x2,y2)(x3,y3) //Vi laver linjen ud fra vores 2 punkter i canvas.
  C

let LinjeiCanvas = setVektor C blue (100.0,100.0) (250.0,250.0) 

show C "Vektor"