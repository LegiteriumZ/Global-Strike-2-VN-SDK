public interface IbigheadModelHeroSelectProvider : IModuleProvider
{
	bool NoHero(int index);

	string SetHero(int index);

	bool SeleHero(int index);

	bool IsShow();

	float Select1();

	float Select2();

	float Select3();

	float HideUI();

	string GetTimeout();
}
