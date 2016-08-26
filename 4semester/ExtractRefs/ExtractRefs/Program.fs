open System
open System.Threading
open System.Net
open System.IO
open System.Text.RegularExpressions

let extractUrlText (url : string) = 
    let request = WebRequest.Create(url)
    use response = request.GetResponse()
    use stream = response.GetResponseStream()
    use reader = new StreamReader(stream)
    reader.ReadToEnd()

let findRefs (text : string) = 
    let pattern = "<a href=\"http://.+?\">"
    let regex = new Regex(pattern, RegexOptions.IgnoreCase)
    let matches = regex.Matches(text)
    seq {
    for x in matches do
        yield x.Value.Substring(9, x.Value.Length - 9 - 2)
    }

let asyncReadRef (url : string) = 
    async {
        try 
            let request = WebRequest.Create(url)
            use! response = request.AsyncGetResponse()
            use stream = response.GetResponseStream()
            use reader = new StreamReader(stream)
            let text = reader.ReadToEnd()
            do printfn "%s URL consists of %d characters" url text.Length
        with
        | :? WebException as e ->
            printfn "Page not found" 
    }

let getAllRefsInfo url = 
    url 
    |> extractUrlText 
    |> findRefs 
    |> Seq.map (fun s -> asyncReadRef s) 
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

getAllRefsInfo "http://fsharp.org/"