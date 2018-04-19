using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtility
{
	[ExecuteInEditMode]
	public sealed class Sample_IsPointInTriangle2D : MonoBehaviour
	{
		[SerializeField]
		Material polygonMaterial;
		[SerializeField]
		Transform[] verticeTransforms;
		[SerializeField]
		Transform containedPoint;
		[SerializeField]
		Text resultText;

		Vector2[] vertices = new Vector2[3];

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				pos.z = containedPoint.position.z;
				containedPoint.position = pos;
			}

			var verticesLength = verticeTransforms.Length;
			if (vertices.Length != verticesLength)
			{
				vertices = new Vector2[verticesLength];
			}
			for (int i = 0; i < verticesLength; ++i)
			{
				vertices[i] = verticeTransforms[i].position;
			}

			// containedPointがverticesに含まれているかどうか.
			bool isInside = MathEx.IsPointInTriangleStrip2D(containedPoint.position, vertices);
			resultText.text = isInside ? "<color=red>Inside</color>" : "Outside";
		}

		void OnRenderObject()
		{
			if (Camera.current != Camera.main)
			{
				return;
			}

			GL.PushMatrix();
			polygonMaterial.SetPass(0);
			GL.Begin(GL.TRIANGLE_STRIP);
			foreach (var vertice in verticeTransforms)
			{
				GL.Vertex(vertice.position);
			}
			GL.End();
			GL.PopMatrix();
		}
	}
}