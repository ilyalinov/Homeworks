let isOpeningBracket x = 
    match x with 
    | '(' | '[' | '{' -> true
    | _ -> false

let isBracket x = 
    match x with 
    | '(' | '[' | '{' | '}' | ']' | ')' -> true
    | _ -> false

let getOpeningBracket b = 
    match b with 
    | ')' -> '('
    | ']' -> '['
    | '}' -> '{'
    | _ -> failwith "this symbol is not an allowed bracket"

let check s = 
    let sUtil = List.filter isBracket s
    let rec checkUtil s stack = 
        match s with
        | [] -> List.isEmpty stack
        | x::st -> 
            match x with 
            | ')' | ']' | '}' ->
                match stack with 
                | [] -> false
                | z::t -> 
                    if z = getOpeningBracket x then
                        checkUtil st t
                    else
                        false
            | _ -> checkUtil st (x::stack)
    checkUtil sUtil []

printfn "%A" <| check (Seq.toList "[qrb]{adfef}([(as)ddf])")
