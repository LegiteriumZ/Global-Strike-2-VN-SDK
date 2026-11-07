namespace Assets.Sources.Info.GameRule;

public class RpgGuozhan2GameRule : RpgGameRule
{
	public RpgGuozhan2GameRule()
	{
		Relive = true;
	}

	public override bool IsShowGateUnderAttack()
	{
		return false;
	}
}
