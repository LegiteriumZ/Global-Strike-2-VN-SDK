public interface IcommonStateProgressProvider : IModuleProvider
{
	string SetDes();

	string SetPlayerName();

	float GetProgresPercent();

	float GetShinePos();

	bool IsProgressShow();
}
