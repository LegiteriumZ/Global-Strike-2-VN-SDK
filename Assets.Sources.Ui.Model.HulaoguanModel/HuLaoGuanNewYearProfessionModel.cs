using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.HulaoguanModel;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.HulaoguanModel;

[GameUiTest]
public class HuLaoGuanNewYearProfessionModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private HuLaoGuanNewYearProfessionViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int testjobid;

	private Dictionary<string, string> _rpgSkillStateCache = new Dictionary<string, string>();

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
		_viewModel = new HuLaoGuanNewYearProfessionViewModel();
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
		NotifyManager.MakeNotifyClass(112, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
		_viewModel.PanelShow = false;
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			int typeId = tipsEvent[i].TypeId;
			_viewModel.PanelShow = tipsEvent[i].Show;
			switch (typeId)
			{
			case -13217:
				UpdateUI("0", tipsEvent[i], "iconzf", "iconjm");
				break;
			case -13218:
				UpdateUI("2", tipsEvent[i], "iconxz", "iconyy");
				break;
			case -13219:
				UpdateUI("3", tipsEvent[i], "iconyz", "iconrx");
				break;
			case -13220:
				UpdateUI("1", tipsEvent[i], "iconfy", "iconjs");
				break;
			}
		}
		tipsEvent.Clear();
	}

	public void UpdateUI(string career, RpgTipsEventData tipsEvent, string skill1, string skill2)
	{
		_viewModel.NameString = ScriptLocalization.Get($"HULAOGUAN_JOB_NAME_[{career}]");
		_viewModel.JobDesString = ScriptLocalization.Get($"HULAOGUAN_JOB_DES_[{career}]");
		_viewModel.DesString1 = string.Format(ScriptLocalization.Get($"HULAOGUAN_SKILL_T_[{career}]"), tipsEvent.Time1, tipsEvent.Time2, tipsEvent.Time3, tipsEvent.Str1);
		_viewModel.DesString2 = string.Format(ScriptLocalization.Get($"HULAOGUAN_SKILL_Y_[{career}]"), tipsEvent.Str1, tipsEvent.Str2);
		string value = null;
		if (!_rpgSkillStateCache.TryGetValue(skill1, out value))
		{
			value = "Assets/Res/Assets/ui/GameGUIRes/hulaoguanmodel/newyear/" + skill1 + ".png";
			_rpgSkillStateCache[skill1] = value;
		}
		base.Loader.RetriveSprite("ui/hulaoguanmodel", value, delegate(Sprite sprite)
		{
			_viewModel.SKillSprite1 = sprite;
		});
		if (!_rpgSkillStateCache.TryGetValue(skill2, out value))
		{
			value = "Assets/Res/Assets/ui/GameGUIRes/hulaoguanmodel/newyear/" + skill2 + ".png";
			_rpgSkillStateCache[skill2] = value;
		}
		base.Loader.RetriveSprite("ui/hulaoguanmodel", value, delegate(Sprite sprite)
		{
			_viewModel.SkillSprite2 = sprite;
		});
		if (!_rpgSkillStateCache.TryGetValue(career, out value))
		{
			value = "Assets/Res/Assets/ui/GameGUIRes/hulaoguanmodel/newyear/" + career + ".png";
			_rpgSkillStateCache[career] = value;
		}
		base.Loader.RetriveSprite("ui/hulaoguanmodel", value, delegate(Sprite sprite)
		{
			_viewModel.iconSprite = sprite;
		});
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
