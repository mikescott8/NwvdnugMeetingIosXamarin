// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace NWVDNUGMeetings
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel endLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel locationLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.MapKit.MKMapView mapView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView notesLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel presenterLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton speakerLinkButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel startLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel titleLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
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
			if (speakerLinkButton != null) {
				speakerLinkButton.Dispose ();
				speakerLinkButton = null;
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
