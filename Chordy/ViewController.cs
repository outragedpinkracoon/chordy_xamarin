using System.Collections.Generic;
using System;
using Chordy.Domain;
using UIKit;
using System.Text;

namespace Chordy
{
	public partial class ViewController : UIViewController
	{
		ChordyRunner chordy = new ChordyRunner();

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
			ResultLabel.Hidden = false;
			ResultLabel.Text = Run();
		}

		string Run()
		{
			var input = ChordTextInput.Text;
			string[] raw = input.Split(' ');
			var config = new List<string>(raw);

			var chord = chordy.Run(config);
			return chord;
		}
			
	}
}

