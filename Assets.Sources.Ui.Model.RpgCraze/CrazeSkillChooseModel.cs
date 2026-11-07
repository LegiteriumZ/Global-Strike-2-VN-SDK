using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgCraze;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.RpgCraze;

[GameUiTest]
public class CrazeSkillChooseModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetBattleServerContext, ICursorControl
{
	private CrazeSkillChooseViewModel _viewModel;

	private BattleServerContext _battleServerContext;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private List<List<int>> _skillData = new List<List<int>>();

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CrazeSkillChooseViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null)
		{
			_ = _viewModel.IsInited;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		for (int j = 1; j <= 3; j++)
		{
			int i1 = j;
			_viewModel.CreateTriggerEntry(_viewModel.GetChooseTriggers(i1), EventTriggerType.PointerClick, delegate
			{
				SkillChooseClick(i1);
			});
		}
		NotifyManager.MakeNotify(81, UiIEventCondition.Get_Craze_SkillChoose, ShowPanel);
	}

	private void ShowPanel(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		_skillData.Clear();
		for (int i = 1; i <= 3; i++)
		{
			_viewModel.SetChooseShow(i, value: false);
			_viewModel.SetDesShow(i, value: false);
		}
		for (int j = 0; j < _gameRuleContext.craze.SkillChoseData.Count; j++)
		{
			CrazeSkillData crazeSkillData = _gameRuleContext.craze.SkillChoseData[j];
			_skillData.Add(new List<int> { crazeSkillData.SklId, crazeSkillData.Lv });
			_viewModel.SetDesString(j + 1, crazeSkillData.TextId);
			_viewModel.SetChooseShow(j + 1, value: true);
			_viewModel.SetDesShow(j + 1, value: true);
		}
	}

	private void SkillChooseClick(int index)
	{
		CrazeSkillData message = new CrazeSkillData
		{
			SklId = _skillData[index - 1][0],
			Lv = _skillData[index - 1][1]
		};
		_battleServerContext.battleServer.Server.SendTcpMessage(37, message);
		_viewModel.ShowShow = false;
	}

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 16384;
	}

	public int GetForbidButtons()
	{
		return 175;
	}
}
