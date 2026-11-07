using System.Collections.Generic;
using Assets.Sources.Chat;
using Assets.Sources.Components.Interface.Info.Chat;
using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class ChattingBigHornModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetBattleRoomContext
{
	private ChattingBigHornViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	private const int BighornShowTimer = 10000;

	private const int WaitmoveTimer = 1000;

	private const float ChattingTextSpeed = 0.05f;

	private ChatContext _chatContext;

	private int _waitMoveTime;

	private ActiveChip _panelActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		_chatContext = Contexts.sharedInstance.chat;
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new ChattingBigHornViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_viewModel.PanelShow)
		{
			if (!_chatContext.hasChatJobHistroy)
			{
				return;
			}
			List<IChatHistroyData> group = _chatContext.chatJobHistroy.BigHornList.Group;
			if (group.Count > 0)
			{
				ChatHistroyData chatHistroyData = (ChatHistroyData)(object)group[0];
				if (chatHistroyData.MsgType == "big_horn2")
				{
					if (Contexts.sharedInstance.player.myPlayerEntity.basicInfo.PlayerName.Equals(chatHistroyData.SenderName))
					{
						_viewModel.PlayerNameString = ScriptLocalization.Get("MY");
					}
					else
					{
						_viewModel.PlayerNameString = chatHistroyData.SenderName;
					}
					_viewModel.PlayerNameTextcolor = new Color(1f, 0.797f, 1f);
					_viewModel.ChatTextTextcolor = new Color(1f, 1f, 1f);
				}
				else
				{
					_viewModel.PlayerNameString = "";
					_viewModel.ChatTextTextcolor = new Color(1f, 1f, 0f);
				}
				_viewModel.ChatTextString = chatHistroyData.AssembleBody;
				_viewModel.ChatTextPosition = new Vector3(0f, 0f);
				_waitMoveTime = 0;
				group.RemoveAt(0);
				_panelActiveChip.Time = 10000;
			}
			_chatContext.chatJobHistroy.BigHornList.Mark = false;
			return;
		}
		_waitMoveTime += _timeComponent.FrameInterval;
		if (_waitMoveTime > 1000 && _viewModel.ChatTextSize.x > _viewModel.MaskSize.x)
		{
			_viewModel.ChatTextPosition = new Vector3((int)(-0.05f * (float)(_waitMoveTime - 1000)), 0f);
			if (_viewModel.ChatTextSize.x + _viewModel.ChatTextPosition.x <= _viewModel.MaskSize.x)
			{
				_waitMoveTime = 0;
				_viewModel.ChatTextPosition = new Vector3(0f, 0f);
			}
		}
		else
		{
			_viewModel.ChatTextPosition = new Vector3(0f, 0f);
		}
		_viewModel.MaskSize = new Vector3(403f - _viewModel.PlayerNameSize.x, 28f);
		_viewModel.MaskSize += new Vector3(_viewModel.MaskSize.x % 2f, 0f);
		_viewModel.LayoutHlayoutupdate();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		IGameRule rule = _gameRuleContext.currentRule.Rule;
		int raceType = _battleRoomContext.roomData.Data.RaceType;
		if (rule.IsExplode())
		{
			_viewModel.BackPosition = new Vector3(0f, -60f);
		}
		else if (raceType == 9)
		{
			_viewModel.BackPosition = new Vector3(0f, -80f);
		}
		else if (rule.IsBio())
		{
			_viewModel.BackPosition = new Vector3(0f, -90f);
		}
		else
		{
			switch (raceType)
			{
			case 10:
				_viewModel.BackPosition = new Vector3(0f, -140f);
				break;
			case 26:
				_viewModel.BackPosition = new Vector3(0f, -125f);
				break;
			default:
				_viewModel.BackPosition = new Vector3(0f, -55f);
				break;
			}
		}
		_viewModel.PanelShow = false;
	}

	private void InitChips()
	{
		_panelActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.PanelShow = _panelActiveChip.Update(_timeComponent);
	}
}
