using System;
using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.RpgGroup;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgTeamRace;

public class RpgTeamRaceFinalInfoModel : RpgGroupIndividualInfoModel
{
	private List<OneKillInfoData> _list1 = new List<OneKillInfoData>();

	private List<OneKillInfoData> _list2 = new List<OneKillInfoData>();

	private List<OneKillInfoData> _list3 = new List<OneKillInfoData>();

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpgteamrace";
		_viewModel.ResourceAssetName = "RpgTeamRaceFinalIndividualInfo";
		CellClass = typeof(RpgTeamRaceFinalIndividualScoreCellModel);
		TeamNum = 3;
	}

	protected override void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamNum * TeamMember];
		if (TeamNum != 3)
		{
			return;
		}
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetTeam1);
		IListNotify listNotify2 = NotifyManager.MakeTempNotifyList(GetTeam2);
		IListNotify listNotify3 = NotifyManager.MakeTempNotifyList(GetTeam3);
		for (int i = 0; i < _playerCells.Length; i++)
		{
			_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
			if (i < TeamMember)
			{
				_playerCells[i].Container = _viewModel.TeamGridObj1;
				_playerCells[i].Listener = listNotify;
				_playerCells[i].Index = i;
			}
			else if (i < TeamMember * 2 && i >= TeamMember)
			{
				_playerCells[i].Container = _viewModel.TeamGridObj2;
				_playerCells[i].Listener = listNotify2;
				_playerCells[i].Index = i - TeamMember;
			}
			else
			{
				_playerCells[i].Container = _viewModel.TeamGridObj3;
				_playerCells[i].Listener = listNotify3;
				_playerCells[i].Index = i - TeamMember * 2;
			}
			_playerCells[i].SetPlayerContext(_playerContext);
			_playerCells[i].Initialize();
		}
		_notifyGroup.Add(listNotify.Id);
		_notifyGroup.Add(listNotify2.Id);
		_notifyGroup.Add(listNotify3.Id);
	}

	private List<OneKillInfoData> GetTeam1()
	{
		if (_playerContext.isMyPlayer)
		{
			_playerContext.myPlayerEntity.GetTeam();
		}
		List<OneKillInfoData> all = _battleRoomContext.playerInfo.All;
		_list1.Clear();
		_list2.Clear();
		_list3.Clear();
		for (int i = 0; i < all.Count; i++)
		{
			if (all[i].Team == 8)
			{
				_list1.Add(all[i]);
			}
			else if (all[i].Team == 6)
			{
				_list2.Add(all[i]);
			}
			else
			{
				_list3.Add(all[i]);
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
}
