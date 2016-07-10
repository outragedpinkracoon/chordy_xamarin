using System;
using System.Collections.Generic;
namespace Chordy.Domain
{
	public class ChordLookup
	{
		Dictionary<string, string> chordDictionary;

		public ChordLookup()
		{
			chordDictionary = new Dictionary<string, string>
			{
				{"0-4-7","Major"},
				{"0-3-7","Minor"},
				{"0-4-7-11","Major Seventh"},
				{"0-2-7","Suspended Second"},
				{"0-5-7","Suspended Fourth"},
				{"0-3-7-10","Minor Seventh"},
				{"0-4-7-10","Dominant Seventh"}
			};
		}

		public string ConvertToKey(List<string> intervalsArray)
		{
			return string.Join("-", intervalsArray);
		}

		public string FindChord(List<string> intervalsArray, string rootNote)
		{
			string result = rootNote + " ";
			var key = ConvertToKey(intervalsArray);
			string chord;
			if (chordDictionary.TryGetValue(key, out chord))
			{
				return result + chord;
			}
			return "Chord not found";
		}
	}
}