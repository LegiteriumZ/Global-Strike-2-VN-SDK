namespace Assets.Sources.Info.GameRule;

public class FinalBio3GameRule : FinalBioGameRule
{
	public override bool IsShowLowHp(string career, long hp)
	{
		return false;
	}
}
