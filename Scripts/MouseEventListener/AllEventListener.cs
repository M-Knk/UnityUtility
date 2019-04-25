using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UnityUtility.MouseEventListeners
{
	[RequireComponent(typeof(Collider))]
	public class AllEventListener : MonoBehaviour
	{
		[SerializeField]
		UnityEvent onMouseEnter;
		[SerializeField]
		UnityEvent onMouseOver;
		[SerializeField]
		UnityEvent onMouseDown;
		[SerializeField]
		UnityEvent onMouseDrag;
		[SerializeField]
		UnityEvent onMouseUp;
		[SerializeField]
		UnityEvent onMouseUpAsButton;
		[SerializeField]
		UnityEvent onMouseExit;

		void OnMouseEnter()
		{
			onMouseEnter.Invoke();
		}

		void OnMouseOver()
		{
			onMouseOver.Invoke();
		}

		void OnMouseDown()
		{
			onMouseDown.Invoke();
		}

		void OnMouseDrag()
		{
			onMouseDrag.Invoke();
		}

		void OnMouseUp()
		{
			onMouseUp.Invoke();
		}

		void OnMouseUpAsButton()
		{
			onMouseUpAsButton.Invoke();
		}

		void OnMouseExit()
		{
			onMouseExit.Invoke();
		}
	}
}