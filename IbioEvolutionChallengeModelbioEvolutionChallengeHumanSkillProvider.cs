public interface IbioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider : IModuleProvider
{
	bool isShow();

	bool isBackShow();

	string getSkillTypeFBackUrl();

	bool isShowSkillTypeF();

	string getSkillTypeFUrl();

	bool isShowSkillTypeNoKey();

	string getSkillTypeNoKeyUrl();

	float getWaitProgress();
}
