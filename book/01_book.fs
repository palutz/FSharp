
//
// function declaration
//

// inner function and variavble scope
let moduleValue = 1
let f fParam =
	let g gParam = fParam + gParam + moduleValue
		let a = g 1
		let b = g 2
		a + b;;

val moduleValue : int = 1
val f : fParam:int -> int 

f 13;;
val it : int = 31
------------
// multiple value
let fd x y = (x * x), (y * y);;

val fd : x:int -> y:int -> int * int

// and then call it, with double assignment...
let a, b = fd 2 3;;
val b : int = 9
val a : int = 4
--------------
//
// "if" is always returning a value
//
let tryif x =
	let result = 
		if x > 10 then
			x / 10
		else
			x * 10
	result;;

// without an explicit else branch the if is returning unit on the else, while the then branch return an int
let tryif x = 
	y = 
		if x > 10 then
			x - 10
	y;;

          y = 
  --------^
error FS0039: The value or constructor 'y' is not defined

// correct way to return a value with an if (to avoit the unit value)
let tryif x = 
	let y = 
		if x > 10 then
			x - 10
		else 
        	x
	y;;

val tryif : x:int -> int