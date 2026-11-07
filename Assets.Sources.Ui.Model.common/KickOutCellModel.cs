using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class KickOutCellModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private KickOutCellViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private KickOutUIModel _kickOutUIModel;

	public GameObject Container { get; set; }

	public int Index { get; set; }

	public int Team { get; set; }

	public SimpleNotifyGroup Group { get; set; }

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetKicOutUIModel(KickOutUIModel context)
	{
		_kickOutUIModel = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new KickOutCellViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ViewGameObject.transform.SetParent(Container.transform);
		base.DoSubscribe();
		Group.Add(SimpleNotify.Add(GetVisible, SetVisible, Index));
		Group.Add(SimpleNotify.Add(GetName, SetName, Index));
		_viewModel.KickOutCellClicked.AddListener(OnClicked);
	}

	private void SetName(string arg1, int index)
	{
		_viewModel.PlayerNameString = arg1;
	}

	private string GetName(int index)
	{
		OneKillInfoData player = GetPlayer(index);
		if (player == null)
		{
			return "";
		}
		return player.PlayerName;
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.SelectedShow = arg1;
	}

	private bool GetVisible(int index)
	{
		OneKillInfoData player = GetPlayer(index);
		if (player == null)
		{
			return false;
		}
		return player.Id == _kickOutUIModel.GetPlayerID();
	}

	private void OnClicked()
	{
		OneKillInfoData player = GetPlayer(Index);
		_kickOutUIModel.SetPlayer(player);
	}

	private OneKillInfoData GetPlayer(int index)
	{
		List<OneKillInfoData> list = _gameRuleContext.kickOut.ctPlayerList;
		if (Team == 2)
		{
			list = _gameRuleContext.kickOut.tPlayerList;
		}
		if (index >= list.Count)
		{
			return null;
		}
		return list[index];
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
