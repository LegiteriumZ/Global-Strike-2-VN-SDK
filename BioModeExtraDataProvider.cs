public class BioModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/biomodel";
		Providers.Add(new bioModelshadowDemonSkillProvider(contexts));
		Providers.Add(new bioModelHeroSelectProvider(contexts));
		Providers.Add(new bioModelHeroSkillProvider(contexts));
		Providers.Add(new bioModelMaolinProgressProvider(contexts));
	}
}
