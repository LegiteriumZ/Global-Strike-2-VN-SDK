public interface IgoldRankModelRoundReviewProvider : IModuleProvider
{
	bool IsShow();

	string SetMessage();

	float SetScore(int index);
}
