module library
type pos = int * int
type value = Red | Green | Blue | Yellow | Black //piece values
type piece = value*pos
type state = piece list

val fromValue : v : value -> Canvas.color
val nextColor : c : value -> value
val filter : k : int -> s : state -> state
val transpose : s : state -> state
(* val flipUD : s : state -> state
val shiftUp : s : state -> state
val empty : s : state -> pos list
val addRandom : c : value -> s : state -> state option *)
