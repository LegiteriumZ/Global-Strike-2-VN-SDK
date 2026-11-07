using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Components.Weapon;
using Assets.Sources.Info.Weapon.Attach;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class HeroBladeMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int SpecialSpeed;

	internal int Speed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		int index = 2;
		if ((currentWeapon.GetComponent(index) as AttachComponent).Data is HeroBladeAttach { swordPatternType: 1 })
		{
			return SpecialSpeed;
		}
		return Speed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		SpecialSpeed = restlts[0];
		Speed = restlts[1];
	}
}
