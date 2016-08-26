open System.Threading

let oneMillion = Array.create 1000000 1
let mutable flags = Array.create 100 false
let mutable result = 0

let threadBody i = 
    for j = 1 to 10000 do
        result <- result + oneMillion.[i * j - 1]
    flags.[i - 1] <- true 

let threads = seq {
    for i = 1 to 100 do
        let threadBody () = threadBody i
        yield new Thread(threadBody)
    }

let sumArray = 
    threads |> Seq.iter (fun x -> x.Start())

    while not (Array.forall (fun x -> x) flags) do Thread.Sleep(0)
         
printfn "%A" result