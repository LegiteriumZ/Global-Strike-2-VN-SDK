using System.Collections.Generic;
using Assets.Sources.Components.Message.Bochemical;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalMessageModel : AbstractModel, IPlaybackSystem, ISetPlayerContext
{
	protected BiochemicalmessageViewModel _viewModel = new BiochemicalmessageViewModel();

	protected PlayerContext _playerContext;

	protected bool _isBio3Model;

	protected static AssetInfo _ammunitionRefreshAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/ammunitionRefresh.png");

	protected static AssetInfo _changeHeroAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/changeHero.png");

	protected static AssetInfo _heroKillAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/heroKill.png");

	protected static AssetInfo _resurrectionAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/resurrection.png");

	protected static AssetInfo _useSkillAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/useSkill.png");

	protected static AssetInfo _weaponKillAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/weaponKill.png");

	protected static AssetInfo _killheroAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/killhero.png");

	protected static AssetInfo _successfulinfectionAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/successfulinfection.png");

	protected static AssetInfo _biochemicalserumsuccessAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/biochemicalserumsuccess.png");

	protected static AssetInfo _biochemicalserumfailAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/biochemicalserumfail.png");

	protected static AssetInfo _disarmAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/disarm.png");

	protected static AssetInfo _warrantAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/warrant.png");

	protected static AssetInfo _knifekillAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/knifekill.png");

	protected static AssetInfo _insanefulinfectionAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/insanefulinfection.png");

	protected static AssetInfo _metalmanskillhitAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/metalmanskillhit.png");

	protected static AssetInfo _petrifiedskillhitAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/petrifiedskillhit.png");

	protected static AssetInfo _twineskillhitAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/twineskillhit.png");

	protected static AssetInfo _helpKillAsset = new AssetInfo("ui/bio3model", "Assets/Res/Assets/ui/GameGUIRes/bio3Model/message/helpKill.png");

	protected static AssetInfo _knifeKillLevelDownAsset = new AssetInfo("ui/bio3model", "Assets/Res/Assets/ui/GameGUIRes/bio3Model/message/knifeKillLevelDown.png");

	protected static AssetInfo _levelDownAsset = new AssetInfo("ui/bio3model", "Assets/Res/Assets/ui/GameGUIRes/bio3Model/message/levelDown.png");

	protected static AssetInfo _CannotUseMiwuAsset = new AssetInfo("ui/bio3model", "Assets/Res/Assets/ui/GameGUIRes/bio3Model/message/pandoraCannotUseMiwu.png");

	protected static AssetInfo _UseMiwuAsset = new AssetInfo("ui/bio3model", "Assets/Res/Assets/ui/GameGUIRes/bio3Model/message/pandoraUseMiwu.png");

	protected static AssetInfo _getEncourageSuccessAsset = new AssetInfo("ui/bioEvolutionModel", "Assets/Res/Assets/ui/GameGUIRes/bioEvolutionModel/message/getEncourageSuccess.png");

	protected AssetInfo _currMessageImage;

	private AssetInfo _currSelfMessageImage;

	protected bool _refreshMessage;

	protected ActiveChip _selfMessageImageActiveChip = new ActiveChip();

	protected ActiveChip _messageImageActiveChip = new ActiveChip();

	protected ActiveChip _stateImageActiveChip = new ActiveChip();

	protected ActiveChip _skillImageActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	protected PlayerContext GetPlayerContext()
	{
		return _playerContext;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		base.Initialize();
		InitChips();
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		_isBio3Model = RuleUtilty.IsNewBio3Rule(raceType);
	}

	public virtual void OnPlayback()
	{
		UpdateChips();
	}

	protected virtual void UpdatePlayerKillData()
	{
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_bioMessageData_Message, SetMessage, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetIsDead, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiMyPlayer_Career, SetCareer, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_humanityGrowUp_GrowUpLevel, SetGrowUpLevel, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Passed, SetPassed, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Observer, SetObserver, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PlayerWarrantDecelerateFlag, SetPlayerWarrantDecelerateFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PlayerDisarmFlag, SetPlayerDisarmFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeNotify(79, UiIEventCondition.Get_menu_VisibleChanged, SetPickShow, initinvoke: false, isFrameSeparation: true);
	}

	private void SetPickShow(bool arg1, bool arg2)
	{
		UpdateImage(BioMessageType.GETENCOURAGESUCCESS);
	}

	private void SetPlayerDisarmFlag(bool arg1, bool arg2)
	{
		UpdatePlayerData();
	}

	private void SetPlayerWarrantDecelerateFlag(bool arg1, bool arg2)
	{
		UpdatePlayerData();
	}

	private void SetObserver(int arg1, int arg2)
	{
		UpdatePlayerData();
	}

	private void SetPassed(int arg1, int arg2)
	{
		UpdateBioSkillIconData();
	}

	private void SetGrowUpLevel(int arg1, int arg2)
	{
		UpdateBioHumanityGrowUpData();
	}

	private void SetCareer(string arg1, string arg2)
	{
		UpdateBioHumanityGrowUpData();
	}

	private void SetIsDead(bool arg1, bool arg2)
	{
		UpdateBioHumanityGrowUpData();
	}

	protected virtual void UpdatePlayerData()
	{
		if (UiIEventCondition.Get_cameraOwnerData_Observer() == 0)
		{
			if (UiIEventCondition.Get_pveState_PlayerWarrantDecelerateFlag())
			{
				UpdateImage(BioMessageType.WARRANTDECELERATE);
			}
			if (UiIEventCondition.Get_pveState_PlayerDisarmFlag())
			{
				UpdateImage(BioMessageType.DISARM);
			}
		}
	}

	protected virtual void UpdateBioSkillIconData()
	{
		if ((!PlayerCareerConstantUtility.IsEmpress(UiIEventCondition.Get_uiMyPlayer_Career()) && !PlayerCareerConstantUtility.IsDoun(UiIEventCondition.Get_uiMyPlayer_Career())) || UiIEventCondition.Get_uiMyPlayer_IsDead())
		{
			return;
		}
		if (_refreshMessage)
		{
			_messageImageActiveChip.Time = 0;
		}
		else if (_messageImageActiveChip.Time > 0)
		{
			return;
		}
		Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
		if (uiSkill_Skills == null || !uiSkill_Skills.ContainsKey(106))
		{
			return;
		}
		SkillInfoData skillInfoData = uiSkill_Skills[106];
		if (ActiveSkillName.IsUseEnergySkill(skillInfoData.SkillName))
		{
			return;
		}
		if (ActiveSkillName.IsUseMpSkill(skillInfoData.SkillName) && !_isBio3Model)
		{
			if (skillInfoData.Mp >= skillInfoData.NeedMp)
			{
				UpdateImage(BioMessageType.USESKILL);
			}
		}
		else if (skillInfoData.CurrentCdTime <= 0)
		{
			UpdateImage(BioMessageType.USESKILL);
		}
	}

	protected virtual void UpdateBioHumanityGrowUpData()
	{
		if (!UiIEventCondition.Get_uiRoomData_GameRule().IsBio2() && !UiIEventCondition.Get_uiMyPlayer_IsDead() && PlayerCareerConstantUtility.IsHumanity(UiIEventCondition.Get_uiMyPlayer_Career()) && UiIEventCondition.Get_humanityGrowUp_GrowUpLevel() >= 10)
		{
			UpdateImage(BioMessageType.CHANGEHERO);
		}
	}

	protected virtual void SetMessage(MessageDataInfo ov, MessageDataInfo info)
	{
		if (info != null)
		{
			string uiMyPlayer_PlayerName = UiIEventCondition.Get_uiMyPlayer_PlayerName();
			if (!(info.PlayerName != uiMyPlayer_PlayerName) || (info.Type != BioMessageType.KILLHERO && info.Type != BioMessageType.INSANEFULINFECTION))
			{
				UpdateImage(info.Type);
			}
		}
	}

	protected void SetMessageImage(ref AssetInfo asset)
	{
		if (_currMessageImage != asset)
		{
			_currMessageImage = asset;
			_viewModel.MessageImageSprite = this.GetLoader().RetriveSprite(asset, delegate(Sprite sprite)
			{
				_viewModel.MessageImageSprite = sprite;
				_viewModel.MessageImageNtvsize();
			});
		}
	}

	protected void SetSelfMessageImage(ref AssetInfo asset)
	{
		if (_currSelfMessageImage != asset)
		{
			_currSelfMessageImage = asset;
			_viewModel.SelfMessageImageSprite = this.GetLoader().RetriveSprite(asset, delegate(Sprite sprite)
			{
				_viewModel.SelfMessageImageSprite = sprite;
				_viewModel.SelfMessageImageNtvsize();
			});
		}
	}

	protected virtual void UpdateImage(BioMessageType messageType)
	{
		_refreshMessage = false;
		switch (messageType)
		{
		case BioMessageType.AMMUNITIONREFRESH:
			_messageImageActiveChip.Time = 3000;
			SetMessageImage(ref _ammunitionRefreshAsset);
			break;
		case BioMessageType.CHANGEHERO:
			_messageImageActiveChip.Time = 1000;
			SetMessageImage(ref _changeHeroAsset);
			break;
		case BioMessageType.HEROKILL:
			_messageImageActiveChip.Time = 3000;
			SetMessageImage(ref _heroKillAsset);
			break;
		case BioMessageType.RESURRECTION:
			_messageImageActiveChip.Time = 3000;
			SetMessageImage(ref _resurrectionAsset);
			break;
		case BioMessageType.USESKILL:
			_messageImageActiveChip.Time = 1000;
			SetMessageImage(ref _useSkillAsset);
			_refreshMessage = true;
			break;
		case BioMessageType.WEAPONKILL:
			_messageImageActiveChip.Time = 3000;
			SetMessageImage(ref _weaponKillAsset);
			break;
		case BioMessageType.KILLHERO:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _killheroAsset);
			break;
		case BioMessageType.SUCCESSFULINFECTION:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _successfulinfectionAsset);
			break;
		case BioMessageType.CHANGFAILED:
		{
			PlayerEntityData playerEntityData = ((_playerContext.myPlayerEntity != null && _playerContext.myPlayerEntity.hasBasicInfo) ? _playerContext.myPlayerEntity.basicInfo.Current : null);
			if (playerEntityData != null)
			{
				if (PlayerCareerConstantUtility.IsHumanity(playerEntityData.Career))
				{
					SetSelfMessageImage(ref _biochemicalserumsuccessAsset);
				}
				else
				{
					SetSelfMessageImage(ref _biochemicalserumfailAsset);
				}
				_selfMessageImageActiveChip.Time = 3000;
			}
			break;
		}
		case BioMessageType.DISARM:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _disarmAsset);
			break;
		case BioMessageType.WARRANTDECELERATE:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _warrantAsset);
			break;
		case BioMessageType.KNIFEKILL:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _knifekillAsset);
			break;
		case BioMessageType.INSANEFULINFECTION:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _insanefulinfectionAsset);
			break;
		case BioMessageType.METALMANSKILLHIT:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _metalmanskillhitAsset);
			break;
		case BioMessageType.PERTRIFIEDSKILLHIT:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _petrifiedskillhitAsset);
			break;
		case BioMessageType.TWINESSKILLHIT:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _twineskillhitAsset);
			break;
		case BioMessageType.HELPKILL:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _helpKillAsset);
			break;
		case BioMessageType.KNIFEKILLLEVELDOWN:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _knifeKillLevelDownAsset);
			break;
		case BioMessageType.LEVELDOWN:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _levelDownAsset);
			break;
		case BioMessageType.PANDORACANNOTUSEMIWU:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _CannotUseMiwuAsset);
			break;
		case BioMessageType.PANDORAUSEMIWU:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _UseMiwuAsset);
			break;
		case BioMessageType.GETENCOURAGESUCCESS:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _getEncourageSuccessAsset);
			break;
		}
	}

	protected ActiveChip GetMessageImageActiveChip()
	{
		return _messageImageActiveChip;
	}

	protected ActiveChip GetSelfMessageImageActiveChip()
	{
		return _selfMessageImageActiveChip;
	}

	private void InitChips()
	{
		_selfMessageImageActiveChip.Time = 0;
		_messageImageActiveChip.Time = 0;
		_stateImageActiveChip.Time = 0;
		_skillImageActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.SelfMessageImageShow = _selfMessageImageActiveChip.Update(_timeComponent);
		_viewModel.MessageImageShow = _messageImageActiveChip.Update(_timeComponent);
		_viewModel.StateImageShow = _stateImageActiveChip.Update(_timeComponent);
		_viewModel.SkillImageShow = _skillImageActiveChip.Update(_timeComponent);
	}
}
