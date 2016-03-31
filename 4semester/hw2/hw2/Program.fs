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