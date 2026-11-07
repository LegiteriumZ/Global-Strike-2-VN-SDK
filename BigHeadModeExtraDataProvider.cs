public class BigHeadModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/bigheadmodel";
		Providers.Add(new bigheadModelshadowDemonSkillProvider(contexts));
		Providers.Add(new bigheadModelHeroSelectProvider(contexts));
		Providers.Add(new bigheadModelHeroSkillProvider(contexts));
	}
}
