using System.Collections.Generic;
using Assets.Sources.Components.Time;

public class rpgHolidayModelskillProvider : IrpgHolidayModelskillProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	private List<int> ActiveSkillTypeList = new List<int> { 120, 125, 126, 102 };

	private List<int> skillNameList = new List<int>();

	private List<int> skillNumList = new List<int>();

	private List<int> skillKeyList = new List<int>();

	public rpgHolidayModelskillProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public string changeImage(int index)
	{
		int skillName = getSkillName(index);
		if (skillName > 0)
		{
			int num = 0;
			if (index < skillNumList.Count)
			{
				num = skillNumList[index];
			}
			string arg = ((num > 0) ? ("activeBg_" + skillName) : ("unactiveBg_" + skillName));
			return $"/ui/GameGUIRes/rpgHolidayModel/skill/{arg}";
		}
		return "";
	}

	public bool isShowSkill(int index)
	{
		if (getSkillName(index) > 0)
		{
			return true;
		}
		return false;
	}

	public float showNum(int index)
	{
		if (index < skillNumList.Count)
		{
			return skillNumList[index];
		}
		return 0f;
	}

	private int getSkillName(int index)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.hasSkill && cameraOwnerEntity.skill.Skills != null)
		{
			for (int i = 0; i < ActiveSkillTypeList.Count; i++)
			{
				cameraOwnerEntity.skill.Skills.TryGetValue(ActiveSkillTypeList[i], out var value);
				if (value != null && value.Kind == 8)
				{
					int num = skillKeyList.IndexOf(ActiveSkillTypeList[i]);
					if (num == -1)
					{
						skillKeyList.Add(ActiveSkillTypeList[i]);
						skillNameList.Add(value.SkillName);
						skillNumList.Add(value.Mp);
					}
					else
					{
						skillNameList[num] = value.SkillName;
						skillNumList[num] = value.Mp;
					}
				}
			}
		}
		if (index < skillNameList.Count)
		{
			return skillNameList[index];
		}
		return 0;
	}
}
