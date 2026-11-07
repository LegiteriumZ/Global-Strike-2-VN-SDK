using System;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.PveCommon;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.PveCommon;

public class PveAllKillInfoModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, IKeyboardResponder, ICursorControl, ISetBattleRoomContext, ISetPlayerContext
{
	protected PveAllKillInfoViewModel _viewModel;

	protected int TeamMember = 6;

	protected Type CellClass;

	protected NotifyGroup _notifyGroup = new NotifyGroup();

	protected IPlayerScoreCell[] _playerCells;

	private ActiveChip _resultActiveChip = new ActiveChip();

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveAllKillInfoViewModel();
		CellClass = typeof(PveAllKillInfoCellModel);
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		if (_resultActiveChip.Time > 0)
		{
			UpdateChips();
			if (_viewModel.ResultShow)
			{
				_viewModel.CountDownString = Mathf.FloorToInt((float)_resultActiveChip.Time / 1000f).ToString();
			}
			else
			{
				_viewModel.ShowShow = false;
			}
		}
		if (_playerCells != null)
		{
			for (int i = 0; i < _playerCells.Length; i++)
			{
				_playerCells[i].OnPlayback();
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiRoomData_RoomTitle, SetRoomTitle, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_PveLevel, SetPveLevel, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_allKillInfo_TeamCount2, SetTeamCount, null, initinvoke: true));
		CreateCells();
		_notifyGroup.SetSuspend(suspend: true);
	}

	protected virtual void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamMember];
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_allKillInfo_Team2);
		for (int i = 0; i < _playerCells.Length; i++)
		{
			_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
			_playerCells[i].Container = _viewModel.TeamGridObj;
			_playerCells[i].Listener = listNotify;
			_playerCells[i].Index = i;
			_playerCells[i].SetPlayerContext(_playerContext);
			_playerCells[i].Initialize();
		}
		_notifyGroup.Add(listNotify.Id);
	}

	private void SetTeamCount(int arg1, int arg2)
	{
		_viewModel.PlayerCountString = arg2 + "/" + _battleRoomContext.roomData.LimitNum;
	}

	private void SetLoot(string val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		UpdateLoot(idx + 1, newfs);
	}

	private void SetRoomTitle(string ov, string name)
	{
		_viewModel.RoomNameString = name;
	}

	private void SetMessageData(GameMessageData ov, GameMessageData messageData)
	{
		if (messageData == null)
		{
			return;
		}
		GameMessageType type = messageData.Type;
		if (type == GameMessageType.SHOWNEXTBATTLE)
		{
			if (!_battleRoomContext.roomData.IsObserver)
			{
				_resultActiveChip.Time = messageData.Time;
			}
			_viewModel.ShowShow = true;
			_notifyGroup.SetSuspend(suspend: false);
		}
	}

	private void SetPveLevel(int ov, int level)
	{
		string bundleName;
		string arg;
		if (RuleUtilty.IsOldPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			bundleName = "ui/towerdefensemodel";
			arg = "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel";
		}
		else
		{
			bundleName = "ui/rpgmodel";
			arg = "Assets/Res/Assets/ui/GameGUIRes/rpgModel";
		}
		AssetInfo assetInfo = new AssetInfo(bundleName, $"{arg}/killList/normal.png");
		AssetInfo assetInfo2 = new AssetInfo(bundleName, $"{arg}/killList/difficult.png");
		AssetInfo assetInfo3 = new AssetInfo(bundleName, $"{arg}/killList/nightmare.png");
		AssetInfo assetInfo4 = new AssetInfo(bundleName, $"{arg}/killList/singlefight.png");
		switch (level)
		{
		case 2:
			base.Loader.RetriveSprite(assetInfo2.BundleName, assetInfo2.AssetName, delegate(Sprite sprite)
			{
				_viewModel.TitleSprite = sprite;
			});
			break;
		case 3:
			base.Loader.RetriveSprite(assetInfo3.BundleName, assetInfo3.AssetName, delegate(Sprite sprite)
			{
				_viewModel.TitleSprite = sprite;
			});
			break;
		case 4:
			base.Loader.RetriveSprite(assetInfo4.BundleName, assetInfo4.AssetName, delegate(Sprite sprite)
			{
				_viewModel.TitleSprite = sprite;
			});
			break;
		default:
			base.Loader.RetriveSprite(assetInfo.BundleName, assetInfo.AssetName, delegate(Sprite sprite)
			{
				_viewModel.TitleSprite = sprite;
			});
			break;
		}
	}

	private void UpdateLoot(int index, string image)
	{
		if (string.IsNullOrEmpty(image))
		{
			_viewModel.SetLootShow(index, value: false);
			return;
		}
		_viewModel.SetLootShow(index, value: true);
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		AssetInfo assetInfo;
		if (image == "tuxihuiji")
		{
			assetInfo = new AssetInfo("ui/rpgrescuemodel", "Assets/Res/Assets/ui/GameGUIRes/rpgRescueModel/killList/" + image + ".png");
		}
		else
		{
			string bundleName;
			string arg;
			if (RuleUtilty.IsOldPve(raceType))
			{
				bundleName = "ui/towerdefensemodel";
				arg = "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel";
				if (index == 1)
				{
					_viewModel.SetLootAnchoredposition(1, new Vector2(-206f, -163f));
				}
				else if (index == 2)
				{
					_viewModel.SetLootAnchoredposition(2, new Vector2(135f, -69f));
				}
				else if (index == 3)
				{
					_viewModel.SetLootAnchoredposition(3, new Vector2(257f, -155f));
				}
				else if (index == 4)
				{
					_viewModel.SetLootAnchoredposition(4, new Vector2(150f, -235f));
				}
			}
			else
			{
				bundleName = "ui/rpgmodel";
				arg = "Assets/Res/Assets/ui/GameGUIRes/rpgModel";
			}
			assetInfo = new AssetInfo(bundleName, $"{arg}/killList/{image}.png");
		}
		base.Loader.RetriveSprite(assetInfo.BundleName, assetInfo.AssetName, delegate(Sprite sprite)
		{
			_viewModel.SetLootSprite(index, sprite);
			_viewModel.CallLootNtvsize(index);
		});
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.Tab)
		{
			_viewModel.ShowShow = true;
			_gameRuleContext.individualVisible.IndividualVisible = true;
			_notifyGroup.SetSuspend(suspend: false);
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (key == KeyCode.Tab)
		{
			_viewModel.ShowShow = false;
			_gameRuleContext.individualVisible.IndividualVisible = false;
			_notifyGroup.SetSuspend(suspend: true);
		}
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public int GetCursorState()
	{
		return 0;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	private void InitChips()
	{
		_resultActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ResultShow = _resultActiveChip.Update(_timeComponent);
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
