public class rpgDanrenMineModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpgdanrenminemodel";
		Providers.Add(new rpgDanrenMineModelDamageCountProvider(contexts));
	}
}
