using UnityEngine.UI;

namespace Assets.Scripts.ResScripts.Refrenceless.DyVersion;

public static class ImageExtension
{
	public static void NotifyUiDyLoadEnable(this Image image, bool enable)
	{
		UiRefrenceAssetInfoResUnit component = image.GetComponent<UiRefrenceAssetInfoResUnit>();
		if (component != null)
		{
			component.NotifyEnable(enable);
		}
		else
		{
			image.enabled = enable;
		}
	}
}
