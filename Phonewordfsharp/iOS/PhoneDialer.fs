namespace Phonewordfsharp.iOS

open Foundation
open Xamarin.Forms
open UIKit
open Phonewordfsharp

type PhoneDialer() =
    interface IDialer with
        member this.Dial number =
            UIApplication.SharedApplication.OpenUrl(new NSUrl("tel:" + number))
