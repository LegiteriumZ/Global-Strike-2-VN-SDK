using System;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Constant;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AchievementHandler : ApcPacketHandler<AchievementData>
{
	private GameRuleContext _gameRuleContext;

	private readonly Comparison<AchievementComponent.AchievementInfo> _comparison;

	public AchievementHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_comparison = AchievementsSortComparison;
	}

	public override int MethodId()
	{
		return 72;
	}

	public override void Handle(AchievementData data)
	{
		AchievementComponent.AchievementInfo achievementInfo = AchievementComponent.AchievementInfo.FindAchievement(_gameRuleContext.achievement.Achievements, data.Type);
		if (achievementInfo == null)
		{
			achievementInfo = new AchievementComponent.AchievementInfo();
			achievementInfo.AchievementType = data.Type;
			_gameRuleContext.achievement.Achievements.Add(achievementInfo);
		}
		achievementInfo.CurrentProgress = data.Now;
		achievementInfo.TotalProgress = data.Max;
		if (AchievementTypeConstant.IsLimitedTimeReward(achievementInfo.AchievementType))
		{
			achievementInfo.IsLimitedTimeReward = true;
			if (achievementInfo.CurrentProgress == achievementInfo.TotalProgress)
			{
				achievementInfo.RemainTime = 3000;
			}
			else
			{
				achievementInfo.RemainTime = 45000;
			}
		}
		else
		{
			achievementInfo.IsLimitedTimeReward = false;
			achievementInfo.RemainTime = 3000;
		}
		_gameRuleContext.achievement.Achievements.Sort(_comparison);
		if (data.Now == 0)
		{
			_gameRuleContext.pveIncentiveTypeView.AchievementType = data.Type;
			IntData intData = new IntData();
			intData.Data = data.Type;
			_gameRuleContext.pveIncentiveView.IncentiveData = intData;
			_gameRuleContext.pveIncentiveView.Dirty = true;
		}
		NotifyManager.ForceInvoke(47);
	}

	private int AchievementsSortComparison(AchievementComponent.AchievementInfo a, AchievementComponent.AchievementInfo b)
	{
		if (a.IsLimitedTimeReward)
		{
			return -1;
		}
		if (b.IsLimitedTimeReward)
		{
			return 1;
		}
		float num = (float)a.CurrentProgress / (float)a.TotalProgress;
		float num2 = (float)b.CurrentProgress / (float)b.TotalProgress;
		if (num < num2)
		{
			return 1;
		}
		if (num == num2)
		{
			return 0;
		}
		return -1;
	}
}
