using SSJJBase.Singleton;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Assets.Sources.Utils;

public class MyQualitySettings : MonoBehaviourSingleton<MyQualitySettings>
{
	public enum QualityLevel
	{
		Off,
		Low,
		Medium,
		High
	}

	public enum DamageShowLevel
	{
		ShowAll,
		ShowBoss,
		None
	}

	public void SetColorGradingOn(bool isOn)
	{
		SetPostEffectOn<ColorGrading>(isOn);
	}

	private void SetPostEffectOn<T>(bool isOn) where T : PostProcessEffectSettings
	{
		PostProcessVolume[] array = Object.FindObjectsOfType<PostProcessVolume>();
		foreach (PostProcessVolume postProcessVolume in array)
		{
			if (postProcessVolume.profile.HasSettings<T>())
			{
				postProcessVolume.profile.GetSetting<T>().enabled.value = isOn;
			}
		}
	}

	public void SetAntiAliasingLevel(PostProcessLayer.Antialiasing mode)
	{
		Object.FindObjectOfType<PostProcessLayer>().antialiasingMode = mode;
	}

	public void SetShadowLevel(QualityLevel level)
	{
		QualitySettings.shadowNearPlaneOffset = 0f;
		QualitySettings.shadowProjection = ShadowProjection.StableFit;
		switch (level)
		{
		case QualityLevel.Off:
			QualitySettings.shadows = ShadowQuality.Disable;
			break;
		case QualityLevel.Low:
			QualitySettings.shadowDistance = 2000f;
			QualitySettings.shadows = ShadowQuality.HardOnly;
			QualitySettings.shadowResolution = ShadowResolution.Low;
			QualitySettings.shadowCascades = 0;
			break;
		case QualityLevel.Medium:
			QualitySettings.shadowDistance = 5000f;
			QualitySettings.shadows = ShadowQuality.All;
			QualitySettings.shadowResolution = ShadowResolution.Medium;
			QualitySettings.shadowCascades = 2;
			break;
		case QualityLevel.High:
			QualitySettings.shadowDistance = 10000f;
			QualitySettings.shadows = ShadowQuality.All;
			QualitySettings.shadowResolution = ShadowResolution.High;
			QualitySettings.shadowCascades = 2;
			break;
		}
	}
}
