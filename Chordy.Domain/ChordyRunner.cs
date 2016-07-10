using System;
using System.Collections.Generic;
namespace Chordy.Domain
{
	public class ChordyRunner
	{
		NoteLookup noteLookup;
		FretboardReader reader;
		ChordFinder chordFinder;
		ChordLookup chordLookup;

		public ChordyRunner()
		{
			noteLookup = new NoteLookup();
			reader = new FretboardReader(new List<string> { "E", "A", "D", "G", "B", "E"}, noteLookup);
			chordFinder = new ChordFinder(noteLookup);
			chordLookup = new ChordLookup();
		}

		public string Run(List<string> fretboardConfig)
		{
			var chordNotes = reader.GenerateNotes(fretboardConfig);
			var rootNoteIndex = chordFinder.RootNoteIndex(chordNotes);
			var intervalsArray = chordFinder.NoteIntervals(chordNotes, rootNoteIndex);
			var rootNote = noteLookup.notes[rootNoteIndex];
			var chord = chordLookup.FindChord(intervalsArray, rootNote);
			return chord;
		}
	}
}

