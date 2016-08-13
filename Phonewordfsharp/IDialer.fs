namespace Phonewordfsharp

type IDialer =
    abstract member Dial : string -> bool
