using UnityEngine;
using System.Collections;

namespace UnityUtility
{
	public struct Tuple<T, U>
	{
		public T Item1 { get; private set; }
		public U Item2 { get; private set; }

		public Tuple(T item1, U item2)
		{
			Item1 = item1;
			Item2 = item2;
		}
	}

	public struct Tuple<T, U, V>
	{
		public T Item1 { get; private set; }
		public U Item2 { get; private set; }
		public V Item3 { get; private set; }

		public Tuple(T item1, U item2, V item3)
		{
			Item1 = item1;
			Item2 = item2;
			Item3 = item3;
		}
	}
}