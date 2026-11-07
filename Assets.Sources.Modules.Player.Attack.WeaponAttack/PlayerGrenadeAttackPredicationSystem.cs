using Assets.Sources.Framework;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class PlayerGrenadeAttackPredicationSystem : IPredicateSystem
{
	private readonly WeaponContext _weaponContext;

	public PlayerGrenadeAttackPredicationSystem(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
	}

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		PredictCmdOnWeapon(myPlayer, cmd);
	}

	private void PredictCmdOnWeapon(PlayerEntity player, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			int clientTime = player.clientTime.ClientTime;
			if (cmd.IsAttackOn && WeaponUtility.CanFire(currentWeaponEntity, clientTime))
			{
				currentWeaponEntity.attack.ShotsFired = 1;
				PlayerAnimationUtility.SetViewAnimation(player, 21);
			}
			if (!cmd.IsAttackOn && currentWeaponEntity.attack.ShotsFired == 1)
			{
				currentWeaponEntity.attack.ShotsFired = 0;
				WeaponUtility.DescClip(currentWeaponEntity);
				currentWeaponEntity.attack.NextAttackTimer = (uint)(clientTime + currentWeaponEntity.basicInfo.Info.AttackInterval);
				PlayerAnimationUtility.SetViewAnimation(player, 23);
			}
			else if (cmd.IsSecondaryAttackOn)
			{
				WeaponUtility.CanSecondaryFire(currentWeaponEntity, clientTime);
			}
		}
	}
}
