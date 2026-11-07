using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class SwordHeavenJudgeMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int SpecialSpeed1;

	internal int SpecialSpeed2;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		int num = ((currentWeapon.power.Power2 != 0) ? SpecialSpeed2 : SpecialSpeed1);
		if (currentWeapon.special.SpecialMode && currentWeapon.clip.CarryClip2 == 2000)
		{
			num = (int)((float)num * (1f - (float)(player.clientTime.ClientTime - (currentWeapon.power.RpgMaxPower - 2000)) / 200f * 0.05f));
			if (num < 0)
			{
				num = 0;
			}
		}
		return num;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		SpecialSpeed1 = restlts[0];
		SpecialSpeed2 = restlts[1];
	}
}
