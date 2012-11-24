
//"Date,Open,High,Low,Close,Volume,Adj Close"

let stockData =
    [ 
      "2012-03-30,32.40,32.41,32.04,32.26,31749400,32.26";
      "2012-03-29,32.06,32.19,31.81,32.12,37038500,32.12";
      "2012-03-28,32.52,32.70,32.04,32.19,41344800,32.19";
      "2012-03-27,32.65,32.70,32.40,32.52,36274900,32.52";
      "2012-03-26,32.19,32.61,32.15,32.59,36758300,32.59";
      "2012-03-23,32.10,32.11,31.72,32.01,35912200,32.01";
      "2012-03-22,31.81,32.09,31.79,32.00,31749500,32.00";
      "2012-03-21,31.96,32.15,31.82,31.91,37928600,31.91";
      "2012-03-20,32.10,32.15,31.74,31.99,41566800,31.99";
      "2012-03-19,32.54,32.61,32.15,32.20,44789200,32.20";
      "2012-03-16,32.91,32.95,32.50,32.60,65626400,32.60";
      "2012-03-15,32.79,32.94,32.58,32.85,49068300,32.85";
      "2012-03-14,32.53,32.88,32.49,32.77,41986900,32.77";
      "2012-03-13,32.24,32.69,32.15,32.67,48951700,32.67";
      "2012-03-12,31.97,32.20,31.82,32.04,34073600,32.04";
      "2012-03-09,32.10,32.16,31.92,31.99,34628400,31.99";
      "2012-03-08,32.04,32.21,31.90,32.01,36747400,32.01";
      "2012-03-07,31.67,31.92,31.53,31.84,34340400,31.84";
      "2012-03-06,31.54,31.98,31.49,31.56,51932900,31.56";
      "2012-03-05,32.01,32.05,31.62,31.80,45240000,31.80";
      "2012-03-02,32.31,32.44,32.00,32.08,47314200,32.08";
      "2012-03-01,31.93,32.39,31.85,32.29,77344100,32.29";
      "2012-02-29,31.89,32.00,31.61,31.74,59323600,31.74"; ]

let splitCommas (x:string) =
    x.Split([|','|])

stockData
|> List.map splitCommas
|> List.maxBy (fun x -> abs(float x.[1] - float x.[4]))
|> (fun x -> x.[0])

(*
splitCommas takes a string and breaks it into pieces whenever it finds a comma. 
String.Split is a function that splits a string based on takes an array of separator characters. Arrays are another basic container type in F# that allow you to index stored elements.
You create arrays using a [| ... |] which is similar to the [ .. ] syntax used for lists. Here,[|','|] creates a single element array containing a comma. The result of the splitCommas is also an array. This array contains the individual string parts.
For example, parsing the last line of the input yields the array [| 2012-02-29; 31.89; 32.00; 31.61; 31.74; 59323600; 31.74 |].

Now that you've separated the data by commas, you need to find the maximum variance between the opening and closing days. You accomplish that using the List.maxBy function, which finds the maximum item in a List based a given comparison function. You use a comparison function of (fun x -> abs(float x.[1] - float x.[4])) to find the maximum variance. Note that abs is a function for calculating absolute value, and float is a function to parse a floating point number from a string. The x.[1] and x.[4] calls get the second and fifth elements in the array, respectively (in F# array indexing is zero-based).

Finally, you project the date from the maximum row using List.map and a projection function of (fun x -> x.[0]).
*)

// Record type
type Book = 
  { Name: string;
    AuthorName: string;
    Rating: int;
    ISBN: string }

let expertFSharp = 
  { Name = "Expert F#";
    AuthorName = "Don Syme, Adam Granicz, Antonio Cisternino";
    Rating = 5;
    ISBN = "1590598504" }

 // using let expertFSharp is immutable... to change we can clone another record with the same data and change only what we need
let partDeux = { expertFSharp with Name = "Expert F# 2.0" }

// USING OPTION (optional parameter)
type Book =
  { Name: string;
    AuthorName: string;
    Rating: int option;
    ISBN: string }
// ERROR!!! Rating missing....
let unratedEdition = 
  { Name = "Expert F#";
    AuthorName = "Don Syme, Adam Granicz, Antonio Cisternino";
    ISBN = "1590598504" }
// Correct with empty/none value
let unratedEdition = 
  { Name = "Expert F#";
    AuthorName = "Don Syme, Adam Granicz, Antonio Cisternino";
    Rating = None;    
    ISBN = "1590598504" }
// giving a value to option
let stingyReview = 
  { Name = "Expert F#";
    AuthorName = "Don Syme, Adam Granicz, Antonio Cisternino";
    Rating = Some 1;    // without Some is wrong!! 
    ISBN = "1590598504" }

// Using MATCH (looking for record where an option field exists)
let printRating book =
    match book.Rating with
    | Some rating -> printfn "I give this book %d star(s) out of 5!" rating
    | None -> printfn "I didn't review this book"

// DISCRIMIATED UNIONS
type PowerUp =
| FireFlower
| Mushroom
| Star


let powerUp = FireFlower
match powerUp with
| FireFlower -> printfn "Ouch, that's hot!"
| Mushroom -> printfn "Please don't step on me..."
| Star -> printfn "Let me play some special music for you."
# Output
Ouch, that's hot!

val powerUp : PowerUp = FireFlower
val it : unit = ()

let handlePowerUp powerUp =
    match powerUp with
    | FireFlower -> printfn "Ouch, that's hot!"
    | Mushroom color -> match color with
                        | Red -> printfn "Please don't step on me..."
                        | Green -> printfn "1UP!!!"
                        | Purple -> printfn "Sorry, about that!"
    | Star duration -> printfn "Let me play some special music for you 
        for %d seconds." duration

// Test handlePowerUp.
let powerUp = Star 14
handlePowerUp powerUp