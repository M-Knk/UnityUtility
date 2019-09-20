using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityUtility.PropertyAttributes
{
	/// <summary>
	/// EditorGUI.EnumPopup()で表示する.
	/// </summary>
	public class EnumPopupAttribute : PropertyAttribute
	{
		public readonly System.Type enumType;
		public EnumPopupAttribute(System.Type enumType)
		{
			this.enumType = enumType;
		}
	}

#if UNITY_EDITOR
	[CustomPropertyDrawer(typeof(EnumPopupAttribute))]
	public class EnumPopupDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EnumPopupAttribute enumPopupAttribute = (EnumPopupAttribute)attribute;

			if (property.propertyType != SerializedPropertyType.Enum)
			{
				EditorGUI.PropertyField(position, property);
				return;
			}

			System.Array values = System.Enum.GetValues(enumPopupAttribute.enumType);
			System.Enum selected = (System.Enum)values.GetValue(property.enumValueIndex);
			selected = EditorGUI.EnumPopup(position, property.displayName, selected);
			property.enumValueIndex = System.Array.IndexOf(values, selected);
		}
	}
#endif
}