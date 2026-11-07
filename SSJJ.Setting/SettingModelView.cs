using SSJJ.Utility;
using SSJJBase.Singleton;
using SSJJUniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SSJJ.Setting;

public class SettingModelView : MonoBehaviour
{
	public Toggle VsyncToggle;

	private void Start()
	{
		MonoBehaviourSingleton<SettingManager>.Instance.Model.VSyncOn.SubscribeToToggle(VsyncToggle);
		VsyncToggle.OnValueChangedAsObservable().Subscribe(delegate(bool value)
		{
			MonoBehaviourSingleton<SettingManager>.Instance.Model.VSyncOn.Value = value;
		});
	}
}
