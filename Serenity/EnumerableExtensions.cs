using System;
using System.Collections.Generic;

namespace Serenity
{
	public static class EnumerableExtensions
	{
		public static void Foreach<T>(this IEnumerable<T> that, Action<T> fn)
		{
			foreach (T value in that)
			{
				fn(value);
			}
		}
	}
}