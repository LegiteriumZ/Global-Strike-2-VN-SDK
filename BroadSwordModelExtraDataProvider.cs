public class BroadSwordModelExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/broadswordmodel";
		Providers.Add(new BroadSwordModelPowerProvider(contexts));
		Providers.Add(new BroadSwordModelmessageProvider(contexts));
	}
}
