public interface IbioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider : IModuleProvider
{
	bool isShow();

	string getSkillTypeFUrl();

	bool isBackShow();

	string getSkillTypeFBackUrl();

	string getSkillTypeNoKeyUrl();

	float getWaitProgress();
}
