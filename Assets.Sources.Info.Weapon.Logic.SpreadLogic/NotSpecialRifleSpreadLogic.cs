using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class NotSpecialRifleSpreadLogic : IParamParse, ISpreadLogic
{
	private float DefaultParam { get; set; }

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 1);
		DefaultParam = restlts[0];
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		if (!currentWeapon.special.SpecialMode)
		{
			spread = DefaultParam;
		}
		spread = 0f;
	}
}
