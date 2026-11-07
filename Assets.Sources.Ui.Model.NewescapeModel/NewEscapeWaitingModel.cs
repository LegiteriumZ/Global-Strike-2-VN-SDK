using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.NewescapeModel;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.NewescapeModel;

[GameUiTest]
public class NewEscapeWaitingModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private NewEscapeWaitingViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new NewEscapeWaitingViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.PanelShow = false;
		NotifyManager.MakeNotifyClass(117, GetTipsList, SetTipsEvent, initinvoke: true);
	}

	public List<NewEscapeMessageData> GetTipsList()
	{
		return Contexts.sharedInstance.message.newEscapeTipsShow.TipsEvent;
	}

	protected virtual void SetTipsEvent(List<NewEscapeMessageData> ov, List<NewEscapeMessageData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].Type == NewEscapeMessageType.WAITINGPLAYER)
			{
				NewEscapeMessageData temp = tipsEvent[i];
				_viewModel.PanelShow = true;
				string assetName = "Assets/Res/Assets/ui/GameGUIRes/newescapemodel/message/massage_start_" + _raceType + ".png";
				base.Loader.RetriveSprite("ui/newescapemodel", assetName, delegate(Sprite sprite)
				{
					_viewModel.GameStartImageSprite = sprite;
					_viewModel.TimeTextString = temp.IntData[0] + "/" + temp.IntData[1];
				});
				if (temp.IntData[0] >= temp.IntData[1])
				{
					_viewModel.PanelShow = false;
				}
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
