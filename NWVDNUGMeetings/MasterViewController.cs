using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NWVDNUG.Core.Contracts;

namespace NWVDNUGMeetings
{
	public partial class MasterViewController : UITableViewController
	{
		TableSource<MeetingInfo> dataSource;

		public MasterViewController (IntPtr handle) : base (handle)
		{
//			Title = NSBundle.MainBundle.LocalizedString ("Master", "Master");
			
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				PreferredContentSize = new SizeF (320f, 600f);
				ClearsSelectionOnViewWillAppear = false;
			}
			
			// Custom initialization
		}

		public DetailViewController DetailViewController {
			get;
			set;
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TableView.Source = dataSource = new TableSource<MeetingInfo> ();
			UIEdgeInsets inset = new UIEdgeInsets(16, 12, 16, 12);
			TableView.ContentInset = inset;

			dataSource.OnRowSelected += (object sender, TableSource<MeetingInfo>.RowSelectedEventArgs e) => {
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					DetailViewController.SetDetailItem (dataSource.Data [e.indexPath.Row]);
			};
			NWVDNUG.Core.DataService.FetchMeetings (fetchCallback);
		}

		public void fetchCallback(List<MeetingInfo> meetings) {
			InvokeOnMainThread (delegate {
				dataSource.Data = meetings;
				this.TableView.ReloadData ();
			});
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showDetail") {
				var indexPath = TableView.IndexPathForSelectedRow;
				var item = dataSource.Data [indexPath.Row];

				((DetailViewController)segue.DestinationViewController).SetDetailItem (item);
			}
		}
	}
}

