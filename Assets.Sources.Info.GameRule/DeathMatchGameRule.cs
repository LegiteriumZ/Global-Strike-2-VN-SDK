namespace Assets.Sources.Info.GameRule;

public class DeathMatchGameRule : DefaultGameRule
{
	public override int GetNotMoveTime()
	{
		return 3000;
	}

	public override bool IsShowKiller()
	{
		return true;
	}
}
