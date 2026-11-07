namespace Assets.Sources.Info.GameRule;

public class RpgZhouNianQingGameRule : RpgGameRule
{
	public RpgZhouNianQingGameRule()
	{
		Relive = true;
	}

	public override bool IsShowGateUnderAttack()
	{
		return false;
	}
}
