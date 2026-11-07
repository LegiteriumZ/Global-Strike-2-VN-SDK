using Assets.Sources.Modules.Ui;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using I2.Loc;
using SSJJUIEditor.RunTime;
using UnityEngine;

namespace Assets.Libs.UiEditor.RunTime;

public class RunTimeBindingManager : BaseRunTimeBindingManager
{
	private static RunTimeBindingManager _intance;

	public static RunTimeBindingManager Instance
	{
		get
		{
			if (_intance == null)
			{
				_intance = new RunTimeBindingManager();
			}
			return _intance;
		}
	}

	public override void Init()
	{
		base.Init();
		_loader = (UiResourcesLoader)AbstractModel.GetUiResourceLoader();
	}

	public override void RefreshCommonTxt(GameObject objGameObject, string txtSign)
	{
		if (string.IsNullOrEmpty(ScriptLocalization.Get(txtSign)))
		{
			LanguageUtils.GetWeaponCnName(txtSign);
		}
		base.RefreshCommonTxt(objGameObject, txtSign);
	}

	protected override void RegisterKeyCode()
	{
		base.RegisterKeyCode();
		if (!Contexts.sharedInstance.userCommand.input.KeyboardResponders.Contains(this))
		{
			Contexts.sharedInstance.userCommand.input.KeyboardResponders.Add(this);
		}
	}

	public new void Clear()
	{
		base.Clear();
	}
}
