public interface IAllRoundSinglesModelbattletipProvider : IModuleProvider
{
	bool IsShowCountDown();

	float SetCountDown();

	bool IsShowLoseHp();

	bool IsShowWait();
}
