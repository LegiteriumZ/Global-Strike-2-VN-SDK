using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class ArcElectricShotgunSpreadLogic : ISpreadLogic, IParamParse
{
	internal float DefaultParam { get; set; }

	internal float AirParam { get; set; }

	public void Parse(string param)
	{
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float num = 0.06f;
		if (currentWeapon.power.RpgMaxPower > 0 && currentWeapon.basicInfo.Data.WeaponFlag != 1)
		{
			num *= 1f + 0.12f * (float)currentWeapon.power.RpgMaxPower;
		}
		spread = num;
	}
}
