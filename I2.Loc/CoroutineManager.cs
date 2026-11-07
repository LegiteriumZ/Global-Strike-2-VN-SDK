using UnityEngine;

namespace I2.Loc;

public class CoroutineManager : MonoBehaviour
{
	private static CoroutineManager mInstance;

	public static CoroutineManager pInstance
	{
		get
		{
			if (mInstance == null)
			{
				GameObject obj = new GameObject("GoogleTranslation");
				obj.hideFlags |= HideFlags.HideAndDontSave;
				mInstance = obj.AddComponent<CoroutineManager>();
			}
			return mInstance;
		}
	}
}
