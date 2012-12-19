
> let t1 = 12, 5, 7  // this is a tuples
// val t1 : int * int * int = (12, 5, 7)

> let v1, v2, v3 = t1  // assign every values of the tuples to the v1 v2 v3

//val v3 : int = 7
//val v2 : int = 5
//val v1 : int = 12

> let x1, x2, _ = t1 // if we don't care about one value we can use the _ (extracting the other values)

//val x2 : int = 5
//val x1 : int = 12