using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace LeagueDossier.iOS
{
	partial class SummonerViewController : UIViewController
	{
		public SummonerViewController (IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
		}

		public override void ViewWillAppear(bool animated)
		{
			NavigationController.SetNavigationBarHidden(false, false);
		}
	}
}
