using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgBossHpModel : AbstractModel, IPlaybackSystem, ISetPlayerContext
{
	private RpgBossHpViewModel _viewModel;

	private PlayerContext _playerContext;

	private int[] statusTable = new int[6] { 141001, 141002, 141003, 141004, 141005, 141006 };

	private string[] atfTable = new string[6] { "BeDamageDecBuff", "BeAttackCritDecBuff", "BeAttackCritRatioDecBuff", "RecoveDecHaloBuff", "DamageAddBuff", "extraHpDamageBuff" };

	private string[] atfList = new string[6];

	private List<int> showList = new List<int>();

	private int[] valueList = new int[6];

	private int _waitTime;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private bool isLock;

	private FrameAnimaChip _lockIconEffect;

	private FrameAnimaChip _lockEffect;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgBossHpViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_viewModel.PanelRootshow)
		{
			return;
		}
		UpdateEffect();
		showList.Clear();
		for (int i = 0; i < 6; i++)
		{
			PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(Contexts.sharedInstance.gameRule.hpProgressData.BossId);
			if (entityWithEntityId != null && entityWithEntityId.HasStatus(statusTable[i]))
			{
				showList.Add(i);
				atfList[i] = atfTable[i];
				valueList[i] = entityWithEntityId.skill.Status[statusTable[i]].Number;
			}
		}
	}

	private void UpdateEffect()
	{
		_waitTime -= _timeComponent.FrameInterval;
		if (_waitTime <= 0)
		{
			float num = _viewModel.EffectProgressBarFillamount - 0.001f * (float)_timeComponent.FrameInterval;
			float curHpProgressBarFillamount = _viewModel.CurHpProgressBarFillamount;
			_viewModel.EffectProgressBarFillamount = ((num < curHpProgressBarFillamount) ? curHpProgressBarFillamount : num);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.lockHpShow = false;
		_viewModel.PanelRootshow = false;
		NotifyManager.MakeNotify(18, Get_hpProgressData_BossId, SetBossId, initinvoke: true);
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossName, SetBossName, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_CritHpData_BgName, SetBossCritHpBgName, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossLevel, SetBossLevel, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossHpPercent, SetBossHpPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossHuDunPercent, SetBossHpPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossZhuangJiaPercent, SetBossHpPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossLockPercent, SetBossLockPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossLock, SetBossLock, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossCurPercent, SetBossCurPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossHpBackImage, SetBossHpBackImage, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossHpProgressImage, SetBossHpProgressImage, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossAttribute0, SetBossAttribute0, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossAttribute1, SetBossAttribute1, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossAttribute2, SetBossAttribute2, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossAttribute3, SetBossAttribute3, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossAttribute4, SetBossAttribute4, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossAttribute5, SetBossAttribute5, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossRaceInfo, SetBossRaceInfo, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_hpProgressData_BossCareer, SetBossCareer, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossType, SetBossType, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossShieldPercent, SetBossShieldPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_critDefhpProgressData_BossHpPercent, SetBossYanHpPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_critRateDefHpPercentData_BossHpPercent, SetBossYinHpPercent, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_critDefhpBLData_BossBL, SetBossbl, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_critRateDefHpBSData_BossBS, SetBossbs, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_critDefhpProgressData_BossAddResisShow, SetBossAddResisShow, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossHpProgressExtraLife, SetBossExtraLife, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetBuffCount, SetExtraordinaryShow, null, initinvoke: true));
		_viewModel.AddResisShow = false;
	}

	private int GetBuffCount()
	{
		return showList.Count;
	}

	private void SetBossAddResisShow(bool ov, bool percent)
	{
		_viewModel.AddResisShow = percent;
	}

	private void SetBossExtraLife(int ov, int percent)
	{
		_viewModel.extraLifeNumShow = percent > 0;
		_viewModel.numString = percent.ToString();
	}

	private void SetBossYanHpPercent(float ov, float percent)
	{
		_viewModel.YanHpImageFillamount = percent;
	}

	private void SetBossYinHpPercent(float ov, float percent)
	{
		_viewModel.YinHpImageFillamount = percent;
	}

	private void SetExtraordinaryShow(int a, int b)
	{
		for (int j = 0; j < 6; j++)
		{
			if (showList.Count > j)
			{
				_viewModel.SetbuffShow(j + 1, value: true);
			}
			else
			{
				_viewModel.SetbuffShow(j + 1, value: false);
			}
		}
		for (int k = 0; k < showList.Count; k++)
		{
			int i = k;
			base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/extraordinary/" + atfList[showList[i]] + ".png", delegate(Sprite sprite)
			{
				_viewModel.SetbufficonSprite(i + 1, sprite);
			});
		}
		for (int l = 0; l < showList.Count; l++)
		{
			_viewModel.SetbuffValueString(l + 1, valueList[showList[l]].ToString());
		}
	}

	private void SetBossbl(bool ov, bool percent)
	{
		_viewModel.bladdShow = percent;
	}

	private void SetBossbs(bool ov, bool percent)
	{
		_viewModel.bsaddShow = percent;
	}

	public static int Get_hpProgressData_BossId()
	{
		PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(Contexts.sharedInstance.gameRule.hpProgressData.BossId);
		if (entityWithEntityId != null && entityWithEntityId.HasStatus(PlayerInfoStatusConstant.BOSS_HP_UI_HIDE.ID))
		{
			return 0;
		}
		return Contexts.sharedInstance.gameRule.hpProgressData.BossId;
	}

	private void SetBossAttribute0(string arg1, string arg2)
	{
		UpdateAttribute(1, arg2);
	}

	private void SetBossAttribute1(string arg1, string arg2)
	{
		UpdateAttribute(2, arg2);
	}

	private void SetBossAttribute2(string arg1, string arg2)
	{
		UpdateAttackType(1, arg2);
	}

	private void SetBossAttribute3(string arg1, string arg2)
	{
		UpdateAttackType(2, arg2);
	}

	private void SetBossAttribute4(string arg1, string arg2)
	{
		UpdateAttribute(3, arg2);
	}

	private void SetBossAttribute5(string arg1, string arg2)
	{
		UpdateAttribute(4, arg2);
	}

	private void SetBossType(int ov, int type)
	{
		if (type == 3)
		{
			_viewModel.NameLabelTextcolor = new Color(66f / 85f, 13f / 51f, 0.10980392f);
		}
		else
		{
			_viewModel.NameLabelTextcolor = new Color(74f / 85f, 0.4f, 0.08627451f);
		}
	}

	private void SetBossCareer(string ov, string career)
	{
		if (!string.IsNullOrEmpty(career))
		{
			_viewModel.BossIconSprite = base.Loader.RetriveSprite("ui/halfloadedres/bossTitle", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/bossTitle/" + career + ".png", delegate(Sprite sprite)
			{
				_viewModel.BossIconSprite = sprite;
				_viewModel.BossIconNtvsize();
			});
		}
	}

	private void SetBossCurPercent(float ov, float percent)
	{
		_viewModel.CurHpProgressBarFillamount = percent;
		_viewModel.FollowImagePosition = new Vector3(-350f + 700f * percent, 0f);
		_waitTime = 100;
	}

	private void SetBossHpBackImage(string ov, string image)
	{
		if (UiIEventCondition.Get_hpProgressData_BosslifeBarSeq().Count > 0)
		{
			return;
		}
		if (string.IsNullOrEmpty(image))
		{
			_viewModel.BottomHdImageShow = false;
			_viewModel.BottomHpImageImage.enabled = false;
			return;
		}
		_viewModel.BottomHpImageImage.enabled = true;
		_viewModel.BottomHdImageShow = true;
		base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/botHp/" + image + ".png", delegate(Sprite sprite)
		{
			_viewModel.BottomHpImageSprite = sprite;
		});
	}

	private void SetBossHpProgressImage(string ov, string image)
	{
		if (!string.IsNullOrEmpty(image))
		{
			base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/botHp/" + image + ".png", delegate(Sprite sprite)
			{
				_viewModel.CurHpProgressBarSprite = sprite;
			});
		}
	}

	private void SetBossRaceInfo(List<string> ov, List<string> raceInfo)
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

	private void SetBossShieldPercent(float ov, float percent)
	{
		_viewModel.ShieldPercentBgFillamount = 0f;
	}

	private void SetBossHpPercent(float ov, float percent)
	{
		_viewModel.HpPercentString = StringCache.IntToString((int)(UiIEventCondition.Get_hpProgressData_BossHpPercent() * 100f));
		_viewModel.MonterPanelShow = false;
		if (!(UiIEventCondition.Get_hpProgressData_BossMaxHuDun() > 0f) && !(UiIEventCondition.Get_hpProgressData_BossMaxZhuangJia() > 0f) && (!(UiIEventCondition.Get_hpProgressData_BossMaxHp() > 0f) || UiIEventCondition.Get_hpProgressData_BosslifeBarSeq().Count <= 0))
		{
			return;
		}
		_viewModel.MonterPanelShow = _viewModel.PanelRootshow;
		List<int> hpProgressData_BosslifeBarSeq = UiIEventCondition.Get_hpProgressData_BosslifeBarSeq();
		int count = hpProgressData_BosslifeBarSeq.Count;
		_viewModel.BottommHpImageShow = count > 0;
		_viewModel.BottomHdImageShow = count > 1;
		_viewModel.BottomZjImageShow = count > 2;
		float num = 0f;
		float num2 = 0f;
		base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/botHp/lock" + hpProgressData_BosslifeBarSeq[UiIEventCondition.Get_hpProgressData_CurrentLifeBarSeq()] + ".png", delegate(Sprite sprite)
		{
			_viewModel.lockmsgSprite = sprite;
		});
		for (int i = 0; i < hpProgressData_BosslifeBarSeq.Count; i++)
		{
			float num3 = 0f;
			if (hpProgressData_BosslifeBarSeq[i] == 1)
			{
				num3 = UiIEventCondition.Get_hpProgressData_BossHpPercent();
				num2 += UiIEventCondition.Get_hpProgressData_BossHp();
				num += UiIEventCondition.Get_hpProgressData_BossMaxHp();
			}
			if (hpProgressData_BosslifeBarSeq[i] == 2)
			{
				num3 = UiIEventCondition.Get_hpProgressData_BossHuDunPercent();
				num2 += UiIEventCondition.Get_hpProgressData_BossHuDun();
				num += UiIEventCondition.Get_hpProgressData_BossMaxHuDun();
			}
			if (hpProgressData_BosslifeBarSeq[i] == 3)
			{
				num3 = UiIEventCondition.Get_hpProgressData_BossZhuangJiaPercent();
				num2 += UiIEventCondition.Get_hpProgressData_BossZhuangJia();
				num += UiIEventCondition.Get_hpProgressData_BossMaxZhuangJia();
			}
			switch (i)
			{
			case 0:
				base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/botHp/boss_c_" + hpProgressData_BosslifeBarSeq[i] + ".png", delegate(Sprite sprite)
				{
					_viewModel.CurmHpProgressBarSprite = sprite;
				});
				_viewModel.CurmHpProgressBarFillamount = num3;
				break;
			case 1:
				base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/botHp/boss_x_" + hpProgressData_BosslifeBarSeq[i] + ".png", delegate(Sprite sprite)
				{
					_viewModel.CurHdProgressBarSprite = sprite;
				});
				_viewModel.CurHdProgressBarFillamount = num3;
				break;
			default:
				base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/botHp/boss_x_" + hpProgressData_BosslifeBarSeq[i] + ".png", delegate(Sprite sprite)
				{
					_viewModel.CurZjProgressBarSprite = sprite;
				});
				_viewModel.CurZjProgressBarFillamount = num3;
				break;
			}
		}
		_viewModel.HpPercentString = StringCache.IntToString((int)(num2 / num * 100f));
		_viewModel.BottomHpImageShow = false;
		_viewModel.lockeffectShow = false;
	}

	private void SetBossLockPercent(float ov, float percent)
	{
		if (UiIEventCondition.Get_hpProgressData_BossMaxHuDun() > 0f || UiIEventCondition.Get_hpProgressData_BossMaxZhuangJia() > 0f)
		{
			_viewModel.locklFillamount = UiIEventCondition.Get_hpProgressData_BossLockPercent() / 100f;
			_viewModel.lockrFillamount = UiIEventCondition.Get_hpProgressData_BossLockPercent() / 100f;
		}
	}

	private void SetBossLock(bool ov, bool isLockhp)
	{
		if (UiIEventCondition.Get_hpProgressData_BossMaxHuDun() > 0f || UiIEventCondition.Get_hpProgressData_BossMaxZhuangJia() > 0f)
		{
			if (!isLockhp && isLock != isLockhp)
			{
				_viewModel.lockeffectShow = true;
				_lockIconEffect.Index = 1;
			}
			_viewModel.lockHpShow = isLockhp;
			isLock = isLockhp;
		}
	}

	private void SetBossLevel(int ov, int level)
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

	private void SetBossName(string ov, string name)
	{
		_viewModel.NameLabelString = name;
	}

	private void SetBossCritHpBgName(string ov, string name)
	{
		base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/botHp/taiji/" + name + ".png", delegate(Sprite sprite)
		{
			_viewModel.bgSprite = sprite;
		});
	}

	private void SetBossId(int ov, int id)
	{
		_viewModel.PanelRootshow = id > 0;
		_notifyGroup.SetSuspend(id <= 0);
	}

	private void InitChips()
	{
		_lockIconEffect = new FrameAnimaChip
		{
			Count = 9,
			StartIndex = 1,
			Path = "Assets/Res/Assets/ui/GameGUIRes/rpgModel/botHp/ps/ps",
			Delay = 100,
			IsLoop = false
		};
		_lockIconEffect.Init();
		_lockEffect = new FrameAnimaChip
		{
			Count = 12,
			StartIndex = 1,
			Path = "Assets/Res/Assets/ui/GameGUIRes/rpgModel/botHp/lock/qiliu000",
			Delay = 100,
			IsLoop = true
		};
		_lockEffect.Init();
	}

	private void UpdateChips()
	{
		if (_lockIconEffect.Index == 1 || !_lockIconEffect.IsOver)
		{
			_lockIconEffect.Update(_timeComponent);
			if (_lockIconEffect.Changed)
			{
				base.Loader.RetriveSprite("ui/rpgmodel", _lockIconEffect.Value, delegate(Sprite sprite)
				{
					_viewModel.lockeffectSprite = sprite;
				});
				if (_lockIconEffect.IsOver)
				{
					_viewModel.lockeffectShow = UiIEventCondition.Get_hpProgressData_BossLock();
				}
			}
		}
		_lockEffect.Update(_timeComponent);
		if (_lockEffect.Changed)
		{
			base.Loader.RetriveSprite("ui/rpgmodel", _lockEffect.Value, delegate(Sprite sprite)
			{
				_viewModel.effeectSprite = sprite;
			});
		}
	}
}
