using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Info.Weapon.Attach;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class ReadyMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int SpecialSpeed;

	internal int Speed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon.hasAttach && currentWeapon.attach.Data is GatlingAttach && (currentWeapon.attach.Data as GatlingAttach).State.Equals(GatlingState.Ready))
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
