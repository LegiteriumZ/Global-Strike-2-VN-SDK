using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleShotGunLeftAction : ShotGuntLeftAction
{
	public DoubleShotGunLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddFire(FireUtility.LeftFireQkhhAfterFire);
	}
}
