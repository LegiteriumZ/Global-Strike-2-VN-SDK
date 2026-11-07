using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;
using share.constant;

public class bigheadModelHeroSkillProvider : IbigheadModelHeroSkillProvider, IModuleProvider
{
	public bigheadModelHeroSkillProvider(Contexts contexts)
	{
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool IsHero()
	{
		if (PlayerCareerUtil.IsHumanHero(UiIEventCondition.Get_uiMyPlayer_Career()))
		{
			return true;
		}
		return false;
	}

	public bool Exists(int index)
	{
		return GetSkillName(index) != 0;
	}

	public bool GetSkill(int index)
	{
		index %= 3;
		if (GetSkillName(index) != 0)
		{
			return true;
		}
		return false;
	}

	public string SetSkillIcon(int index)
	{
		string text;
		if (index < 3)
		{
			int skillName = GetSkillName(index);
			if (skillName != 0)
			{
				text = "/ui/GameGUIRes/halfLoadedRes/HeroSkill/" + skillName;
				if (GetSkillTime(index) < 1f)
				{
					text += "_black";
				}
				return text;
			}
			return "";
		}
		text = "/ui/GameGUIRes/halfLoadedRes/HeroSkill/key" + (index - 2);
		if (GetSkillTime(index - 3) < 1f)
		{
			text += "_black";
		}
		return text;
	}

	public float GetSkillTime(int index)
	{
		int skillKey = GetSkillKey(index);
		Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
		if (uiSkill_Skills != null)
		{
			if (!uiSkill_Skills.ContainsKey(skillKey))
			{
				return 1f;
			}
			if (uiSkill_Skills[skillKey] != null && uiSkill_Skills[skillKey].CurrentCdTime > 0 && uiSkill_Skills[skillKey].CurrentCdTime <= uiSkill_Skills[skillKey].CdTime)
			{
				return 1f - (float)uiSkill_Skills[skillKey].CurrentCdTime / (float)uiSkill_Skills[skillKey].CdTime;
			}
		}
		return 1f;
	}

	private int GetSkillName(int index)
	{
		int result = 0;
		int skillKey = GetSkillKey(index);
		if (index < 3)
		{
			Dictionary<int, SkillInfoData> uiSkill_Skills = UiIEventCondition.Get_uiSkill_Skills();
			if (uiSkill_Skills != null && uiSkill_Skills.ContainsKey(skillKey))
			{
				result = uiSkill_Skills[skillKey].SkillName;
			}
		}
		return result;
	}

	private int GetSkillKey(int index)
	{
		int result = 0;
		switch (index)
		{
		case 0:
			result = 11;
			break;
		case 1:
			result = 105;
			break;
		case 2:
			result = 136;
			break;
		}
		return result;
	}
}
