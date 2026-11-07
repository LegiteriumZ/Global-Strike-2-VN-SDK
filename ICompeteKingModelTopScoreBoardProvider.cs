public interface ICompeteKingModelTopScoreBoardProvider : IModuleProvider
{
	bool SetTeamNumber(int index);

	float SetRoundTime();

	float SetProgressBar(int index);
}
