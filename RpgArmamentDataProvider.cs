public class RpgArmamentDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpgarmamentmodel";
		Providers.Add(new rpgArmamentModelRpgArmamentMessageProvider(contexts));
		Providers.Add(new rpgArmamentModelRpgArmamentMyPointProvider(contexts));
	}
}
