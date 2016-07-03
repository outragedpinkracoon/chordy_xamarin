using System.Collections.Generic;
namespace Chordy.Domain
{
	public class NoteLookup
	{
		public List<string> notes { get; private set; }
		int interval { get; set; }
		int currentLocation { get; set; }

		public NoteLookup()
		{
			notes = new List<string>() { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
		}

		public int NoteIndex(string note)
		{
			return notes.IndexOf(note);
		}

		public int NoteInterval(int rootNoteIndex, string noteToFind)
		{
			interval = 0;
			currentLocation = rootNoteIndex;
			var found = MatchRootToEnd(noteToFind);
			if (found) return interval;
			currentLocation = 0;

			found = MatchStartOfArrayToRoot(noteToFind, rootNoteIndex);

			if (found) return interval;
			return -1;
		}

		bool MatchRootToEnd(string noteToFind)
		{
			return Match(noteToFind, notes.Count);
		}
		bool MatchStartOfArrayToRoot(string noteToFind, int previousStartPoint)
		{
			return Match(noteToFind, previousStartPoint);
		}

		bool Match(string noteToFind, int endPointOfSearch)
		{
			while (currentLocation < endPointOfSearch)
			{
				var currentNote = notes[currentLocation];
				if (noteToFind == currentNote) return true;
				interval += 1;
				currentLocation += 1;
			}
			return false;
		}
	}
}

