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
        let simpTerm1 = simp term1
        let simpTerm2 = simp term2 
        match (simpTerm1, simpTerm2) with
        | (Const(c1), Const(c2)) -> Const(float(c1) + float(c2))
        | (Const(c), term) | (term, Const(c)) when c = float(0) -> term
        | _ -> Addition(simp simpTerm1, simp simpTerm2)
    | Substraction(term1, term2) ->
        let simpTerm1 = simp term1
        let simpTerm2 = simp term2
        match (simpTerm1, simpTerm2) with
        | (Const(c1), Const(c2)) -> Const(c1 - c2)
        | (term, Const(c)) when c = float(0) -> term
        | _ -> Substraction(simpTerm1, simpTerm2)
    | Multiplication(term1, term2) ->
        let simpTerm1 = simp term1
        let simpTerm2 = simp term2
        match (simpTerm1, simpTerm2) with
        | (Const(c1), Const(c2)) -> Const(c1 * c2)
        | (Const(c), term) | (term, Const(c)) ->
            match c with
            | x when x = float(1) -> simp term
            | x when x = float(0) -> Const(float(0))
            | _ -> Multiplication(Const(c), simp term)
        | _ -> Multiplication(simpTerm1, simpTerm2)
    | Division(term1, term2) ->
        let simpTerm1 = simp term1
        let simpTerm2 = simp term2 
        match (simpTerm1, simpTerm2) with
        | (Const(c1), Const(c2)) -> Const(c1 / c2)
        | (Const(c), _) when c = float(0) -> Const(float(0))
        | (term, Const(c)) ->
            match c with 
            | x when x = float(0) -> failwith "Division by zero"
            | x when x = float(1) -> simp term
            | _ -> Division(simp term, Const(c))
        | _ -> simp <| Division(simpTerm1, simpTerm2)
    
//let testExpression = 
//    Multiplication(
//        Const(1.5),
//        Addition(Const(2.5), Variable)
//    )

//let testExpression = Multiplication(Substraction(Const 1.0, Const 1.0), Variable)

//let testExpression = Addition(Const(0.0), Variable)

//let testExpression = Addition(Substraction(Multiplication(Const(2.5), Variable), Multiplication(Const(3.5), Variable)), Multiplication(Variable, Variable))

printfn "%A" (simp (diff testExpression))