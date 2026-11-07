using SSJJBase.Singleton;
using SSJJUniRx;
using UnityEngine;

namespace SSJJ.Setting;

public class SettingManager : MonoBehaviourSingleton<SettingManager>
{
	public SettingModel Model = new SettingModel();

	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		Model.VSyncOn.Value = PlayerPrefs.GetInt("VSync") != 0;
		Model.VSyncOn.AsObservable().Subscribe(delegate(bool value)
		{
			QualitySettings.vSyncCount = (value ? 1 : 0);
			PlayerPrefs.SetInt("VSync", QualitySettings.vSyncCount);
			PlayerPrefs.Save();
		});
	}
}
