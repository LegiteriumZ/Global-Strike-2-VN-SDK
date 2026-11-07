using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgTower;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.RpgTower;

[GameUiTest]
public class RpgTowerMoneyModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private class GetInfo
	{
		public int Value;

		public string Resname;

		public int Alphatime;

		public int Index;

		private void CopyTo(GetInfo info)
		{
			Value = info.Value;
			Resname = info.Resname;
			Alphatime = info.Alphatime;
			Index = info.Index;
		}
	}

	private RpgTowerMoneyViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private List<GetInfo> _infoQueue = new List<GetInfo>();

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
		_viewModel = new RpgTowerMoneyViewModel();
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
		for (int i = 1; i <= 3; i++)
		{
			_viewModel.SetCellShow(i, value: false);
		}
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_rpgTower_Money, SetMoney, null, initinvoke: true);
	}

	private void SetMoney(int arg1, int arg2)
	{
		_viewModel.JinbiCountString = StringCache.IntToString(arg2);
		int num = arg2 - arg1;
		if (num == 0)
		{
			return;
		}
		GetInfo getInfo = new GetInfo();
		getInfo.Value = num;
		getInfo.Alphatime = 3000;
		getInfo.Resname = ((num > 0) ? "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/getmoneyexp/money.png" : "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/getmoneyexp/losemoney.png");
		if (_infoQueue.Count == 3)
		{
			_infoQueue.RemoveAt(0);
		}
		for (int i = 1; i <= 3; i++)
		{
			bool flag = false;
			for (int j = 0; j < _infoQueue.Count; j++)
			{
				if (_infoQueue[j].Index == i)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				getInfo.Index = i;
				break;
			}
		}
		_infoQueue.Add(getInfo);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		for (int i = 0; i < _infoQueue.Count; i++)
		{
			GetInfo getInfo = _infoQueue[i];
			_viewModel.SetnumtxtString(getInfo.Index, StringCache.IntToString(getInfo.Value));
			float a = (float)getInfo.Alphatime / 3000f;
			_viewModel.SetCellColor(getInfo.Index, new Color(1f, 1f, 1f, a));
			_viewModel.SetnumtxtTextcolor(getInfo.Index, new Color(1f, 1f, 1f, a));
			base.Loader.RetriveSprite("ui/towerdefensemodel", getInfo.Resname, _viewModel.GetCellImage(getInfo.Index));
			getInfo.Alphatime -= _timeComponent.FrameInterval;
			if (getInfo.Alphatime <= 0)
			{
				_infoQueue.RemoveAt(i--);
			}
		}
		for (int j = 1; j <= 3; j++)
		{
			bool value = false;
			for (int k = 0; k < _infoQueue.Count; k++)
			{
				if (j == _infoQueue[k].Index)
				{
					value = true;
				}
			}
			_viewModel.SetCellShow(j, value);
		}
	}
}
