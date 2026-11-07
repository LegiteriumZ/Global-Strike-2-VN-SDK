using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.GroupGunKing;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.GroupGunKing;

public class GroupGunKingMessageModel : AbstractModel, IPlaybackSystem
{
	private GroupGunKingMessageViewModel _viewModel;

	private int _messageShowTimer;

	private int _index;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new GroupGunKingMessageViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_messageShowTimer >= 0)
		{
			_messageShowTimer -= _timeComponent.FrameInterval;
			if (_index != _messageShowTimer / 1000 + 1)
			{
				_index = _messageShowTimer / 1000 + 1;
				base.Loader.RetriveSprite("ui/groupgunkingmodel", "Assets/Res/Assets/ui/GameGUIRes/groupGunkingModel/message/gamestart" + _index + ".png", delegate(Sprite sprite)
				{
					_viewModel.StartGameSprite = sprite;
				});
			}
		}
		else
		{
			_viewModel.CenterShow = false;
			_viewModel.TopShow = false;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotify(24, UiIEventCondition.Get_groupGunKingMessageData_Type, SetType, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_groupGunKingMessageData_Phase, SetPhase, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_groupGunKingMessageData_PhaseScore, SetPhaseScore, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_groupGunKingMessageData_WinScore, SetWinScore, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_groupGunKingMessageData_LoseScore, SetLoseScore, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_groupGunKingMessageData_WinTeam, SetWinTeam, null, initinvoke: true);
	}

	private void SetWinTeam(int ov, int team)
	{
		if (team == 1)
		{
			base.Loader.RetriveSprite("ui/groupgunkingmodel", "Assets/Res/Assets/ui/GameGUIRes/groupGunkingModel/message/t.png", delegate(Sprite sprite)
			{
				_viewModel.WinTeamSprite = sprite;
			});
			GroupGunKingMessageViewModel viewModel = _viewModel;
			bool tWinScoreShow = (_viewModel.CtLoseScoreShow = true);
			viewModel.TWinScoreShow = tWinScoreShow;
			GroupGunKingMessageViewModel viewModel2 = _viewModel;
			tWinScoreShow = (_viewModel.TLoseScoreShow = false);
			viewModel2.CtWinScoreShow = tWinScoreShow;
		}
		else
		{
			base.Loader.RetriveSprite("ui/groupgunkingmodel", "Assets/Res/Assets/ui/GameGUIRes/groupGunkingModel/message/ct.png", delegate(Sprite sprite)
			{
				_viewModel.WinTeamSprite = sprite;
			});
			GroupGunKingMessageViewModel viewModel3 = _viewModel;
			bool tWinScoreShow = (_viewModel.CtLoseScoreShow = false);
			viewModel3.TWinScoreShow = tWinScoreShow;
			GroupGunKingMessageViewModel viewModel4 = _viewModel;
			tWinScoreShow = (_viewModel.TLoseScoreShow = true);
			viewModel4.CtWinScoreShow = tWinScoreShow;
		}
	}

	private void SetLoseScore(int ov, int score)
	{
		_viewModel.CtLoseScoreString = score.ToString();
		_viewModel.TLoseScoreString = score.ToString();
	}

	private void SetWinScore(int ov, int score)
	{
		_viewModel.TWinScoreString = score.ToString();
		_viewModel.CtWinScoreString = score.ToString();
	}

	private void SetPhaseScore(int ov, int score)
	{
		_viewModel.PhaseScoreString = score.ToString();
	}

	private void SetPhase(int ov, int phase)
	{
		for (int i = 0; i <= 5; i++)
		{
			_viewModel.SetPhaseShow(i, i == phase);
		}
		if (phase <= 5)
		{
			base.Loader.RetriveSprite("ui/groupgunkingmodel", "Assets/Res/Assets/ui/GameGUIRes/groupGunkingModel/message/phase" + phase + ".png", delegate(Sprite sprite)
			{
				_viewModel.NextPhaseSprite = sprite;
			});
		}
	}

	private void SetType(int ov, int type)
	{
		HideMessage();
		switch (type)
		{
		case 1:
			_viewModel.StartGameShow = true;
			_viewModel.CenterShow = true;
			_viewModel.MessageShow = true;
			_viewModel.TopShow = true;
			_messageShowTimer = 5000;
			break;
		case 2:
			_viewModel.PhaseEndShow = true;
			_viewModel.TopShow = true;
			_messageShowTimer = 5000;
			break;
		}
	}

	private void HideMessage()
	{
		_viewModel.CenterShow = false;
		_viewModel.StartGameShow = false;
		_viewModel.MessageShow = false;
		_viewModel.PhaseEndShow = false;
		_viewModel.TopShow = false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
