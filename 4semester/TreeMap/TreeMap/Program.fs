type BinTree<'a> = 
    | Tree of 'a * BinTree<'a> * BinTree<'a>
    | Tip of 'a

let rec treeMap tree f =
    match tree with 
    | Tree(x, l, r) -> Tree(f x, treeMap l f, treeMap r f)
    | Tip x -> Tip(f x) 

let testTree = 
    Tree(
        2, 
        Tree(7, Tip(4), Tip(5)),
        Tree(5, Tip(5), Tip(5))
    )

printfn "%A" <| treeMap testTree (fun x -> x * x)