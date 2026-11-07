namespace Assets.Sources.Info.GameRule;

public class RpgTeamRaceGameRule : RpgGameRule
{
	public RpgTeamRaceGameRule()
	{
		ShowTargetHp = true;
	}

	public override bool IsHideSkillWhenHidePlayer()
	{
		return true;
	}

	public override bool CanChangeWeapon()
	{
		return false;
	}

	public override bool IsShowEnemyHpBar()
	{
		return true;
	}
}
