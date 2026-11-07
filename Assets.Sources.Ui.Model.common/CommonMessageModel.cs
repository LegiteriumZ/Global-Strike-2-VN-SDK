using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class CommonMessageModel : AbstractModel, IPlaybackSystem
{
	private CommonmessageViewModel _viewModel;

	private string _messageAssetBoundle;

	private string _messageAssetName;

	private string _selfMessageAssetBoundle;

	private string _selfMessageAssetName;

	private string _stateMessageAssetBoundle = "";

	private string _stateMessageAssetName = "";

	private ActiveChip _messageImageActiveChip = new ActiveChip();

	private ActiveChip _messageTextActiveChip = new ActiveChip();

	private ActiveChip _selfMessageImageActiveChip = new ActiveChip();

	private ActiveChip _stateMessageImageActiveChip = new ActiveChip();

	private ActiveChip _weaponEffectLevelTipsMessageImageActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CommonmessageViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotify(42, UiIEventCondition.Get_sparyMessageData_Changed, UpdateSparyMessage, initinvoke: true);
		NotifyManager.MakeNotify(13, UiIEventCondition.Get_gameMessageData_Changed, UpdateGameBaseMessage, initinvoke: true);
		NotifyManager.MakeNotify(87, UiIEventCondition.Get_weaponParticleEffectLevel_Changed, UpdateWeaponEffectLevelMessage, initinvoke: true);
		NotifyManager.MakeNotifyClass(14, UiIEventCondition.Get_gameTipsShow_TipsEvent, UpdatePlayerBeAttackedMessage, initinvoke: true);
	}

	private void UpdateImage()
	{
		if (_viewModel.MessageImageShow && !string.IsNullOrEmpty(_messageAssetName))
		{
			_viewModel.MessageImageSprite = base.Loader.RetriveSprite(_messageAssetBoundle, _messageAssetName, delegate(Sprite sprite)
			{
				_viewModel.MessageImageSprite = sprite;
				_viewModel.MessageImageNtvsize();
			});
			_viewModel.MessageImageNtvsize();
		}
		if (_viewModel.SelfMessageImageShow && !string.IsNullOrEmpty(_selfMessageAssetName))
		{
			_viewModel.SelfMessageImageSprite = base.Loader.RetriveSprite(_selfMessageAssetBoundle, _selfMessageAssetName, delegate(Sprite sprite)
			{
				_viewModel.SelfMessageImageSprite = sprite;
				_viewModel.SelfMessageImageNtvsize();
			});
			_viewModel.SelfMessageImageNtvsize();
		}
		if (_viewModel.StateMessageImageShow && !string.IsNullOrEmpty(_stateMessageAssetName))
		{
			_viewModel.StateMessageImageSprite = base.Loader.RetriveSprite(_stateMessageAssetBoundle, _stateMessageAssetName, delegate(Sprite sprite)
			{
				_viewModel.StateMessageImageSprite = sprite;
				_viewModel.StateMessageImageNtvsize();
			});
			_viewModel.StateMessageImageNtvsize();
		}
	}

	private void UpdateWeaponEffectLevelMessage(bool ov, bool changed)
	{
		_weaponEffectLevelTipsMessageImageActiveChip.Time = (changed ? 5000 : 0);
	}

	private void UpdatePlayerBeAttackedMessage(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int num = tipsEvent.Count - 1; num >= 0; num--)
		{
			if (tipsEvent[num].TypeId == -5000)
			{
				_selfMessageImageActiveChip.Time = 3000;
				_selfMessageAssetBoundle = "ui/jumpmodel";
				_selfMessageAssetName = "Assets/Res/Assets/ui/GameGUIRes/jumpModel/jumpTip.png";
				UpdateImage();
				tipsEvent.RemoveAt(num);
			}
		}
	}

	private void UpdateGameBaseMessage(bool ov, bool changed)
	{
		if (changed && UiIEventCondition.Get_gameMessageData_MsgTypeDic() != null)
		{
			Dictionary<int, int> gameMessageData_MsgTypeDic = UiIEventCondition.Get_gameMessageData_MsgTypeDic();
			if (gameMessageData_MsgTypeDic.ContainsKey(5))
			{
				_messageImageActiveChip.Time = 100;
				_messageAssetBoundle = "ui/common";
				_messageAssetName = "Assets/Res/Assets/ui/GameGUIRes/common/message/getrechargweapon.png";
				UpdateImage();
			}
			if (gameMessageData_MsgTypeDic.ContainsKey(6))
			{
				_selfMessageImageActiveChip.Time = 100;
				_selfMessageAssetBoundle = "ui/common";
				_selfMessageAssetName = "Assets/Res/Assets/ui/GameGUIRes/common/message/kongzhiqiopen.png";
				UpdateImage();
			}
			if (gameMessageData_MsgTypeDic.ContainsKey(7))
			{
				_selfMessageImageActiveChip.Time = 100;
				_selfMessageAssetBoundle = "ui/common";
				_selfMessageAssetName = "Assets/Res/Assets/ui/GameGUIRes/common/message/kongzhiqiclose.png";
				UpdateImage();
			}
		}
	}

	private void UpdateSparyMessage(bool ov, bool changed)
	{
		if (changed)
		{
			_messageTextActiveChip.Time = 3000;
			switch (UiIEventCondition.Get_sparyMessageData_Type())
			{
			case SprayMessageType.NOSPRAY:
				_viewModel.MessageTextString = ScriptLocalization.Get("Nospray");
				break;
			case SprayMessageType.DISTANCENOTENOUGH:
				_viewModel.MessageTextString = ScriptLocalization.Get("Spraytoofar");
				break;
			case SprayMessageType.SPRAYEDOVER:
				_viewModel.MessageTextString = ScriptLocalization.Get("Spraywaitbureau");
				break;
			case SprayMessageType.NOTIMETO:
				_viewModel.MessageTextString = ScriptLocalization.Get("Spraywaittime");
				break;
			case SprayMessageType.NOTSPRAY:
				_viewModel.MessageTextString = ScriptLocalization.Get("Sprayface");
				break;
			}
		}
	}

	private void InitChips()
	{
		_messageImageActiveChip.Time = 0;
		_messageTextActiveChip.Time = 0;
		_selfMessageImageActiveChip.Time = 0;
		_stateMessageImageActiveChip.Time = 0;
		_weaponEffectLevelTipsMessageImageActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.MessageImageShow = _messageImageActiveChip.Update(_timeComponent);
		_viewModel.MessageTextShow = _messageTextActiveChip.Update(_timeComponent);
		_viewModel.SelfMessageImageShow = _selfMessageImageActiveChip.Update(_timeComponent);
		_viewModel.StateMessageImageShow = _stateMessageImageActiveChip.Update(_timeComponent);
		_viewModel.WeaponEffectLevelTipsShow = _weaponEffectLevelTipsMessageImageActiveChip.Update(_timeComponent);
	}
}
