using System;
using System.Collections.Generic;

namespace Chordy.Domain
{
	public class ChordFinder
	{
		NoteLookup lookup { get; set; }

		public ChordFinder(NoteLookup noteLookup)
		{
			lookup = noteLookup;
		}

		public string findChord(List<string> chordNotes)
		{
			if (chordNotes.Count == 1)
			{
				return chordNotes[0];
			}
			var index = rootNoteIndex(chordNotes);
			return index.ToString();
		}

		public int rootNoteIndex(List<string> chordNotes)
		{
			var rootNote = chordNotes[0];
			return lookup.NoteIndex(rootNote);
		}

		public List<int> NoteIntervals(List<string> chordNotes, int rootNoteIndex)
		{
			var chordArray = new List<int>();
			foreach (var note in chordNotes)
			{
				var noteInterval = lookup.NoteInterval(rootNoteIndex, note);
				chordArray.Add(noteInterval);
			}
			return chordArray;
		}
	}
}
