using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class HitCrossModel : AbstractModel, IPlaybackSystem
{
	private HitCrossViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new HitCrossViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_HideCross, SetHideCross, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_ChangRedCrossTime, SetChangRedCrossTime, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_CrossType, SetCrossType, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Left, SetLeft, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Right, SetRight, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Up, SetUp, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Down, SetDown, null, initinvoke: true);
	}

	private void SetCrossType(int ov, int type)
	{
		if (type + 1 == 6)
		{
			_viewModel.ShowRotation = Quaternion.Euler(0f, 0f, 45f);
		}
		else
		{
			_viewModel.ShowRotation = Quaternion.Euler(0f, 0f, 0f);
		}
	}

	private void SetRight(int ov, int value)
	{
		_viewModel.RdPosition = new Vector3(UiIEventCondition.Get_uiCross_Right(), UiIEventCondition.Get_uiCross_Down());
		_viewModel.RuPosition = new Vector3(UiIEventCondition.Get_uiCross_Right(), UiIEventCondition.Get_uiCross_Up());
	}

	private void SetUp(int ov, int value)
	{
		_viewModel.RuPosition = new Vector3(UiIEventCondition.Get_uiCross_Right(), UiIEventCondition.Get_uiCross_Up());
		_viewModel.LuPosition = new Vector3(UiIEventCondition.Get_uiCross_Left(), UiIEventCondition.Get_uiCross_Up());
	}

	private void SetDown(int ov, int value)
	{
		_viewModel.RdPosition = new Vector3(UiIEventCondition.Get_uiCross_Right(), UiIEventCondition.Get_uiCross_Down());
		_viewModel.LdPosition = new Vector3(UiIEventCondition.Get_uiCross_Left(), UiIEventCondition.Get_uiCross_Down());
	}

	private void SetLeft(int ov, int value)
	{
		_viewModel.LdPosition = new Vector3(UiIEventCondition.Get_uiCross_Left(), UiIEventCondition.Get_uiCross_Down());
		_viewModel.LuPosition = new Vector3(UiIEventCondition.Get_uiCross_Left(), UiIEventCondition.Get_uiCross_Up());
	}

	private void SetHideCross(bool ov, bool value)
	{
		CheckVisible();
	}

	private void SetChangRedCrossTime(int ov, int time)
	{
		CheckVisible();
	}

	private void CheckVisible()
	{
		if (UiIEventCondition.Get_uiCross_HideCross())
		{
			_viewModel.ShowHere = false;
		}
		else if (UiIEventCondition.Get_uiCross_ChangRedCrossTime() > 0)
		{
			_viewModel.ShowHere = true;
		}
		else
		{
			_viewModel.ShowHere = false;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
