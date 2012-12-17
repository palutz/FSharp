// Active Patterns

// MATCH

let input = [ (1., 2., 0.); (2., 1., 1.); (3., 0., 1.) ]
let rec search lst =
  match lst with
  | (1., _, z) :: tail -> printfn "found x=1. and z=%f" z; search tail
  | (2., _, _) :: tail -> printfn "found x=2."; search tail
  | _ :: tail -> search tail
  | [] -> printfn "done."
search input

found x=1. and z=0.000000
found x=2.
done.

// What we just did
// Unpack the list in a head and tail
// Give a sort of template to the head value (a triple whose first argument is a float)
// Bind an element of the head triple to a name (in this case z)
// Check different conditions through a set of rules

let add10 = add 10
let mult5 = mult 5
let calcResult = mult5(add10 17)
// the last one is the same of writing 
let calcResult' = 17 |> add10 |> mult5
// |> is the chaining operator and is working appending what is in the left side 
// to the parameter list of what is in the right


// using composition operator
// in this case the data move from left to right. First add10 then mult5
let add10mult5 = add10 >> mult5
// so we will pass 17 the call the add10 and then the result will be passed to mult5
let calcResult'' = add10mult5 17    // same as all the other calcResult

// we can also use the pipeline in the opposite way (mult5 then add10)
let add10mult5' = add10 << mult5

// always pay attention to the TYPE of the parameters

// Composition allow to create new funcionts from old functions, using them as a composition block.