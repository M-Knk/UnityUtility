using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityUtility
{
	public sealed class CircularMotion : MonoBehaviour
	{
		[SerializeField]
		Vector3 center;
		[SerializeField]
		Vector3 axis = new Vector3(0f, 0f, -1f);
		[SerializeField]
		float angleSpeed = 360f;

		void Update()
		{
			var matrix = Matrix4x4.Translate(center);
			matrix *= Matrix4x4.Rotate(Quaternion.AngleAxis(angleSpeed * Time.deltaTime, axis));
			matrix *= Matrix4x4.Translate(-center);
			transform.position = matrix.MultiplyPoint(transform.position);
		}

#if UNITY_EDITOR
		const int circleResolution = 16;
		readonly Vector3[] circlePoints = new Vector3[circleResolution + 1];
		public void OnSceneGUI()
		{
			center = Handles.DoPositionHandle(center, transform.rotation);

			var position = transform.position;
			var diff = position - center;
			circlePoints[0] = position;
			var mat = Matrix4x4.Rotate(Quaternion.AngleAxis(360f / circleResolution, axis));
			for(int i = 1, length = circlePoints.Length; i < length; ++i)
			{
				diff = mat.MultiplyPoint3x4(diff);
				circlePoints[i] = center + diff;
			}
			Handles.DrawPolyLine(circlePoints);
		}
#endif
	}

#if UNITY_EDITOR
	[CustomEditor(typeof(CircularMotion))]
	public sealed class CircularMotionEditor : Editor
	{
		void OnSceneGUI()
		{
			((CircularMotion)target).OnSceneGUI();
		}
	}
#endif
}