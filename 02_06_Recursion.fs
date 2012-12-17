// Recursion

// rec define a recursive function, and make available the declaration
// of the function also inside the function itself

let rec fact x =   
    if x = 1 then 1
    else x * (fact (x-1))


let fnB() = fnA()
let fnA() = fnB()  // not working

// other way.. recursive using "and" and "rec"

let rec fnB() = fnA()
and fnA() = fnA()  // making a recursive network of function

// looping with recursive functions

open System
open System.Threading

//first version
(*
let showValues() =
    let r = Random()
    while true do
        printfn "%d" (r.Next())
        Thread.Sleep(1000)
*)
// works as the previous but recursive.
// not so used cause of the stackOverflow issue
// but F# and many functional languages has stack optimization
let showValues() =
    let r = Random()
    let rec dl() =
        printfn "%d" (r.Next())
        Thread.Sleep(1000)
        dl()
    dl()

showValues()


