using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using NotifyEvent;

namespace Assets.Sources.Modules.GameRule.Common;

public class AchievementSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private GameRuleContext _gameRuleContext;

	private TimeComponent _timeComponent;

	public AchievementSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		List<AchievementComponent.AchievementInfo> achievements = _gameRuleContext.achievement.Achievements;
		bool flag = false;
		for (int num = achievements.Count - 1; num >= 0; num--)
		{
			achievements[num].RemainTime -= _timeComponent.FrameInterval;
			if (achievements[num].RemainTime <= 0)
			{
				achievements.RemoveAt(num);
				flag = true;
			}
		}
		if (flag)
		{
			NotifyManager.ForceInvoke(47);
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return true;
	}
}
