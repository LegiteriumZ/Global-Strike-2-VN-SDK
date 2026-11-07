public class HighSpeedGroupModelExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/highSpeedGroupModel";
		Providers.Add(new highSpeedGroupModelHighSpeedGroupSkillProvider(contexts));
	}
}
