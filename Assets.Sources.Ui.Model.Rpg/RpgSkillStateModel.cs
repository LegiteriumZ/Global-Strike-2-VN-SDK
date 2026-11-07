using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgSkillStateModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetGameRuleContext
{
	private RpgSkillStateViewModel _viewModel;

	private List<int> SkillTypeList = new List<int> { 124, 105, 106, 107, 117, 125, 10, 9 };

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private int[] _lastSkillNames = new int[8];

	private bool[] _lastEffectVisibles = new bool[8];

	private List<SkillInfoData> _skillList = new List<SkillInfoData>();

	private Dictionary<string, string> _rpgSkillStateCache = new Dictionary<string, string>();

	private Dictionary<int, string> _rpgSkillStateSkillTypeCache = new Dictionary<int, string>();

	private Dictionary<int, string> _rpgSkillStateLevelCache = new Dictionary<int, string>();

	private FrameAnimaChip[] _skillEffectFrameAnimaChips;

	private FrameAnimaChip _awakeSkillEffectAnimaChip;

	private FrameAnimaChip _dragoonSkillEffectAnimaChip;

	private FrameAnimaChip _fireEffectAnimaChip;

	private PlayerContext _playerContext;

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
		_viewModel = new RpgSkillStateViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetEnergyPercent, SetEnergyPercent, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_tdSkillStateData_CurrentMp, SetCurrentMp, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetAbsorbedPercent, SetAbsorbedPercent, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_rpgSkillStateData_CurrentXpEnergy, SetCurrentXpEnergy, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(GetAwakeSkill, SetAwakeSkillVisible, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetAwakeSkillIcon, SetAwakeSkillIcon, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetAwakeSkillEffectVisible, SetAwakeSkillEffectVisible, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetAwakeSkillMaskPercent, SetAwakeSkillMaskPercent, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetAwakeSkillTime, SetAwakeSkillTime, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(GetDragoonSkill, SetDragoonSkillVisible, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetDragoonSkillIcon, SetDragoonSkillIcon, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetDragoonSkillEffectVisible, SetDragoonSkillEffectVisible, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetDragoonSkillMaskPercent, SetDragoonSkillMaskPercent, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetDragoonSkillTime, SetDragoonSkillTime, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetDragoonBackShow, SetDragoonBackShow, null, initinvoke: true, isFrameSeparation: true));
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_LongQibingUIEffect, SetFireEffectVisible, null, initinvoke: true, isFrameSeparation: true);
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetSkillTypeList);
		for (int i = 0; i < SkillTypeList.Count; i++)
		{
			listNotify.AddEvent<SkillInfoData, BeforeJoinString>("SkillIcon", GetSkillIcon, SetSkillIcon, i);
			listNotify.AddEvent<SkillInfoData, bool>("EffectVisible", GetEffectVisible, SetEffectVisible, i);
			listNotify.AddEvent<SkillInfoData, float>("MaskPercent", GetMaskPercent, SetMaskPercent, i);
			listNotify.AddEvent<SkillInfoData, int>("Level", GetLevel, SetLevel, i);
			listNotify.AddEvent<SkillInfoData, int>("Time", GetTime, SetTime, i);
			listNotify.AddEvent<SkillInfoData, int>("NeedMp", GetNeedMp, SetNeedMp, i);
			listNotify.AddEvent<SkillInfoData, int>("Type", GetType, SetType, i);
		}
		_notifyGroup.Add(listNotify.Id);
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_notifyGroup.SetSuspend(!arg2);
		_viewModel.PanelShow = arg2;
	}

	private bool GetVisible()
	{
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 18023 && PlayerCareerConstantUtility.IsHero(UiIEventCondition.Get_cameraOwnerData_Career()))
		{
			return false;
		}
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 133 && PlayerCareerConstantUtility.IsNoHuMan(UiIEventCondition.Get_cameraOwnerData_Career()))
		{
			return false;
		}
		if (!_playerContext.isCameraOwner)
		{
			return true;
		}
		if (!_gameRuleContext.currentRule.Rule.IsHideSkillWhenHidePlayer())
		{
			return true;
		}
		if (_playerContext.cameraOwnerEntity.HasState(131072))
		{
			return false;
		}
		return true;
	}

	private void SetSkillIcon(SkillInfoData val, int idx, BeforeJoinString oldfs, BeforeJoinString newfs, ElementStatus status)
	{
		string text = newfs.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			_viewModel.SetSkillIconShow(idx + 1, value: true);
			_viewModel.SetSkillUseMpBackShow(idx + 1, value: true);
			string value = null;
			if (!_rpgSkillStateCache.TryGetValue(text, out value))
			{
				value = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/" + text + ".png";
				_rpgSkillStateCache[text] = value;
			}
			base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", value, delegate(Sprite sprite)
			{
				_viewModel.SetSkillIconSprite(idx + 1, sprite);
			});
		}
		else
		{
			_viewModel.SetSkillEffectShow(idx + 1, value: false);
			_viewModel.SetSkillIconShow(idx + 1, value: false);
			_viewModel.SetSkillMaskShow(idx + 1, value: false);
			_viewModel.SetSkillUseMpBackShow(idx + 1, value: false);
		}
	}

	private BeforeJoinString GetSkillIcon(SkillInfoData skillInfo, int idx)
	{
		if (skillInfo != null)
		{
			bool flag = false;
			if (skillInfo.CurrentCdTime > 0)
			{
				flag = true;
			}
			else if (idx < 4)
			{
				if (skillInfo.NeedMp > Contexts.sharedInstance.gameRule.tdSkillStateData.CurrentMp)
				{
					flag = true;
				}
			}
			else if (idx >= 4 && skillInfo.NeedMp > Contexts.sharedInstance.gameRule.rpgSkillStateData.CurrentXpEnergy)
			{
				flag = true;
			}
			return new BeforeJoinString(skillInfo.SkillName, flag ? "_black" : "");
		}
		return default(BeforeJoinString);
	}

	private void SetType(SkillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		if (newfs > 0)
		{
			string value = null;
			if (!_rpgSkillStateSkillTypeCache.TryGetValue(newfs, out value))
			{
				value = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/skillType_" + newfs + ".png";
				_rpgSkillStateSkillTypeCache[newfs] = value;
			}
			base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", value, delegate(Sprite sprite)
			{
				_viewModel.SetSkillTypeSprite(idx + 1, sprite);
			});
		}
	}

	private int GetType(SkillInfoData skillInfo, int idx)
	{
		return skillInfo?.Type ?? 0;
	}

	private void SetNeedMp(SkillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.SetSkillUseMpString(idx + 1, newfs.ToString());
	}

	private int GetNeedMp(SkillInfoData skillInfo, int idx)
	{
		return skillInfo?.NeedMp ?? 0;
	}

	private void SetTime(SkillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.SetSkillTimeString(idx + 1, ((int)((double)newfs * 0.001)).ToString());
	}

	private int GetTime(SkillInfoData skillInfo, int idx)
	{
		return GetCurrentCdTime(skillInfo);
	}

	private void SetLevel(SkillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		if (newfs > 1)
		{
			string value = null;
			if (!_rpgSkillStateLevelCache.TryGetValue(newfs, out value))
			{
				value = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/lv" + newfs + ".png";
				_rpgSkillStateLevelCache[newfs] = value;
			}
			base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", value, delegate(Sprite sprite)
			{
				_viewModel.SetSkillLvShow(idx + 1, value: true);
				_viewModel.SetSkillLvSprite(idx + 1, sprite);
			});
		}
		else
		{
			_viewModel.SetSkillLvShow(idx + 1, value: false);
		}
	}

	private int GetLevel(SkillInfoData skillInfo, int idx)
	{
		return skillInfo?.Lv ?? 0;
	}

	private void SetMaskPercent(SkillInfoData val, int idx, float oldfs, float newfs, ElementStatus status)
	{
		_viewModel.SetSkillMaskShow(idx + 1, newfs > 0f);
		_viewModel.SetSkillMaskFillamount(idx + 1, newfs);
	}

	private float GetMaskPercent(SkillInfoData skillInfo, int idx)
	{
		return GetCdPercent(skillInfo);
	}

	private void SetEffectVisible(SkillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		_viewModel.SetSkillEffectShow(idx + 1, newfs);
		int num = _lastSkillNames[idx];
		if (val != null)
		{
			_lastSkillNames[idx] = val.SkillName;
			if (newfs && num == val.SkillName)
			{
				_skillEffectFrameAnimaChips[idx].Index = 0;
				_skillEffectFrameAnimaChips[idx].RemainTime = 0;
			}
		}
	}

	private bool GetEffectVisible(SkillInfoData skillInfo, int idx)
	{
		if (skillInfo != null)
		{
			if (skillInfo.CurrentCdTime > skillInfo.CdTime)
			{
				return _lastEffectVisibles[idx];
			}
			return _lastEffectVisibles[idx] = skillInfo.CurrentCdTime <= 0;
		}
		return false;
	}

	private List<SkillInfoData> GetSkillTypeList()
	{
		_skillList.Clear();
		for (int i = 0; i < SkillTypeList.Count; i++)
		{
			_skillList.Add(null);
		}
		int num = 0;
		int num2 = 4;
		Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
		if (uiSkill_Skills != null)
		{
			for (int j = 0; j < SkillTypeList.Count; j++)
			{
				if (uiSkill_Skills.TryGetValue(SkillTypeList[j], out var value) && (!_gameRuleContext.currentRule.Rule.IsRpgHolidayMode() || value.Type != 125))
				{
					if (value.Kind == 2)
					{
						_skillList[num2++] = value;
					}
					else
					{
						_skillList[num++] = value;
					}
				}
			}
		}
		return _skillList;
	}

	private void SetDragoonSkillTime(int arg1, int arg2)
	{
		_viewModel.DragoonSkillTimeString = ((int)((double)arg2 * 0.001)).ToString();
	}

	private bool GetDragoonBackShow()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.RaceType != 121003;
	}

	private void SetDragoonBackShow(bool arg1, bool arg2)
	{
		_viewModel.DragonBackShow = arg2;
	}

	private int GetDragoonSkillTime()
	{
		SkillInfoData dragoonSkill = GetDragoonSkill();
		return GetCurrentCdTime(dragoonSkill);
	}

	private void SetDragoonSkillMaskPercent(float arg1, float arg2)
	{
		_viewModel.DragoonSkillMaskFillamount = arg2;
		_viewModel.DragoonSkillMaskShow = arg2 > 0f;
	}

	private float GetDragoonSkillMaskPercent()
	{
		SkillInfoData dragoonSkill = GetDragoonSkill();
		return GetCdPercent(dragoonSkill);
	}

	private void SetFireEffectVisible(bool arg1, bool arg2)
	{
		_viewModel.FireShowShow = arg2;
		_fireEffectAnimaChip.Index = 0;
		_fireEffectAnimaChip.RemainTime = 0;
	}

	private void SetDragoonSkillEffectVisible(bool arg1, bool arg2)
	{
		_viewModel.DragoonSkillEffectShow = arg2;
		_dragoonSkillEffectAnimaChip.Index = 0;
		_dragoonSkillEffectAnimaChip.RemainTime = 0;
	}

	private bool GetDragoonSkillEffectVisible()
	{
		SkillInfoData dragoonSkill = GetDragoonSkill();
		if (dragoonSkill != null)
		{
			return dragoonSkill.CurrentCdTime <= 0;
		}
		return false;
	}

	private void SetDragoonSkillIcon(BeforeJoinString arg1, BeforeJoinString arg2)
	{
		string text = arg2.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			string value = null;
			if (!_rpgSkillStateCache.TryGetValue(text, out value))
			{
				value = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/" + text + ".png";
				_rpgSkillStateCache[text] = value;
			}
			base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", value, delegate(Sprite sprite)
			{
				_viewModel.DragoonSkillIconSprite = sprite;
			});
		}
	}

	private BeforeJoinString GetDragoonSkillIcon()
	{
		SkillInfoData dragoonSkill = GetDragoonSkill();
		if (dragoonSkill != null)
		{
			return new BeforeJoinString(dragoonSkill.SkillName, (dragoonSkill.CurrentCdTime <= 0) ? "" : "_black");
		}
		return default(BeforeJoinString);
	}

	private void SetDragoonSkillVisible(SkillInfoData arg1, SkillInfoData arg2)
	{
		if (arg2 != null)
		{
			_viewModel.DragoonSkillIconShow = true;
			return;
		}
		_viewModel.DragoonSkillIconShow = false;
		_viewModel.DragoonSkillEffectShow = false;
		_viewModel.DragoonSkillMaskShow = false;
	}

	private SkillInfoData GetDragoonSkill()
	{
		Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
		if (uiSkill_Skills == null)
		{
			return null;
		}
		if (uiSkill_Skills.TryGetValue(103, out var value))
		{
			if (value.Kind == 14)
			{
				return null;
			}
			return value;
		}
		return null;
	}

	private void SetAwakeSkillTime(int arg1, int arg2)
	{
		_viewModel.AwakeSkillTimeString = ((int)((double)arg2 * 0.001)).ToString();
	}

	private int GetAwakeSkillTime()
	{
		SkillInfoData awakeSkill = GetAwakeSkill();
		return GetCurrentCdTime(awakeSkill);
	}

	private void SetAwakeSkillMaskPercent(float arg1, float arg2)
	{
		_viewModel.AwakeSkillMaskFillamount = arg2;
		_viewModel.AwakeSkillMaskShow = arg2 > 0f;
	}

	private float GetAwakeSkillMaskPercent()
	{
		SkillInfoData awakeSkill = GetAwakeSkill();
		return GetCdPercent(awakeSkill);
	}

	private void SetAwakeSkillEffectVisible(bool arg1, bool arg2)
	{
		_viewModel.AwakeSkillEffectShow = arg2;
		_awakeSkillEffectAnimaChip.Index = 0;
		_awakeSkillEffectAnimaChip.RemainTime = 0;
	}

	private bool GetAwakeSkillEffectVisible()
	{
		SkillInfoData awakeSkill = GetAwakeSkill();
		if (awakeSkill != null)
		{
			return awakeSkill.CurrentCdTime <= 0;
		}
		return false;
	}

	private void SetAwakeSkillIcon(BeforeJoinString arg1, BeforeJoinString arg2)
	{
		string text = arg2.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			string value = null;
			if (!_rpgSkillStateCache.TryGetValue(text, out value))
			{
				value = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/" + text + ".png";
				_rpgSkillStateCache[text] = value;
			}
			base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", value, delegate(Sprite sprite)
			{
				_viewModel.AwakeSkillIconSprite = sprite;
			});
		}
	}

	private BeforeJoinString GetAwakeSkillIcon()
	{
		SkillInfoData awakeSkill = GetAwakeSkill();
		if (awakeSkill != null)
		{
			return new BeforeJoinString(awakeSkill.SkillName, "_", awakeSkill.Lv, (awakeSkill.CurrentCdTime <= 0) ? "" : "_black");
		}
		return default(BeforeJoinString);
	}

	private void SetAwakeSkillVisible(SkillInfoData arg1, SkillInfoData arg2)
	{
		if (arg2 != null)
		{
			_viewModel.AwakeSkillIconShow = true;
			return;
		}
		_viewModel.AwakeSkillIconShow = false;
		_viewModel.AwakeSkillEffectShow = false;
		_viewModel.AwakeSkillMaskShow = false;
	}

	private SkillInfoData GetAwakeSkill()
	{
		Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
		if (uiSkill_Skills == null)
		{
			return null;
		}
		if (uiSkill_Skills.TryGetValue(114, out var value))
		{
			return value;
		}
		return null;
	}

	private void SetCurrentXpEnergy(int arg1, int arg2)
	{
		_viewModel.AbsorbedCountString = arg2.ToString();
	}

	private void SetAbsorbedPercent(float arg1, float arg2)
	{
		_viewModel.AbsorbedProgressFillamount = arg2;
	}

	private float GetAbsorbedPercent()
	{
		RpgSkillStateDataComponent rpgSkillStateData = Contexts.sharedInstance.gameRule.rpgSkillStateData;
		if (rpgSkillStateData.TotalXpEnergy <= 0)
		{
			return 0f;
		}
		return (float)rpgSkillStateData.CurrentXpEnergy / (float)rpgSkillStateData.TotalXpEnergy;
	}

	private void SetCurrentMp(int ov, int mp)
	{
		_viewModel.EnergyCountString = mp.ToString();
	}

	private void SetEnergyPercent(float arg1, float arg2)
	{
		_viewModel.EnergyProgressFillamount = arg2;
	}

	private float GetEnergyPercent()
	{
		TdSkillStateDataComponent tdSkillStateData = Contexts.sharedInstance.gameRule.tdSkillStateData;
		if (tdSkillStateData.TotalMp <= 0)
		{
			return 0f;
		}
		return (float)tdSkillStateData.CurrentMp / (float)tdSkillStateData.TotalMp;
	}

	private void InitChips()
	{
		_skillEffectFrameAnimaChips = new FrameAnimaChip[8];
		for (int i = 0; i < _skillEffectFrameAnimaChips.Length; i++)
		{
			_skillEffectFrameAnimaChips[i] = new FrameAnimaChip
			{
				Count = 6,
				StartIndex = 0,
				Path = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/effect",
				Delay = 100,
				IsLoop = false
			};
			_skillEffectFrameAnimaChips[i].Init();
		}
		_awakeSkillEffectAnimaChip = new FrameAnimaChip
		{
			Count = 6,
			StartIndex = 0,
			Path = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/awakeEffect",
			Delay = 100,
			IsLoop = false
		};
		_dragoonSkillEffectAnimaChip = new FrameAnimaChip
		{
			Count = 6,
			StartIndex = 0,
			Path = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/dragoonEffect",
			Delay = 100,
			IsLoop = false
		};
		_fireEffectAnimaChip = new FrameAnimaChip
		{
			Count = 10,
			StartIndex = 0,
			Path = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/fireEffect",
			Delay = 100,
			IsLoop = true
		};
		_dragoonSkillEffectAnimaChip.Init();
		_fireEffectAnimaChip.Init();
		_awakeSkillEffectAnimaChip.Init();
	}

	private void UpdateChips()
	{
		for (int j = 0; j < _skillEffectFrameAnimaChips.Length; j++)
		{
			if (!_viewModel.GetSkillEffectShow(j + 1))
			{
				continue;
			}
			_skillEffectFrameAnimaChips[j].Update(_timeComponent);
			if (_skillEffectFrameAnimaChips[j].Changed)
			{
				int i1 = j;
				base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", _skillEffectFrameAnimaChips[j].Value, delegate(Sprite sprite)
				{
					_viewModel.SetSkillEffectSprite(i1 + 1, sprite);
				});
			}
			_viewModel.SetSkillEffectShow(j + 1, !_skillEffectFrameAnimaChips[j].IsOver);
		}
		if (_viewModel.AwakeSkillEffectShow)
		{
			_awakeSkillEffectAnimaChip.Update(_timeComponent);
			if (_awakeSkillEffectAnimaChip.Changed)
			{
				base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", _awakeSkillEffectAnimaChip.Value, delegate(Sprite sprite)
				{
					_viewModel.AwakeSkillEffectSprite = sprite;
				});
			}
			_viewModel.AwakeSkillEffectShow = !_awakeSkillEffectAnimaChip.IsOver;
		}
		if (_viewModel.DragoonSkillEffectShow)
		{
			_dragoonSkillEffectAnimaChip.Update(_timeComponent);
			if (_dragoonSkillEffectAnimaChip.Changed)
			{
				base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", _dragoonSkillEffectAnimaChip.Value, delegate(Sprite sprite)
				{
					_viewModel.DragoonSkillEffectSprite = sprite;
				});
			}
			_viewModel.DragoonSkillEffectShow = !_dragoonSkillEffectAnimaChip.IsOver;
		}
		if (!_viewModel.FireShowShow)
		{
			return;
		}
		_fireEffectAnimaChip.Update(_timeComponent);
		if (_fireEffectAnimaChip.Changed)
		{
			base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", _fireEffectAnimaChip.Value, delegate(Sprite sprite)
			{
				_viewModel.FireEffectSprite = sprite;
			});
		}
	}

	private float GetCdPercent(SkillInfoData skillInfo)
	{
		if (skillInfo != null && skillInfo.CurrentCdTime > 0 && skillInfo.CurrentCdTime <= skillInfo.CdTime)
		{
			return (float)skillInfo.CurrentCdTime / (float)skillInfo.CdTime;
		}
		return 0f;
	}

	private int GetCurrentCdTime(SkillInfoData skillInfo)
	{
		if (skillInfo != null && skillInfo.CurrentCdTime > 0 && skillInfo.CurrentCdTime <= skillInfo.CdTime)
		{
			return skillInfo.CurrentCdTime;
		}
		return 0;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
