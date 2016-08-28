open System.IO

let menu = 
        printfn "0 - exit"
        printfn "1 - add name and number"
        printfn "2 - find name by phone"
        printfn "3 - find phone by name"
        printfn "4 - save data to file"
        printfn "5 - write file's data to list"
    
type filterOption = 
    | SearchName
    | SearchPhone

let phonebook (fileName : string) = 
    let getKey x = 
        printfn "Enter your key:"
        System.Console.ReadKey().Key

    let filter l s option =
        let result = 
            match option with
            | SearchName -> List.map (fun x -> fst x) <| List.filter (fun x -> snd x = s) l
            | SearchPhone -> List.map (fun x -> snd x) <| List.filter (fun x -> fst x = s) l
        match result with
        | [] -> 
            printfn "No coincedences found"
        | _ -> 
            printfn "Search result:"
            result |> Seq.iter (printfn "%A")

    let rec phonebookUtil key oldBook =
        printf "\n"
        let book = oldBook |> Seq.distinct |> Seq.toList  

        match key with 
            | System.ConsoleKey.D0 -> printfn "exit"
            | System.ConsoleKey.D1 -> 
                printfn "enter name and number. Notice that there must be a space between."
                let record = System.Console.ReadLine()
                let splittedRecord = 
                    let split = record.Split [|' '|]
                    // First is name, second is phone
                    (split.[0], split.[1])
                phonebookUtil <| getKey () <| splittedRecord::book
            | System.ConsoleKey.D2 -> 
                printfn "enter your phone:"
                let s = System.Console.ReadLine()
                filter book s SearchName
                phonebookUtil <| getKey () <| book
            | System.ConsoleKey.D3 -> 
                printfn "enter your name:"
                let s = System.Console.ReadLine()
                filter book s SearchPhone
                phonebookUtil <| getKey () <| book
            | System.ConsoleKey.D4 ->
                use sr = new StreamWriter(fileName)
                let modify (x : string, y : string)=
                    x + " " + y 
                book |> Seq.iter (fun x -> sr.WriteLine(modify x))
                printfn "writing completed"
                sr.Close()
                phonebookUtil <| getKey () <| book
            | System.ConsoleKey.D5 ->
                use sr = new StreamReader(fileName)
                let rec readLines l = 
                    if (not sr.EndOfStream) then
                        let buffer = sr.ReadLine()
                        let split = buffer.Split [|' '|]
                        readLines <| ((split.[0], split.[1])::l)
                    else
                        l
                let book1 = (readLines book)
                sr.Close()
                printfn "done"
                phonebookUtil <| getKey () <| book1
            | _ -> 
                printfn "wrong key"
                phonebookUtil <| getKey () <| book

    phonebookUtil (getKey ()) []

phonebook "Phonebook.txt"