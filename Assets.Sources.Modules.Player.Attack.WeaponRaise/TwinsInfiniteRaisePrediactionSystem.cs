using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class TwinsInfiniteRaisePrediactionSystem : AbstractRaisePredicactionSystem
{
	public TwinsInfiniteRaisePrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if (!TwinsInfinitePredicationSystem.isLeftAttack(currentWeapon))
		{
			return 16;
		}
		return 47;
	}

	protected override void RaiseAction(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		base.RaiseAction(player, currentWeapon, lastWeapon, cmd);
		TwinsInfinitePredicationSystem.setMeleeStartAttack(currentWeapon, meleeStartAttack: true);
	}
}
