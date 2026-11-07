using UnityEngine;

namespace Assets.Res.Assets.Scripts;

[ExecuteInEditMode]
public class TipsBack : MonoBehaviour
{
	public RectTransform RelativeObj;

	private void Update()
	{
		if (base.gameObject.IsActiveSelf())
		{
			GetComponent<RectTransform>().sizeDelta = new Vector2((int)RelativeObj.sizeDelta.x + 10, (int)RelativeObj.sizeDelta.y + 10);
		}
	}
}
