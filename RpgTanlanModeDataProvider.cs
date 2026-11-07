public class RpgTanlanModeDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpgtanlanmodel";
		Providers.Add(new rpgTanlanModelRpgTanlanProgressUIProvider(contexts));
		Providers.Add(new rpgTanlanModelRpgTanlanTargetUIProvider(contexts));
	}
}
