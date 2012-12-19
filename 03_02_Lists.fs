
let intList = [12; 10; 1; 13]

let AddItem xs x = x :: xs

let newIntList = AddItem intList 42

printfn "%A" newIntList   // [42; 12; 10; 1; 13]

let strList = ["Hello"; "World"]
let strList2 = ["My"; "name"; "is"; "Stefano"]

printfn "%A" (strList @ strList2)   // ["Hello"; "World"; "My"; "name"; "is"; "Stefano"]

let strConcat = strList @ strList2
printfn "%A" strConcat // ["Hello"; "World"; "My"; "name"; "is"; "Stefano"]

printfn "%A" newIntList.Head //42
printfn "%A" newIntList.Tail  // [12; 10; 1; 13]
printfn "%A" newIntList.Tail.Tail // [10; 1; 13]
printfn "%A" newIntList.Tail.Tail.Head // 10

for i in newIntList do 
    printfn "%A" i

// listLength recursive... we need type annotation cause we use Properties from List (IsEmpty and Tail)
let rec listLength (l: 'a list) =   // type annotation, a list of 'a, the generic type for F#
    if l.IsEmpty then 0
        else 1 + (listLength l.Tail)

// another implementation with the Match expression
let rec listLength' l =
    match l with 
    | [] -> 0 // empty return 0
    | x :: xs -> 1 + (listLength' xs) // take the list apart into its head and tail and then call again on the tail