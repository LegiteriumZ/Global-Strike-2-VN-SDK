public class MechKingModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/mechkingmodel";
		Providers.Add(new mechKingModelmechKingSkillProvider(contexts));
		Providers.Add(new MechKingModelmechKingMessageProvider(contexts));
		Providers.Add(new mechKingModelmechKingPromptProvider(contexts));
		Providers.Add(new mechKingModelReliveProcessProvider(contexts));
	}
}
