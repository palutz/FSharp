Operator Definition and Overloading

// The forward operator is NOT native. It's actually part of library.
// This is the definition: 

> let (|>) x f = f x  // The operator is infix and simply indicates that the argument 
					  // comes before the function that should receive it

// In F# you can combine operators to make a new one.
// For instance, + <|> are infix operators and !~ is a prefix operator.

//REGULARE EXPRESSION

open System.Text.RegularExpressions
//test match
let (^?) a b = Regex.IsMatch(a, b)
// perform a match and returns match info
let (^!) a b = Regex.Match(a, b)
// Query the number of matches
let (!@) (a:Match) = a.Groups.Count - 1
// Access the nth match (1 based, equivalent of $1..$n notation)
let (^@) (a:Match) (b:int) = a.Groups.[b].Value

let input = "F# 3.0 is a very cool programming language"
if input ^? @"F# [\d\.]+" then
  let m = input ^! @"F# ([\d\.]+)"
  printfn "matched %d groups and the F# version is %s" !@m (m^@1)

// Two things are missing from the typical Perl usage: a syntax for substitution and the ability to specify
// regex options such as ignore case (typically indicated by letters like i, s, and g). We can easily extend our
// definition to allow specifying a string with options:

// Revised Regular Expression Operators

open System.Text.RegularExpressions
let string2opt (s:string) =
    let mutable ret = RegexOptions.ECMAScript
    for c in s do
        match c with
        | 's' -> ret <- ret ||| RegexOptions.Singleline
        | 'm' -> ret <- ret ||| RegexOptions.Multiline
        | 'i' -> ret <- ret ||| RegexOptions.IgnoreCase
        | _ -> ()
    ret

// test match
let (^?) a (b, c) = Regex.IsMatch(a, b, string2opt c)
// perform a match and returns match info
let (^!) a (b, c) = Regex.Match(a, b, string2opt c)
// Query the number of matches
let (!@) (a:Match) = a.Groups.Count - 1
// Access the nth match (1 based, equivalent of $1..$n notation)
let (^@) (a:Match) (b:int) = a.Groups.[b].Value

let input = "F# 3.0 is a very cool programming language"
if input ^? (@"F# [\d\.]+", "i") then // ignore case
    let m = input ^! (@"F# ([\d\.]+)", "")
    printfn "matched %d groups and the F# version i

let (^~) a (b, c:string, d) = Regex.Replace(a, b, c, string2opt d)
printfn "%s" (input ^~ ("very", "super", ""))

F# 3.0 is a super cool programming language  // <- result

//Overloading an operator with a type

type Point(x:float, y:float) =
  member this.X = x
  member this.Y = y

  static member (+) (p1:Point, p2:Point) = new Point(p1.X + p2.X, p1.Y+p2.Y)

let p1, p2 = new Point(0., 1.), new Point(1.,1.)
p1 + p2