using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UnityUtility.MouseEventListeners
{
	// [RequireComponent(typeof(Collider))]
	public class ButtonListener : MonoBehaviour
	{
		public UnityEvent onPressed;

		void OnMouseUpAsButton()
		{
			onPressed.Invoke();
		}
	}
}