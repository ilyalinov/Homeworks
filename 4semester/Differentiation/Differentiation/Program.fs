type Expression<'a> = 
    | Const of 'a
    | Variable
    | Addition of Expression<'a> * Expression<'a>
    | Substraction of Expression<'a> * Expression<'a>
    | Multiplication of Expression<'a> * Expression<'a>
    | Division of Expression<'a> * Expression<'a>

let rec diff (expression : Expression<float>) = 
    match expression with
    | Const(_) -> 
        Const(float(0))
    | Variable -> 
        Const(float(1))
    | Addition(term1, term2) -> 
        Addition(diff term1, diff term2)
    | Substraction(term1, term2) -> 
        Substraction(diff term1, diff term2)
    | Multiplication(term1, term2) -> 
        Addition(Multiplication(diff term1, term2), Multiplication(term1, diff term2))
    | Division(term1, term2) -> 
        Division(Substraction(Multiplication(diff term1, term2), Multiplication(term1, diff term2)), Multiplication(term2, term2))

// Might be some other ways to make the expression more simple
let rec simp (expression : Expression<float>) = 
    match expression with
    | Const(_) | Variable -> expression
    | Addition(term1, term2) ->
        match (term1, term2) with
        | (Const(c1), Const(c2)) -> Const(float(c1) + float(c2))
        | _ -> Addition(simp term1, simp term2)
    | Substraction(term1, term2) ->
        match (term1, term2) with
        | (Const(c1), Const(c2)) -> Const(c1 - c2)
        | _ -> Addition(simp term1, simp term2)
    | Multiplication(term1, term2) ->
        match (term1, term2) with
        | (Const(c1), Const(c2)) -> Const(c1 * c2)
        | (Const(c), term) | (term, Const(c)) ->
            match c with
            | x when x = float(1) -> simp term
            | x when x = float(0) -> Const(float(0))
            | _ -> Multiplication(simp term1, simp term2)
        | _ -> simp <| Multiplication(simp term1, simp term2)
    | Division(term1, term2) -> 
        match (term1, term2) with
        | (Const(c1), Const(c2)) -> Const(c1 / c2)
        | (Const(c), _) when c = float(0) -> Const(float(0))
        | (term, Const(c)) ->
            match c with 
            | x when x = float(0) -> failwith "Division by zero"
            | x when x = float(1) -> simp term
            | _ -> Division(simp term1, simp term2)
        | _ -> Division(simp term1, simp term2)
    
//let testExpression = 
//    Multiplication(
//        Const(1.5),
//        Addition(Const(2.5), Variable)
//    )

let testExpression = Multiplication(Variable, Variable)

printfn "%A" (simp (diff testExpression))