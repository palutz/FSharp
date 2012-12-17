let add x y = x + y // This function evaluates to val add : x:int -> y:int -> int, the application 
add 1 2             // can be read (and written) as ((add 1) 2)

let inc = add 1
let anotherInc x = add 1 x
printfn "%d is the same as %d" (inc 1) (anotherInc 1)


let addFive = add 5
let adf = addFive 10

printfn "and this is the result of my addfive %d" adf

let addTen = add 10
let fAddTen x = add x 10

printfn "and this is the result of my addfive %d" (fAddTen 20)

// The important aspect to be considered here is that the order of arguments matters in F#.

let searchEven = Seq.filter (fun v -> v % 2 = 0)
printfn "%d even numbers in [1, 100]" ([ 1 .. 100] |> searchEven |> Seq.length)
printfn "%d even numbers in [1, 1000]" ([ 1 .. 1000] |> searchEven |> Seq.length)

//Swap arguments (problem with function like subtraction)

let sub x y = x - y
// swapping arguments
let swapargs f x y = f y x
this is the inferred type of swapargs
f:('a -> 'b -> 'c) -> x:'b -> y:'a -> 'c 

> let swapargs f x y = f y x
> let dec = swapargs sub 1
> printfn "Before 10 there is %d" (dec 10)

Before 10 there is 9
