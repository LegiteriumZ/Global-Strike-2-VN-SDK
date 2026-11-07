public interface IknifeFightModelRoundScoreBoardProvider : IModuleProvider
{
	bool SetBlueScoreShow(int index);

	bool SetRedScore(int index);

	float SetRoundScore(int index);
}
