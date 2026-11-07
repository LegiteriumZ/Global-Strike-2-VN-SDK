public class BioUnionBaseDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/biounionbase";
		Providers.Add(new bioUnionBaseSelectPlayerUIProvider(contexts));
		Providers.Add(new bioUnionBaseSelectTeamUIProvider(contexts));
		Providers.Add(new bioUnionBaseSoulUIProvider(contexts));
		Providers.Add(new bioUnionBaseWaitPlayerUIProvider(contexts));
	}
}
