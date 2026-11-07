using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.PlayerBag.SwitchWeapon;
using SSJJUserCmd;
using share.constant;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class PlayerSwitchWeaponPredicationSystem : IPredicateSystem
{
	protected readonly WeaponContext WeaponContext;

	private readonly IPredicateSystem _defaultPredicateSystem;

	protected readonly GameRuleContext GameRuleContext;

	public PlayerSwitchWeaponPredicationSystem(Contexts contexts)
	{
		WeaponContext = contexts.weapon;
		GameRuleContext = contexts.gameRule;
		_defaultPredicateSystem = new DefaultSwitchWeaponPredicationSystem(contexts);
	}

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		if (GameRuleContext.currentRule.Rule.CanChangeWeapon() && !PlayerCareerUtil.IsTPS(myPlayer.GetCareer()))
		{
			IPredicateSystem defaultPredicateSystem = _defaultPredicateSystem;
			bool flag = cmd.Weapon != 0 && cmd.Weapon != myPlayer.currentWeapon.Weapon && myPlayer.CanChangeWeapon() && !myPlayer.IsDead();
			if (cmd.Weapon == 6 && myPlayer.currentWeapon.Weapon == 4 && myPlayer.currentWeapon.Index == 1)
			{
				flag = false;
			}
			else if (cmd.Weapon == 7 && myPlayer.currentWeapon.Weapon == 4 && myPlayer.currentWeapon.Index == 2)
			{
				flag = false;
			}
			if (flag)
			{
				defaultPredicateSystem.OnPredicate(myPlayer, cmd);
			}
		}
	}
}
