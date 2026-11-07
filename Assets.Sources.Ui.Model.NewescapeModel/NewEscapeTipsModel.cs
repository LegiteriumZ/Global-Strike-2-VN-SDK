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
public class NewEscapeTipsModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private NewEscapeTipsViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

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
		_viewModel = new NewEscapeTipsViewModel();
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
			if (tipsEvent[i].Type == NewEscapeMessageType.WARNINGCHASE || tipsEvent[i].Type == NewEscapeMessageType.STARTCHASE || tipsEvent[i].Type == NewEscapeMessageType.WAITINGFINALESCAPE || tipsEvent[i].Type == NewEscapeMessageType.WARNINGFINALESCAPE || tipsEvent[i].Type == NewEscapeMessageType.OPENDOOR)
			{
				_centerActiveChip.Time = tipsEvent[i].Time;
				NewEscapeMessageType type = tipsEvent[i].Type;
				_viewModel.PanelShow = true;
				string assetName = "Assets/Res/Assets/ui/GameGUIRes/newescapemodel/message/message_" + (int)type + ".png";
				base.Loader.RetriveSprite("ui/newescapemodel", assetName, delegate(Sprite sprite)
				{
					_viewModel.messageSprite = sprite;
					_viewModel.messageImage.SetNativeSize();
				});
				if (tipsEvent[i].Type == NewEscapeMessageType.STARTCHASE || tipsEvent[i].Type == NewEscapeMessageType.WARNINGCHASE)
				{
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/autosound", $"Assets/Res/Assets/sound/autoSound/{6931}.mp3"), GameSoundManager.Config.AsideVolume);
				}
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
	}
}
