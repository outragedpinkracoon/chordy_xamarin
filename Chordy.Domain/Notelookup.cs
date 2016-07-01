using System.Collections.Generic;
namespace Chordy.Domain
{
	public class NoteLookup
	{
		public List<string> notes { get; private set; }

		public NoteLookup()
		{
			notes = new List<string>() { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
		}
	}
}

