public class BioEvolutionModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/bioevolutionmodel";
		Providers.Add(new bioEvolutionModelBioEvolutionDamageBufferProvider(contexts));
	}
}
