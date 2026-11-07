public class RpgLootMineModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpglootminemodel";
		Providers.Add(new rpgLootMineModelRpgLootMineMessageProvider(contexts));
	}
}
