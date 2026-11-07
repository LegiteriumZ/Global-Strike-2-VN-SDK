using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class CommonIndividualScoreCellModel : AbstractModel, IPlaybackSystem, IPlayerScoreCell, ISetPlayerContext
{
	protected CommonIndividualScoreCellViewModel _viewModel;

	private OneKillInfoData _updateScore;

	protected static AssetInfo AceAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/ace.png");

	protected static AssetInfo Ace2Asset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/2nd.png");

	protected static AssetInfo Ace3Asset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/3nd.png");

	protected static AssetInfo KdKingAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/kd.png");

	protected static AssetInfo MvpAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/mvp.png");

	protected static AssetInfo MaxHidePackAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/blaster.png");

	protected static AssetInfo HasC4Asset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/c4icon.png");

	protected static AssetInfo MaxOpenPackAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/specialists.png");

	protected static AssetInfo GunkingAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/gunking.png");

	protected static AssetInfo CompeteKingAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/competeKing.png");

	private OneKillInfoData _updateHonoray;

	protected PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public GameObject Container { get; set; }

	public int Index { get; set; }

	public IListNotify Listener { get; set; }

	public bool HasSubscribed()
	{
		return true;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CommonIndividualScoreCellViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_updateHonoray != null)
			{
				HideHonoray(UpdateHonoray(_updateHonoray));
				_updateHonoray = null;
			}
			if (_updateScore != null)
			{
				UpdateScore(_updateScore);
				_updateScore = null;
			}
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ViewGameObject.transform.SetParent(Container.transform);
		base.DoSubscribe();
		_viewModel.ViewGameObjectShow = false;
		_viewModel.RankTextString = (Index + 1).ToString();
		Listener.AddEvent<OneKillInfoData, string>("PlayerName", UiIEventCondition.Get_OneKillInfoData_PlayerName, SetPlayerName, Index);
		Listener.AddEvent<OneKillInfoData, int>("VipLevel", UiIEventCondition.Get_OneKillInfoData_VipLevel, SetVipLevel, Index);
		Listener.AddEvent<OneKillInfoData, bool>("IsDead", UiIEventCondition.Get_OneKillInfoData_IsDead, SetIsDead, Index);
		Listener.AddEvent<OneKillInfoData, bool>("HasHeroWeapon", UiIEventCondition.Get_OneKillInfoData_HasHeroWeapon, SetHasHeroWeapon, Index);
		Listener.AddEvent<OneKillInfoData, string>("Career", UiIEventCondition.Get_OneKillInfoData_Career, SetCareer, Index);
		Listener.AddEvent<OneKillInfoData, int>("Ping", UiIEventCondition.Get_OneKillInfoData_Ping, SetPing, Index);
		Listener.AddEvent<OneKillInfoData, string>("TeamName", UiIEventCondition.Get_OneKillInfoData_TeamName, SetTeamName, Index);
		Listener.AddEvent<OneKillInfoData, bool>("LoginUnity", UiIEventCondition.Get_OneKillInfoData_LoginUnity, SetLoginUnity, Index);
		Listener.AddEvent<OneKillInfoData, string>("FastWeapon", UiIEventCondition.Get_OneKillInfoData_FastWeapon, SetFastWeapon, Index);
		Listener.AddEvent<OneKillInfoData, bool>("Ace", UiIEventCondition.Get_OneKillInfoData_Ace, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("Ace2", UiIEventCondition.Get_OneKillInfoData_Ace2, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("Ace3", UiIEventCondition.Get_OneKillInfoData_Ace3, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("KdKing", UiIEventCondition.Get_OneKillInfoData_KdKing, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("Mvp", UiIEventCondition.Get_OneKillInfoData_Mvp, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("HasC4", UiIEventCondition.Get_OneKillInfoData_HasC4, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("GoldHunter", UiIEventCondition.Get_OneKillInfoData_GoldHunter, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("MaxHidePack", UiIEventCondition.Get_OneKillInfoData_MaxHidePack, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("MaxOpenPack", UiIEventCondition.Get_OneKillInfoData_MaxOpenPack, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("Overload", UiIEventCondition.Get_OneKillInfoData_Overload, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("Terminator", UiIEventCondition.Get_OneKillInfoData_Terminator, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("Nurse", UiIEventCondition.Get_OneKillInfoData_Nurse, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, int>("KillNum", UiIEventCondition.Get_OneKillInfoData_KillNum, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("BeKillNum", UiIEventCondition.Get_OneKillInfoData_BeKillNum, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("AssistsNum", UiIEventCondition.Get_OneKillInfoData_AssistsNum, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("StrikeScore", UiIEventCondition.Get_OneKillInfoData_StrikeScore, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("AccessoryScore", UiIEventCondition.Get_OneKillInfoData_AccessoryScore, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("TreatmentScore", UiIEventCondition.Get_OneKillInfoData_TreatmentScore, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, long>("Score", UiIEventCondition.Get_OneKillInfoData_Score, SetScoreLong, Index);
		Listener.AddEvent<OneKillInfoData, int>("JumpTime", UiIEventCondition.Get_OneKillInfoData_JumpTime, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("SavePoint", UiIEventCondition.Get_OneKillInfoData_SavePoint, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("ReadPoint", UiIEventCondition.Get_OneKillInfoData_ReadPoint, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("AdditionalTime", UiIEventCondition.Get_OneKillInfoData_AdditionalTime, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("Lv", UiIEventCondition.Get_OneKillInfoData_Lv, SetScore, Index);
	}

	private void SetFastWeapon(OneKillInfoData val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		_viewModel.WeaponString = ScriptLocalization.Get(newfs);
	}

	protected virtual void SetCareer(OneKillInfoData val, int idx, string oldfs, string newfs, ElementStatus status)
	{
	}

	protected void SetScore(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_updateScore = val;
		}
	}

	protected void SetScoreLong(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_updateScore = val;
		}
	}

	protected virtual void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.KillNum.ToString();
		_viewModel.PlayerScoreString2 = data.BeKillNum.ToString();
		_viewModel.PlayerScoreString3 = data.AssistsNum.ToString();
	}

	private void SetLoginUnity(OneKillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		_viewModel.UnityFlagShow = newfs;
	}

	private void SetTeamName(OneKillInfoData val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_viewModel.PlayerTeamString = newfs;
			SetSelfTeamBackShow(val.PlayerName, newfs);
		}
	}

	private void SetSelfTeamBackShow(string playerName, string teamName)
	{
		_viewModel.SelfTeamBackShow = playerName != UiIEventCondition.Get_uiMyPlayer_PlayerName() && !string.IsNullOrEmpty(teamName) && teamName == UiIEventCondition.Get_uiMyPlayer_TeamName();
	}

	protected virtual int UpdateHonoray(OneKillInfoData data)
	{
		int uiMyPlayer_Team = UiIEventCondition.Get_uiMyPlayer_Team();
		int index = 1;
		index = SetHonoray(data.Ace, index, ref AceAsset);
		index = SetHonoray(data.Ace2, index, ref Ace2Asset);
		index = SetHonoray(data.Ace3, index, ref Ace3Asset);
		index = SetHonoray(data.KdKing, index, ref KdKingAsset);
		index = SetHonoray(data.Mvp, index, ref MvpAsset);
		index = SetHonoray(data.MaxHidePack, index, ref MaxHidePackAsset);
		index = SetHonoray(data.HasC4 && data.Team == uiMyPlayer_Team, index, ref HasC4Asset);
		return SetHonoray(data.MaxOpenPack, index, ref MaxOpenPackAsset);
	}

	protected void SetAce(OneKillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		_updateHonoray = val;
	}

	private void SetPing(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerPingString = newfs.ToString();
	}

	protected virtual void SetHasHeroWeapon(OneKillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		_viewModel.HeroImageShow = newfs;
	}

	private void SetIsDead(OneKillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		_viewModel.PlayerDeadShow = newfs;
	}

	private void SetPlayerName(OneKillInfoData val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_viewModel.ViewGameObjectShow = true;
			_viewModel.PlayerNameString = newfs;
			_viewModel.SelfBackShow = newfs == UiIEventCondition.Get_uiMyPlayer_PlayerName();
			SetSelfTeamBackShow(newfs, val.TeamName);
		}
		else
		{
			_viewModel.ViewGameObjectShow = false;
		}
	}

	protected virtual void SetVipLevel(OneKillInfoData val, int idx, int oldfs, int level, ElementStatus status)
	{
		if (level > 0)
		{
			_viewModel.VipShow = true;
			this.GetLoader().RetriveSprite(CommonAssets.VipAssets[level], delegate(Sprite sprite)
			{
				_viewModel.VipSprite = sprite;
			});
		}
		else
		{
			_viewModel.VipShow = false;
		}
	}

	protected int SetHonoray(bool flag, int index, ref AssetInfo image)
	{
		if (flag && index <= 2)
		{
			_viewModel.SetPlayerHonorShow(index, value: true);
			int index2 = index;
			this.GetLoader().RetriveSprite(image, delegate(Sprite sprite)
			{
				_viewModel.SetPlayerHonorSprite(index2, sprite);
			});
			index++;
		}
		return index;
	}

	protected void HideHonoray(int index)
	{
		while (index < 4)
		{
			_viewModel.SetPlayerHonorShow(index, value: false);
			index++;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
