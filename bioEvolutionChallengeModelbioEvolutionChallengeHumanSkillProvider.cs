using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;
using share.constant;

public class bioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider : IbioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	public bioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isShow()
	{
		return PlayerCareerUtil.IsHumanity(UiIEventCondition.Get_cameraOwnerData_Career());
	}

	private SkillInfoData GetSkillInfo(int arg1)
	{
		if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.hasSkill)
		{
			Dictionary<int, SkillInfoData> skills = _playerContext.cameraOwnerEntity.skill.Skills;
			if (skills.ContainsKey(arg1))
			{
				return skills[arg1];
			}
		}
		return null;
	}

	private bool isHumanSkill(int skillId)
	{
		if (skillId >= 272)
		{
			return skillId <= 277;
		}
		return false;
	}

	public bool isBackShow()
	{
		SkillInfoData skillInfo = GetSkillInfo(106);
		if (skillInfo == null)
		{
			return false;
		}
		int skillName = skillInfo.SkillName;
		if (!isHumanSkill(skillName))
		{
			return false;
		}
		return skillInfo.CurrentCdTime > 0;
	}

	public string getSkillTypeFBackUrl()
	{
		SkillInfoData skillInfo = GetSkillInfo(106);
		if (skillInfo == null)
		{
			return "";
		}
		return $"/ui/GameGUIRes/bioEvolutionChallengeModel/humanSkill/{skillInfo.SkillName}_back";
	}

	public bool isShowSkillTypeF()
	{
		SkillInfoData skillInfo = GetSkillInfo(106);
		if (skillInfo == null)
		{
			return false;
		}
		int skillName = skillInfo.SkillName;
		return isHumanSkill(skillName);
	}

	public string getSkillTypeFUrl()
	{
		SkillInfoData skillInfo = GetSkillInfo(106);
		if (skillInfo == null)
		{
			return "";
		}
		return $"/ui/GameGUIRes/bioEvolutionChallengeModel/humanSkill/{skillInfo.SkillName}";
	}

	public bool isShowSkillTypeNoKey()
	{
		SkillInfoData skillInfo = GetSkillInfo(0);
		if (skillInfo == null)
		{
			return false;
		}
		int skillName = skillInfo.SkillName;
		return isHumanSkill(skillName);
	}

	public string getSkillTypeNoKeyUrl()
	{
		SkillInfoData skillInfo = GetSkillInfo(0);
		if (skillInfo == null)
		{
			return "";
		}
		return $"/ui/GameGUIRes/bioEvolutionChallengeModel/humanSkill/{skillInfo.SkillName}";
	}

	public float getWaitProgress()
	{
		SkillInfoData skillInfo = GetSkillInfo(106);
		if (skillInfo == null)
		{
			return 0f;
		}
		int cdTime = skillInfo.CdTime;
		return (float)skillInfo.CurrentCdTime * 1f / (float)cdTime;
	}
}
