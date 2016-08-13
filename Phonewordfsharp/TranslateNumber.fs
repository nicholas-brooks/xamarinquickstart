namespace Phonewordfsharp

module TranslateNumber = 
    open System
    
    let validChar chr = String.exists (fun c -> chr = c) " -0123456789"
    
    let convertChar chr = 
        match chr with
        | 'A' | 'B' | 'C' -> Some '2'
        | 'D' | 'E' | 'F' -> Some '3'
        | 'G' | 'H' | 'I' -> Some '4'
        | 'J' | 'K' | 'L' -> Some '5'
        | 'M' | 'N' | 'O' -> Some '6'
        | 'P' | 'Q' | 'R' | 'S' -> Some '7'
        | 'T' | 'U' | 'V' -> Some '8'
        | 'W' | 'X' | 'Y' | 'Z' -> Some '9'
        | _ -> None
    
    let rec convertRec str (accum : char list) = 
        match str with
        | [] -> Some accum
        | head :: tail -> 
            if (validChar head) then
                (convertRec tail (accum @ [ head ]))
            else 
                match (convertChar head) with
                | Some c -> (convertRec tail (accum @ [ c ]))
                | None -> None
    
    let convert (upper : string) = 
        match (convertRec (upper.ToCharArray() |> Array.toList) []) with
        | Some v -> v |> Array.ofList |> String
        | _ -> null
    
    let toNumber (raw : string) = 
        match raw.ToUpperInvariant() with
        | null -> null
        | "" -> null
        | s -> convert s
