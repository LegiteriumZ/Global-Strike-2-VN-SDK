namespace Assets.Sources.Info.GameRule;

public class FinalBioGameRule : BiochemicalGameRule
{
	public override int GetUltimateTime()
	{
		return 45000;
	}

	public override int GetTipsIndex()
	{
		return 6;
	}
}
