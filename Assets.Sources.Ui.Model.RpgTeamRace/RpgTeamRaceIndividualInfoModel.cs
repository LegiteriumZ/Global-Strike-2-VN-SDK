using System;
using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.RpgGroup;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgTeamRace;

public class RpgTeamRaceIndividualInfoModel : RpgGroupIndividualInfoModel
{
	private List<OneKillInfoData> _list1 = new List<OneKillInfoData>();

	private List<OneKillInfoData> _list2 = new List<OneKillInfoData>();

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpggroup";
		_viewModel.ResourceAssetName = "RpgGroupIndividualInfo";
		CellClass = typeof(RpgGroupIndividualScoreCellModel);
	}

	protected override void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamNum * TeamMember];
		if (TeamNum == 2)
		{
			IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetTeam1);
			IListNotify listNotify2 = NotifyManager.MakeTempNotifyList(GetTeam2);
			for (int i = 0; i < _playerCells.Length; i++)
			{
				_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
				_playerCells[i].Container = ((i < TeamMember) ? _viewModel.TeamGridObj1 : _viewModel.TeamGridObj2);
				_playerCells[i].Listener = ((i < TeamMember) ? listNotify : listNotify2);
				_playerCells[i].Index = ((i < TeamMember) ? i : (i - TeamMember));
				_playerCells[i].SetPlayerContext(_playerContext);
				_playerCells[i].Initialize();
			}
			_notifyGroup.Add(listNotify.Id);
			_notifyGroup.Add(listNotify2.Id);
		}
	}

	private List<OneKillInfoData> GetTeam1()
	{
		int num = (_playerContext.isMyPlayer ? _playerContext.myPlayerEntity.GetTeam() : 0);
		List<OneKillInfoData> all = _battleRoomContext.playerInfo.All;
		_list1.Clear();
		_list2.Clear();
		for (int i = 0; i < all.Count; i++)
		{
			if (all[i].Team == num)
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
}
