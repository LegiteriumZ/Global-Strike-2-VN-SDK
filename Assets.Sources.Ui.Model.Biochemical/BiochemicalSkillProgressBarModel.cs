using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalSkillProgressBarModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetPlayerContext
{
	private BiochemicalskillprogressbarViewModel _viewModel = new BiochemicalskillprogressbarViewModel();

	private int _currTime;

	private int _totalTime;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PlayerDeathcallFlag, SetPlayerDeathcallFlag, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_BeDeathCall, SetBeDeathCall, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Phasetransfer, SetPhasetransfer, null, initinvoke: true);
		NotifyManager.MakeNotifyClass(12, UiIEventCondition.Get_uiSkill_Skills, SetSkills, initinvoke: true);
	}

	private void SetSkills(Dictionary<int, SkillInfoData> arg1, Dictionary<int, SkillInfoData> arg2)
	{
		UpdateTotalTime();
	}

	private void SetPhasetransfer(bool arg1, bool arg2)
	{
		UpdateTotalTime();
	}

	private void SetCareer(string arg1, string arg2)
	{
		UpdateTotalTime();
	}

	private void SetBeDeathCall(bool arg1, bool arg2)
	{
		UpdateTotalTime();
	}

	private void SetPlayerDeathcallFlag(bool arg1, bool arg2)
	{
		UpdateTotalTime();
	}

	private void UpdateTotalTime()
	{
		Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
		if (UiIEventCondition.Get_pveState_PlayerDeathcallFlag() || UiIEventCondition.Get_pveState_BeDeathCall())
		{
			_totalTime = 4000;
		}
		else if (UiIEventCondition.Get_cameraOwnerData_Career() == "queen" && uiSkill_Skills != null && uiSkill_Skills.ContainsKey(125) && uiSkill_Skills[125].SkillName > 0)
		{
			_totalTime = 5000;
		}
		else if (UiIEventCondition.Get_pveState_Phasetransfer())
		{
			if (_gameRuleContext.currentRule.Rule.IsBio3())
			{
				_totalTime = _playerContext.myPlayerEntity.GetPlayerInfo().Num1;
			}
			else
			{
				_totalTime = 1500;
			}
		}
		else
		{
			_currTime = 0;
			_totalTime = 0;
		}
	}

	public void OnPlayback()
	{
		if (_totalTime > 0)
		{
			_viewModel.BottomShow = true;
			_currTime += _timeComponent.FrameInterval;
			_viewModel.ProgressImageFillamount = (float)_currTime / (float)_totalTime;
		}
		else
		{
			_viewModel.BottomShow = false;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
