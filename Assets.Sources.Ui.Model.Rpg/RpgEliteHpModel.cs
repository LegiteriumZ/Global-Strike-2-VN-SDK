using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgEliteHpModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext
{
	private RpgEliteHpViewModel _viewModel;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private bool _isShow;

	private int _waitTime;

	private ActiveChip _panelActiveChip = new ActiveChip();

	private BattleRoomContext _battleRoom;

	private int _raceType;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgEliteHpViewModel();
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
		_viewModel.PanelShow = false;
		InitPos();
		NotifyManager.MakeNotify(16, UiIEventCondition.Get_hpProgressData_BotId, SetBotId, initinvoke: true);
		NotifyManager.MakeNotify(17, UiIEventCondition.Get_hpProgressData_EliteId, SetEliteId, initinvoke: true);
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_EliteName, SetEliteName, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_EliteLevel, SetEliteLevel, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_EliteHpPercent, SetEliteHpPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_EliteAttribute0, SetEliteAttribute0, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_EliteAttribute1, SetEliteAttribute1, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_EliteAttribute2, SetEliteAttribute2, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_EliteAttribute3, SetEliteAttribute3, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_EliteAttribute4, SetEliteAttribute4, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_EliteAttribute5, SetEliteAttribute5, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_EliteRaceInfo, SetEliteRaceInfo, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_EliteType, SetEliteType, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_critDefhpProgressData_EliteHpPercent, SetEliteYinHpPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_critRateDefHpPercentData_EliteHpPercent, SetEliteYanHpPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_critDefhpMaxData_EliteHp, SetEliteYinBgShow, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_critRateDefHpMaxData_EliteHp, SetEliteYanBgShow, null, initinvoke: true));
		_notifyGroup.SetSuspend(suspend: true);
		_viewModel.AddResisShow = false;
	}

	private void SetEliteYanHpPercent(float ov, float percent)
	{
		_viewModel.YanHpImageFillamount = percent;
	}

	private void SetEliteYinHpPercent(float ov, float percent)
	{
		_viewModel.YinHpImageFillamount = percent;
	}

	private void SetEliteYanBgShow(float ov, float value)
	{
		_viewModel.bgYanShow = value > 0f;
		_viewModel.YanHpImageFillamount = 0f;
	}

	private void SetEliteYinBgShow(float ov, float value)
	{
		_viewModel.bgYinShow = value > 0f;
		_viewModel.YinHpImageFillamount = 0f;
	}

	private void InitPos()
	{
		if (_raceType == 17000)
		{
			Vector2 panelAnchoredposition = _viewModel.PanelAnchoredposition;
			panelAnchoredposition.y = 220f;
			_viewModel.PanelAnchoredposition = panelAnchoredposition;
		}
	}

	private void SetEliteAttribute0(string arg1, string arg2)
	{
		UpdateAttribute(1, arg2);
	}

	private void SetEliteAttribute1(string arg1, string arg2)
	{
		UpdateAttribute(2, arg2);
	}

	private void SetEliteAttribute2(string arg1, string arg2)
	{
		UpdateAttackType(1, arg2);
	}

	private void SetEliteAttribute3(string arg1, string arg2)
	{
		UpdateAttackType(2, arg2);
	}

	private void SetEliteAttribute4(string arg1, string arg2)
	{
		UpdateAttribute(3, arg2);
	}

	private void SetEliteAttribute5(string arg1, string arg2)
	{
		UpdateAttribute(4, arg2);
	}

	private void SetEliteType(int ov, int type)
	{
		if (type == 1)
		{
			_viewModel.NameLabelTextcolor = new Color(32f / 85f, 2f / 3f, 0.8f);
		}
		else
		{
			_viewModel.NameLabelTextcolor = new Color(36f / 85f, 0.7647059f, 0.47058824f);
		}
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

	private void SetEliteRaceInfo(List<string> ov, List<string> raceInfo)
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

	private void SetEliteHpPercent(float ov, float percent)
	{
		_viewModel.HpPercentBarFillamount = percent;
		_waitTime = 100;
		_viewModel.HpPercentString = StringCache.IntToString((int)(percent * 100f));
	}

	private void SetEliteLevel(int ov, int level)
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

	private void SetEliteName(string ov, string name)
	{
		_viewModel.NameLabelString = name;
	}

	private void SetBotId(int ov, int id)
	{
		if (id > 0)
		{
			_panelActiveChip.Time = 0;
		}
		_notifyGroup.SetSuspend(suspend: true);
	}

	private void SetEliteId(int ov, int id)
	{
		if (id > 0)
		{
			_panelActiveChip.Time = 3000;
		}
	}

	private void InitChips()
	{
		_panelActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		bool flag = _panelActiveChip.Update(_timeComponent);
		if (flag != _isShow)
		{
			_isShow = flag;
			_viewModel.PanelShow = _isShow;
			_notifyGroup.SetSuspend(!_isShow);
		}
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_raceType = context.roomData.Data.RaceType;
		_battleRoom = context;
	}
}
