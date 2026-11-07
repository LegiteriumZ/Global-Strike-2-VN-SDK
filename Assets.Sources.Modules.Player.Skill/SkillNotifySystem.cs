using System.Collections.Generic;
using Assets.Sources.Framework;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Skill;

public class SkillNotifySystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private Dictionary<int, int> _uiSkills = new Dictionary<int, int>();

	public SkillNotifySystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnPlayback()
	{
		if (!_playerContext.isCameraOwner)
		{
			return;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (!cameraOwnerEntity.hasSkill || cameraOwnerEntity.skill.Skills == null)
		{
			return;
		}
		bool flag = cameraOwnerEntity.skill.Skills.Count != _uiSkills.Count;
		foreach (KeyValuePair<int, SkillInfoData> skill in cameraOwnerEntity.skill.Skills)
		{
			if (!_uiSkills.ContainsKey(skill.Key) || _uiSkills[skill.Key] != skill.Value.SkillName)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		_uiSkills.Clear();
		foreach (KeyValuePair<int, SkillInfoData> skill2 in cameraOwnerEntity.skill.Skills)
		{
			_uiSkills[skill2.Key] = skill2.Value.SkillName;
		}
		NotifyManager.ForceInvoke(12);
	}
}
