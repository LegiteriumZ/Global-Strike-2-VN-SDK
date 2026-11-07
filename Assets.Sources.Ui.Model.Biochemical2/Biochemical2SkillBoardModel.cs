using System.Collections.Generic;
using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Biochemical2;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical2;

[GameUiTest]
public class Biochemical2SkillBoardModel : AbstractModel, IPlaybackSystem, ICursorControl, IKeyboardResponder, ISetPlayerContext
{
	public static Dictionary<string, string> HumanSkills = new Dictionary<string, string>
	{
		{ "H_AUTOLOAD", "autoload" },
		{ "H_BACKUPGUN", "backupgun" },
		{ "H_BACKUPPISTOL", "backuppistol" },
		{ "H_BLADE", "blade" },
		{ "H_BLASTBULLET", "blastbullet" },
		{ "H_GRAPESHOT", "grapeshot" },
		{ "H_JUMP", "jump" },
		{ "H_LIANLIANKAN", "lianliankan" },
		{ "H_RAPID", "rapid" },
		{ "H_REGENBULLET", "regenbullet" },
		{ "H_REGENGRENADE", "regengrenade" },
		{ "H_RIVEGRENADE", "rivegrenade" },
		{ "H_SLOWGRENADE", "slowgrenade" },
		{ "H_STRENGTHBLAST", "strengthblast" },
		{ "H_STRENGTHBULLET", "strengthbullet" },
		{ "H_STRENGTHEN", "strengthen" },
		{ "H_STRENGTHENGRENADE", "strengthengrenade" }
	};

	public static Dictionary<string, string> NatureSkills = new Dictionary<string, string>
	{
		{ "V_N_ENDURE", "endure" },
		{ "V_N_KING", "king" },
		{ "V_N_INVISIBLE", "invisible" },
		{ "V_N_RAPID", "rapid" },
		{ "V_N_ROBUST", "robust" },
		{ "V_N_EVOLUTION", "evolution" },
		{ "V_N_STRONG", "strong" },
		{ "V_N_VAMPIRE", "vampire" },
		{ "V_N_SNAKERRELIVE", "snakerrelive" },
		{ "V_N_DODGE", "dodge" }
	};

	public static Dictionary<string, string> VariantSkills = new Dictionary<string, string>
	{
		{ "V_2PHRASEJUMP", "2phrasejump" },
		{ "V_IRONHEAD", "ironhead" },
		{ "V_JUMP", "jump" },
		{ "V_POISONOUS", "poisonous" },
		{ "V_REBORN", "reborn" },
		{ "V_SELFHEALTH", "selfhealth" },
		{ "V_SHIELD", "shield" },
		{ "V_SNEAK", "sneak" },
		{ "V_VAMPIRE", "vampire" },
		{ "V_RAPID", "rapid" }
	};

	private Biochemical2SkillBoardViewModel _viewModel;

	private PlayerContext _playerContext;

	private Biochemical2SkillItemModel[] _humanSkills;

	private Biochemical2SkillItemModel[] _variantSkills;

	private List<PassiveSkillComponent> humanSkills = new List<PassiveSkillComponent>(32);

	private List<PassiveSkillComponent> variantSkills = new List<PassiveSkillComponent>(32);

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

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
		_viewModel = new Biochemical2SkillBoardViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			for (int i = 0; i < _humanSkills.Length; i++)
			{
				_humanSkills[i].OnPlayback();
			}
			for (int j = 0; j < _variantSkills.Length; j++)
			{
				_variantSkills[j].OnPlayback();
			}
			if (_viewModel.ShowShow)
			{
				Update();
			}
		}
	}

	protected override void DoSubscribe()
	{
		_humanSkills = new Biochemical2SkillItemModel[HumanSkills.Count];
		for (int i = 0; i < _humanSkills.Length; i++)
		{
			_humanSkills[i] = new Biochemical2SkillItemModel();
			_humanSkills[i].Container = _viewModel.GridObj1;
			_humanSkills[i].ParentViewModel = _viewModel;
			_humanSkills[i].Initialize();
		}
		_variantSkills = new Biochemical2SkillItemModel[VariantSkills.Count + NatureSkills.Count];
		for (int j = 0; j < _variantSkills.Length; j++)
		{
			_variantSkills[j] = new Biochemical2SkillItemModel();
			_variantSkills[j].Container = _viewModel.GridObj2;
			_variantSkills[j].ParentViewModel = _viewModel;
			_variantSkills[j].Initialize();
		}
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		_viewModel.TipsShow = false;
	}

	private void Update()
	{
		if (_playerContext.myPlayerEntity.hasPassiveSkillGroup)
		{
			humanSkills.Clear();
			variantSkills.Clear();
			foreach (KeyValuePair<string, PassiveSkillComponent> allPassiveSkill in _playerContext.myPlayerEntity.passiveSkillGroup.allPassiveSkills)
			{
				if (HumanSkills.ContainsKey(allPassiveSkill.Value.skillName))
				{
					SortSkill(humanSkills, allPassiveSkill.Value);
				}
				else
				{
					SortSkill(variantSkills, allPassiveSkill.Value);
				}
			}
		}
		for (int i = 0; i < _humanSkills.Length; i++)
		{
			if (i < humanSkills.Count)
			{
				_humanSkills[i].SetInfo(humanSkills[i]);
			}
			else
			{
				_humanSkills[i].SetInfo(null);
			}
		}
		for (int j = 0; j < _variantSkills.Length; j++)
		{
			if (j < variantSkills.Count)
			{
				_variantSkills[j].SetInfo(variantSkills[j]);
			}
			else
			{
				_variantSkills[j].SetInfo(null);
			}
		}
	}

	private void SortSkill(List<PassiveSkillComponent> list, PassiveSkillComponent skill)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (Compare(list[i], skill) > 0)
			{
				list.Insert(i, skill);
				return;
			}
		}
		list.Add(skill);
	}

	private int Compare(PassiveSkillComponent a, PassiveSkillComponent b)
	{
		if (NatureSkills.ContainsKey(a.skillName) && !NatureSkills.ContainsKey(b.skillName))
		{
			return -1;
		}
		if (NatureSkills.ContainsKey(b.skillName) && !NatureSkills.ContainsKey(a.skillName))
		{
			return 1;
		}
		return b.skillLV - a.skillLV;
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 1;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.P)
		{
			_viewModel.ShowShow = !_viewModel.ShowShow;
			if (_viewModel.ShowShow)
			{
				Update();
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
