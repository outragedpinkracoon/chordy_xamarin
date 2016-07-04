using System.Collections.Generic;
using System;
using Chordy.Domain;
using UIKit;
using System.Text;

namespace Chordy
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			ResultLabel.Hidden = true;
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void SearchButton_TouchUpInside(UIButton sender)
		{
			var reader = SetUpReader();
			var fretConfig = new List<string> { "X", "3", "2", "0", "1", "0" };
			var result = reader.GenerateNotes(fretConfig);
			ResultLabel.Hidden = false;
			ResultLabel.Text = result.Prettify();

		}

		private FretboardReader SetUpReader()
		{
			var noteLookup = new NoteLookup();
			var tuning = new List<string> { "E", "A", "D", "G", "B", "E" };
			var reader = new FretboardReader(tuning, noteLookup);
			return reader;
		}
	}
}

