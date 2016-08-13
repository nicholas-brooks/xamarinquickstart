using Foundation;
using Xamarin.Forms;
using UIKit;
using Phonewordcsharp.iOS;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Phonewordcsharp.iOS
{
	public class PhoneDialer : IDialer
	{
		public bool Dial(string number)
		{
			return UIApplication.SharedApplication.OpenUrl(
				new NSUrl("tel:" + number));
		}
	}
}

