using System;
using UIKit;
using Foundation;
using System.Drawing;

namespace LeagueDossier.iOS
{
	public class BaseMainMenuCell : UICollectionViewCell
	{
		//ID string used to register the cell for reuse
		public static NSString ID = new NSString("MainMenuCell");

		public BaseMainMenuCell(RectangleF frame) : base(frame)
		{
		}

		public virtual void UpdateCell(float VCWidth)
		{
			//Size the cell
			var cellFrame = Frame;
			cellFrame.Width = VCWidth / MainMenuViewController.MainMenuCollectionViewFlowLayout.CellsPerRow;
			cellFrame.Height = cellFrame.Width;
			Frame = cellFrame;
		}

		public virtual void CellSelected(UINavigationController navControl)
		{
			//Do nothing for base implementation
		}
	}
}

