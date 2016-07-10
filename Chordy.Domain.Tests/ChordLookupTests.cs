using System.Collections.Generic;
using NUnit.Framework;

namespace Chordy.Domain.Tests
{
	public class ChordLookupTests
	{
		ChordLookup lookup;

		[SetUp]
		public void Init()
		{
			lookup = new ChordLookup();
		}

		[Test]
		public void TestConvertsIntervalsToKey()
		{
			var result = lookup.ConvertToKey(new List<int> {0, 4, 7 });

			Assert.That(result, Is.EqualTo("0-4-7"));
		}

		[Test]
		public void TestMajorChord()
		{
			var result = lookup.FindChord(new List<int> { 0, 4, 7 }, "C");
			Assert.That(result, Is.EqualTo("C Major"));
		}

		[Test]
		public void TestMinorChord()
		{
			var result = lookup.FindChord(new List<int> { 0, 3, 7 }, "A");
			Assert.That(result, Is.EqualTo("A Minor"));
		}
	}
}