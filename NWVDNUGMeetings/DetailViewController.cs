using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NWVDNUG.Core.Contracts;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

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

				var pinLoc = new CLLocationCoordinate2D (0,0);

				var geocoder = new CLGeocoder ();
				geocoder.GeocodeAddress (detailItem.Location, (CLPlacemark[] locations, NSError error) => {
					if (locations.Length>0) {
						pinLoc = locations[0].Location.Coordinate;

						var pin = new MKPointAnnotation ();
						pin.Title = detailItem.Location.Substring(0, detailItem.Location.IndexOf(","));
						pin.Subtitle = detailItem.Location.Substring (detailItem.Location.IndexOf (",") + 1);
						pin.Coordinate = pinLoc;

						mapView.AddAnnotation (pin);
						mapView.SetRegion (new MKCoordinateRegion (pinLoc, new MKCoordinateSpan (0.5, 0.5)), true);
					}
				});
				locationLabel.Text = detailItem.Location;
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
			//barButtonItem.Title = NSBundle.MainBundle.LocalizedString ("Master", "Master");
			barButtonItem.Title = "Upcoming Meetings";
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

