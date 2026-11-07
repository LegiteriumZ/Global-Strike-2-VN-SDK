using System.Collections.Generic;
using Assets.Sources.Components.GameRule.RpgBaseRun;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgBaseRunChallengeHandler : ApcPacketHandler<ChallengeMessageData>
{
	private RpgBaseRunChallengeComponent challengeCom;

	public RpgBaseRunChallengeHandler(Contexts contexts)
	{
		challengeCom = contexts.gameRule.rpgBaseRunChallenge;
	}

	public override int MethodId()
	{
		return 620;
	}

	public override void Handle(ChallengeMessageData data)
	{
		if (challengeCom.TaskList == null)
		{
			challengeCom.TaskList = new List<ChallengeMessageCellData>();
		}
		for (int i = 0; i < data.UpdateCellList.Count; i++)
		{
			ChallengeMessageCellData challengeMessageCellData = data.UpdateCellList[i];
			bool flag = false;
			for (int j = 0; j < challengeCom.TaskList.Count; j++)
			{
				if (challengeCom.TaskList[j].Id == challengeMessageCellData.Id)
				{
					flag = true;
					challengeCom.TaskList[j] = challengeMessageCellData;
					break;
				}
			}
			if (!flag)
			{
				challengeCom.TaskList.Add(challengeMessageCellData);
			}
		}
		challengeCom.IsUpdate = true;
		int num = 0;
		int num2 = data.ExtraAddValue;
		int num3 = 1;
		for (int k = 0; k < challengeCom.TaskList.Count; k++)
		{
			ChallengeMessageCellData challengeMessageCellData2 = challengeCom.TaskList[k];
			bool flag2 = challengeMessageCellData2.AddValue > 0;
			int num4 = (flag2 ? challengeMessageCellData2.AddValue : challengeMessageCellData2.MulValue);
			if (challengeMessageCellData2.IsFinish)
			{
				if (flag2)
				{
					num2 += num4;
				}
				else
				{
					num3 *= num4;
				}
			}
		}
		num = num2 * num3;
		challengeCom.TotalRewardNum = num;
		challengeCom.AddRewardNum = num2;
		challengeCom.MulRewardNum = num3;
		challengeCom.PveLevelRage = data.PveLevelRage;
		challengeCom.RewardLvlNum = data.ExChangeLv;
	}
}
