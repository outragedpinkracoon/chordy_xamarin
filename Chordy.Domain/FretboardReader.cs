using System;
using System.Collections.Generic;
namespace Chordy.Domain
{
	public class FretboardReader
	{
		public List<string> Tuning { get; private set; }
		public NoteLookup NoteLookup { get; private set; }

		public FretboardReader(List<string> tuning, NoteLookup notes)
		{
			Tuning = tuning;
			NoteLookup = notes;
		}

		public List<string> GenerateNotes(List<string> fretboardValues)
		{
			var chordNotes = new List<string>();
			if (fretboardValues.Count < Tuning.Count)
				return chordNotes;

			var index = 0;
			foreach (var fretNumber in fretboardValues)
			{
				if (fretNumber.ToLower().Equals("x"))
					continue;
				var standardTuningNote = Tuning[index];
				var note = FindNote(fretNumber, standardTuningNote);
				chordNotes.Add(note);
				index++;
			}

			var uniqueNotes = RemoveDuplicateNotes(chordNotes);

			return uniqueNotes;

		}

		public String FindNote(String fretboardPosition, String openNote)
		{
			var frettedNoteIndex = FrettedNoteIndex(fretboardPosition, openNote);
			var frettedNote = NoteLookup.notes[frettedNoteIndex];
			return frettedNote;
		}

		public int FrettedNoteIndex(String fretboardPosition, String openNote)
		{
			var fretNumber = int.Parse(fretboardPosition);
			var noteIndex = NoteLookup.notes.IndexOf(openNote);
			var frettedNoteIndex = fretNumber + noteIndex;
			var validFrettedNoteIndex = ValidNoteIndex(frettedNoteIndex);
			return validFrettedNoteIndex;
		}

		public int ValidNoteIndex(int frettedNoteIndex)
		{
			var numberOfNotes = NoteLookup.notes.Count;
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
				if (!uniqueNotes.Contains(note))
					uniqueNotes.Add(note);
			}
			return uniqueNotes;
		}
	}
}

