using Assets.Libs.UiEditor.RunTime;
using Assets.Sources.Components.GameRule.Common;
using SSJJUIEditor.UI;
using UnityEngine;

namespace Assets.Sources.Modules.Ui.UiEditorRunTime.UiLogicSystem;

public class SkatePress : DefaultRunTimeGui
{
	private GameObject _progress;

	private GameObject _show;

	public SkatePress()
	{
		base.Key = "SkatePressGui";
	}

	public override void Binding(UiEditorLayoutAsset asset)
	{
		base.Binding(asset);
		if (base.BindingGameObject != null)
		{
			_show = base.BindingGameObject.transform.Find("Show").gameObject;
			_progress = base.BindingGameObject.transform.Find("Show/ProgressImage1").gameObject;
			base.BindingGameObject.SetObjectActive(isactive: true);
		}
	}

	public override void PlayBack()
	{
		SkatePressComponent skatePress = Contexts.sharedInstance.gameRule.skatePress;
		bool isactive = false;
		if (skatePress != null && skatePress.IsPress && Time.time - skatePress.StartTime < skatePress.RemainTime)
		{
			RunTimeBindingManager.Instance.RefreshImageFillmount(_progress, (Time.time - skatePress.StartTime) / skatePress.RemainTime);
			isactive = true;
		}
		_show.SetObjectActive(isactive);
	}
}
