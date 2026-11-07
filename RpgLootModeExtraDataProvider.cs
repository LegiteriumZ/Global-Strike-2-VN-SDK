public class RpgLootModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpglootmodel";
		Providers.Add(new rpgLootModelPlayerGetFlagProvider(contexts));
		Providers.Add(new rpgLootModelMessageProvider(contexts));
	}
}
