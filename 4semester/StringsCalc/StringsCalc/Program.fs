open System

let convert s =
    let success, result = Int32.TryParse(s)
    if success then
        Some(result)
    else
        None

type WorkflowBuilder() =
    member this.Bind ((s : string), (rest : int -> 'int Option)) =
        let result = convert s
        match result with
        | Some(y) -> rest y
        | None -> None

    member this.Return (x : 'a) = Some(x) 

let strexpr = WorkflowBuilder()

let test1 = 
    strexpr {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }

printfn "%A" test1

let test2 = 
    strexpr {
    let! x = "1"
    let! y = "Ы"
    let z = x + y
    return z
    }

printfn "%A" test2