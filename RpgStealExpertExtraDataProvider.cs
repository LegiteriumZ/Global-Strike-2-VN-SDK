public class RpgStealExpertExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpgstralexpertmodel";
		Providers.Add(new rpgStralExpertModelRpgStralExpertMaterialProvider(contexts));
		Providers.Add(new rpgStralExpertModelRpgStralExpertMessageProvider(contexts));
		Providers.Add(new rpgStralExpertModelRpgStralExpertSelfTeamProvider(contexts));
	}
}
