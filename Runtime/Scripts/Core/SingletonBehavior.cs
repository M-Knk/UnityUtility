using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityUtility
{
	public class SingletonBehavior<T> : MonoBehaviour
		where T : SingletonBehavior<T>
	{
		static T instance = null;
		public static T I
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<T>();
				}
				return instance;
			}
		}
	}
}
