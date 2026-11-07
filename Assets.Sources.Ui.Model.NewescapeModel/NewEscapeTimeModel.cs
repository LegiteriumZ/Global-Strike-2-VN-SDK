using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.NewescapeModel;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Sound;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Ui.Model.NewescapeModel;

[GameUiTest]
public class NewEscapeTimeModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private NewEscapeTimeViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int timer_audio = 10;

	private ActiveChip _centerActiveChip = new ActiveChip();

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
		_viewModel = new NewEscapeTimeViewModel();
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
			if (tipsEvent[i].Type == NewEscapeMessageType.WAITINGCHASE)
			{
				_centerActiveChip.Time = tipsEvent[i].Time;
				_viewModel.PanelShow = true;
				string assetName = "Assets/Res/Assets/ui/GameGUIRes/newescapemodel/message/massage_start1.png";
				base.Loader.RetriveSprite("ui/newescapemodel", assetName, delegate(Sprite sprite)
				{
					timer_audio = 10;
					_viewModel.GameStartImageSprite = sprite;
					_viewModel.GameStartImageImage.SetNativeSize();
				});
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].Type == NewEscapeMessageType.WARNINGFIELDINFECTION)
			{
				_centerActiveChip.Time = tipsEvent[i].Time;
				_viewModel.PanelShow = true;
				string assetName2 = "Assets/Res/Assets/ui/GameGUIRes/newescapemodel/message/massage_start2.png";
				base.Loader.RetriveSprite("ui/newescapemodel", assetName2, delegate(Sprite sprite)
				{
					_viewModel.GameStartImageSprite = sprite;
					_viewModel.GameStartImageImage.SetNativeSize();
				});
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].Type == NewEscapeMessageType.WARNINGFIELDINFECTIONCANCEL)
			{
				_centerActiveChip.Time = 0;
				_viewModel.PanelShow = false;
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void InitChips()
	{
		_centerActiveChip.Time = 0;
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.PanelShow = _centerActiveChip.Update(_timeComponent);
		if (_viewModel.PanelShow)
		{
			int num = Mathf.CeilToInt((float)_centerActiveChip.Time / 1000f);
			_viewModel.TimeTextString = num.ToString();
			if (timer_audio == num && timer_audio > 0)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/biogamestart", $"Assets/Res/Assets/sound/bioGameStart/{timer_audio}.mp3"), GameSoundManager.Config.AsideVolume);
				timer_audio--;
			}
		}
	}
}
