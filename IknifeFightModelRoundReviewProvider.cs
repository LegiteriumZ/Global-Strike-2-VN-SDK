public interface IknifeFightModelRoundReviewProvider : IModuleProvider
{
	bool IsShow();

	string SetMessage();

	float SetScore(int index);
}
