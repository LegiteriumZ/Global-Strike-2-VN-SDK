public class BladeStrongholdNewModelExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/bladestrongholdnewmodel";
		Providers.Add(new bladeStrongholdNewModelMessageUIProvider(contexts));
		Providers.Add(new bladeStrongholdNewModelstateProvider(contexts));
	}
}
