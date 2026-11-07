using System;
using System.Collections.Generic;
using SSJJBase.Manager;

namespace Assets.Sources.Info.SkillProgress;

public class SkillProgressFactory : BattleSingletonInstance<SkillProgressFactory>
{
	public Dictionary<int, ISkillProgressInfo> SkillProgressInfos = new Dictionary<int, ISkillProgressInfo>();

	public ISkillProgressInfo GetInfo(string weaponName, BattleRoomEntity battleRoom)
	{
		foreach (KeyValuePair<int, ISkillProgressInfo> skillProgressInfo in SkillProgressInfos)
		{
			ISkillProgressInfo value = skillProgressInfo.Value;
			if (value.Config.Name.Equals(weaponName, StringComparison.OrdinalIgnoreCase) && value.Visiable.IsModeShow(value.Config, battleRoom))
			{
				return value;
			}
		}
		return null;
	}

	public override void Clear()
	{
		SkillProgressInfos.Clear();
	}
}
