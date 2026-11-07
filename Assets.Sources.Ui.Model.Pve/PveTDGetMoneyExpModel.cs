using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public class PveTDGetMoneyExpModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private struct GetInfo
	{
		public string resname;

		public int value;

		public int keptTime;

		public int alphatime;
	}

	private PveTDGetMoneyExpViewModel _viewModel;

	private List<GetInfo> _queue = new List<GetInfo>();

	private int currentMoney;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveTDGetMoneyExpViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			Hide();
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Money, SetMoney, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_addExpData_Dirty, AddExpInfo);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		int count = _queue.Count;
		for (int i = 0; i < count; i++)
		{
			_viewModel.SetcellShow(i + 1, value: true);
			GetInfo value = _queue[i];
			base.Loader.RetriveSprite("ui/towerdefensemodel", value.resname, _viewModel.GetcellImage(i + 1));
			_viewModel.SetnumtxtString(i + 1, value.value.ToString());
			if (value.keptTime > 0)
			{
				value.keptTime -= _timeComponent.FrameInterval;
			}
			else
			{
				value.alphatime -= _timeComponent.FrameInterval;
			}
			Color value2 = default(Color);
			value2.r = (value2.g = (value2.b = 1f));
			value2.a = (float)(4 - i) / (float)count * ((float)value.alphatime / 2000f);
			_viewModel.SetnumtxtTextcolor(i + 1, value2);
			_viewModel.SetcellColor(i + 1, value2);
			_queue[i] = value;
		}
		for (int j = count; j < 4; j++)
		{
			_viewModel.SetcellShow(j + 1, value: false);
		}
	}

	private void Hide()
	{
		for (int num = _queue.Count - 1; num >= 0; num--)
		{
			GetInfo getInfo = _queue[num];
			if (getInfo.keptTime < 0 && getInfo.alphatime < 0)
			{
				_queue.RemoveAt(num);
			}
		}
		_viewModel.pveTDGetMoneyExpShow = _queue.Count > 0;
	}

	private void AddExpInfo(bool old, bool newval)
	{
		_gameRuleContext.addExpData.Dirty = false;
		if (newval)
		{
			if (_queue.Count >= 4)
			{
				_queue.RemoveAt(_queue.Count - 1);
			}
			GetInfo item = default(GetInfo);
			item.resname = "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/getmoneyexp/exp.png";
			item.value = UiIEventCondition.Get_addExpData_addExp();
			item.keptTime = 5000;
			item.alphatime = 2000;
			_queue.Insert(0, item);
		}
	}

	private void SetMoney(int ov, int money)
	{
		_gameRuleContext.addExpData.Dirty = false;
		if (_queue.Count >= 4)
		{
			_queue.RemoveAt(_queue.Count - 1);
		}
		GetInfo item = default(GetInfo);
		if (money - currentMoney > 0)
		{
			item.resname = "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/getmoneyexp/money.png";
			item.value = money - currentMoney;
		}
		else
		{
			item.resname = "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/getmoneyexp/losemoney.png";
			item.value = currentMoney - money;
		}
		item.keptTime = 5000;
		item.alphatime = 2000;
		currentMoney = money;
		_queue.Insert(0, item);
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
