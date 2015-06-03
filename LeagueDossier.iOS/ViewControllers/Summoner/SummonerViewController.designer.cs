// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace LeagueDossier.iOS
{
	[Register ("SummonerViewController")]
	partial class SummonerViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView SummonerIconView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SummonerLevelLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SummonerNameLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (SummonerIconView != null) {
				SummonerIconView.Dispose ();
				SummonerIconView = null;
			}
			if (SummonerLevelLabel != null) {
				SummonerLevelLabel.Dispose ();
				SummonerLevelLabel = null;
			}
			if (SummonerNameLabel != null) {
				SummonerNameLabel.Dispose ();
				SummonerNameLabel = null;
			}
		}
	}
}
