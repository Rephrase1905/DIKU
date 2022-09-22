#r "nuget:DIKU.Canvas, 1.0"
//En funktion der tager 2 argumenter, en vektor A og en vektor B.
///<summary> Defining the type "vector" and the vectors we were to use in the following programs</summary>
///<param> Vektor1, Vektor2 </param>
type vec = float * float
let Vektor1 : vec = (5.0,5.0)
let Vektor2 : vec = (3.0,3.0)


//opgave 2g0
//del opgave a)
//Addition af 2 vektorer
/// <example>
///    The following code:
///    <code>
///    let (a,b) = vec1
///    let (c,d) = vec2
///    (a+c, b+d)
///    </code>
/// </example>
/// <param name= "a">The value x1</param name>
/// <param name= "b">The value y1</param name>
/// <param name= "c">The value x2</param name>
/// <param name= "b">The value y2</param name>
/// <returns> The value a,b and c,d summed as floats</returns>
let addition (vec1 : vec) (vec2 : vec) = //
  let (a: float,b: float) = vec1 //we define the values of the vectors as floats and name them a and b respectively 
  let (c: float: float,d) = vec2 //we define the values of the vectors as floats and name them c and d respectively
  (a+c, b+d) //we return the sum of the vectors as floats
addition Vektor1 Vektor2 //we call the function with the vectors we defined earlier
//opgave 2g0
//del opgave b)
//gange vektor med konstant

/// calculate a vector multiplied by a constant
/// <summary> calculate a*v=(a*x1,a*y1) </summary>
/// <remarks> The constant is defined where the function is called <remarks>
/// <param> Vektor1, x, y and c<param>
/// <example>
///    The following code:
///    <code>
///      let (x, y) = vec  
///      let nyVektor = (x * c, y * c)
///    </code>
/// <param name= "x">The value x1 from Vektor1</param name>
/// <param name= "y">The value y1 from Vektor1</param name>
/// <param name= "c">The constant to be multiplied with</param name>
/// <returns> The value a*x1 and a*y1 as floats</returns>
let multiplicationFloat (vec : vec) (c : float) =
  let (x, y) = vec  
  let nyVektor = (x * c, y * c)       
  nyVektor
let vektorGangetMedFloat = multiplicationFloat Vektor1 4.0
printfn "multiply with constant = %A" vektorGangetMedFloat
//opgave 2g0
//del opgave c)
// rotation af en  vektor


let rotationVektor (vec : vec) (angle1 : float) =
  let (x, y) = vec
  let angle = angle1 * System.Math.PI / 180.0
  let x1 : float = x*cos(angle)-y*sin(angle)
  let y1 : float = x*sin(angle)+y*cos(angle)
  let drejetVektor : vec = (x1 ,y1)
  drejetVektor

//Opgave 2g1
//del opgave a)
//Konverterer en vector fra float *float -> int * int

/// <summary> converts a vector of float * float to a vector of int * int </summary>
/// <example> 
///    the following code
///      <code>
///        let vector : vec = 5.0 5.0
///        let vectorInt = toInt vector
///        printfn "vector of float: %A, vector of Int: %A" vector vectorInt
///      </code>
///      prints <c> vector of float: 5.0 5.0, vector of Int: 5 5 </c>
/// </example>
/// <param name = "v"> vector of float * float </param>
/// <returns> vector of int * int </returns>

let toInt (v: float * float) =
    let (x: float, y: float) = v 
    (int x, int y) 

//opgave 2g1
//del opgave b)
//Function der tegner vektor fra linje p til p+v i canvas

/// <summary> shows a canvas with a line from p to p+v </summary>
/// <param name = "C"> Canvas </param>
/// <param name = "nyVektor"> vector p </param>
/// <param name = "punkt1"> vector v </param>
/// <returns> a canvas with a line p+v </returns>



open Canvas
let w: int = 500
let h: int = 500
let C = create w h
let setVektor (C : canvas) (color) (nyVektor : vec) (punkt1 : vec) =
  let color: color = color 
  let punkt1Int = toInt punkt1 
  let nyVektorInt = toInt nyVektor 
  let (x1: int, y1: int) = nyVektorInt   
  let (x2: int, y2: int) = punkt1Int    
  let punkt2: int * int = (x1 + x2, y1 + y2)  
  let (x3: int, y3: int) = punkt2 
  do setLine C color (x2,y2)(x3,y3) 
  C

let LinjeiCanvas = setVektor C blue (250,0.0) (250.0,250.0)
show C "Vektor"

//opgave 2g1 
//del opgave c)
//Function der tager en vektor og tegner 36 vektorer roteret med 10 grader

/// <summary>Creates a Canvas with a given height & width , and returns a Canvas with 36 spokes </summary>
/// <remarks> it takes a given vector, then increasing the angle with 10 degrees and creating a circle consisting of 36 vectors. The 36 vectors are then drawn using the setVektor function  </remarks>
/// <param name = "vec"> a given vector consisting of float * float </param>
/// <param name = "C"> is the chosen canvas we want to show our vectors on </param>
/// <param name = "color"> The color of our vectors </param>
/// <returns> The canvas with 36 spokes </returns>

let drawVinkelV2 (vec : vec) (C : canvas) (color)=
  for i in -5.0..10.0..355.0 do
    setVektor C (color) (rotationVektor (vec) (i)) (250.0,250.0) |> ignore
    ()
let testing = drawVinkelV2 (200.0,200.0) (C) (black)
show C "Vektor"