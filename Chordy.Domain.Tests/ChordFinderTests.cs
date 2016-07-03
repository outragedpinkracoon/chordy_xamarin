using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Chordy.Domain.Tests
{
	public class ChordFinderTests
	{
		private ChordFinder finder;
		private NoteLookup lookup;

		[SetUp]
		public void Init()
		{
			lookup = new NoteLookup();
			finder = new ChordFinder(lookup);
		}

		[Test]
		public void SingleNoteReturnsItself(){
			var chordArray = new List<string> {"C"};
			Assert.That(finder.findChord(chordArray), Is.EqualTo("C"));
		}

		[Test]
		public void IndexOfRootNote()
		{
			var chordNotes = new List<string> { "C", "E", "G" };
			Assert.That(finder.rootNoteIndex(chordNotes), Is.EqualTo(3));
		}

		[Test]
		public void TestNoteIntervalsBasic()
		{
			var chordNotes = new List<string> { "C", "E", "G" };
			var rootNoteIndex = 3;
			var result = finder.NoteIntervals(chordNotes, rootNoteIndex);
			Assert.That(result, Is.EqualTo(new List<int> { 0, 4, 7 }));
		}

		[Test]
		public void TestNoteIntervalsLooping()
		{
			var chordNotes = new List<string> { "G", "B", "D" };
			var rootNoteIndex = 10;
			var result = finder.NoteIntervals(chordNotes, rootNoteIndex);
			Assert.That(result, Is.EqualTo(new List<int> { 0, 4, 7 }));
		}

	}
}
