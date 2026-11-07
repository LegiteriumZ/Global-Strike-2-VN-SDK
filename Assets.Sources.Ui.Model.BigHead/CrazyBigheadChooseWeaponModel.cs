using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BigHead;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BigHead;

[GameUiTest]
public class CrazyBigheadChooseWeaponModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, IKeyboardResponder, ISetBattleServerContext
{
	private CrazyBigheadChooseWeaponViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private BattleServerContext _battleServerContext;

	private ActiveChip _tActiveChip;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
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
		_viewModel = new CrazyBigheadChooseWeaponViewModel();
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
		_viewModel.ShowShow = false;
		for (int i = 1; i <= 6; i++)
		{
			_viewModel.SetSelectShow(i, value: false);
			_viewModel.SetUnSelectShow(i, value: false);
			_viewModel.SetWeaponShow(i, value: false);
		}
		NotifyManager.MakeNotify(83, UiIEventCondition.Get_CrazyBigHeadMessage, ShowChooseWeapon);
	}

	private void ShowChooseWeapon(bool arg1, bool arg2)
	{
		HeroWeaponData heroWeaponData = _gameRuleContext.crazyBigHead.HeroWeaponData;
		_tActiveChip.Time = heroWeaponData.ShowTime;
		_viewModel.ShowShow = true;
		for (int j = 1; j <= 6; j++)
		{
			_viewModel.SetSelectShow(j, heroWeaponData.CurrentKey == j);
			_viewModel.SetUnSelectShow(j, j != 6 && string.IsNullOrEmpty(_gameRuleContext.crazyBigHead.WeaponList[j - 1]));
			_viewModel.SetWeaponShow(j, j == 6 || !string.IsNullOrEmpty(_gameRuleContext.crazyBigHead.WeaponList[j - 1]));
			if (!_viewModel.GetWeaponShow(j) || j >= 6)
			{
				continue;
			}
			string name = _gameRuleContext.crazyBigHead.WeaponList[j - 1];
			IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(name);
			if (weaponInfo != null)
			{
				AssetInfo weaponIcon_2AssetInfo = weaponInfo.GetWeaponIcon_2AssetInfo("");
				int i1 = j;
				base.Loader.RetriveSprite(weaponIcon_2AssetInfo.BundleName, weaponIcon_2AssetInfo.AssetName, delegate(Sprite sprite)
				{
					_viewModel.SetWeaponSprite(i1, sprite);
					_viewModel.SetWeaponScale(i1, Vector3.one * 0.9f);
				});
			}
		}
	}

	private void InitChips()
	{
		_tActiveChip = new ActiveChip();
		_tActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ShowShow = _tActiveChip.Update(_timeComponent);
	}

	private bool GetIsUnSelect(int i)
	{
		if (i == 5)
		{
			return false;
		}
		return string.IsNullOrEmpty(_gameRuleContext.crazyBigHead.WeaponList[i]);
	}

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}

	private void SetSelected(int key)
	{
		if (!GetIsUnSelect(key))
		{
			_tActiveChip.Time = 0;
			_gameRuleContext.crazyBigHead.SelectedIndex = key + 1;
			_gameRuleContext.crazyBigHead.IsSelected = true;
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (_battleRoomContext.roomData.Data.RaceType != 120)
		{
			return false;
		}
		if (_tActiveChip.Time > 0)
		{
			if (key.CheckEqualKeyCode(KeyCode.Alpha1))
			{
				SetSelected(0);
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha2))
			{
				SetSelected(1);
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha3))
			{
				SetSelected(2);
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha4))
			{
				SetSelected(3);
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha5))
			{
				SetSelected(4);
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha6))
			{
				_tActiveChip.Time = 0;
				_gameRuleContext.crazyBigHead.SelectedIndex = 6;
				_gameRuleContext.crazyBigHead.IsSelected = true;
			}
			if (_gameRuleContext.crazyBigHead.IsSelected)
			{
				ProtoIntData protoIntData = new ProtoIntData();
				protoIntData.Data = _gameRuleContext.crazyBigHead.SelectedIndex;
				_battleServerContext.battleServer.Server.SendTcpMessage(114, protoIntData);
				_gameRuleContext.crazyBigHead.IsSelected = false;
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}
}
