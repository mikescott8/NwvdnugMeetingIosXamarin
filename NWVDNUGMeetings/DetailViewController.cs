using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NWVDNUG.Core.Contracts;

namespace NWVDNUGMeetings
{
	public partial class DetailViewController : UIViewController
	{
		UIPopoverController masterPopoverController;
		MeetingInfo detailItem;

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		public void SetDetailItem (MeetingInfo newDetailItem)
		{
			if (detailItem != newDetailItem) {
				detailItem = newDetailItem;
				
				// Update the view
				ConfigureView ();
			}
			
			if (masterPopoverController != null)
				masterPopoverController.Dismiss (true);
		}

		void ConfigureView ()
		{
			// Update the user interface for the detail item
			if (IsViewLoaded && detailItem != null) {
				titleLabel.Text = detailItem.Title;
				presenterLabel.Text = detailItem.SpeakerName;
				notesLabel.Text = detailItem.Notes;
				notesLabel.ContentInset = new UIEdgeInsets (0, 0, 0, 0);

				startLabel.Text = detailItem.MeetingStartTime;
				endLabel.Text = detailItem.MeetingEndTime;
				if (string.IsNullOrWhiteSpace(detailItem.SpeakerBioLink)) {
					speakerLinkButton.Hidden = true;
				} else {
					speakerLinkButton.TouchUpInside += (sender, e) => {
						UIApplication.SharedApplication.OpenUrl(new NSUrl(detailItem.SpeakerBioLink));
					};
				}
				locationLabel.Text = detailItem.Location;

				mapView.AddPlacemark (new MonoTouch.MapKit.MKPlacemark (
					new MonoTouch.CoreLocation.CLLocationCoordinate2D (0, 0),
					new NSDictionary (detailItem.Location, null)
				));
			}
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

			// Perform any additional setup after loading the view, typically from a nib.
			ConfigureView ();
		}

		[Export ("splitViewController:willHideViewController:withBarButtonItem:forPopoverController:")]
		public void WillHideViewController (UISplitViewController splitController, UIViewController viewController, UIBarButtonItem barButtonItem, UIPopoverController popoverController)
		{
			barButtonItem.Title = NSBundle.MainBundle.LocalizedString ("Master", "Master");
			NavigationItem.SetLeftBarButtonItem (barButtonItem, true);
			masterPopoverController = popoverController;
		}

		[Export ("splitViewController:willShowViewController:invalidatingBarButtonItem:")]
		public void WillShowViewController (UISplitViewController svc, UIViewController vc, UIBarButtonItem button)
		{
			// Called when the view is shown again in the split view, invalidating the button and popover controller.
			NavigationItem.SetLeftBarButtonItem (null, true);
			masterPopoverController = null;
		}
	}
}

