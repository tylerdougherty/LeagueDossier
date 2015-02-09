using System;
using Foundation;
using System.Drawing;
using UIKit;

namespace LeagueDossier.iOS
{
	public class SummonerMainMenuCell : BaseMainMenuCell
	{
		public UIImageView ImageView { get; private set; } //Move to Base class

		[Export("initWithFrame:")]
		public SummonerMainMenuCell(RectangleF frame) : base(frame)
		{
			//Create the image view
			ImageView = new UIImageView();

			//Add it to the content view
			ContentView.AddSubview(ImageView);
		}
			
		public void UpdateCell(float VCWidth, UIImage image)
		{
			base.UpdateCell(VCWidth);

			//Load the image into the view
			ImageView.Image = image;
			ImageView.Frame = new CoreGraphics.CGRect(0, 0, Frame.Width, Frame.Height);


			//Animate the views
//			ImageView.Layer.RemoveAllAnimations();
//			UIView.Animate(2, 0, UIViewAnimationOptions.Repeat | UIViewAnimationOptions.Autoreverse, () => {
//				ImageView.Frame = new CoreGraphics.CGRect(Frame.Width/4, Frame.Height/4,
//					Frame.Width/2, Frame.Height/2);
//			}, null);
		}

		public override void CellSelected(UINavigationController navControl)
		{
			var storyboard = UIStoryboard.FromName("MainStoryboard", null);
			var SummonerViewController = storyboard.InstantiateViewController("summonerViewController");
			navControl.PushViewController(SummonerViewController, true);
		}
	}
}

