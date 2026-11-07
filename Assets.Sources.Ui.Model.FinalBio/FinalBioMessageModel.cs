using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Sources.Utils.Ui;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.FinalBio;

public class FinalBioMessageModel : BiochemicalMessageModel, ISetBattleRoomContext
{
	private bool _showUltimateTimeMessage = true;

	private BattleRoomContext _battleRoomContext;

	private static AssetInfo _ultimatetimecomeonAsset = new AssetInfo("ui/finalbiomodel", "Assets/Res/Assets/ui/GameGUIRes/finalbioModel/message/ultimatetimecomeon.png");

	private static AssetInfo _changefinaldeathAsset = new AssetInfo("ui/finalbiomodel", "Assets/Res/Assets/ui/GameGUIRes/finalbioModel/message/changefinaldeath.png");

	private static AssetInfo _playerinvincibleAsset = new AssetInfo("ui/finalbiomodel", "Assets/Res/Assets/ui/GameGUIRes/finalbioModel/message/playerinvincible.png");

	private static AssetInfo _getZombieCanBeKilledByKnifeAsset = new AssetInfo("ui/bio3model", "Assets/Res/Assets/ui/GameGUIRes/bio3Model/message/dounKnifeKill.png");

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	protected override void UpdateBioHumanityGrowUpData()
	{
	}

	protected override void UpdateBioSkillIconData()
	{
		if (!(UiIEventCondition.Get_uiMyPlayer_Career() == "queen"))
		{
			base.UpdateBioSkillIconData();
		}
	}

	public override void OnPlayback()
	{
		base.OnPlayback();
		SetPassed();
	}

	protected void SetPassed()
	{
		long num = _battleRoomContext.sectionTime.SectionTime;
		if (num <= 0)
		{
			_showUltimateTimeMessage = false;
			return;
		}
		if (RuleUtilty.IsBioEvoLutionMode(UiIEventCondition.Get_uiRoomData_RaceType()))
		{
			if (num > 60000)
			{
				_showUltimateTimeMessage = true;
			}
			else if (_showUltimateTimeMessage && FinalBioDecisiveBattleModel.humanityCount > 0)
			{
				UpdateImage(BioMessageType.ULTIMATETIMECOMEON);
				_showUltimateTimeMessage = false;
			}
			return;
		}
		if (num > 45000)
		{
			_showUltimateTimeMessage = true;
			return;
		}
		bool cameraOwnerData_IsDead = UiIEventCondition.Get_cameraOwnerData_IsDead();
		string cameraOwnerData_Career = UiIEventCondition.Get_cameraOwnerData_Career();
		if (!cameraOwnerData_IsDead && PlayerCareerConstantUtility.IsHumanity(cameraOwnerData_Career))
		{
			if (!RuleUtilty.IsBioEvoLutionMode(UiIEventCondition.Get_uiRoomData_RaceType()))
			{
				UpdateImage(BioMessageType.CHANGEHERO);
			}
			return;
		}
		if (!cameraOwnerData_IsDead)
		{
			switch (cameraOwnerData_Career)
			{
			case "death":
			case "pandoraMonther":
			case "pandoraMonther_baigu":
				UpdateImage(BioMessageType.CHANGEDEATH);
				return;
			}
		}
		if (PlayerCareerConstantUtility.IsDoun(cameraOwnerData_Career) && _showUltimateTimeMessage)
		{
			UpdateImage(BioMessageType.ULTIMATETIMECOMEON);
			_showUltimateTimeMessage = false;
		}
	}

	protected override void UpdateImage(BioMessageType messageType)
	{
		base.UpdateImage(messageType);
		BiochemicalmessageViewModel viewModel = (BiochemicalmessageViewModel)ViewModel;
		switch (messageType)
		{
		case BioMessageType.ULTIMATETIMECOMEON:
			if (_currMessageImage != _ultimatetimecomeonAsset)
			{
				_currMessageImage = _ultimatetimecomeonAsset;
				viewModel.MessageImageSprite = this.GetLoader().RetriveSprite(_currMessageImage, delegate(Sprite sprite)
				{
					viewModel.MessageImageSprite = sprite;
					viewModel.MessageImageNtvsize();
				});
			}
			GetMessageImageActiveChip().Time = 1000;
			break;
		case BioMessageType.CHANGEDEATH:
			if (_currMessageImage != _changefinaldeathAsset && !RuleUtilty.IsBioEvoLutionMode(UiIEventCondition.Get_uiRoomData_RaceType()))
			{
				_currMessageImage = _changefinaldeathAsset;
				viewModel.MessageImageSprite = this.GetLoader().RetriveSprite(_currMessageImage, delegate(Sprite sprite)
				{
					viewModel.MessageImageSprite = sprite;
					viewModel.MessageImageNtvsize();
				});
			}
			GetMessageImageActiveChip().Time = 1000;
			break;
		case BioMessageType.PLAYERINVINCIBLE:
			if (_currMessageImage != _playerinvincibleAsset)
			{
				_currMessageImage = _playerinvincibleAsset;
				viewModel.MessageImageSprite = this.GetLoader().RetriveSprite(_currMessageImage, delegate(Sprite sprite)
				{
					viewModel.MessageImageSprite = sprite;
					viewModel.MessageImageNtvsize();
				});
			}
			GetMessageImageActiveChip().Time = 1000;
			break;
		case BioMessageType.ZOMBIECANBEKILLEDBYKNIFE:
			SetMessageImage(ref _getZombieCanBeKilledByKnifeAsset);
			GetMessageImageActiveChip().Time = 3000;
			break;
		default:
			_currMessageImage = AssetInfo.None;
			break;
		}
	}
}
