using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class PickaxeModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private PickaxeViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

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
		_viewModel = new PickaxeViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = true;
		NotifyManager.MakeTempNotify(GetPowerNumber, SetPowerNumber, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetMaxPowerNumber, SetMaxPowerNumber, null, initinvoke: true);
	}

	private int GetPowerNumber()
	{
		if (_weaponContext.currentWeaponEntity != null && _weaponContext.currentWeaponEntity.hasPower)
		{
			return _weaponContext.currentWeaponEntity.power.Power;
		}
		return 0;
	}

	private void SetPowerNumber(int arg1, int arg2)
	{
		for (int i = 0; i < 5; i++)
		{
			_viewModel.SetdunShow(i + 1, arg2 > i);
		}
	}

	private int GetMaxPowerNumber()
	{
		if (_weaponContext.currentWeaponEntity != null && _weaponContext.currentWeaponEntity.hasPower)
		{
			return _weaponContext.currentWeaponEntity.power.MaxPower;
		}
		return 0;
	}

	private void SetMaxPowerNumber(int arg1, int arg2)
	{
		for (int i = 0; i < 5; i++)
		{
			_viewModel.SetdunBgShow(i + 1, arg2 > i);
		}
		switch (arg2)
		{
		case 3:
			_viewModel.ShowPosition = new Vector3(16f, 0f, 0f);
			break;
		case 5:
			_viewModel.ShowPosition = new Vector3(0f, 0f, 0f);
			break;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
