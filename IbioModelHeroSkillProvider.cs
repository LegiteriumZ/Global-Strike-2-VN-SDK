public interface IbioModelHeroSkillProvider : IModuleProvider
{
	bool IsHero();

	bool Exists(int index);

	bool GetSkill(int index);

	string SetSkillIcon(int index);

	float GetSkillTime(int index);
}
