public class RpgHolidayModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/rpgholidaymodel";
		Providers.Add(new rpgHolidayModelskillProvider(contexts));
	}
}
