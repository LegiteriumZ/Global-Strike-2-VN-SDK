using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.GoldExplode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.GoldExplode;

public class GoldExplodeIndividualMoneyModel : AbstractModel, IPlaybackSystem
{
	private GoldExplodeIndividualMoneyViewModel _viewModel = new GoldExplodeIndividualMoneyViewModel();

	protected GoldExplodeIndividualScoreCellModel[] _playerCells;

	private int _maxPlayerInOneTeam = 8;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	protected override IUiViewModel ViewModel => _viewModel;

	public void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_notifyGroup.Add(NotifyManager.MakeNotifyClass(26, UiIEventCondition.Get_allKillInfo_TeamMoney1, SetTeamMoney1, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeNotifyClass(27, UiIEventCondition.Get_allKillInfo_TeamMoney2, SetTeamMoney2, initinvoke: true));
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_allKillInfo_IndividualVisible, SetIndividualVisible, null, initinvoke: true);
	}

	private void SetIndividualVisible(bool ov, bool visible)
	{
		_viewModel.ShowShow = visible;
		if (visible)
		{
			SetTeamMoney1(null, UiIEventCondition.Get_allKillInfo_TeamMoney1());
			SetTeamMoney2(null, UiIEventCondition.Get_allKillInfo_TeamMoney2());
		}
		_notifyGroup.SetSuspend(!visible);
	}

	private void SetTeamMoney1(List<OneKillInfoData> ov, List<OneKillInfoData> list)
	{
		int i;
		for (i = 0; i < list.Count && i < _maxPlayerInOneTeam; i++)
		{
			OneKillInfoData data = list[i];
			UpdatePlayerMoney(data, i + 1);
		}
		for (; i < _maxPlayerInOneTeam; i++)
		{
			_viewModel.SetNameTextShow(i + 1, value: false);
		}
	}

	private void SetTeamMoney2(List<OneKillInfoData> ov, List<OneKillInfoData> list)
	{
		int i;
		for (i = 0; i < list.Count && i < _maxPlayerInOneTeam; i++)
		{
			OneKillInfoData data = list[i];
			UpdatePlayerMoney(data, _maxPlayerInOneTeam + i + 1);
		}
		for (; i < _maxPlayerInOneTeam; i++)
		{
			_viewModel.SetNameTextShow(_maxPlayerInOneTeam + i + 1, value: false);
		}
	}

	private void UpdatePlayerMoney(OneKillInfoData data, int index)
	{
		_viewModel.SetNameTextShow(index, value: true);
		_viewModel.SetNameTextString(index, data.PlayerName);
		_viewModel.SetMoneyTextString(index, data.AllMoney.ToString());
	}
}
