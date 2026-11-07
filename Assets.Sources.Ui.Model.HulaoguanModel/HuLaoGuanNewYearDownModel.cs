using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.HulaoguanModel;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.HulaoguanModel;

[GameUiTest]
public class HuLaoGuanNewYearDownModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private HuLaoGuanNewYearDownViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private List<int> SkillTypeList = new List<int> { 120, 125 };

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private Dictionary<string, string> _rpgSkillStateCache = new Dictionary<string, string>();

	private List<SkillInfoData> _skillList = new List<SkillInfoData>();

	private int[] _lastSkillNames = new int[2];

	private bool[] _lastEffectVisibles = new bool[8];

	private FrameAnimaChip[] _skillFullEffect;

	private FrameAnimaChip[] _skillFillEffect;

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
		_viewModel = new HuLaoGuanNewYearDownViewModel();
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
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetSkillTypeList);
		for (int i = 0; i < SkillTypeList.Count; i++)
		{
			listNotify.AddEvent<SkillInfoData, BeforeJoinString>("SkillIcon", GetSkillIcon, SetSkillIcon, i);
			listNotify.AddEvent<SkillInfoData, float>("Time", GetTime, SetTime, i);
			listNotify.AddEvent<SkillInfoData, bool>("EffectVisible", GetEffectVisible, SetEffectVisible, i);
		}
		_notifyGroup.Add(listNotify.Id);
		NotifyManager.MakeNotifyClass(115, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			switch (tipsEvent[i].TypeId)
			{
			case -13223:
				_skillFullEffect[tipsEvent[i].Time1 - 1].Index = 0;
				_skillFullEffect[tipsEvent[i].Time1 - 1].RemainTime = 0;
				break;
			case -13224:
				_skillFillEffect[tipsEvent[i].Time1 - 1].Index = 0;
				_skillFillEffect[tipsEvent[i].Time1 - 1].RemainTime = 0;
				break;
			}
			_viewModel.SeteffectShow(tipsEvent[i].Time1, value: true);
		}
		tipsEvent.Clear();
	}

	private void SetSkillIcon(SkillInfoData val, int idx, BeforeJoinString oldfs, BeforeJoinString newfs, ElementStatus status)
	{
		string text = newfs.ToString();
		int index = idx + 1;
		if (!string.IsNullOrEmpty(text))
		{
			_viewModel.SetSkillShow(index, value: true);
			string value = null;
			if (!_rpgSkillStateCache.TryGetValue(text, out value))
			{
				value = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/rpgSkillState/" + text + ".png";
				_rpgSkillStateCache[text] = value;
			}
			base.Loader.RetriveSprite("ui/halfloadedres/rpgSkillState", value, delegate(Sprite sprite)
			{
				_viewModel.SeticonSprite(index, sprite);
			});
			if (val.CdTime == 0)
			{
				_viewModel.SetkjjString(index, "");
			}
			else if (val.Type == 120)
			{
				_viewModel.SetkjjString(index, "T");
			}
			else if (val.Type == 125)
			{
				_viewModel.SetkjjString(index, "Y");
			}
		}
		else
		{
			_viewModel.SetSkillShow(index, value: false);
		}
	}

	private BeforeJoinString GetSkillIcon(SkillInfoData skillInfo, int idx)
	{
		if (skillInfo != null)
		{
			bool flag = GetCurrentCdTime(skillInfo) != 0f;
			return new BeforeJoinString(skillInfo.SkillName, flag ? "_black" : "");
		}
		return default(BeforeJoinString);
	}

	private void SetTime(SkillInfoData val, int idx, float oldfs, float newfs, ElementStatus status)
	{
		_viewModel.SetcdFillamount(idx + 1, 1f - newfs);
	}

	private float GetTime(SkillInfoData skillInfo, int idx)
	{
		return GetCurrentCdTime(skillInfo);
	}

	private float GetCurrentCdTime(SkillInfoData skillInfo)
	{
		if (skillInfo == null)
		{
			return 0f;
		}
		if (skillInfo.CdTime == 0)
		{
			return 0f;
		}
		if (skillInfo.NeedMp == 0)
		{
			if (skillInfo.CurrentCdTime > 0 && skillInfo.CurrentCdTime <= skillInfo.CdTime)
			{
				return (float)skillInfo.CurrentCdTime * 1f / (float)skillInfo.CdTime;
			}
			return 0f;
		}
		return 1f - (float)skillInfo.Energy * 1f / (float)skillInfo.NeedMp;
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

	private void SetEffectVisible(SkillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		int num = _lastSkillNames[idx];
		if (val != null)
		{
			_lastSkillNames[idx] = val.SkillName;
			if (newfs && num == val.SkillName)
			{
				_skillFullEffect[idx].Index = 0;
				_skillFullEffect[idx].RemainTime = 0;
			}
		}
		_viewModel.SeteffectShow(idx + 1, newfs);
	}

	private bool GetEffectVisible(SkillInfoData skillInfo, int idx)
	{
		if (skillInfo != null && skillInfo.NeedMp == 0)
		{
			if (skillInfo.CurrentCdTime > skillInfo.CdTime)
			{
				return _lastEffectVisibles[idx];
			}
			return _lastEffectVisibles[idx] = skillInfo.CurrentCdTime <= 0;
		}
		return false;
	}

	private void InitChips()
	{
		_skillFullEffect = new FrameAnimaChip[2];
		for (int i = 0; i < _skillFullEffect.Length; i++)
		{
			_skillFullEffect[i] = new FrameAnimaChip
			{
				Count = 8,
				StartIndex = 0,
				Path = "Assets/Res/Assets/ui/GameGUIRes/hulaoguanmodel/newyear/skill_full_effect/full",
				Delay = 100,
				IsLoop = false
			};
			_skillFullEffect[i].Init();
		}
		_skillFillEffect = new FrameAnimaChip[2];
		for (int j = 0; j < _skillFillEffect.Length; j++)
		{
			_skillFillEffect[j] = new FrameAnimaChip
			{
				Count = 9,
				StartIndex = 1,
				Path = "Assets/Res/Assets/ui/GameGUIRes/hulaoguanmodel/newyear/skill_fill_effect/fill",
				Delay = 100,
				IsLoop = false
			};
			_skillFillEffect[j].Init();
		}
	}

	private void UpdateChips(TimeComponent time)
	{
		for (int j = 0; j < _skillFullEffect.Length; j++)
		{
			if (!_viewModel.GeteffectShow(j + 1))
			{
				continue;
			}
			_skillFullEffect[j].Update(_timeComponent);
			if (_skillFullEffect[j].Changed)
			{
				int i2 = j;
				base.Loader.RetriveSprite("ui/hulaoguanmodel", _skillFullEffect[j].Value, delegate(Sprite sprite)
				{
					_viewModel.SeteffectSprite(i2 + 1, sprite);
				});
			}
			_skillFillEffect[j].Update(_timeComponent);
			if (_skillFillEffect[j].Changed)
			{
				int i1 = j;
				base.Loader.RetriveSprite("ui/hulaoguanmodel", _skillFillEffect[j].Value, delegate(Sprite sprite)
				{
					_viewModel.SeteffectSprite(i1 + 1, sprite);
				});
			}
			_viewModel.SeteffectShow(j + 1, !_skillFullEffect[j].IsOver || !_skillFillEffect[j].IsOver);
		}
	}
}
