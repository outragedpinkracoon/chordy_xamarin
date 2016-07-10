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
			var input = ChordTextInput.Text;
			string[] raw = input.Split(' ');
			List<string> config = new List<string>(raw);

			var chordy = new Chordy();
			var chord = chordy.Run(config);

			ResultLabel.Hidden = false;
			ResultLabel.Text = result.Prettify();

		}
	}
}

