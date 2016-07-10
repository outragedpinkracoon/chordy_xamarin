using System.Collections.Generic;
using NUnit.Framework;
namespace Chordy.Domain.Tests
{
	public class ChordyTests
	{
		ChordyRunner chordy;

		public ChordyTests()
		{
			chordy = new ChordyRunner();
		}

		[Test]
		public void TestCMajor()
		{
			var chord = chordy.Run(new List<string> { "X", "3", "2", "0", "1", "0"});
			Assert.That(chord, Is.EqualTo("C Major"));
		}

		[Test]
		public void TestAMinor()
		{
			var chord = chordy.Run(new List<string> { "X", "0", "2", "2", "1", "0" });
			Assert.That(chord, Is.EqualTo("A Minor"));
		}

		[Test]
		public void TestGSus4()
		{
			var chord = chordy.Run(new List<string> { "3", "3", "0", "0", "1", "3" });
			Assert.That(chord, Is.EqualTo("G Suspended Fourth"));
		}


		[Test]
		public void TestChordNotFound()
		{
			var chord = chordy.Run(new List<string> { "9", "3", "0", "0", "1", "3" });
			Assert.That(chord, Is.EqualTo("Chord not found"));
		}
	}
}