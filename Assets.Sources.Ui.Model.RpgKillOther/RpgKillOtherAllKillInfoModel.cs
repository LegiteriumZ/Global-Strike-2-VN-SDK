using System;
using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgKillOther;

public class RpgKillOtherAllKillInfoModel : CommonIndividualScoreInfoModel
{
	private List<OneKillInfoData> _list1 = new List<OneKillInfoData>();

	private List<OneKillInfoData> _list2 = new List<OneKillInfoData>();

	private List<OneKillInfoData> _list3 = new List<OneKillInfoData>();

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpgkillother";
		_viewModel.ResourceAssetName = "RpgKillOtherAllKillInfo";
		CellClass = typeof(RpgKillOtherPlayerInfoCellModel);
	}

	protected override void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[24];
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetGroup1);
		IListNotify listNotify2 = NotifyManager.MakeTempNotifyList(GetGroup2);
		IListNotify listNotify3 = NotifyManager.MakeTempNotifyList(GetGroup3);
		for (int i = 0; i < _playerCells.Length; i++)
		{
			_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
			if (i < 6)
			{
				_playerCells[i].Container = _viewModel.TeamGridObj1;
				_playerCells[i].Listener = listNotify;
				_playerCells[i].Index = i;
			}
			else if (i < 18)
			{
				_playerCells[i].Container = _viewModel.TeamGridObj2;
				_playerCells[i].Listener = listNotify2;
				_playerCells[i].Index = i - 6;
			}
			else
			{
				_playerCells[i].Container = _viewModel.TeamGridObj3;
				_playerCells[i].Listener = listNotify3;
				_playerCells[i].Index = i - 18;
			}
			_playerCells[i].SetPlayerContext(_playerContext);
			_playerCells[i].Initialize();
		}
		_notifyGroup.Add(listNotify.Id);
		_notifyGroup.Add(listNotify2.Id);
		_notifyGroup.Add(listNotify3.Id);
	}

	private List<OneKillInfoData> GetGroup1()
	{
		return GetGroup(0, _list1, 6);
	}

	private List<OneKillInfoData> GetGroup2()
	{
		return GetGroup(1, _list2, 12);
	}

	private List<OneKillInfoData> GetGroup3()
	{
		return GetGroup(2, _list3, 6);
	}

	private List<OneKillInfoData> GetGroup(int group, List<OneKillInfoData> list, int maxCount)
	{
		list.Clear();
		List<OneKillInfoData> all = _battleRoomContext.playerInfo.All;
		for (int i = 0; i < all.Count; i++)
		{
			OneKillInfoData oneKillInfoData = all[i];
			if (list.Count < maxCount && oneKillInfoData.Group == group)
			{
				list.Add(oneKillInfoData);
			}
		}
		return list;
	}
}
