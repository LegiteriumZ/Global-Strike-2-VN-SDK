public interface IBroadSwordModelmessageProvider : IModuleProvider
{
	bool IsEShow();

	bool IsFinalComingShow();

	bool IsLevelUpShow();

	bool IsStrengthenShow();

	bool IsFinalComingCalShow();

	bool IsWaitPlayerShow();

	float GetFinalComingTime();

	float GetWaitPlayerCount();
}
