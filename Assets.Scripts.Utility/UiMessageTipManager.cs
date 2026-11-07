using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utility;

public class UiMessageTipManager : MonoBehaviour
{
	public Text MessageText;

	private float _hideTime;

	public static UiMessageTipManager Instance;

	private void Awake()
	{
		Instance = this;
	}

	public void ShowMessage(string text, float duration)
	{
		MessageText.text = text;
		_hideTime = Time.realtimeSinceStartup + duration;
		MessageText.gameObject.SetObjectActive(isactive: true);
	}

	private void Update()
	{
		if (MessageText.gameObject.IsActiveSelf() && Time.realtimeSinceStartup > _hideTime)
		{
			MessageText.gameObject.SetObjectActive(isactive: false);
		}
	}
}
