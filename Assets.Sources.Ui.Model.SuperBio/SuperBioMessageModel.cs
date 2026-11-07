using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Sources.Utils.Ui;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Ui.Model.SuperBio;

public class SuperBioMessageModel : BiochemicalMessageModel, ISetMessageContext
{
	private new static AssetInfo _resurrectionAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/resurrection.png");

	private static AssetInfo _usedouncallAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/usedouncall.png");

	private static AssetInfo _selfleaderAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/selfleader.png");

	private static AssetInfo _nearleaderAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/nearleader.png");

	private static AssetInfo _leaderfulinfectionfailAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/leaderfulinfectionfail.png");

	private static AssetInfo _leaderAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/leader.png");

	private static AssetInfo _superhumanityAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/superhumanity.png");

	private static AssetInfo _getaccelerateAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/getaccelerate.png");

	private static AssetInfo _gethumanitycallAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/gethumanitycall.png");

	private static AssetInfo _getenergyshieldAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/getenergyshield.png");

	private static AssetInfo _getstealthAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/getstealth.png");

	private static AssetInfo _getdamagedeepAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/getdamagedeep.png");

	private static AssetInfo _humanitycallAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/humanitycall.png");

	private static AssetInfo _humanitybecallAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/humanitybecall.png");

	private static AssetInfo _dounfulinfectionfailAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/dounfulinfectionfail.png");

	private static AssetInfo _bedouncallAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/bedouncall.png");

	private static AssetInfo _useingdouncallAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/useingdouncall.png");

	private static AssetInfo _protectivecoverdestroyAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/protectivecoverdestroy.png");

	private static AssetInfo _destroyprotectivecoverAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/destroyprotectivecover.png");

	private bool _protectivecoverdestroy;

	private bool _refreshSelf;

	private bool _refreshState;

