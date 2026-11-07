using Assets.Generated.Table;
using Assets.Sources.Constant;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BigHead;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BigHead;

public class AddHpCrossModel : AbstractModel, IPlaybackSystem
{
	private AddHpCrossViewModel _viewModel;

	private bool _crossCover;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new AddHpCrossViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_CrossColor, SetCrossColor, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiCross_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowHere = arg2;
	}

	private bool GetVisible()
	{
		if (UiIEventCondition.Get_uiCross_HideCross())
		{
			return false;
		}
		if (UiIEventCondition.Get_uiCross_AwpVisible())
		{
			return false;
		}
		if (UiIEventCondition.Get_uiCross_AddHp())
		{
			return !_crossCover;
		}
		return false;
	}

	private void SetWeaponName(string arg1, string arg2)
	{
		WeaponCrossTable.Row row = (string.IsNullOrEmpty(arg2) ? null : WeaponCrossLoader.Instance.Table.Find_Name(arg2));
		_crossCover = row != null && row.SniperCross == WeaponCrossTable.SniperCrossType.Dangong;
	}

	private void SetCrossColor(int ov, int color)
	{
		Color specialColor = CrossColor.Colors[color];
		_viewModel.SpecialColor = specialColor;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
