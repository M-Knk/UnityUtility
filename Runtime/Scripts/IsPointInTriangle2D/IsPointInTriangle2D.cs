using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityUtility
{
	public static partial class MathEx
	{
		/// <summary>
		/// 点がメッシュの内側にあるかどうかを判定する.
		/// </summary>
		/// <param name="p">点の座標</param>
		/// <param name="mesh">メッシュ</param>
		public static bool IsPointInMesh2D(Vector2 p, Mesh mesh)
		{
			int containsTriangleIndex;
			return IsPointInMesh2D(p, mesh, out containsTriangleIndex);
		}
		/// <summary>
		/// 点がメッシュの内側にあるかどうかを判定する.
		/// </summary>
		/// <param name="p">点の座標</param>
		/// <param name="mesh">メッシュ</param>
		/// <param name="containsTriangleIndex">点が内側にあった場合、点を含む三角形を構成するtrianglesの先頭のインデックスを返す</param>
		public static bool IsPointInMesh2D(Vector2 p, Mesh mesh, out int containsTriangleIndex)
		{
			containsTriangleIndex = -1;
			int[] triangles = mesh.triangles;
			Vector3[] vertices = mesh.vertices;
			for (int i = 0, length = triangles.Length; i < length - 2; ++i)
			{
				if (IsPointInTriangle2D(p, vertices[triangles[i]], vertices[triangles[i + 1]], vertices[triangles[i + 2]]))
				{
					containsTriangleIndex = i;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 点が指定した頂点からなる多角形の内側にあるかどうかを判定する.
		/// </summary>
		/// <param name="p">点の座標</param>
		/// <param name="vertices">頂点の座標</param>
		public static bool IsPointInTriangleStrip2D(Vector2 p, Vector2[] vertices)
		{
			int containsIndex;
			return IsPointInTriangleStrip2D(p, vertices, out containsIndex);
		}
		/// <summary>
		/// 点が指定した頂点からなる多角形の内側にあるかどうかを判定する.
		/// </summary>
		/// <param name="p">点の座標</param>
		/// <param name="vertices">頂点の座標</param>
		/// <param name="containsIndex">点が内側にあった場合、点を含む三角形を構成するverticesの先頭のインデックスを返す</param>
		public static bool IsPointInTriangleStrip2D(Vector2 p, Vector2[] vertices, out int containsIndex)
		{
			containsIndex = -1;
			for (int i = 0, length = vertices.Length; i < length - 2; ++i)
			{
				if (IsPointInTriangle2D(p, vertices[i], vertices[i + 1], vertices[i + 2]))
				{
					containsIndex = i;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 点が指定した頂点からなる三角形の内側にあるかどうかを判定する.
		/// </summary>
		/// <param name="p">点の座標</param>
		/// <param name="v1">頂点1の座標</param>
		/// <param name="v2">頂点2の座標</param>
		/// <param name="v3">頂点3の座標</param>
		public static bool IsPointInTriangle2D(Vector2 p, Vector2 v1, Vector2 v2, Vector2 v3)
		{
			bool b1 = GetSide2D(p, v1, v2) < 0f;
			bool b2 = GetSide2D(p, v2, v3) < 0f;
			bool b3 = GetSide2D(p, v3, v1) < 0f;
			return ((b1 == b2) && (b2 == b3));
		}

		static float GetSide2D(Vector2 p, Vector2 v1, Vector2 v2)
		{
			return (p.x - v2.x) * (v1.y - v2.y) - (v1.x - v2.x) * (p.y - v2.y);
		}
	}
}