namespace Assets.Sources.Info.GameRule;

public class FlyKnifeGameRule : DefaultGameRule
{
	public override int GetTipsIndex()
	{
		return 34;
	}

	public override bool IsShowKiller()
	{
		return true;
	}
}
