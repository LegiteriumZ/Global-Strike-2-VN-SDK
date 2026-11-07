using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Utils.Player;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class G18UniqueSpreadLogic : ISpreadLogic, IParamParse
{
	public static readonly int G18_ACCURACY_FLAG = 2048;

	public static readonly int AK47_ACCURACY_FLAG = 8;

	private float airSpread = 1.5f;

	private float moveSpread = 0.09f;

	private float duckSpread = 0.08f;

	private float defaultSpread = 0.09f;

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float num = ((!isAccuracyActive(currentWeapon) && !player.OnGround() && !isWeightlessness) ? airSpread : ((!isAccuracyActive(currentWeapon) && PlayerUtility.PlayerLength2D(player) > 13f) ? moveSpread : ((player.DuckState() != 0) ? defaultSpread : duckSpread)));
		spread = num * (1f - currentWeapon.accuracy.Accuracy);
	}

	private static bool isAccuracyActive(WeaponEntity currentWeapon)
	{
		if ((currentWeapon.special.EffectLevel & G18_ACCURACY_FLAG) <= 0)
		{
			return (currentWeapon.special.EffectLevel & AK47_ACCURACY_FLAG) > 0;
		}
		return true;
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
