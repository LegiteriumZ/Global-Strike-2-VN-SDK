using Assets.Sources.Constant.Career;

namespace Assets.Sources.Info.GameRule;

public class RpgSurvivalPvpGameRule : RpgGameRule
{
	public RpgSurvivalPvpGameRule()
	{
		LockWeaponTips = false;
		ShowTargetHp = true;
	}

	public override bool CanRelive()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			return !PlayerCareerConstantUtility.IsHumanity(myPlayerEntity.GetCareer());
		}
		return false;
	}

	public override bool GetLockWeapon()
	{
		return Contexts.sharedInstance.player.myPlayerEntity.GetTeam() == 100;
	}
}
