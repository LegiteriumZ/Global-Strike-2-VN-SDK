public interface ICompeteKingModelRoundReviewProvider : IModuleProvider
{
	string SetMessage();

	string SetFlag(int index);

	float SetScore(int index);

	bool IsShow();
}
