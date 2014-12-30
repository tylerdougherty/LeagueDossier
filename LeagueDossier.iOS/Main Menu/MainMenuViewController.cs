using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;

namespace LeagueDossier.iOS
{
	partial class MainMenuViewController : UIViewController
	{
		public MainMenuViewController(IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var layout = new MainMenuCollectionViewFlowLayout(this);
			CollectionView.SetCollectionViewLayout(layout, true);

			CollectionView.DataSource = new MainMenuCollectionDataSource(this);
			CollectionView.RegisterClassForCell(typeof(MainMenuCell), MainMenuCell.CellID);
			CollectionView.ReloadData();
		}

		//TODO: Add a MainMenuCell
		public class MainMenuCell : UICollectionViewCell
		{
			//ID string used to register the cell for reuse
			public static NSString CellID = new NSString("MainMenuCell");

			[Export("initWithFrame:")] //Link this constructor with the objective-c selector
			public MainMenuCell(RectangleF frame) : base(frame)
			{

			}
		}

		public class MainMenuCollectionDataSource : UICollectionViewDataSource
		{
			//Used to fit the cells to the collection view
			private UIViewController parentViewController;

			//List of images (at some point will make a wrapper class for the elements)
			public List<UIImage> images = new List<UIImage>();

			public MainMenuCollectionDataSource(UIViewController parent)
			{
				parentViewController = parent;

				for (int q = 1; q <= 10; q++)
				{
					var filename = String.Format("Images/pi{0}", q);
					var img = UIImage.FromBundle(filename);
					images.Add(img);
				}
			}

			public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
			{
				//Get new cell from the collection view
				var cell = (MainMenuCell)collectionView.DequeueReusableCell(MainMenuCell.CellID, indexPath);
				var cellFrame = cell.Frame;
				cellFrame.Width = parentViewController.View.Frame.Width / MainMenuCollectionViewFlowLayout.CellsPerRow;
				cellFrame.Height = cellFrame.Width;
				cell.Frame = cellFrame;

				//Load the image and create a view for it
				var imageView = new UIImageView(images[indexPath.Row]);
				var newFrame = imageView.Frame;
				newFrame.Height = cell.Frame.Height;
				newFrame.Width = cell.Frame.Width;
				imageView.Frame = newFrame;

				//Add the image view as a subview and return the cell
				cell.ContentView.AddSubview(imageView);
				return cell;
			}

			public override nint NumberOfSections(UICollectionView collectionView)
			{
				return 1;
			}

			public override nint GetItemsCount(UICollectionView collectionView, nint section)
			{
				return images.Count;
			}
		}

		public class MainMenuCollectionViewFlowLayout : UICollectionViewFlowLayout
		{
			public static int CellsPerRow = 4;

			public MainMenuCollectionViewFlowLayout(UIViewController parent) : base()
			{
				MinimumLineSpacing = 20;
				MinimumInteritemSpacing = 0;

//				var cellSize = parent.View.Frame.Size.Width / 4;
				var cellSize = 300;
				ItemSize = new CoreGraphics.CGSize(cellSize, cellSize);
			}
		}
	}
}
