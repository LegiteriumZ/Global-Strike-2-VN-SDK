using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class VoidLinkSpreadLogic : ISpreadLogic, IParamParse
{
	internal float VoidLinkDefault { get; set; }

	internal float VoidLinkSpecial { get; set; }

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 2);
		VoidLinkDefault = restlts[0];
		VoidLinkSpecial = restlts[1];
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float num = (((currentWeapon.basicInfo.Data.EffectLevel & 8) > 0 || player.OnGround() || isWeightlessness) ? VoidLinkSpecial : VoidLinkDefault);
		spread = num * currentWeapon.accuracy.Accuracy;
	}
}
