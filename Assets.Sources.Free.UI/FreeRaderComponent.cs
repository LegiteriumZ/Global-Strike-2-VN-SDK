using Assets.Sources.Free.Data;
using Assets.Sources.Free.Utility;
using NotifyEvent;
using SSJJBase.Singleton;

namespace Assets.Sources.Free.UI;

public class FreeRaderComponent : FreeBaseComponent
{
	private bool _set;

	public FreeRaderComponent()
	{
		base.Type = 5;
		base.ValueType = 2;
		UnityObject = UnityUiUtility.CreateEmptyDisplayObject("Rader");
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	public void SetRadarActive(bool isActive)
	{
		if (isActive)
		{
			NotifyManager.ForceInvoke(71);
		}
		else
		{
			NotifyManager.ForceInvoke(72);
		}
	}

	public override void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		if (UnityObject.Parent != null && !UnityObject.Parent.gameObject.activeInHierarchy && !_set)
		{
			_set = true;
			SetRadarActive(isActive: false);
		}
	}

	public override IFreeComponent Clone()
	{
		return new FreeRaderComponent();
	}
}
