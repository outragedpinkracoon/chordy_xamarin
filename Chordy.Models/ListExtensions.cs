using System;
using System.Collections.Generic;
using System.Text;
namespace Chordy.Domain
{
	public static class ListExtensions
	{
		public static string Prettify<T>(this List<T> list)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var item in list)
			{
				sb.Append(item);
				sb.Append(" ");
			}
			return sb.ToString();
		}
	}
}

