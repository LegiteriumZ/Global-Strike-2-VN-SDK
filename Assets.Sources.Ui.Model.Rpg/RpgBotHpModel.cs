using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgBotHpModel : AbstractModel, IPlaybackSystem
{
	private RpgBotHpViewModel _viewModel;

	private int _waitTime;

	private Dictionary<int, float> _botHps = new Dictionary<int, float>();

	private int _currId;

	private ActiveChip _panelActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgBotHpViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.PanelShow)
			{
				UpdateEffect();
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotify(16, UiIEventCondition.Get_hpProgressData_BotId, SetBotId, initinvoke: true);
		NotifyManager.MakeNotify(17, UiIEventCondition.Get_hpProgressData_EliteId, SetEliteId, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BotName, SetBotName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BotLevel, SetBotLevel, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BotHpPercent, SetBotHpPercent, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BotAttribute0, SetBotAttribute0, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BotAttribute1, SetBotAttribute1, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BotAttribute2, SetBotAttribute2, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BotAttribute3, SetBotAttribute3, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BotAttribute4, SetBotAttribute4, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BotAttribute5, SetBotAttribute5, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BotRaceInfo, SetBotRaceInfo, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BotTitle, Settitle, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_critDefhpProgressData_BotHpPercent, SetBotYinHpPercent, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_critRateDefHpPercentData_BotHpPercent, SetBotYanHpPercent, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_critDefhpMaxData_BotHp, SetBotYinBgShow, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_critRateDefHpMaxData_BotHp, SetBotYanBgShow, null, initinvoke: true);
		_viewModel.AddResisShow = false;
	}

	private void SetBotYanHpPercent(float ov, float percent)
	{
		_viewModel.YanHpImageFillamount = percent;
	}

	private void SetBotYinHpPercent(float ov, float percent)
	{
		_viewModel.YinHpImageFillamount = percent;
	}

	private void SetBotYanBgShow(float ov, float value)
	{
		_viewModel.bgYanShow = value > 0f;
		_viewModel.YanHpImageFillamount = 0f;
	}

	private void SetBotYinBgShow(float ov, float value)
	{
		_viewModel.bgYinShow = value > 0f;
		_viewModel.YinHpImageFillamount = 0f;
	}

	private void Settitle(int index, int type)
	{
		base.Loader.RetriveSprite("ui/halfLoadedRes/playerHononary", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerHononary/{type}.png", delegate(Sprite sprite)
		{
			_viewModel.TitleSprite = sprite;
		});
	}

	private void SetBotAttribute0(string arg1, string arg2)
	{
		UpdateAttribute(1, arg2);
	}

	private void SetBotAttribute1(string arg1, string arg2)
	{
		UpdateAttribute(2, arg2);
	}

	private void SetBotAttribute2(string arg1, string arg2)
	{
		UpdateAttackType(1, arg2);
	}

	private void SetBotAttribute3(string arg1, string arg2)
	{
		UpdateAttackType(2, arg2);
	}

	private void SetBotAttribute4(string arg1, string arg2)
	{
		UpdateAttribute(3, arg2);
	}

	private void SetBotAttribute5(string arg1, string arg2)
	{
		UpdateAttribute(4, arg2);
	}

	private void UpdateEffect()
	{
		_waitTime -= _timeComponent.FrameInterval;
		if (_waitTime <= 0)
		{
			float num = _viewModel.HpPercentEffectFillamount - 0.001f * (float)_timeComponent.FrameInterval;
			float hpPercentBarFillamount = _viewModel.HpPercentBarFillamount;
			_viewModel.HpPercentEffectFillamount = ((num < hpPercentBarFillamount) ? hpPercentBarFillamount : num);
		}
	}

	private void SetBotRaceInfo(List<string> ov, List<string> raceInfo)
	{
		int i = 1;
		if (raceInfo != null)
		{
			for (; i <= 5 && i <= raceInfo.Count; i++)
			{
				_viewModel.SetRaceShow(i, value: true);
				_viewModel.SetRaceNameString(i, raceInfo[i - 1]);
			}
		}
		for (; i <= 5; i++)
		{
			_viewModel.SetRaceShow(i, value: false);
		}
	}

	private void UpdateAttackType(int index, string type)
	{
		if (string.IsNullOrEmpty(type))
		{
			_viewModel.SetAttackShow(index, value: false);
			return;
		}
		_viewModel.SetAttackShow(index, value: true);
		_viewModel.SetAttackTypeString(index, type);
	}

	private void UpdateAttribute(int index, string attr)
	{
		if (string.IsNullOrEmpty(attr))
		{
			_viewModel.SetAttributeImageShow(index, value: false);
			return;
		}
		_viewModel.SetAttributeImageShow(index, value: true);
		int index2 = index;
		base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/botHp/" + attr + ".png", delegate(Sprite sprite)
		{
			_viewModel.SetAttributeImageSprite(index2, sprite);
		});
	}

	private void SetBotHpPercent(float ov, float percent)
	{
		_viewModel.HpPercentBarFillamount = percent;
		_waitTime = 100;
		if (_botHps.ContainsKey(_currId))
		{
			_botHps[_currId] = percent;
		}
	}

	private void SetBotLevel(int ov, int level)
	{
		int num = level - UiIEventCondition.Get_cameraOwnerData_Level();
		if (num <= 0)
		{
			_viewModel.LvLabelString = "Lv" + level;
			_viewModel.LvLabelTextcolor = new Color(0.422f, 0.76f, 0.469f);
			_viewModel.KulouImageShow = false;
		}
		else if (num <= 2)
		{
			_viewModel.LvLabelString = "Lv" + level;
			_viewModel.LvLabelTextcolor = new Color(0.926f, 0.797f, 0.289f);
			_viewModel.KulouImageShow = false;
		}
		else if (num <= 4)
		{
			_viewModel.LvLabelString = "Lv" + level;
			_viewModel.LvLabelTextcolor = new Color(0.867f, 0.398f, 0.086f);
			_viewModel.KulouImageShow = false;
		}
		else
		{
			_viewModel.LvLabelString = "";
			_viewModel.KulouImageShow = true;
		}
	}

	private void SetBotName(string ov, string name)
	{
		_viewModel.NameLabelString = name;
	}

	private void SetBotId(int ov, int id)
	{
		if (id > 0 && !(UiIEventCondition.Get_hpProgressData_BossMaxHuDun() > 0f) && !(UiIEventCondition.Get_hpProgressData_BossMaxZhuangJia() > 0f))
		{
			_panelActiveChip.Time = 3000;
			_currId = id;
			if (_botHps.ContainsKey(_currId))
			{
				_viewModel.HpPercentEffectFillamount = _botHps[_currId];
			}
			else
			{
				_botHps[_currId] = 1f;
				_viewModel.HpPercentEffectFillamount = 1f;
			}
			_waitTime = 100;
		}
	}

	private void SetEliteId(int ov, int id)
	{
		if (id > 0)
		{
			_panelActiveChip.Time = 0;
		}
	}

	private void InitChips()
	{
		_panelActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.PanelShow = _panelActiveChip.Update(_timeComponent);
	}
}
