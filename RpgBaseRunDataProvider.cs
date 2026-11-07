public class RpgBaseRunDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpgbaserunmodel";
		Providers.Add(new rpgBaseRunModelRpgBaseRunProgressUIProvider(contexts));
		Providers.Add(new rpgBaseRunModelRpgBaseRunTaskUIProvider(contexts));
	}
}
