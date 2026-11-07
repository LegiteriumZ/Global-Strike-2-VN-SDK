public interface IgunFightModelScoreBoardProvider : IModuleProvider
{
	bool SetBlueTeamNum(int index);

	string GetPrediction();

	bool SetRedTeamNum(int index);

	float SetHpNum(int index);

	float SetProgressBar(int index);

	float SetRoundTime();
}
