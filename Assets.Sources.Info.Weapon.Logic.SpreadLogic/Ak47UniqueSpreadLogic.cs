using System;
using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Utils.Player;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class Ak47UniqueSpreadLogic : ISpreadLogic, IParamParse
{
	private class Ak47UniqueNormalSpreadLogic : ISpreadLogic, IParamParse
	{
		private float airSpread;

		private float moveSpread;

		private float defaultSpread;

		private float duckSpread;

		public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
		{
			if (!isAccuracyActive(currentWeapon) && !player.OnGround() && !isWeightlessness)
			{
				spread = airSpread * currentWeapon.accuracy.Accuracy;
			}
			else if (!isAccuracyActive(currentWeapon) && PlayerUtility.PlayerLength2D(player) > 350f)
			{
				spread = moveSpread * currentWeapon.accuracy.Accuracy;
			}
			else if (player.DuckState() == 0)
			{
				spread = duckSpread * currentWeapon.accuracy.Accuracy;
			}
			else
			{
				spread = defaultSpread * currentWeapon.accuracy.Accuracy;
			}
		}

		private bool isAccuracyActive(WeaponEntity currentWeapon)
		{
			return (currentWeapon.special.EffectLevel & G18UniqueSpreadLogic.AK47_ACCURACY_FLAG) > 0;
		}

		public void Parse(string param)
		{
			ParamParseHelp.ParseFloat(out var restlts, param, 4);
			airSpread = restlts[0];
			moveSpread = restlts[1];
			duckSpread = restlts[2];
			defaultSpread = restlts[3];
		}
	}

	private readonly G18UniqueSpreadLogic specail = new G18UniqueSpreadLogic();

	private readonly Ak47UniqueNormalSpreadLogic normal = new Ak47UniqueNormalSpreadLogic();

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		if (currentWeapon.special.SpecialMode)
		{
			specail.BeforeFire(out spread, player, currentWeapon, cmd, isWeightlessness);
		}
		else
		{
			normal.BeforeFire(out spread, player, currentWeapon, cmd, isWeightlessness);
		}
	}

	public void Parse(string param)
	{
		string[] array = param.Split(',');
		if (array.Length != 8)
		{
			throw new Exception($"param error:{param}");
		}
		normal.Parse($"{array[0]},{array[1]},{array[2]},{array[3]}");
		specail.Parse($"{array[4]},{array[5]},{array[6]},{array[7]}");
	}
}
