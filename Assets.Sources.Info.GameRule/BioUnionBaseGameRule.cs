namespace Assets.Sources.Info.GameRule;

public class BioUnionBaseGameRule : DefaultGameRule
{
	public override bool CanShowAddHpCross()
	{
		return true;
	}

	public override bool IsShowKiller()
	{
		return true;
	}

	public override bool IsShowEnemyHpBar()
	{
		return true;
	}

	public override int GetTipsIndex()
	{
		return 36;
	}
}
