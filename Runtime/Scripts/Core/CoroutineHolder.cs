using System.Collections;
using UnityEngine;

namespace UnityUtility
{
	public class CoroutineHolder
	{
		private readonly MonoBehaviour owner;
		private Coroutine currentCoroutine = null;

		public CoroutineHolder(MonoBehaviour behavior)
		{
			owner = behavior;
		}

		public void Start(IEnumerator routine)
		{
			Stop();

			currentCoroutine = owner.StartCoroutine(StartAsync(routine));
		}
		private IEnumerator StartAsync(IEnumerator routine)
		{
			yield return routine;
			currentCoroutine = null;
		}

		public void Stop()
		{
			if (currentCoroutine != null)
			{
				owner.StopCoroutine(currentCoroutine);
				currentCoroutine = null;
			}
		}
	}
}
