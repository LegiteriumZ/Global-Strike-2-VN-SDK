using System;
using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.HomeLandModel;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.HomeLandModel;

[GameUiTest]
public class HomeLandModelRentModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ICursorControl
{
	private HomeLandModelRentViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	public int pag = 1;

	public int maxPag;

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
		_viewModel = new HomeLandModelRentViewModel();
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
		_viewModel.l_btnClicked1.AddListener(delegate
		{
			if (pag > 1)
			{
				pag--;
				NotifyManager.ForceInvoke(152);
			}
		});
		_viewModel.l_btnClicked2.AddListener(delegate
		{
			pag = 1;
			NotifyManager.ForceInvoke(152);
		});
		_viewModel.r_btnClicked1.AddListener(delegate
		{
			if (pag < maxPag)
			{
				pag++;
				NotifyManager.ForceInvoke(152);
			}
		});
		_viewModel.r_btnClicked2.AddListener(delegate
		{
			pag = maxPag;
			NotifyManager.ForceInvoke(152);
		});
		_viewModel.clone_btnClicked.AddListener(delegate
		{
			_viewModel.ShowShow = false;
		});
		_viewModel.ShowShow = false;
		NotifyManager.MakeNotifyClass(152, GetWeaponList, SetWeaponList);
	}

	public List<HomelandHistoryInfoData> GetWeaponList()
	{
		return Contexts.sharedInstance.message.homeLandScene.listHomelandHistoryInfoData;
	}

	public void SetWeaponList(List<HomelandHistoryInfoData> ov, List<HomelandHistoryInfoData> infoDatas)
	{
		_viewModel.ShowShow = true;
		int num = Mathf.Min(infoDatas.Count, pag * 10);
		maxPag = infoDatas.Count / 10 + 1;
		int num2 = 0;
		for (int i = (pag - 1) * 10; i < num; i++)
		{
			num2++;
			_viewModel.SetbgShow(num2, value: true);
			_viewModel.SetplayerNameString(num2, infoDatas[i].PlayerName);
			_viewModel.SetweaponNameString(num2, LanguageUtils.GetWeaponCnName(infoDatas[i].CodeName));
			DateTime dateTime = new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(infoDatas[i].Dateline);
			_viewModel.SetrentTimeString(num2, dateTime.ToString("yyyy-MM-dd"));
		}
		for (int j = num2 + 1; j < 11; j++)
		{
			_viewModel.SetbgShow(j, value: false);
		}
		_viewModel.z_numString = Contexts.sharedInstance.message.homeLandScene.leftWeekRentOutCount.ToString();
		_viewModel.y_numString = Contexts.sharedInstance.message.homeLandScene.leftMonthRentOutCount.ToString();
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
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
		_viewModel.pagString = $"{pag}/{maxPag}";
	}
}
