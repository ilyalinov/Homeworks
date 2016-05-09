module HW1

// task 1
let rec factorial n =
    match n with
    | _ when n <= 1 -> 1
    | _ -> n * factorial(n - 1)

printfn "5! = %d" (factorial 5)

// task 2
let rec fibonacci n =
    if n = 0 then 
        0
    elif n = 1 then
        1
    else
        fibonacci (n - 2) + fibonacci (n - 1)

printfn "5th fibonacci number is %d" (fibonacci 5)

// task 3
let listReverse list = 
    let rec listReverseUtil acc list =
        match list with  
        | head :: tail -> listReverseUtil (head :: acc) tail
        | [] -> acc
    listReverseUtil [] list

let testList = [1..10]
System.Console.WriteLine(listReverse testList)

// task 4
let listCreator x = 
    List.map (fun n -> pown 2 n) <| [x..x+4]

printfn "%A" <| listCreator 5


