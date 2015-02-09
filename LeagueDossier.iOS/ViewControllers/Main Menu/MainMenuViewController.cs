using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;

namespace LeagueDossier.iOS
{
	partial class MainMenuViewController : UICollectionViewController
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
			CollectionView.RegisterClassForCell(typeof(SummonerMainMenuCell), BaseMainMenuCell.ID);
			CollectionView.IndicatorStyle = UIScrollViewIndicatorStyle.White;
			CollectionView.ReloadData();
		}

		public override void ViewWillAppear(bool animated)
		{
			NavigationController.SetNavigationBarHidden(true, false);
		}

		public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = CollectionView.CellForItem(indexPath);
			cell.Alpha = (nfloat)0.6;
		}

		public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = collectionView.CellForItem(indexPath);
			cell.Alpha = (nfloat)1;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = (BaseMainMenuCell)collectionView.CellForItem(indexPath);
			cell.CellSelected(NavigationController);
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
				var cell = (SummonerMainMenuCell)collectionView.DequeueReusableCell(SummonerMainMenuCell.ID, indexPath);

				//Update and size the cell
				cell.UpdateCell((float)parentViewController.View.Frame.Width, images[indexPath.Row % images.Count]);

				return cell;
			}

			public override nint NumberOfSections(UICollectionView collectionView)
			{
				return 1;
			}

			public override nint GetItemsCount(UICollectionView collectionView, nint section)
			{
				return 100;
			}
		}

		public class MainMenuCollectionViewFlowLayout : UICollectionViewFlowLayout
		{
			public static int CellsPerRow = 2;

			public MainMenuCollectionViewFlowLayout(UIViewController parent) : base()
			{
				MinimumLineSpacing = 0;
				MinimumInteritemSpacing = 0;

				var cellSize = parent.View.Frame.Size.Width / CellsPerRow;
				ItemSize = new CoreGraphics.CGSize(cellSize, cellSize);
			}
		}
	}
}
