using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class PhotonPistolCombinationPredicationSystem : AbstractAttackPredicationSystem
{
	public class PhotonPistolCombinationRightAction : IRightCmdAction, ICmdAction
	{
		public PhotonPistolCombinationRightAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			return false;
		}
	}

	public PhotonPistolCombinationPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RifleLeftAction(contexts));
		RightActions.Add(new PhotonPistolCombinationRightAction(contexts));
	}
}
