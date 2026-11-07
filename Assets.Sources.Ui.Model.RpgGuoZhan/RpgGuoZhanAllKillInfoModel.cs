using System;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.PveCommon;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgGuoZhan;

public class RpgGuoZhanAllKillInfoModel : PveAllKillInfoModel
{
	protected override void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamMember];
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_allKillInfo_All);
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
}
