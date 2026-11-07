using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg2022newyeadMode;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg2022newyeadMode;

[GameUiTest]
public class Rpg2022NewYeadgLeftModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private Rpg2022NewYeadgLeftViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private List<int> SkillTypeList = new List<int> { 120, 125, 126, 103, 122 };

	private List<string> SkillTypeListStr = new List<string> { "T", "Y", "Z", "C", "V" };

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private Dictionary<string, string> _rpgSkillStateCache = new Dictionary<string, string>();

	private List<SkillInfoData> _skillList = new List<SkillInfoData>();

	private ActiveChip _gameTipActiveChip = new ActiveChip();

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
		_viewModel = new Rpg2022NewYeadgLeftViewModel();
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
		NotifyManager.MakeNotifyClass(123, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetSkillTypeList);
		for (int i = 0; i < SkillTypeList.Count; i++)
		{
			listNotify.AddEvent<SkillInfoData, BeforeJoinString>("SkillIcon", GetSkillIcon, SetSkillIcon, i);
			listNotify.AddEvent<SkillInfoData, float>("MaskPercent", GetMaskPercent, SetMaskPercent, i);
		}
		_notifyGroup.Add(listNotify.Id);
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
					_viewModel.SetbuffsumString(num + 1, SkillTypeListStr[j]);
					_skillList[num++] = value;
				}
			}
		}
		return _skillList;
	}

	private void SetMaskPercent(SkillInfoData val, int idx, float oldfs, float newfs, ElementStatus status)
	{
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
			string value = null;
			if (!_rpgSkillStateCache.TryGetValue(text, out value))
			{
				value = "Assets/Res/Assets/ui/GameGUIRes/rpg2022newyeadMode/BuffIcon/" + text + ".png";
				_rpgSkillStateCache[text] = value;
			}
			base.Loader.RetriveSprite("ui/rpg2022newyeadMode", value, delegate(Sprite sprite)
			{
				_viewModel.SetbufficonSprite(idx + 1, sprite);
				_viewModel.SetbuffShow(idx + 1, value: true);
			});
		}
		else
		{
			_viewModel.SetbuffShow(idx + 1, value: false);
		}
	}

	private void SetBuffIcon(int num, string aPath)
	{
		int i;
		for (i = 0; i < num; i++)
		{
			base.Loader.RetriveSprite("ui/rpg2022newyeadMode", aPath, delegate(Sprite sprite)
			{
				_viewModel.SetbShow(i + 1, value: true);
				_viewModel.SetbSprite(i + 1, sprite);
			});
		}
		for (int j = num; j < 7; j++)
		{
			_viewModel.SetbShow(j + 1, value: false);
		}
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		int num;
		for (num = 0; num < tipsEvent.Count; num++)
		{
			if (tipsEvent[num].TypeId == -13515)
			{
				_viewModel.jfString2 = tipsEvent[num].Time1.ToString();
			}
			else if (tipsEvent[num].TypeId == -13517)
			{
				string aPath = "Assets/Res/Assets/ui/GameGUIRes/rpg2022newyeadMode/zybuff.png";
				SetBuffIcon(tipsEvent[num].Time1, aPath);
			}
			else if (tipsEvent[num].TypeId == -13516)
			{
				string aPath2 = "Assets/Res/Assets/ui/GameGUIRes/rpg2022newyeadMode/dcbuff.png";
				SetBuffIcon(tipsEvent[num].Time1, aPath2);
			}
			else if (tipsEvent[num].Show)
			{
				string assetName = "Assets/Res/Assets/ui/GameGUIRes/rpg2022newyeadMode/tips/" + tipsEvent[num].TypeId + ".png";
				bool show = tipsEvent[num].Show;
				base.Loader.RetriveSprite("ui/rpg2022newyeadMode", assetName, delegate(Sprite sprite)
				{
					_viewModel.game_messageSprite = sprite;
					_viewModel.game_messageImage.SetNativeSize();
					_gameTipActiveChip.Time = (show ? 3000 : 0);
				});
			}
			tipsEvent.RemoveAt(num);
			num--;
		}
	}

	private void InitChips()
	{
		_gameTipActiveChip.Time = 0;
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.Game_TipShow = _gameTipActiveChip.Update(_timeComponent);
	}
}
