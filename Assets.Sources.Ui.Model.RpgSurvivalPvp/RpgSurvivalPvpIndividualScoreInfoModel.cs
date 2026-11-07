using System;
using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgSurvivalPvp;

public class RpgSurvivalPvpIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	private Comparison<OneKillInfoData> _sortKillComparer;

	protected override void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamNum * TeamMember];
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetList);
		for (int i = 0; i < _playerCells.Length; i++)
		{
			_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
			_playerCells[i].Container = _viewModel.TeamGridObj1;
			_playerCells[i].Listener = listNotify;
			_playerCells[i].Index = i;
			_playerCells[i].SetPlayerContext(_playerContext);
			_playerCells[i].Initialize();
		}
		_notifyGroup.Add(listNotify.Id);
	}

	private int SortSkill(OneKillInfoData a, OneKillInfoData b)
	{
		if (a.Team > b.Team)
		{
			return 1;
		}
		if (a.Team < b.Team)
		{
			return -1;
		}
		if (a.Score > b.Score)
		{
			return -1;
		}
		if (a.Score < b.Score)
		{
			return 1;
		}
		if (a.Id < b.Id)
		{
			return -1;
		}
		if (a.Id > b.Id)
		{
			return 1;
		}
		return 0;
	}

	private List<OneKillInfoData> GetList()
	{
		List<OneKillInfoData> all = _battleRoomContext.playerInfo.All;
		all.Sort(_sortKillComparer);
		return all;
	}

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpgsurvivalpvp";
		_viewModel.ResourceAssetName = "RpgSurvivalPvpIndividualScoreInfo";
		CellClass = typeof(RpgSurvivalPvpIndividualScoreCellModel);
		TeamNum = 1;
		TeamMember = 64;
		_sortKillComparer = SortSkill;
	}

	protected override void SetIsObserver(bool ov, bool flag)
	{
		_viewModel.ResultBgShow = false;
	}
}
