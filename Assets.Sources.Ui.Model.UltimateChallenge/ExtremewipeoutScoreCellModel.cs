using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.UltimateChallenge;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.UltimateChallenge;

[GameUiTest]
public class ExtremewipeoutScoreCellModel : AbstractModel, IPlaybackSystem, IPlayerScoreCell
{
	private ExtremewipeoutScoreCellViewModel _viewModel;

	private PlayerContext _playerContext;

	protected static AssetInfo AceAsset = new AssetInfo("ui/extremewipeoutmodel", "Assets/Res/Assets/ui/GameGUIRes/ExtremeWipeOutModel/1.png");

	protected static AssetInfo Ace2Asset = new AssetInfo("ui/extremewipeoutmodel", "Assets/Res/Assets/ui/GameGUIRes/ExtremeWipeOutModel/2.png");

	protected static AssetInfo Ace3Asset = new AssetInfo("ui/extremewipeoutmodel", "Assets/Res/Assets/ui/GameGUIRes/ExtremeWipeOutModel/3.png");

	private OneKillInfoData _updateHonoray;

	private OneKillInfoData _updateScore;

	protected override IUiViewModel ViewModel => _viewModel;

	public GameObject Container { get; set; }

	public int Index { get; set; }

	public IListNotify Listener { get; set; }

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new ExtremewipeoutScoreCellViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
			if (_updateHonoray != null)
			{
				UpdateAce(_updateHonoray);
				_updateHonoray = null;
			}
			if (_updateScore != null)
			{
				UpdateScore(_updateScore);
				_updateScore = null;
			}
		}
	}

	public bool HasSubscribed()
	{
		return true;
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ViewGameObjectShow = false;
		_viewModel.rankShow = false;
		_viewModel.ViewGameObject.transform.SetParent(Container.transform);
		_viewModel.rankNumString = (Index + 1).ToString();
		Listener.AddEvent<OneKillInfoData, string>("PlayerName", UiIEventCondition.Get_OneKillInfoData_PlayerName, SetPlayerName, Index);
		Listener.AddEvent<OneKillInfoData, int>("VipLevel", UiIEventCondition.Get_OneKillInfoData_VipLevel, SetVipLevel, Index);
		Listener.AddEvent<OneKillInfoData, int>("Ping", UiIEventCondition.Get_OneKillInfoData_Ping, SetPing, Index);
		Listener.AddEvent<OneKillInfoData, bool>("Ace", UiIEventCondition.Get_OneKillInfoData_Ace, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("Ace2", UiIEventCondition.Get_OneKillInfoData_Ace2, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("Ace3", UiIEventCondition.Get_OneKillInfoData_Ace3, SetAce, Index);
		Listener.AddEvent<OneKillInfoData, bool>("IsDead", UiIEventCondition.Get_OneKillInfoData_IsDead, SetDead, Index);
		Listener.AddEvent<OneKillInfoData, int>("KillNum", UiIEventCondition.Get_OneKillInfoData_KillNum, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, long>("Score", UiIEventCondition.Get_OneKillInfoData_Score, SetLongScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("AssistsNum", UiIEventCondition.Get_OneKillInfoData_AssistsNum, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("AllMoney", UiIEventCondition.Get_OneKillInfoData_hurt, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("lv", UiIEventCondition.Get_OneKillInfoData_Lv, SetScore, Index);
	}

	private void SetDead(OneKillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			if (!newfs)
			{
				_viewModel.IsSaveString = "存活";
				_viewModel.IsSaveTextcolor = Color.white;
			}
			else
			{
				_viewModel.IsSaveString = "淘汰";
				_viewModel.IsSaveTextcolor = new Color(14f / 51f, 14f / 51f, 14f / 51f);
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private void SetAce(OneKillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_updateHonoray = val;
		}
	}

	private void SetScore(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_updateScore = val;
		}
	}

	private void SetLongScore(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_updateScore = val;
		}
	}

	protected virtual void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.KillNum.ToString();
		_viewModel.PlayerScoreString2 = data.Score.ToString();
		_viewModel.PlayerScoreString3 = data.AssistsNum.ToString();
		_viewModel.PlayerHurtString = data.AllMoney.ToString();
		_viewModel.rankNumString = data.Lv.ToString();
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

	private void SetPlayerName(OneKillInfoData val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_viewModel.ViewGameObjectShow = true;
			_viewModel.PlayerNameString = newfs;
		}
		else
		{
			_viewModel.ViewGameObjectShow = false;
		}
	}

	private void SetPing(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerPingString = newfs.ToString();
	}

	protected virtual void UpdateAce(OneKillInfoData data)
	{
		SetHonoray(data.Ace, ref AceAsset);
		SetHonoray(data.Ace2, ref Ace2Asset);
		SetHonoray(data.Ace3, ref Ace3Asset);
	}

	protected void SetHonoray(bool flag, ref AssetInfo image)
	{
		if (flag)
		{
			_viewModel.rankShow = true;
			this.GetLoader().RetriveSprite(image, delegate(Sprite sprite)
			{
				_viewModel.rankSprite = sprite;
			});
		}
	}
}
