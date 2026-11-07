using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Ui.ViewModel.HomeLandModel;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.HomeLandModel;

[GameUiTest]
public class HomeLandModelRentInfoModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ICursorControl
{
	private HomeLandModelRentInfoViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	public int pag;

	private HomelandRentType _homelandRentType;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

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
		_viewModel = new HomeLandModelRentInfoViewModel();
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
		base.DoSubscribe();
		_viewModel.ShowTipsShow = false;
		_viewModel.ShowShow = false;
		_viewModel.rent_btnClicked.AddListener(delegate
		{
			_viewModel.ShowTipsShow = true;
			_homelandRentType = HomelandRentType.HOMELANDRENT;
			_viewModel.titleString = string.Format(ScriptLocalization.Get("HomeLandRentTitle"), _viewModel.weaponNameString);
			Contexts.sharedInstance.message.homeLandScene.isShowRent = false;
		});
		_viewModel.l_rent_btnClicked.AddListener(delegate
		{
			_viewModel.ShowTipsShow = true;
			_homelandRentType = HomelandRentType.HOMELANDRENTRONGGUANGCHIP2;
			_viewModel.titleString = string.Format(ScriptLocalization.Get("HomeLandRentTitle2"), _viewModel.weaponNameString);
			Contexts.sharedInstance.message.homeLandScene.isShowRent = false;
		});
		_viewModel.l_btnClicked.AddListener(delegate
		{
			if (pag > 0)
			{
				pag--;
				UpdateWeapon();
			}
		});
		_viewModel.r_btnClicked.AddListener(delegate
		{
			if (pag < Contexts.sharedInstance.message.homeLandScene.weaponList.Count - 1)
			{
				pag++;
				UpdateWeapon();
			}
		});
		_viewModel.clone_btnClicked.AddListener(delegate
		{
			Contexts.sharedInstance.message.homeLandScene.isShowRent = false;
		});
		_viewModel.rent2_btnClicked.AddListener(delegate
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(127, new HomelandRentData
			{
				Type = 0,
				Idx = Contexts.sharedInstance.message.homeLandScene.weaponList[pag].Idx,
				RentType = (int)_homelandRentType
			});
			_viewModel.ShowTipsShow = false;
		});
		_viewModel.z_numString = Contexts.sharedInstance.message.homeLandScene.leftWeekRentOutCount.ToString();
		_viewModel.y_numString = Contexts.sharedInstance.message.homeLandScene.leftMonthRentOutCount.ToString();
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		_viewModel.clone2_btnClicked.AddListener(delegate
		{
			_viewModel.ShowTipsShow = false;
		});
	}

	public bool GetVisible()
	{
		return Contexts.sharedInstance.message.homeLandScene.isShowRent;
	}

	public void UpdateWeapon()
	{
		HomelandWeaponData homelandWeaponData = Contexts.sharedInstance.message.homeLandScene.weaponList[pag];
		_viewModel.tb_numString = homelandWeaponData.TblData.Slv * 25 + "%";
		_viewModel.sl_numString = homelandWeaponData.TblData.Lv + "/1000";
		string text = homelandWeaponData.CodeName;
		string skinName = homelandWeaponData.SkinName;
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(text);
		if (weaponInfo == null)
		{
			text += "_ct";
			weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(text);
		}
		if (weaponInfo != null)
		{
			AssetInfo weaponIcon_2AssetInfo = weaponInfo.GetWeaponIcon_2AssetInfo(skinName);
			base.Loader.RetriveSprite(weaponIcon_2AssetInfo.BundleName, weaponIcon_2AssetInfo.AssetName, delegate(Sprite sprite)
			{
				_viewModel.weaponIconSprite = sprite;
			});
			for (int i = 0; i < homelandWeaponData.SlotData.Count; i++)
			{
				_viewModel.Setpj_Show(i + 1, value: true);
			}
			for (int j = homelandWeaponData.SlotData.Count - 1; j < 4; j++)
			{
				_viewModel.Setpj_Show(j + 1, value: false);
			}
			_viewModel.weaponNameString = LanguageUtils.GetWeaponCnName(text);
		}
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		if (_viewModel.ShowShow)
		{
			UpdateWeapon();
			_viewModel.z_numString = Contexts.sharedInstance.message.homeLandScene.leftWeekRentOutCount.ToString();
			_viewModel.y_numString = Contexts.sharedInstance.message.homeLandScene.leftMonthRentOutCount.ToString();
		}
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow && !_viewModel.ShowTipsShow)
		{
			return 0;
		}
		return 64;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
