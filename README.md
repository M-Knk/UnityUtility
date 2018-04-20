# UnityUtility
Unityで実装した処理を汎用的にしたもの。<br />
使う機会があるかどうかは置いておいて、再利用しやすいようにstaticクラスのメソッドにする方針。

## IsPointInTriangle2D
三角形の頂点と点を渡して、点が三角形の内部にあるかどうかを返す関数。
* bool IsPointInTriangle2D(Vector2 p, Vector2 v1, Vector2 v2, Vector2 v3)<br />点が指定した頂点からなる三角形の内側にあるかどうかを判定する
* bool IsPointInTriangleStrip2D(Vector2 p, Vector2[] vertices)<br />点が指定した頂点からなる多角形の内側にあるかどうかを判定する
* bool IsPointInMesh2D(Vector2 p, Mesh mesh)<br />点がメッシュの内側にあるかどうかを判定する
![IsPointInTriangle2D](https://github.com/M-Knk/UnityUtility/blob/sample/SampleGif/IsPointInTriangle2D.gif)

## Tuple
2,3個の値を持つ構造体。ジェネリック。

## CoroutineHolder
コルーチンを1つだけ保持するクラス。新たにStartしたら古いものを止める。
