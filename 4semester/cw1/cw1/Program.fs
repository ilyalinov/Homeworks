let s1 = 
    Seq.initInfinite (fun index -> if (index % 2 = 0) then 1 else -1)

printfn "%A" s1

let s2 = 
    s1 |> Seq.mapi (fun index x -> if (x < 0) then -index - 1 else index + 1)

printfn "%A" s2