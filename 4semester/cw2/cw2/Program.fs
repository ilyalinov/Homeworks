let list = [700..999]

let rec cartesian xs ys = 
    match xs, ys with
    | [], _ -> []
    | _, [] -> []
    | head :: tail, ys -> (List.map (fun y -> y * head) ys) @ (cartesian tail ys)

let listReverse list = 
    let rec listReverseUtil acc list =
        match list with
        | head :: tail -> listReverseUtil (head :: acc) tail
        | [] -> acc
    listReverseUtil [] list

let rec quicksort list = 
    match list with
    | [] -> []
    | head :: tail -> 
        let left = 
            tail |> List.filter (fun x -> x <= head) |> quicksort
        let right = 
            tail |> List.filter (fun x -> x > head) |> quicksort
        left @ [head] @ right

let int2string (x: int) = 
    string x

let isPalindrom s = 
    s
    |> int2string
    |> Seq.toList
    |> listReverse
    |> (=) <| Seq.toList (int2string s)

let result l =
    l
    |> cartesian l
    |> List.filter (fun x -> isPalindrom x)
    |> quicksort
    |> listReverse
    |> List.head

printfn "%i" (result list)