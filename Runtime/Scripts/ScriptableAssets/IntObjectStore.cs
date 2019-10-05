using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityUtility.CommonScriptableObject
{
	[CreateAssetMenu]
	public class IntObjectStore : ScriptableObject
	{
		[System.Serializable]
		public class KeyValue
		{
			public int key;
			public UnityEngine.Object value;
		}

		[SerializeField]
		KeyValue[] keyValues;

		public bool TryGetValue<ValueType>(int key, out ValueType value)
			where ValueType : UnityEngine.Object
		{
			foreach (var keyValue in keyValues)
			{
				if (keyValue.key == key)
				{
					value = keyValue.value as ValueType;
					if (value != null)
					{
						return true;
					}
				}
			}

			value = default(ValueType);
			return false;
		}
	}
}
