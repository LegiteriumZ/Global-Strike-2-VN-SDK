namespace Assets.Sources.Constant;

public class AchievementTypeConstant
{
	public const int PveKnifeKillPaoxiao = 1;

	public const int PveDoubleKill = 2;

	public const int PveTenKill = 4;

	public const int PveHeadKillMeiyin = 5;

	public const int PveSnipeKill = 11;

	public const int PveShotgunKill = 12;

	public const int PveRifleKill = 13;

	public const int PveSubmachinerifeKill = 14;

	public const int PveMachinegunKill = 15;

	public const int PveKnifeKill = 16;

	public const int PveHandgunKill = 17;

	public const int PveGrenadeKill = 18;

	public const int PveKillboss = 21;

	public const int PveMaxKillStreak = 34;

	public const int PveAssistKill = 35;

	public const int PveKillerBane = 101;

	public const int PveKeyMan = 102;

	public const int PveRunItsCourse = 103;

	public const int PveCollectingMania = 104;

	public const int PveStrikeKill = 105;

	public const int PveBeInGraveDanger = 106;

	public const int PveMaoxiaoLKill = 131;

	public const int PveMutantMeiyinKill = 132;

	public const int PveMutantGatlingKill = 133;

	public const int PveKillFiveDoun = 1001;

	public const int PveHeadkillOneDoun = 1002;

	public const int PveStuidOneSkill = 1003;

	public const int PveAttackDoun = 1004;

	public static bool IsLimitedTimeReward(int achievementType)
	{
		if (achievementType == 1001 || achievementType == 1002 || achievementType == 1003 || achievementType == 1004)
		{
			return true;
		}
		return false;
	}
}
