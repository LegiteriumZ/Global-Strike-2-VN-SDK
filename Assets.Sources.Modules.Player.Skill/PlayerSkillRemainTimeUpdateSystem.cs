using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Entitas;
using NetData;

namespace Assets.Sources.Modules.Player.Skill;

public class PlayerSkillRemainTimeUpdateSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _group;

	private PlayerContext _playerContext;

	private GameRuleContext _gameRuleContext;

	private TimeComponent _time;

	public PlayerSkillRemainTimeUpdateSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Skill));
		_playerContext = contexts.player;
		_gameRuleContext = contexts.gameRule;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		UpdateSkillCd();
		UpdateStateCd();
	}

	private void UpdateStateCd()
	{
		foreach (PlayerEntity item in _group)
		{
			PlayerInfoData playerInfo = item.GetPlayerInfo();
			if (playerInfo.TheGripOfDeath)
			{
				playerInfo.TheGripOfDeathTime -= _time.FrameInterval;
				if (playerInfo.TheGripOfDeathTime <= 0)
				{
					playerInfo.TheGripOfDeath = false;
					playerInfo.TheGripOfDeathTime = 0;
				}
			}
			if (playerInfo.ObtainsuppliesTime > 0)
			{
				playerInfo.ObtainsuppliesTime -= _time.FrameInterval;
				if (playerInfo.ObtainsuppliesTime <= 0)
				{
					playerInfo.Obtainsupplies = false;
					playerInfo.ObtainsuppliesTime = 0;
				}
			}
		}
	}

	private void UpdateSkillCd()
	{
		if (!_playerContext.isMyPlayer)
		{
			return;
		}
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		foreach (KeyValuePair<int, SkillInfoData> skill in myPlayerEntity.skill.Skills)
		{
			SkillInfoData value = skill.Value;
			if (value.CurrentCdTime > 0)
			{
				value.CurrentCdTime -= _time.FrameInterval;
			}
			if (PlayerCareerConstantUtility.IsDoun(myPlayerEntity.GetCareer()) && myPlayerEntity.IsDead() && _gameRuleContext.currentRule.Rule.IsRefreshSkillCdWhenDounDead() && !RuleUtilty.IsBio3Mode(UiIEventCondition.Get_uiRoomData_RaceType()))
			{
				value.CurrentCdTime = 0;
			}
		}
	}
}
