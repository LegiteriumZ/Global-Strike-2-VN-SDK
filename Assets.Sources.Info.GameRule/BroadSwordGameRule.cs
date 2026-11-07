namespace Assets.Sources.Info.GameRule;

public class BroadSwordGameRule : DeathMatchGameRule
{
	public override bool CanRelive()
	{
		return true;
	}
}
