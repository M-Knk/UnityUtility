using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityUtility.OutsideResource
{
	public class LocalTexture
	{
		public static IEnumerator GetTexture(string file, System.Action<Texture2D> onComplete)
		{
			UnityWebRequest www = UnityWebRequestTexture.GetTexture(file);
			yield return www.SendWebRequest();

			Texture2D myTexture = null;
			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
			}

			if (onComplete != null)
			{
				onComplete(myTexture);
			}
		}
	}
}