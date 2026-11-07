using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BigHead;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BigHead;

public class BigHeadProgressModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private BigHeadProgressViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int _maxLv = 6;

	private PingPongChip _changeHeroFlashPingPongChip = new PingPongChip();

	private PositionChip[] _flashPositionChips;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = _battleRoomContext.roomData.Data.RaceType;
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
		_flashPositionChips = new PositionChip[6]
		{
			new PositionChip(),
			new PositionChip(),
			new PositionChip(),
			new PositionChip(),
			new PositionChip(),
			new PositionChip()
		};
		for (int i = 0; i < _flashPositionChips.Length; i++)
		{
			_flashPositionChips[i].Position = new Vector3(-100f, 120f);
			_flashPositionChips[i].TargetPosition = new Vector3(20f, 240f);
			_flashPositionChips[i].Speed = new Vector3(60f, 60f);
		}
	}

	public override void CreateViewModel()
	{
		_viewModel = new BigHeadProgressViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_viewModel.ShowShow)
		{
			return;
		}
		_viewModel.ChangeHeroFlashAlpha = _changeHeroFlashPingPongChip.Value;
		int bigHeadProgress_Lv = UiIEventCondition.Get_bigHeadProgress_Lv();
		if (_viewModel.GetFlashShow(bigHeadProgress_Lv + 1))
		{
			_flashPositionChips[bigHeadProgress_Lv].Update(_timeComponent);
			_viewModel.SetFlashPosition(bigHeadProgress_Lv + 1, _flashPositionChips[bigHeadProgress_Lv].Value);
			if (_flashPositionChips[bigHeadProgress_Lv].IsOver)
			{
				_flashPositionChips[bigHeadProgress_Lv].Position = new Vector3(-100f, 120f);
			}
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowShow = true;
		_viewModel.CurrentCountString = "0";
		_viewModel.MaxCountString = "0";
		NotifyManager.MakeNotify(56, UiIEventCondition.Get_bigHeadProgress_Lv, SetLv, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bigHeadProgress_Progress, SetProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Observer, SetObserver, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_IsObserver, SetIsObserver, null, initinvoke: true);
		if (_raceType != 0 && _raceType == 120)
		{
			_viewModel.NoteShow = false;
		}
		else
		{
			NotifyManager.MakeNotifyClass(52, UiIEventCondition.Get_bigHeadMessage_BigHeadMessages, SetBigHeadMessages, initinvoke: true);
		}
	}

	private void SetProgress(int arg1, int arg2)
	{
		UpdateProgress();
	}

	private void SetLv(int arg1, int arg2)
	{
		UpdateProgress();
		ShowFlashAnim(arg2 + 1);
	}

	private void SetIsObserver(bool ov, bool flag)
	{
		CheckVisible();
	}

	private void SetObserver(int ov, int id)
	{
		CheckVisible();
	}

	private void CheckVisible()
	{
		_viewModel.ProgressShowShow = !UiIEventCondition.Get_uiRoomData_IsObserver() && UiIEventCondition.Get_cameraOwnerData_Observer() == 0;
	}

	private void UpdateProgress()
	{
		int num = UiIEventCondition.Get_bigHeadProgress_Lv() + 1;
		_viewModel.ShowShow = num < 7;
		for (int i = 1; i < num; i++)
		{
			_viewModel.SetProgressFillamount(i, 1f);
		}
		_viewModel.SetProgressFillamount(num, (float)UiIEventCondition.Get_bigHeadProgress_Progress() / 100f);
		for (int j = num; j < _maxLv; j++)
		{
			_viewModel.SetProgressFillamount(j + 1, 0f);
		}
	}

	private void ShowFlashAnim(int showLevel)
	{
		for (int i = 1; i <= _maxLv; i++)
		{
			_viewModel.SetFlashShow(i, i == showLevel);
		}
		_viewModel.ChangeHeroFlashShow = showLevel == _maxLv;
	}

	private void SetBigHeadMessages(List<BigHeadMessageData> ov, List<BigHeadMessageData> message)
	{
		foreach (BigHeadMessageData item in message)
		{
			if (item.Type == BigHeadMessageType.SHOWHERO)
			{
				_viewModel.CurrentCountString = StringCache.IntToString(item.BigHeadKingNum);
				_viewModel.MaxCountString = StringCache.IntToString(item.MaxHeroNum);
			}
		}
	}

	private void InitChips()
	{
		_changeHeroFlashPingPongChip.From = 1f;
		_changeHeroFlashPingPongChip.To = 0f;
		_changeHeroFlashPingPongChip.Time = 1000;
	}

	private void UpdateChips()
	{
		_changeHeroFlashPingPongChip.Update(_timeComponent);
	}
}
