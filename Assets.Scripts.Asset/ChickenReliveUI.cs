using UnityEngine.UI;

namespace Assets.Scripts.Asset;

public class ChickenReliveUI : ReusableGameObjectBase
{
	public Image ProgressImage;

	public Text TimeText;

	public override void OnCreated()
	{
		ProgressImage = GetGameObject().transform.Find("WorldSpace/Back/Progress").GetComponent<Image>();
		TimeText = GetGameObject().transform.Find("WorldSpace/Back/Time").GetComponent<Text>();
	}

	public override void OnRecycle()
	{
	}
}
