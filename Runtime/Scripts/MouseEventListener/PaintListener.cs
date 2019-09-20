using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UnityUtility.MouseEventListeners
{
	[RequireComponent(typeof(Collider))]
	public class PaintListener : MonoBehaviour
	{
		public UnityEvent onMouseEnter;
		public UnityEvent onMouseDown;
		public UnityEvent onMouseUp;

		void OnMouseEnter()
		{
			onMouseEnter.Invoke();
		}

		void OnMouseDown()
		{
			onMouseDown.Invoke();
		}

		void OnMouseUp()
		{
			onMouseUp.Invoke();
		}
	}
}