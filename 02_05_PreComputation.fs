// Pre-computation and carried function

open System.Collections.Generic

let IsInList(list: 'a list) v = 
    let lookupTable = new HashSet<'a>(list)
    printfn "looking up"
    lookupTable.Contains v

printfn "%b" (IsInList ["hi"; "there"; "Stefano"] "Stefano")
printfn "%b" (IsInList ["hi"; "there"; "Stefano"] "Vita")

// change the declaration but not the execution. Partial application doesn't change the evaluation order of the function code.
// The execution of the function happens only when all the parameters are passed to the function so, in this case, at the printfn row level.
// This means that there is no difference in execution between these two snippets
let IsInListClever = IsInList ["hi"; "there"; "Stefano"] 
printfn "%b" (IsInListClever "Stefano")
printfn "%b" (IsInListClever "Vita")

// to leverage the functional pre-computations
// we need to create a function that return a function itself

let constructLookup(list: 'a list) =
    let lookupTable = new HashSet<'a>(list)
    printfn "lookup table created"
    fun v ->      // actually erturn this function
        printfn "PErforming lookup"
        lookupTable.Contains v


let IsInListClever' = constructLookup ["hi"; "there"; "Stefano"] 
printfn "%b" (IsInListClever' "Stefano")
printfn "%b" (IsInListClever' "Vita")
(*
And this is the result:

lookup table created
PErforming lookup
true
PErforming lookup
false

So I created the lookup table only once and then performed the lookup
all the time that I need.
*)
