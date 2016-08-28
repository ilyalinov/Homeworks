let round (x : float) (n : int) = System.Math.Round(x, n)

type WorkflowBuilder (n : int) = 
    member this.Bind (x : float, rest : float -> float) = 
        let result = round x n
        rest result

    member this.Return (x : float) =
        round x n 

let rounding n = WorkflowBuilder(n)

let test = 
    rounding 3 {
    let! a = 2.0 / 12.0
    let! b = 3.5
    return a / b
    }