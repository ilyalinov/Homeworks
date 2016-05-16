type Stack(list0 : list<int>) = 
    let mutable list = list0
    
    member this.Push(x) =
        list <- x :: list

    member this.Pop =
        match list with 
        | [] -> failwith "stack is empty"
        | head :: tail -> 
            list <- tail
            printfn "Deleted %i" head

    member this.IsEmpty = 
        printfn "%b" (list = [])
          
// tests:         
let myStack = Stack([1;2;3])
myStack.IsEmpty
myStack.Pop
myStack.Pop
myStack.Pop
myStack.IsEmpty
myStack.Push(1)
myStack.IsEmpty
myStack.Pop
myStack.Pop