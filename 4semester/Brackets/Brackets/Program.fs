let (|SeqNode|SeqEmpty|) s = 
    if Seq.isEmpty s then 
        SeqEmpty
    else 
        SeqNode(Seq.head s, Seq.skip 1 s)
    
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
    let sUtil = Seq.filter isBracket s
    let rec checkUtil s stack = 
        match s with
        | SeqEmpty -> Seq.isEmpty stack
        | SeqNode(x, st) -> 
            match x with 
            | ')' | ']' | '}' ->
                match stack with 
                | SeqEmpty -> false
                | SeqNode(z, t) -> 
                    if z = getOpeningBracket x then
                        checkUtil st t
                    else
                        false
            | _ -> checkUtil st (Seq.append [x] stack)
    checkUtil sUtil Seq.empty

printfn "%A" <| check "[qrb]{adfef}([(as)ddf])"
