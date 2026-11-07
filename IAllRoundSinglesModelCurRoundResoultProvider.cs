public interface IAllRoundSinglesModelCurRoundResoultProvider : IModuleProvider
{
	float SetCampCTWinCount();

	float SetCampTWinCount();

	string GetWinScoreUrl();

	bool IsShow();

	bool IsWin();
}
