using Assets.Sources.Info.Weapon.WeaponCom.WeaponMap;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GuarddianStickFrame : IFrameCmdAction, ICmdAction
{
	private readonly GuardStickWeaponMap _guardStickWeaponMap;

	public GuarddianStickFrame(Contexts contexts)
	{
		_guardStickWeaponMap = new GuardStickWeaponMap(contexts);
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		_guardStickWeaponMap.WeaponLogic(ref arg);
		return true;
	}
}
