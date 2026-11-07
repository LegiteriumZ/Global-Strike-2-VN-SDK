public interface IbladeStrongholdNewModelstateProvider : IModuleProvider
{
	bool showTime(int index);

	float showclock(int index);

	float updateTeamNum1();

	float updateTeamNum2();

	float updateCtScore();

	float updateTeamProgress1();

	float updateTeamProgress2();

	float updateTScore();

	bool showhong();

	float getProgress1();

	bool showlan();

	float getProgress2();

	float updateWinScore();
}
