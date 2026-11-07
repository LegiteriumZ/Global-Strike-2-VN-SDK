using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Mechwarrior;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Mechwarrior;

public class MechwarriorSelectMechWeaponModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ISetGameRuleContext
{
	private MechwarriorSelectMechWeaponViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MechwarriorSelectMechWeaponViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bioSelectAvatarData_SelectTime, SetSelectTime, null, initinvoke: true);
	}

	private void SetSelectTime(int ov, int time)
	{
		_viewModel.BottomShow = time > 0;
		if (_viewModel.BottomShow)
		{
			_viewModel.TimeTextString = (time / 1000).ToString();
			_viewModel.NohaveShow1 = false;
			_viewModel.NohaveShow2 = false;
			_viewModel.NohaveShow3 = !UiIEventCondition.Get_bioSelectAvatarData_HasModel3();
			_viewModel.SelectedShow1 = UiIEventCondition.Get_bioSelectAvatarData_CheckedModel() == 0;
			_viewModel.SelectedShow2 = UiIEventCondition.Get_bioSelectAvatarData_CheckedModel() == 1;
			_viewModel.SelectedShow3 = UiIEventCondition.Get_bioSelectAvatarData_CheckedModel() == 2;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (!_gameRuleContext.hasBioSelectAvatarData)
		{
			return false;
		}
		bool flag = false;
		if (_viewModel.BottomShow)
		{
			if (key.CheckEqualKeyCode(KeyCode.Alpha1))
			{
				flag = true;
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha2))
			{
				flag = true;
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha3) && UiIEventCondition.Get_bioSelectAvatarData_HasModel3())
			{
				flag = true;
			}
			if (flag)
			{
				_viewModel.BottomShow = false;
				_gameRuleContext.bioSelectAvatarData.SelectTime = 0;
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
