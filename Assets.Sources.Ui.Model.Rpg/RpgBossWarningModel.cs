using Assets.Generated.Table;
using Assets.Scripts.Utility.Sound;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgBossWarningModel : AbstractModel, IPlaybackSystem, ISetMessageContext
{
	private RpgBossWarningViewModel _viewModel;

	private static AssetInfo _bossBattle = new AssetInfo("sound/pvecommon", "Assets/Res/Assets/sound/pvecommon/bossbattle.mp3");

	private int _time = -2000;

	private PingPongChip _warnningPingPongChip = new PingPongChip();

	private ActiveChip _panelActiveChip = new ActiveChip();

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgBossWarningViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.PanelRootshow)
		{
			if (_timeComponent.ClientRealTime - _time >= 1900)
			{
				_time = _timeComponent.ClientRealTime;
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, _bossBattle, GameSoundManager.Config.AsideVolume);
			}
			_viewModel.WarnningAlpha = _warnningPingPongChip.Update(_timeComponent);
			RollImage rollImage = _viewModel.UI.Get<RollImage>("Up2");
			RollImage rollImage2 = _viewModel.UI.Get<RollImage>("Down2");
			float num = 0.0008f * (float)_timeComponent.FrameInterval;
			rollImage.RollXAmount = (rollImage.RollXAmount + num) % 1f;
			rollImage2.RollXAmount = Mathf.Max(0f, rollImage2.RollXAmount - num);
			if (rollImage2.RollXAmount - num < 0f)
			{
				rollImage2.RollXAmount = 1f;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_pveMessage_PveMessageData, SetPveMessageData, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveMessage_BossWarning, SetBossWarning, null, initinvoke: true);
	}

	private void SetBossWarning(bool ov, bool flag)
	{
		if (flag)
		{
			_viewModel.PanelObj.HideEverythingExceptGameObject();
		}
		else
		{
			_viewModel.PanelObj.RecoveryEverything();
		}
	}

	private void SetPveMessageData(PveMessageData ov, PveMessageData msg)
	{
		if (msg != null && msg.Type == TowerDefenseMessageType.SHOWBOSSWARNING)
		{
			_panelActiveChip.Time = 5500;
			MonoBehaviourSingleton<BgmSoundManager>.Instance.playBgmSound("1", 5500);
		}
	}

	private void InitChips()
	{
		_warnningPingPongChip.From = 1f;
		_warnningPingPongChip.To = 0.3f;
		_warnningPingPongChip.Time = 1000;
		_panelActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		if (_messageContext.hasPveMessage)
		{
			_viewModel.PanelRootshow = false;
			_viewModel.PanelRootshow = (_messageContext.pveMessage.BossWarning = _panelActiveChip.Update(_timeComponent));
		}
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
