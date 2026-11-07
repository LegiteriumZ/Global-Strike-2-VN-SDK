public interface IgunFightModelRoundReviewProvider : IModuleProvider
{
	bool IsShow();

	string SetMessage();

	float SetScore(int index);
}
