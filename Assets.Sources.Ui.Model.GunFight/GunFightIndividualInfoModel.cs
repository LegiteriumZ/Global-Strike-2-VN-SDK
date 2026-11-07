using System;
using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.GunFight;

[GameUiTest]
public class GunFightIndividualInfoModel : CommonIndividualScoreInfoModel
{
	private List<OneKillInfoData> _list1 = new List<OneKillInfoData>();

	private List<OneKillInfoData> _list2 = new List<OneKillInfoData>();

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/GunFight";
		_viewModel.ResourceAssetName = "GunFightIndividualScoreInfo";
		CellClass = typeof(GunFightScoreCellModel);
		TeamNum = 2;
		TeamMember = 2;
	}

	protected override void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamNum * TeamMember];
		if (TeamNum != 2)
		{
			return;
		}
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetTeam1);
		IListNotify listNotify2 = NotifyManager.MakeTempNotifyList(GetTeam2);
		for (int i = 0; i < _playerCells.Length; i++)
		{
			_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
			if (i < TeamMember)
			{
				_playerCells[i].Container = _viewModel.TeamGridObj1;
				_playerCells[i].Listener = listNotify;
				_playerCells[i].Index = i;
			}
			else
			{
				_playerCells[i].Container = _viewModel.TeamGridObj2;
				_playerCells[i].Listener = listNotify2;
				_playerCells[i].Index = i - TeamMember;
			}
			_playerCells[i].SetPlayerContext(_playerContext);
			_playerCells[i].Initialize();
		}
		_notifyGroup.Add(listNotify.Id);
		_notifyGroup.Add(listNotify2.Id);
	}

	private List<OneKillInfoData> GetTeam1()
	{
		List<OneKillInfoData> all = _battleRoomContext.playerInfo.All;
		_list1.Clear();
		_list2.Clear();
		for (int i = 0; i < all.Count; i++)
		{
			if (all[i].Team == 2)
			{
				_list1.Add(all[i]);
			}
			else
			{
				_list2.Add(all[i]);
			}
		}
		return _list1;
	}

	private List<OneKillInfoData> GetTeam2()
	{
		return _list2;
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
