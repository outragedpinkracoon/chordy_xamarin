using System.Collections.Generic;
namespace Chordy.Domain
{
	public class FretboardReader
	{
		List<string> tuning { get; set; }
		List<string> notes { get; set; }

		public FretboardReader(List<string> tuning, NoteLookup lookup)
		{
			this.tuning = tuning;
			this.notes = lookup.notes;
		}

		public List<string> GenerateNotes(List<string> fretboardValues)
		{
			var chordNotes = new List<string>();
			if (fretboardValues.Count < tuning.Count)
				return chordNotes;

			var index = 0;
			foreach (var fretNumber in fretboardValues)
			{
				if (fretNumber.ToLower ().Equals ("x")) {
					index++;
					continue;
				}
				var standardTuningNote = tuning[index];
				var note = FindNote(fretNumber, standardTuningNote);
				chordNotes.Add(note);
				index++;
			}

			var uniqueNotes = RemoveDuplicateNotes(chordNotes);

			return uniqueNotes;

		}

		public string FindNote(string fretboardPosition, string openNote)
		{
			var frettedNoteIndex = FrettedNoteIndex(fretboardPosition, openNote);
			var frettedNote = notes[frettedNoteIndex];
			return frettedNote;
		}

		public int FrettedNoteIndex(string fretboardPosition, string openNote)
		{
			var fretNumber = int.Parse(fretboardPosition);
			var noteIndex = notes.IndexOf(openNote);
			var frettedNoteIndex = fretNumber + noteIndex;
			var validFrettedNoteIndex = ValidNoteIndex(frettedNoteIndex);
			return validFrettedNoteIndex;
		}

		public int ValidNoteIndex(int frettedNoteIndex)
		{
			var numberOfNotes = notes.Count;
			if (frettedNoteIndex < numberOfNotes - 1)
				return frettedNoteIndex;
			var overflowTimes = frettedNoteIndex / numberOfNotes;
			var multiplier = overflowTimes * numberOfNotes;
			return frettedNoteIndex - multiplier;
		}

		public List<string> RemoveDuplicateNotes(List<string> chordNotes)
		{
			var uniqueNotes = new List<string>();

			foreach (var note in chordNotes)
			{
				if (!uniqueNotes.Contains (note)) {
					uniqueNotes.Add (note);
				}
			}

			return uniqueNotes;
		}
	}
}

