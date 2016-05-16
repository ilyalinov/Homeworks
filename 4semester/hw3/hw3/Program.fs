open System
// task 1
let f l = 
    let min = 
        if List.min l > 0 then
            List.min l
        else
            (List.min l) * 2
    let rec fUtil acc maxi currenti l =
        match l with
        | [] 
        | [_] -> maxi
        | head :: tail -> 
            if head + tail.Head > acc then
                fUtil <| head + tail.Head <| currenti <| currenti + 1 <| tail
            else 
                fUtil acc <| maxi <| currenti + 1 <| tail
    fUtil min -1 0 l
                 
let testList = [100; 99; 98]      
printfn "%A" (f testList)

// task 2.1
let numberOfEven1 list = 
    list
    |> List.filter (fun x -> x % 2 = 0)
    |> List.length

// task 2.2
let numberOfEven2 list = 
    list
    |> List.fold (fun acc x -> acc + (x + 1) % 2) 0

// task 2.3
let numberOfEven3 list = 
    list
    |> List.map (fun x -> (x + 1) % 2)
    |> List.sum

// task 3
type BinTree<'a> = 
    | Node of 'a * BinTree<'a> * BinTree<'a>
    | Empty

let treeHeight binTree = 
    let rec treeHeightUtil acc binTree = 
        match binTree with
        | Empty -> acc
        | Node(x, l, r) -> max (treeHeightUtil (1 + acc) l) (treeHeightUtil (1 + acc) r)
    treeHeightUtil 0 binTree

// task 4
let (|Int|_|) x = 
    let success, result = Int32.TryParse(x)
    if (success) then
        Some(result)
     else
        None    

let (|Plus|Minus|Mult|Div|Number|) x = 
    match x with 
    | Int n -> Number(n)
    | "+" -> Plus
    | "-" -> Minus
    | "*" -> Mult
    | "/" -> Div
    | _ -> failwith "can't recognize symbol"

let rec treeCalculate tree =
    match tree with 
    | Node(x, l, r) -> 
        match x with 
        | Number n -> n
        | Plus -> (treeCalculate l) + (treeCalculate r) 
        | Minus -> (treeCalculate l) - (treeCalculate r)
        | Mult -> (treeCalculate l) * (treeCalculate r)
        | Div -> (treeCalculate l) / (treeCalculate r)
    | Empty -> failwith "incorrect tree format"

printfn "%A" <| treeCalculate (Node("*", Node("5", Empty, Empty), Node("6", Empty, Empty)))
// To be done good this task needs a random arithmetic tree generator or smth like this 
// but i have no idea how to write such thing so i leave it undone

// task 5
let isPrime x = 
    let seqUtil = 
        seq {
            2 .. int(sqrt <| float(x))
        }
    Seq.forall (fun y -> x % y <> 0) seqUtil

let rec primesFrom n = 
    seq {
        if isPrime <| n then yield n
        yield! primesFrom <| n + 1
    }

let integers = primesFrom 2
printfn "%A" integers