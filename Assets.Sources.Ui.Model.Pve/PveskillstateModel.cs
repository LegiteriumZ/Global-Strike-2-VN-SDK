using System.Collections.Generic;
using Assets.Sources.Components.Player;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.UIChip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public class PveskillstateModel : AbstractModel, IPlaybackSystem
{
	private PveskillstateViewModel _viewModel;

	private int _backstate = -1;

	private HashSet<int> _cdlist = new HashSet<int>();

	private int _raceType;

	private Assets.Sources.Utils.Chip.ActiveChip[] _effectActiveChip = new Assets.Sources.Utils.Chip.ActiveChip[4];

	private Assets.Sources.Utils.Chip.ActiveChip[] _boundActiveChip = new Assets.Sources.Utils.Chip.ActiveChip[4];

	private FloatChip[] _boundalphaChip = new FloatChip[4];

	private FloatChip[] _DelayboundalphaChip = new FloatChip[4];

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
		_raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveskillstateViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			if (!Contexts.sharedInstance.battleRoom.roomData.IsObserver)
			{
				_viewModel.pveskillstateShow = true;
				UpdateBackUrl();
				UpdateMpState();
				UpdateSkillImage(106, _timeComponent.FrameInterval, 0);
				UpdateSkillImage(107, _timeComponent.FrameInterval, 1);
				UpdateChips();
			}
			else
			{
				_viewModel.pveskillstateShow = false;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_tdSkillStateData_CurrentMp, SetCurrentMp, null, initinvoke: true);
	}

	private void InitChips()
	{
		for (int i = 0; i < 4; i++)
		{
			_effectActiveChip[i] = new Assets.Sources.Utils.Chip.ActiveChip();
			_boundActiveChip[i] = new Assets.Sources.Utils.Chip.ActiveChip();
			_boundalphaChip[i] = new FloatChip();
			_DelayboundalphaChip[i] = new FloatChip();
			SetChip(i, active: true);
		}
	}

	private void UpdateChips()
	{
		foreach (int item in _cdlist)
		{
			_viewModel.SetEffectShow(item, _effectActiveChip[item - 1].Update(_timeComponent));
			_viewModel.SetboundShow(item, _boundActiveChip[item - 1].Update(_timeComponent));
			_viewModel.SetboundColor(item, new Color(1f, 1f, 1f, _boundalphaChip[item - 1].Update(_timeComponent)));
			if (_boundalphaChip[item - 1].IsOver)
			{
				_viewModel.SetboundColor(item, new Color(1f, 1f, 1f, _DelayboundalphaChip[item - 1].Update(_timeComponent)));
			}
		}
	}

	private void SetChip(int i, bool active)
	{
		if (active)
		{
			_effectActiveChip[i].Time = 166;
			_boundActiveChip[i].Time = 332;
			_boundalphaChip[i].Start = 1f;
			_boundalphaChip[i].Target = 0f;
			_boundalphaChip[i].Time = 166f;
			_DelayboundalphaChip[i].Start = 1f;
			_DelayboundalphaChip[i].Target = 0f;
			_DelayboundalphaChip[i].Time = 166f;
		}
	}

	private void UpdateSkillKeyImage(int skillname, int skillidx)
	{
		if (ActiveSkillName.IsGoldSkill(skillname))
		{
			_viewModel.SetKeyShow(skillidx, value: true);
		}
		else
		{
			_viewModel.SetKeyShow(skillidx, value: false);
		}
	}

	private void UpdateSkillLvImage(int skillname, int lv, int skillidx)
	{
		if (ActiveSkillName.IsGoldSkill(skillname))
		{
			_viewModel.SetLvShow(skillidx, value: true);
			_viewModel.SetLvString(skillidx, lv.ToString());
		}
		else
		{
			_viewModel.SetLvShow(skillidx, value: false);
		}
	}

	private void SetCurrentMp(int ov, int val)
	{
		_viewModel.mptxtString = StringCache.IntToString(val);
	}

	private void UpdateBackUrl()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity == null)
		{
			return;
		}
		CurrentWeaponComponent currentWeapon = myPlayerEntity.currentWeapon;
		if (currentWeapon != null && (currentWeapon.Name.Equals("ak47_hero") || currentWeapon.Name.Equals("ak47_hero1")))
		{
			if (_backstate != 1)
			{
				_backstate = 1;
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/ak47_hero_back.png", delegate(Sprite sprite)
				{
					_viewModel.BackSprite = sprite;
				});
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/ak47_hero_mpback.png", delegate(Sprite sprite)
				{
					_viewModel.mpbackRotationSprite = sprite;
				});
			}
		}
		else
		{
			if (_backstate == 0)
			{
				return;
			}
			_backstate = 0;
			if (_raceType == 1100)
			{
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/back2g.png", delegate(Sprite sprite)
				{
					_viewModel.BackSprite = sprite;
				});
			}
			else
			{
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/back.png", delegate(Sprite sprite)
				{
					_viewModel.BackSprite = sprite;
				});
			}
			base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/mpback.png", delegate(Sprite sprite)
			{
				_viewModel.mpbackRotationSprite = sprite;
			});
		}
	}

	private void UpdateMpback(float p)
	{
		_viewModel.mpbackRotationFillamount = p * 0.84f + 0.08f;
	}

	private void UpdateMpState()
	{
		UpdateMpback((float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() / (float)UiIEventCondition.Get_tdSkillStateData_TotalMp());
	}

	private void UpdateSkillImage(int skillType, int frameinterval, int skillIndex)
	{
		Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
		if (uiSkill_Skills != null && uiSkill_Skills.TryGetValue(skillType, out var value))
		{
			_viewModel.SetskilliconShow(skillIndex + 1, value: true);
			switch (value.SkillName)
			{
			case 23:
			case 96:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/ammunitionsupply.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 24:
			case 94:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/addhp.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 25:
			case 98:
			case 130:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/lightningbound.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 26:
			case 97:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/breastwall.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 53:
			case 90:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/ak47_hero.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 60:
			case 95:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/goldrifle.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 61:
			case 93:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/goldmachine.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 62:
			case 91:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/goldshotgun.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 63:
			case 92:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/goldsniper.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 40001:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/crazeskill1.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 40002:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/crazeskill2.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			case 40003:
				base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/skillstate/crazeskill3.png", _viewModel.GetskilliconImage(skillIndex + 1));
				break;
			default:
				_viewModel.SetskilliconShow(skillIndex + 1, value: false);
				_viewModel.SetLvShow(skillIndex + 1, value: false);
				_viewModel.SetwaiShow(skillIndex + 1, value: false);
				_viewModel.SetKeyShow(skillIndex + 1, value: false);
				_viewModel.SetEffectShow(skillIndex + 1, value: false);
				return;
			}
			if (UiIEventCondition.Get_tdSkillStateData_CurrentMp() < value.NeedMp)
			{
				_cdlist.Remove(skillIndex + 1);
				SetChip(skillIndex, active: true);
				_viewModel.SetwaiShow(skillIndex + 1, value: true);
				_viewModel.SetboundShow(skillIndex + 1, value: false);
				_viewModel.SetEffectShow(skillIndex + 1, value: false);
			}
			else if (value.CurrentCdTime <= 0)
			{
				_cdlist.Add(skillIndex + 1);
				_viewModel.SetwaiShow(skillIndex + 1, value: false);
			}
			else
			{
				_viewModel.SetwaiShow(skillIndex + 1, value: true);
				_viewModel.SetboundShow(skillIndex + 1, value: false);
				_viewModel.SetEffectShow(skillIndex + 1, value: false);
				_cdlist.Remove(skillIndex + 1);
				SetChip(skillIndex, active: true);
			}
			UpdateSkillKeyImage(value.SkillName, skillIndex + 1);
			UpdateSkillLvImage(value.SkillName, value.Lv, skillIndex + 1);
		}
	}
}
