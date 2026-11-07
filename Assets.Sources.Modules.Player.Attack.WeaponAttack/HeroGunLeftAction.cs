using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HeroGunLeftAction : RifleLeftAction
{
	public HeroGunLeftAction(Contexts contexts)
		: base(contexts)
	{
		GunFireCell.HitWorlds.Reset();
		GunFireCell.Hitplayers.Reset();
		OnFireFunc.Reset();
		AddFire(FireUtility.FireNextAttack);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}
}
