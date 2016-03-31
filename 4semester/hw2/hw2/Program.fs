// task 1
let numbersMult x =
    let rec numbersMultUtil acc x =
        let lastNumber = x % 10
        match lastNumber with
        | 0 -> 0
        | _ ->
            match x with
            | _ when x < 0 -> numbersMultUtil acc -x
            | _ when x > 0 && x < 10 -> acc * x
            | _ -> numbersMultUtil <| acc * lastNumber <| x / 10
    numbersMultUtil 1 x

printfn "%i" <| numbersMult 12340566
printfn "%i" <| numbersMult 12345

// task 2
let findPosition list x = 
    let rec findPositionUtil acc listUtil = 
        match listUtil with
        | [] -> -1
        | head :: tail when head = x -> acc   
        | head :: tail -> findPositionUtil <| acc + 1 <| tail
    findPositionUtil 0 list

let testList = [1..100]
printfn "%i" <| findPosition testList 10

// task 3
let listReverse list = 
    let rec listReverseUtil acc list =
        match list with
        | head :: tail -> listReverseUtil (head :: acc) tail
        | [] -> acc
    listReverseUtil [] list

let isPalindrom s = 
    s
    |> Seq.toList
    |> listReverse
    |> (=) <| Seq.toList s

printfn "%b" <| isPalindrom "123321"
printfn "%b" <| isPalindrom "1234445321"

// task 4
let rec quicksort list = 
    match list with
    | [] -> []
    | head :: tail -> 
        let left = 
            tail |> List.filter (fun x -> x <= head) |> quicksort
        let right = 
            tail |> List.filter (fun x -> x > head) |> quicksort
        left @ [head] @ right

let rec checkSortedList list = 
    match list with
    | [] -> true
    | head :: tail when List.length tail > 0 -> 
        if head = tail.Head then false
        else checkSortedList tail 
    | _ -> true

let areAllElemsDifferent list = 
    list |> quicksort |> checkSortedList

printfn "%b" <| areAllElemsDifferent [1;3;2;0]
printfn "%b" <| areAllElemsDifferent [1;3;2;0;2]