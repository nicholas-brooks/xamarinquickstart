namespace Phonewordfsharp

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() = 
    inherit ContentPage()
 
    let mutable translatedNumber = "";

    do
        base.LoadFromXaml(typeof<MainPage>) |> ignore

    let callButton = base.FindByName<Button>("callButton")
    let translateButton = base.FindByName<Button>("translateButton")
    let phoneNumber = base.FindByName<Entry>("phoneNumberText")

    member this.makePhoneCall = async {
        let! ok = Async.AwaitTask(this.DisplayAlert("Dial a Number", sprintf "Would you like to call %s ?" translatedNumber, "Yes", "No"))
        if ok then
            let dialer = DependencyService.Get<IDialer>()
            if not(Object.ReferenceEquals(dialer, null)) then
                dialer.Dial(translatedNumber) |> ignore
    }

    member this.OnTranslate(sender : Object, e : EventArgs) =
        translatedNumber <- (phoneNumber.Text |> TranslateNumber.toNumber)
        if String.IsNullOrWhiteSpace(translatedNumber) then
            callButton.IsEnabled <- false
            callButton.Text <- "Call"
        else
            callButton.IsEnabled <- true
            callButton.Text <- "Call " + translatedNumber

    member this.OnCall(sender : Object, e : EventArgs) =
        this.makePhoneCall |> Async.StartImmediate
