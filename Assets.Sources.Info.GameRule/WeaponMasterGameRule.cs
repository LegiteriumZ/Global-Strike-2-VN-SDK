namespace Assets.Sources.Info.GameRule;

public class WeaponMasterGameRule : DefaultGameRule
{
	public override int GetNotMoveTime()
	{
		return 5000;
	}

	public override bool IsShowKiller()
	{
		return true;
	}
}
