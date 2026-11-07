using System.Collections.Generic;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Mechwarrior;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Mechwarrior;

public class MechwarriorMessageModel : AbstractModel, IPlaybackSystem
{
	private MechwarriorMessageViewModel _viewModel;

	private ActiveChip _selfMessageImageActiveChip = new ActiveChip();

	private ActiveChip _stateMessageImageActiveChip = new ActiveChip();

	private ActiveChip _messageImageActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MechwarriorMessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			UpdateInCoverSkillUsing();
			UpdateChangeHero();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.MessageTextString = "";
		NotifyManager.MakeNotify(21, UiIEventCondition.Get_mechwarriorMessageData_MessageType, SetMessageType, initinvoke: true);
		NotifyManager.MakeNotifyClass(22, UiIEventCondition.Get_killPlayerInfo_InfoList, SetInfoList, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorMessageData_WaitPlayerCount, SetWaitPlayerCount, null, initinvoke: true);
	}

	private void SetWaitPlayerCount(int ov, int count)
	{
		if (count > 0)
		{
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/message/waitplayer.png", delegate(Sprite sprite)
			{
				_viewModel.MessageImageSprite = sprite;
				_viewModel.MessageImageNtvsize();
			});
			_messageImageActiveChip.Time = int.MaxValue;
			_viewModel.MessageTextString = count.ToString();
			_viewModel.MessageTextShow = true;
		}
		else if (_messageImageActiveChip.Time > 1000000)
		{
			_messageImageActiveChip.Time = 0;
			_viewModel.MessageTextShow = false;
		}
	}

	private void UpdateInCoverSkillUsing()
	{
		if (_selfMessageImageActiveChip.Time <= 0 && UiIEventCondition.Get_pveState_InCoverSkillUsing())
		{
			SetMessageType(0, 0);
		}
	}

	private void UpdateChangeHero()
	{
		if (_stateMessageImageActiveChip.Time <= 0 && PlayerCareerConstantUtility.IsMech(UiIEventCondition.Get_cameraOwnerData_Career()) && UiIEventCondition.Get_mechwarriorHeroGrowupData_Lv() == 4 && UiIEventCondition.Get_mechwarriorHeroGrowupData_CurrentExp() >= UiIEventCondition.Get_mechwarriorHeroGrowupData_MaxExp())
		{
			SetMessageType(0, 5);
		}
	}

	private void SetInfoList(Queue<KillPlayerInfoData> ov, Queue<KillPlayerInfoData> killPlayerInfos)
	{
		foreach (KillPlayerInfoData killPlayerInfo in killPlayerInfos)
		{
			if (killPlayerInfo.KillPlayerId == UiIEventCondition.Get_cameraOwnerData_PlayerId())
			{
				switch (UiIEventCondition.Get_cameraOwnerData_Career())
				{
				case "mechfar":
					SetMessageType(0, 12);
					break;
				case "mechnear":
				case "mechbomberman":
					SetMessageType(0, 11);
					break;
				}
			}
		}
	}

	private void SetMessageType(int ov, int type)
	{
		switch (type)
		{
		case 3:
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/message/changedmech.png", delegate(Sprite sprite)
			{
				_viewModel.StateMessageImageSprite = sprite;
				_viewModel.StateMessageImageNtvsize();
			});
			_stateMessageImageActiveChip.Time = 3000;
			break;
		case 4:
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/message/bemechkill.png", delegate(Sprite sprite)
			{
				_viewModel.StateMessageImageSprite = sprite;
				_viewModel.StateMessageImageNtvsize();
			});
			_stateMessageImageActiveChip.Time = 3000;
			break;
		case 0:
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/message/incoverskillusing.png", delegate(Sprite sprite)
			{
				_viewModel.SelfMessageImageSprite = sprite;
				_viewModel.SelfMessageImageNtvsize();
			});
			_selfMessageImageActiveChip.Time = int.MaxValue;
			break;
		case 5:
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/message/changehero.png", delegate(Sprite sprite)
			{
				_viewModel.StateMessageImageSprite = sprite;
				_viewModel.StateMessageImageNtvsize();
			});
			_stateMessageImageActiveChip.Time = int.MaxValue;
			break;
		case 6:
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/message/killhero.png", delegate(Sprite sprite)
			{
				_viewModel.SelfMessageImageSprite = sprite;
				_viewModel.SelfMessageImageNtvsize();
			});
			_selfMessageImageActiveChip.Time = 3000;
			break;
		case 7:
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/message/noenergy.png", delegate(Sprite sprite)
			{
				_viewModel.StateMessageImageSprite = sprite;
				_viewModel.StateMessageImageNtvsize();
			});
			_stateMessageImageActiveChip.Time = 2000;
			break;
		case 9:
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/message/ultimatetimecomeon.png", delegate(Sprite sprite)
			{
				_viewModel.MessageImageSprite = sprite;
				_viewModel.MessageImageNtvsize();
			});
			_messageImageActiveChip.Time = 3000;
			_viewModel.MessageTextShow = false;
			break;
		case 11:
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/message/nearkill.png", delegate(Sprite sprite)
			{
				_viewModel.SelfMessageImageSprite = sprite;
				_viewModel.SelfMessageImageNtvsize();
			});
			_selfMessageImageActiveChip.Time = 3000;
			break;
		case 12:
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/message/farkill.png", delegate(Sprite sprite)
			{
				_viewModel.SelfMessageImageSprite = sprite;
				_viewModel.SelfMessageImageNtvsize();
			});
			_selfMessageImageActiveChip.Time = 3000;
			break;
		}
	}

	private void InitChips()
	{
		_selfMessageImageActiveChip.Time = 0;
		_stateMessageImageActiveChip.Time = 0;
		_messageImageActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.SelfMessageImageShow = _selfMessageImageActiveChip.Update(_timeComponent);
		_viewModel.StateMessageImageShow = _stateMessageImageActiveChip.Update(_timeComponent) && !UiIEventCondition.Get_mechwarriorMessageData_IsUltimateTime();
		_viewModel.MessageImageShow = _messageImageActiveChip.Update(_timeComponent);
	}
}
