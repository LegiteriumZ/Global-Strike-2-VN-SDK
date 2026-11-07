public class RpgModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpgmodel";
		Providers.Add(new rpgModelrpgplayerbufferProvider(contexts));
		Providers.Add(new rpgModelSkatingMechaModelProvider(contexts));
		Providers.Add(new rpgModelSkatingMechaModelInfoProvider(contexts));
		Providers.Add(new rpgModelBlackScreenProvider(contexts));
		Providers.Add(new rpgModelRpgBuffsProvider(contexts));
		Providers.Add(new rpgModelGameUITipsTimeProvider(contexts));
		Providers.Add(new rpgModelNezhaNengliangProvider(contexts));
		Providers.Add(new rpgModelrpglongqibingbufferProvider(contexts));
		Providers.Add(new rpgModelBossDescribeProvider(contexts));
		Providers.Add(new rpgModelextraordinaryProvider(contexts));
		Providers.Add(new rpgModelETPowerProvider(contexts));
	}
}
