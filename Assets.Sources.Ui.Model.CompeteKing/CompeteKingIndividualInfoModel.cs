using System;
using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.CompeteKing;

[GameUiTest]
public class CompeteKingIndividualInfoModel : CommonIndividualScoreInfoModel
{
	private List<OneKillInfoData> _list1 = new List<OneKillInfoData>();

	private List<OneKillInfoData> _list2 = new List<OneKillInfoData>();

	private List<OneKillInfoData> _list3 = new List<OneKillInfoData>();

	private List<OneKillInfoData> _list4 = new List<OneKillInfoData>();

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/CompeteKing";
		_viewModel.ResourceAssetName = "CompeteKingIndividualScoreInfo";
		CellClass = typeof(CompeteKingScoreCellModel);
		TeamNum = 4;
		TeamMember = 2;
	}

	protected override void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamNum * TeamMember];
		if (TeamNum != 4)
		{
			return;
		}
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetTeam1);
		IListNotify listNotify2 = NotifyManager.MakeTempNotifyList(GetTeam2);
		IListNotify listNotify3 = NotifyManager.MakeTempNotifyList(GetTeam3);
		IListNotify listNotify4 = NotifyManager.MakeTempNotifyList(GetTeam4);
		for (int i = 0; i < _playerCells.Length; i++)
		{
			_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
			if (i < 2)
			{
				_playerCells[i].Container = _viewModel.TeamGridObj1;
				_playerCells[i].Listener = listNotify;
				_playerCells[i].Index = i;
			}
			else if (i >= 2 && i < 4)
			{
				_playerCells[i].Container = _viewModel.TeamGridObj2;
				_playerCells[i].Listener = listNotify2;
				_playerCells[i].Index = i - TeamMember;
			}
			else if (i >= 4 && i < 6)
			{
				_playerCells[i].Container = _viewModel.TeamGridObj3;
				_playerCells[i].Listener = listNotify3;
				_playerCells[i].Index = i - TeamMember * 2;
			}
			else
			{
				_playerCells[i].Container = _viewModel.TeamGridObj4;
				_playerCells[i].Listener = listNotify4;
				_playerCells[i].Index = i - TeamMember * 3;
			}
			_playerCells[i].SetPlayerContext(_playerContext);
			_playerCells[i].Initialize();
		}
		_notifyGroup.Add(listNotify.Id);
		_notifyGroup.Add(listNotify2.Id);
		_notifyGroup.Add(listNotify3.Id);
		_notifyGroup.Add(listNotify4.Id);
	}

	private List<OneKillInfoData> GetTeam1()
	{
		List<OneKillInfoData> all = _battleRoomContext.playerInfo.All;
		_list1.Clear();
		_list2.Clear();
		_list3.Clear();
		_list4.Clear();
		for (int i = 0; i < all.Count; i++)
		{
			if (all[i].Team == 1)
			{
				_list1.Add(all[i]);
			}
			else if (all[i].Team == 2)
			{
				_list2.Add(all[i]);
			}
			else if (all[i].Team == 3)
			{
				_list3.Add(all[i]);
			}
			else
			{
				_list4.Add(all[i]);
			}
		}
		return _list1;
	}

	private List<OneKillInfoData> GetTeam2()
	{
		return _list2;
	}

	private List<OneKillInfoData> GetTeam3()
	{
		return _list3;
	}

	private List<OneKillInfoData> GetTeam4()
	{
		return _list4;
	}

	protected override void SetPlayerNum(int idx)
	{
		_viewModel.PlayerNumberString = "";
	}

	protected override void SetRoomTitle(string arg1, string arg2)
	{
		_viewModel.RoomString = "";
	}
}