	private MessageContext _messageContext;

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bioMessageData_IsHeroChanged, SetIsHeroChanged, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiMyPlayer_Career, SetCareer, null, initinvoke: true);
	}

	private void SetCareer(string arg1, string arg2)
	{
		UpdateBioHumanityGrowUpData();
	}

	private void SetIsHeroChanged(bool arg1, bool arg2)
	{
		UpdateBioHumanityGrowUpData();
	}

	protected override void UpdateBioHumanityGrowUpData()
	{
		string uiMyPlayer_Career = UiIEventCondition.Get_uiMyPlayer_Career();
		if (!string.IsNullOrEmpty(uiMyPlayer_Career) && PlayerCareerUtil.IsHumanity(uiMyPlayer_Career) && !_messageContext.bioMessageData.IsHeroChanged)
		{
			UpdateImage(BioMessageType.CHANGEHERO);
		}
	}

	protected override void UpdateBioSkillIconData()
	{
		string uiMyPlayer_Career = UiIEventCondition.Get_uiMyPlayer_Career();
		if ((!PlayerCareerConstantUtility.IsEmpress(uiMyPlayer_Career) && !PlayerCareerConstantUtility.IsDoun(uiMyPlayer_Career)) || UiIEventCondition.Get_uiMyPlayer_IsDead())
		{
			return;
		}
		if (_refreshMessage)
		{
			_messageImageActiveChip.Time = 0;
		}
		if (_refreshSelf)
		{
			_selfMessageImageActiveChip.Time = 0;
		}
		if (_refreshState)
		{
			_stateImageActiveChip.Time = 0;
			_skillImageActiveChip.Time = 0;
		}
		Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
		if (uiSkill_Skills == null)
		{
			return;
		}
		SkillInfoData skillInfoData = uiSkill_Skills[106];
		if (skillInfoData != null)
		{
			if (ActiveSkillName.IsUseMpSkill(skillInfoData.SkillName))
			{
				if (skillInfoData.Mp >= skillInfoData.NeedMp)
				{
					UpdateImage(BioMessageType.USESKILL);
				}
			}
			else if (skillInfoData.CurrentCdTime <= 0)
			{
				if (skillInfoData.SkillName == 2)
				{
					UpdateImage(BioMessageType.HUMANITYCALL);
				}
				else
				{
					UpdateImage(BioMessageType.USESKILL);
				}
			}
		}
		skillInfoData = uiSkill_Skills[125];
		if (skillInfoData != null)
		{
			if (PlayerCareerConstantUtility.IsEmpress(UiIEventCondition.Get_uiMyPlayer_Career()))
			{
				UpdateImage(BioMessageType.USEINGDOUNCALL);
			}
			else
			{
				UpdateImage(BioMessageType.BEDOUNCALL);
			}
			return;
		}
		skillInfoData = uiSkill_Skills[105];
		if (skillInfoData != null)
		{
			if (skillInfoData.CurrentCdTime <= 0)
			{
				UpdateImage(BioMessageType.USEDOUNCALL);
			}
			return;
		}
		skillInfoData = uiSkill_Skills[1];
		if (skillInfoData != null && !_protectivecoverdestroy)
		{
			UpdateImage(BioMessageType.NEARLEADER);
		}
	}

	protected override void UpdateImage(BioMessageType messageType)
	{
		base.UpdateImage(messageType);
		_protectivecoverdestroy = false;
		_refreshSelf = false;
		_refreshState = false;
		switch (messageType)
		{
		case BioMessageType.RESURRECTION:
			SetMessageImage(ref _resurrectionAsset);
			_messageImageActiveChip.Time = 3000;
			break;
		case BioMessageType.USEDOUNCALL:
			if (_messageImageActiveChip.Time <= 0)
			{
				SetMessageImage(ref _usedouncallAsset);
				_messageImageActiveChip.Time = 1000;
				_refreshMessage = true;
			}
			break;
		case BioMessageType.NEARLEADER:
			if (_messageImageActiveChip.Time <= 0)
			{
				if (UiIEventCondition.Get_uiMyPlayer_Leader())
				{
					SetSelfMessageImage(ref _selfleaderAsset);
				}
				else
				{
					SetSelfMessageImage(ref _nearleaderAsset);
				}
				_selfMessageImageActiveChip.Time = 1000;
				_refreshMessage = true;
			}
			break;
		case BioMessageType.LEADERFULINFECTIONFAIL:
			SetSelfMessageImage(ref _leaderfulinfectionfailAsset);
			_selfMessageImageActiveChip.Time = 3000;
			break;
		case BioMessageType.LEADER:
			SetSelfMessageImage(ref _leaderAsset);
			_selfMessageImageActiveChip.Time = 3000;
			break;
		case BioMessageType.SUPERHUMANITY:
			SetStateImage(ref _superhumanityAsset);
			_stateImageActiveChip.Time = 3000;
			_skillImageActiveChip.Time = 3000;
			switch (_messageContext.bioMessageData.SkillName)
			{
			case 1:
				SetSkillImage(ref _getaccelerateAsset);
				break;
			case 2:
				SetSkillImage(ref _gethumanitycallAsset);
				break;
			case 4:
				SetSkillImage(ref _getenergyshieldAsset);
				break;
			case 5:
				SetSkillImage(ref _getstealthAsset);
				break;
			case 3:
				SetSkillImage(ref _getdamagedeepAsset);
				break;
			}
			break;
		case BioMessageType.HUMANITYCALL:
			if (_messageImageActiveChip.Time <= 0)
			{
				SetMessageImage(ref _humanitycallAsset);
				_messageImageActiveChip.Time = 1000;
				_refreshMessage = true;
			}
			break;
		case BioMessageType.HUMANITYBECALL:
			SetStateImage(ref _humanitybecallAsset);
			_stateImageActiveChip.Time = 3000;
			break;
		case BioMessageType.DOUNFULINFECTIONFAIL:
			SetSelfMessageImage(ref _dounfulinfectionfailAsset);
			_selfMessageImageActiveChip.Time = 3000;
			break;
		case BioMessageType.BEDOUNCALL:
			if (_stateImageActiveChip.Time <= 0)
			{
				SetStateImage(ref _bedouncallAsset);
				_stateImageActiveChip.Time = 1000;
				_refreshState = true;
			}
			break;
		case BioMessageType.USEINGDOUNCALL:
			if (_selfMessageImageActiveChip.Time <= 0)
			{
				SetSelfMessageImage(ref _useingdouncallAsset);
				_selfMessageImageActiveChip.Time = 1000;
				_refreshSelf = true;
			}
			break;
		case BioMessageType.DESTROYPROTECTIVECOVER:
		{
			string uiMyPlayer_Career = UiIEventCondition.Get_uiMyPlayer_Career();
			if (!string.IsNullOrEmpty(uiMyPlayer_Career))
			{
				if (PlayerCareerUtil.IsHumanity(uiMyPlayer_Career))
				{
					SetSelfMessageImage(ref _protectivecoverdestroyAsset);
					_protectivecoverdestroy = true;
				}
				else
				{
					SetSelfMessageImage(ref _destroyprotectivecoverAsset);
				}
				_selfMessageImageActiveChip.Time = 3000;
			}
			break;
		}
		}
	}

	private void SetStateImage(ref AssetInfo asset)
	{
		BiochemicalmessageViewModel viewModel = (BiochemicalmessageViewModel)ViewModel;
		viewModel.StateImageSprite = this.GetLoader().RetriveSprite(asset, delegate(Sprite sprite)
		{
			viewModel.StateImageSprite = sprite;
			viewModel.StateImageNtvsize();
		});
	}

	private void SetSkillImage(ref AssetInfo asset)
	{
		BiochemicalmessageViewModel viewModel = (BiochemicalmessageViewModel)ViewModel;
		viewModel.SkillImageSprite = this.GetLoader().RetriveSprite(asset, delegate(Sprite sprite)
		{
			viewModel.SkillImageSprite = sprite;
			viewModel.SkillImageNtvsize();
		});
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
