public interface IcommonGameUITipsProvider : IModuleProvider
{
	string ShowBackUI();

	string ShowProgressUI();

	float ShowProgress();

	bool IsShow();
}
