using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgTeamRace;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.RpgTeamRace;

[GameUiTest]
public class RpgTeamRaceSkillStateModel : AbstractModel, IPlaybackSystem, ISetPlayerContext
{
	private RpgTeamRaceSkillStateViewModel _viewModel;

	private List<int> SkillTypeList = new List<int> { 127, 128, 129, 130, 131, 132, 133, 134 };

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private int[] _lastSkillNames = new int[8];

	private bool[] _lastEffectVisibles = new bool[8];

	private List<SkillInfoData> _skillList = new List<SkillInfoData>();

	private FrameAnimaChip[] _skillEffectFrameAnimaChips;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgTeamRaceSkillStateViewModel();
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
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetSkillTypeList);
		for (int i = 0; i < SkillTypeList.Count; i++)
		{
			listNotify.AddEvent<SkillInfoData, ComboValue<int, string>>("SkillIcon", GetSkillIcon, SetSkillIcon, i);
			listNotify.AddEvent<SkillInfoData, bool>("EffectVisible", GetEffectVisible, SetEffectVisible, i);
			listNotify.AddEvent<SkillInfoData, float>("MaskPercent", GetMaskPercent, SetMaskPercent, i);
			listNotify.AddEvent<SkillInfoData, int>("Level", GetLevel, SetLevel, i);
			listNotify.AddEvent<SkillInfoData, int>("Time", GetTime, SetTime, i);
			listNotify.AddEvent<SkillInfoData, int>("NeedMp", GetNeedMp, SetNeedMp, i);
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
		if (_playerContext.isCameraOwner)
		{
			return _playerContext.cameraOwnerEntity.HasState(131072);
		}
		return false;
	}

	private void SetSkillIcon(SkillInfoData val, int idx, ComboValue<int, string> oldfs, ComboValue<int, string> newfs, ElementStatus status)
	{
		string text = newfs.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			_viewModel.SetSkillIconShow(idx + 1, value: true);
			_viewModel.SetSkillUseMpBackShow(idx + 1, value: true);
			base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/" + text + ".png", delegate(Sprite sprite)
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

	private ComboValue<int, string> GetSkillIcon(SkillInfoData skillInfo, int idx)
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
			return new ComboValue<int, string>(skillInfo.SkillName, flag ? "_black" : "");
		}
		return new ComboValue<int, string>(0, string.Empty);
	}

	private void SetType(SkillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		if (newfs > 0)
		{
			base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/skillType_" + newfs + ".png", delegate(Sprite sprite)
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
		_viewModel.SetSkillUseMpBackShow(idx + 1, newfs > 0);
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
			base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/lv" + newfs + ".png", delegate(Sprite sprite)
			{
				_viewModel.SetSkillLvSprite(idx + 1, sprite);
			});
		}
		else
		{
			_viewModel.SetSkillLvSprite(idx + 1, UiResourcesLoader.DefaultSprite);
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
		Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
		if (uiSkill_Skills != null)
		{
			for (int j = 0; j < SkillTypeList.Count; j++)
			{
				if (uiSkill_Skills.TryGetValue(SkillTypeList[j], out var value))
				{
					_skillList[j] = value;
				}
			}
		}
		return _skillList;
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
}
