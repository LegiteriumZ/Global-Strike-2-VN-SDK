using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical3;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Ui.Model.Biochemical3;

[GameUiTest]
public class Biochemical3SkillModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetCameraContext
{
	private Biochemical3SkillViewModel _viewModel;

	private int[] _keys = new int[5] { 106, 105, 107, 8, 11 };

	private FrameAnimaChip[] _animaChips = new FrameAnimaChip[5];

	private PlayerContext _playerContext;

	private WorldCameraContext _cameraContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Biochemical3SkillViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		for (int i = 0; i < 5; i++)
		{
			SimpleNotify.Add(GetSkillId, SetSkillId, i);
			SimpleNotify.Add(GetSkillPercent, SetSkillPercent, i);
			SimpleNotify.Add(GetSkillCount, SetSkillCount, i);
		}
		NotifyManager.MakeTempNotify(GetShow, SetShow, null, initinvoke: true, isFrameSeparation: true);
		base.Loader.RetriveSprite("ui/bio3model", "Assets/Res/Assets/ui/GameGUIRes/bio3Model/skill/f.png", delegate(Sprite sprite)
		{
			_viewModel.KeySprite1 = sprite;
		});
		base.Loader.RetriveSprite("ui/bio3model", "Assets/Res/Assets/ui/GameGUIRes/bio3Model/skill/e.png", delegate(Sprite sprite)
		{
			_viewModel.KeySprite2 = sprite;
		});
		base.Loader.RetriveSprite("ui/bio3model", "Assets/Res/Assets/ui/GameGUIRes/bio3Model/skill/g.png", delegate(Sprite sprite)
		{
			_viewModel.KeySprite3 = sprite;
		});
	}

	private bool GetShow()
	{
		if (PlayerCareerUtil.IsHumanity(UiIEventCondition.Get_cameraOwnerData_Career()))
		{
			return false;
		}
		return true;
	}

	private void SetShow(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		if (arg2)
		{
			if (PlayerCareerUtil.IsHumanHero(UiIEventCondition.Get_cameraOwnerData_Career()))
			{
				_viewModel.SetItemShow(1, value: false);
				_viewModel.SetItemShow(2, value: false);
				_viewModel.SetItemShow(3, value: false);
			}
			else
			{
				_viewModel.SetItemShow(4, value: false);
				_viewModel.SetItemShow(5, value: false);
			}
		}
	}

	private void SetSkillCount(int arg1, int arg2)
	{
		if (arg1 != 0)
		{
			_viewModel.SetCountShow(arg2 + 1, value: true);
			_viewModel.SetCountString(arg2 + 1, arg1.ToString());
		}
		else
		{
			_viewModel.SetCountShow(arg2 + 1, value: false);
		}
	}

	private int GetSkillCount(int arg1)
	{
		return GetSkillInfo(arg1)?.Slv ?? 0;
	}

	private void SetSkillPercent(float arg1, int arg2)
	{
		_viewModel.SetIconFillamount(arg2 + 1, arg1);
		if (arg1 >= 1f)
		{
			_viewModel.SetEffectShow(arg2 + 1, value: true);
			_animaChips[arg2].Index = 0;
		}
	}

	private float GetSkillPercent(int arg1)
	{
		SkillInfoData skillInfo = GetSkillInfo(arg1);
		if (skillInfo == null)
		{
			return 0f;
		}
		int skillName = skillInfo.SkillName;
		float num = 0f;
		num = (ActiveSkillName.IsPassiveSkill(skillName) ? 1f : (ActiveSkillName.IsUseEnergySkill(skillName) ? ((float)((skillInfo.NeedMp <= skillInfo.Mp) ? 1 : 0)) : ((145 != skillName) ? ((skillInfo.CdTime > 0) ? ((float)(skillInfo.CdTime - skillInfo.CurrentCdTime) / (float)skillInfo.CdTime) : 0f) : 1f)));
		return Mathf.Min(num, 1f);
	}

	private void SetSkillId(int arg1, int arg2)
	{
		if (arg1 > 0)
		{
			_viewModel.SetItemShow(arg2 + 1, value: true);
			base.Loader.RetriveSprite("ui/halfloadedres/bio3Skill", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/bio3Skill/{arg1}_back.png", delegate(Sprite sprite)
			{
				_viewModel.SetBackSprite(arg2 + 1, sprite);
			});
			base.Loader.RetriveSprite("ui/halfloadedres/bio3Skill", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/bio3Skill/{arg1}.png", delegate(Sprite sprite)
			{
				_viewModel.SetIconSprite(arg2 + 1, sprite);
			});
		}
		else
		{
			_viewModel.SetItemShow(arg2 + 1, value: false);
		}
	}

	private int GetSkillId(int arg1)
	{
		return GetSkillInfo(arg1)?.SkillName ?? 0;
	}

	private SkillInfoData GetSkillInfo(int arg1)
	{
		if (_playerContext.isMyPlayer && _playerContext.myPlayerEntity.hasSkill)
		{
			Dictionary<int, SkillInfoData> skills = _playerContext.myPlayerEntity.skill.Skills;
			if (skills.ContainsKey(_keys[arg1]))
			{
				return skills[_keys[arg1]];
			}
		}
		return null;
	}

	private void InitChips()
	{
		for (int i = 0; i < _animaChips.Length; i++)
		{
			_animaChips[i] = new FrameAnimaChip();
			_animaChips[i].StartIndex = 0;
			_animaChips[i].Count = 4;
			_animaChips[i].Path = "Assets/Res/Assets/ui/GameGUIRes/bio3Model/skill/effect";
			_animaChips[i].Init();
		}
	}

	private void UpdateChips()
	{
		for (int j = 0; j < _animaChips.Length; j++)
		{
			if (!_viewModel.GetEffectShow(j + 1))
			{
				continue;
			}
			_animaChips[j].Update(_timeComponent);
			if (_animaChips[j].Changed)
			{
				int i1 = j;
				base.Loader.RetriveSprite("ui/bio3model", _animaChips[j].Value, delegate(Sprite sprite)
				{
					_viewModel.SetEffectSprite(i1 + 1, sprite);
				});
			}
			if (_animaChips[j].IsOver)
			{
				_viewModel.SetEffectShow(j + 1, value: false);
			}
		}
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetCameraContext(WorldCameraContext context)
	{
		_cameraContext = context;
	}
}
