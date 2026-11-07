using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.HerofightingModel;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.HerofightingModel;

[GameUiTest]
public class HeroFightingSkillModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private HeroFightingSkillViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private List<int> SkillTypeList = new List<int> { 11, 105, 136 };

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private List<SkillInfoData> _skillList = new List<SkillInfoData>();

	public int max_time;

	private Dictionary<string, string> _rpgSkillStateCache = new Dictionary<string, string>();

	private ActiveChip _centerActiveChip = new ActiveChip();

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
		_viewModel = new HeroFightingSkillViewModel();
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
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetAwakeSkillIcon, SetAwakeSkillIcon, null, initinvoke: true, isFrameSeparation: true));
		NotifyManager.MakeNotifyClass(123, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetHeriTimeEvent, initinvoke: true);
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetSkillTypeList);
		for (int i = 0; i < SkillTypeList.Count; i++)
		{
			listNotify.AddEvent<SkillInfoData, BeforeJoinString>("SkillIcon", GetSkillIcon, SetSkillIcon, i);
			listNotify.AddEvent<SkillInfoData, float>("MaskPercent", GetMaskPercent, SetMaskPercent, i);
		}
		_notifyGroup.Add(listNotify.Id);
	}

	protected virtual void SetHeriTimeEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId == -13502)
			{
				_viewModel.TimerShow = true;
				_centerActiveChip.Time = tipsEvent[i].Time1;
				_viewModel.timepFillamount = (float)tipsEvent[i].Time1 / ((float)tipsEvent[i].Time2 * 1f);
				max_time = tipsEvent[i].Time2;
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.PanelShow = arg2;
	}

	private bool GetVisible()
	{
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 18023 && PlayerCareerConstantUtility.IsHero(UiIEventCondition.Get_cameraOwnerData_Career()))
		{
			return true;
		}
		return false;
	}

	private void SetMaskPercent(SkillInfoData val, int idx, float oldfs, float newfs, ElementStatus status)
	{
		_viewModel.SetskillpFillamount(idx + 1, newfs);
	}

	private float GetCdPercent(SkillInfoData skillInfo)
	{
		if (skillInfo != null && skillInfo.CurrentCdTime > 0 && skillInfo.CurrentCdTime <= skillInfo.CdTime)
		{
			return 1f - (float)skillInfo.CurrentCdTime / (float)skillInfo.CdTime;
		}
		return 1f;
	}

	private float GetMaskPercent(SkillInfoData skillInfo, int idx)
	{
		return GetCdPercent(skillInfo);
	}

	private BeforeJoinString GetSkillIcon(SkillInfoData skillInfo, int idx)
	{
		if (skillInfo != null)
		{
			bool flag = skillInfo.CurrentCdTime > 0;
			return new BeforeJoinString(skillInfo.SkillName, flag ? "_black" : "");
		}
		return default(BeforeJoinString);
	}

	private void SetSkillIcon(SkillInfoData val, int idx, BeforeJoinString oldfs, BeforeJoinString newfs, ElementStatus status)
	{
		string text = newfs.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			_viewModel.SetskilliShow(idx + 1, value: true);
			string value = null;
			if (!_rpgSkillStateCache.TryGetValue(text, out value))
			{
				value = "Assets/Res/Assets/ui/GameGUIRes/herofightingmodel/skill/" + text + ".png";
				_rpgSkillStateCache[text] = value;
			}
			base.Loader.RetriveSprite("ui/herofightingmodel", value, delegate(Sprite sprite)
			{
				_viewModel.SetskilliSprite(idx + 1, sprite);
			});
			base.Loader.RetriveSprite("ui/herofightingmodel", "Assets/Res/Assets/ui/GameGUIRes/herofightingmodel/skill/key" + (idx + 1) + newfs.Value1 + ".png", delegate(Sprite sprite)
			{
				_viewModel.SetskillkSprite(idx + 1, sprite);
			});
		}
		else
		{
			_viewModel.SetskilliShow(idx + 1, value: false);
		}
	}

	private List<SkillInfoData> GetSkillTypeList()
	{
		_skillList.Clear();
		for (int i = 0; i < SkillTypeList.Count; i++)
		{
			_skillList.Add(null);
		}
		int num = 0;
		Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
		if (uiSkill_Skills != null)
		{
			for (int j = 0; j < SkillTypeList.Count; j++)
			{
				if (uiSkill_Skills.TryGetValue(SkillTypeList[j], out var value))
				{
					_skillList[num++] = value;
				}
			}
		}
		return _skillList;
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

	private void InitChips()
	{
		_centerActiveChip.Time = 0;
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.TimerShow = _centerActiveChip.Update(_timeComponent);
		if (_viewModel.TimerShow)
		{
			_viewModel.timepFillamount = (float)_centerActiveChip.Time / ((float)max_time * 1f);
		}
	}
}
