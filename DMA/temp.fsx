#r "nuget:DIKU.Canvas, 1.0.1"
open Canvas
let w = 400;
let h = 400
let C = create w h

let draw (t) =
    let r = 100.0
    let center = 200.0
    let xt = center + r*cos(t)
    let yt = center + r*sin(t)
    let xxt = center + r*cos(t+0.1)
    let yyt = center + r*sin(t+0.1)
    do setLine C red (int(xt), int(yt)) (int(xxt),int(yyt))

let rec tælle(y) = 
        let mutable t = y
        while t<=6.3 do
            draw(t)
            t <- t + 0.1
        do show C "My First Canvas"
tælle(0.01)
