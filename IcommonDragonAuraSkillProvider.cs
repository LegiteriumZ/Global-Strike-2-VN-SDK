public interface IcommonDragonAuraSkillProvider : IModuleProvider
{
	float GetPercentage();

	float GetProgress();

	bool ShowUI();

	float GetAlpha(int index);
}
