public interface IcommonKickVoteUIProvider : IModuleProvider
{
	string GetAgree();

	bool isResult();

	string GetName();

	string GetReason();

	string GetRejest();

	bool KickVoteShow();

	float Agree();

	float Disagree();

	string getTimerText();
}
