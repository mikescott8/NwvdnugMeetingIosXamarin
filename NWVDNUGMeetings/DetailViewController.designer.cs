// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace NWVDNUGMeetings
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel endLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel locationLabel { get; set; }

		[Outlet]
		MonoTouch.MapKit.MKMapView mapView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView notesLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel presenterLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton speakerLinkButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel startLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel titleLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (speakerLinkButton != null) {
				speakerLinkButton.Dispose ();
				speakerLinkButton = null;
			}

			if (endLabel != null) {
				endLabel.Dispose ();
				endLabel = null;
			}

			if (locationLabel != null) {
				locationLabel.Dispose ();
				locationLabel = null;
			}

			if (mapView != null) {
				mapView.Dispose ();
				mapView = null;
			}

			if (notesLabel != null) {
				notesLabel.Dispose ();
				notesLabel = null;
			}

			if (presenterLabel != null) {
				presenterLabel.Dispose ();
				presenterLabel = null;
			}

			if (startLabel != null) {
				startLabel.Dispose ();
				startLabel = null;
			}

			if (titleLabel != null) {
				titleLabel.Dispose ();
				titleLabel = null;
			}
		}
	}
}
