public class RpgSplitSecondModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpgsplitsecond";
		Providers.Add(new rpgSplitSecondariverPointProvider(contexts));
		Providers.Add(new rpgSplitSecondmessageProvider(contexts));
	}
}
