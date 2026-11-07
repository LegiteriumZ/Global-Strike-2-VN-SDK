namespace Assets.Sources.Info.GameRule;

public class Biochemical3GameRule : BiochemicalGameRule
{
	public override bool IsShowLowHp(string career, long hp)
	{
		return false;
	}
}
