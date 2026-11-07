using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class CommonKillBroadModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetMessageContext
{
	private CommonkillbroadViewModel _viewModel;

	private bool _killBoss;

	private bool _copyWeapon;

	private bool _relive;

	private static AssetInfo _killingspreeAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/killingspree.png");

	private static AssetInfo _unstoppableAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/unstoppable.png");

	private static AssetInfo _bigkillAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/bigkill.png");

	private static AssetInfo _10kill_Asset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/10kill+.png");

	private static AssetInfo[] _killAssets = new AssetInfo[11]
	{
		default(AssetInfo),
		default(AssetInfo),
		default(AssetInfo),
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/3kill.png"),
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/4kill.png"),
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/5kill.png"),
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/6kill.png"),
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/7kill.png"),
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/8kill.png"),
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/9kill.png"),
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killbroad/10kill.png")
	};

	private static Color _blueColor = new Color(0.266f, 0.805f, 0.961f);

	private ActiveChip _panelActiveChip = new ActiveChip();

	private BattleRoomContext _battleRoomContext;

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
		_viewModel = new CommonkillbroadViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
		if (_viewModel.PanelShow)
		{
			UpdateNamePosition();
		}
	}

	private void UpdateNamePosition()
	{
		if (!RuleUtilty.IsOldPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType) || !_copyWeapon)
		{
			_viewModel.PlayerNameAnchoredposition = new Vector2(42f, 22f);
		}
	}

	protected virtual void UpdateKillInfoImage(KillPlayerInfoData info)
	{
		int num = 5;
		if (RuleUtilty.IsExplode(_battleRoomContext.roomData.Data.RaceType))
		{
			num = 3;
		}
		if (info.CurKillNum >= num)
		{
			_viewModel.PanelShow = true;
			UpdateName(info.KillPlayerName, info.KillTeam, info.KillPlayerId);
			_panelActiveChip.Time = 6000;
			if (RuleUtilty.IsPve(_battleRoomContext.roomData.Data.RaceType))
			{
				UpdateKillNumberImage(info.PveCurKillNum);
			}
			else
			{
				UpdateKillNumberImage(info.CurKillNum);
			}
			UpdateKillTypeImage(info.CurKillNum);
		}
	}

	protected virtual void UpdateKillTypeImage(int killNum)
	{
		if (RuleUtilty.IsOldPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			if (!_killBoss && !_copyWeapon && !_relive && killNum > 4)
			{
				if (killNum >= 10)
				{
					this.GetLoader().RetriveSprite(_killingspreeAsset, _viewModel.KillTypeImage, autosetnative: true);
				}
				else if (killNum >= 7)
				{
					this.GetLoader().RetriveSprite(_unstoppableAsset, _viewModel.KillTypeImage, autosetnative: true);
				}
				else
				{
					this.GetLoader().RetriveSprite(_bigkillAsset, _viewModel.KillTypeImage, autosetnative: true);
				}
			}
		}
		else if (killNum >= 9)
		{
			this.GetLoader().RetriveSprite(_killingspreeAsset, _viewModel.KillTypeImage, autosetnative: true);
		}
		else if (killNum >= 7)
		{
			this.GetLoader().RetriveSprite(_unstoppableAsset, _viewModel.KillTypeImage, autosetnative: true);
		}
		else
		{
			this.GetLoader().RetriveSprite(_bigkillAsset, _viewModel.KillTypeImage, autosetnative: true);
		}
	}

	protected virtual void UpdateKillNumberImage(int num)
	{
		if (RuleUtilty.IsOldPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			if (_killBoss || _copyWeapon || _relive)
			{
				return;
			}
			if (num < 6)
			{
				_panelActiveChip.Time = 6000;
				return;
			}
		}
		if (num > 10)
		{
			this.GetLoader().RetriveSprite(_10kill_Asset, _viewModel.KillNumberImage, autosetnative: true);
		}
		else
		{
			this.GetLoader().RetriveSprite(_killAssets[num], _viewModel.KillNumberImage, autosetnative: true);
		}
	}

	protected virtual void UpdateName(string name, int team, int id)
	{
		if (RuleUtilty.IsOldPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType) && (_killBoss || _copyWeapon || _relive))
		{
			return;
		}
		_viewModel.PlayerNameString = name;
		if (_battleRoomContext.roomData.Data.RaceType == 5)
		{
			if (id == UiIEventCondition.Get_uiMyPlayer_PlayerId())
			{
				_viewModel.PlayerNameTextcolor = _blueColor;
			}
			else
			{
				_viewModel.PlayerNameTextcolor = Color.red;
			}
		}
		else if (team == 2)
		{
			_viewModel.PlayerNameTextcolor = _blueColor;
		}
		else
		{
			_viewModel.PlayerNameTextcolor = Color.red;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(22, UiIEventCondition.Get_killPlayerInfo_InfoList, SetInfoList, initinvoke: true);
		if (RuleUtilty.IsOldPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveUIMessage_Reliveteammate, ReliveTeamChange);
			NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveUIMessage_KillBoss, KillBossChange);
			NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveUIMessage_Copyweapon, CopyWeaponChange);
		}
	}

	private void ReliveTeamChange(bool old, bool newval)
	{
		if (newval && !_killBoss && !_copyWeapon)
		{
			_panelActiveChip.Time = 6000;
			_viewModel.KillNumberShow = false;
			_viewModel.hintImageShow = true;
			_viewModel.KillTypeShow = true;
			_viewModel.PlayerNameTextcolor = new Color(0.266f, 0.805f, 0.961f, 1f);
			_viewModel.PlayerNameString = _messageContext.pveUIMessage.PlayerName;
			_viewModel.KillTypeAnchoredposition = new Vector2(-91f, -25f);
			base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/killbroad/relivehint.png", _viewModel.hintImageImage, autosetnative: true);
			base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/killbroad/reliveicon.png", _viewModel.KillTypeImage, autosetnative: true);
			_viewModel.KillTypeShow = true;
			_relive = true;
		}
		_messageContext.pveUIMessage.Reliveteammate = false;
	}

	private void CopyWeaponChange(bool old, bool newval)
	{
		if (newval && !_killBoss)
		{
			_panelActiveChip.Time = 6000;
			_viewModel.KillNumberShow = false;
			_viewModel.KillTypeShow = true;
			_viewModel.weaponImageShow = true;
			_viewModel.hintImageShow = true;
			_viewModel.PlayerNameString = _messageContext.pveUIMessage.PlayerName;
			_viewModel.PlayerNameTextcolor = new Color(0.266f, 0.805f, 0.961f, 1f);
			_viewModel.KillTypeAnchoredposition = new Vector2(-91f, -25f);
			base.Loader.RetriveSprite($"weapon/{_messageContext.pveUIMessage.Weaponname}", GetSketchString(_messageContext.pveUIMessage.Weaponname, _messageContext.pveUIMessage.Permancentweapon), _viewModel.weaponImageImage, autosetnative: true);
			base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/killbroad/copyweaponicon.png", _viewModel.KillTypeImage, autosetnative: true);
			base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/killbroad/copyweaponhint.png", _viewModel.hintImageImage, autosetnative: true);
			_copyWeapon = true;
		}
		_messageContext.pveUIMessage.Copyweapon = false;
	}

	private void KillBossChange(bool old, bool newval)
	{
		if (newval)
		{
			_panelActiveChip.Time = 6000;
			_viewModel.KillNumberShow = false;
			_viewModel.KillTypeShow = true;
			_viewModel.hintImageShow = true;
			_viewModel.weaponImageShow = false;
			_viewModel.PlayerNameString = _messageContext.pveUIMessage.PlayerName;
			_viewModel.PlayerNameTextcolor = new Color(0.266f, 0.805f, 0.961f, 1f);
			_viewModel.KillTypeAnchoredposition = new Vector2(-91f, -25f);
			base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/killbroad/killbossicon.png", _viewModel.KillTypeImage, autosetnative: true);
			base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/killbroad/killbosshint.png", _viewModel.hintImageImage, autosetnative: true);
			_killBoss = true;
		}
		_messageContext.pveUIMessage.KillBoss = false;
	}

	private string GetSketchString(string weaponName, bool permanentWeapon)
	{
		return string.Format("Assets/Res/Assets/weapon/{0}/ui/ui_jy_{0}{1}.png", weaponName, permanentWeapon ? "-P" : "");
	}

	protected void SetInfoList(Queue<KillPlayerInfoData> ov, Queue<KillPlayerInfoData> infoList)
	{
		if (infoList == null)
		{
			return;
		}
		KillPlayerInfoData killPlayerInfoData = null;
		foreach (KillPlayerInfoData info in infoList)
		{
			if (info.CurKillNumSpecified)
			{
				if (killPlayerInfoData == null)
				{
					killPlayerInfoData = info;
				}
				else if (info.CurKillNum > killPlayerInfoData.CurKillNum)
				{
					killPlayerInfoData = info;
				}
				UpdateKillInfoImage(info);
			}
		}
	}

	protected ActiveChip GetPanelActiveChip()
	{
		return _panelActiveChip;
	}

	private void InitChips()
	{
		_panelActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		bool num = RuleUtilty.IsOldPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType);
		_viewModel.PanelShow = _panelActiveChip.Update(_timeComponent);
		if (num && !_viewModel.PanelShow)
		{
			_killBoss = false;
			_copyWeapon = false;
			_relive = false;
			_viewModel.KillNumberShow = true;
			_viewModel.weaponImageShow = false;
			_viewModel.hintImageShow = false;
			_viewModel.KillTypeAnchoredposition = new Vector2(-118f, 0f);
		}
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
