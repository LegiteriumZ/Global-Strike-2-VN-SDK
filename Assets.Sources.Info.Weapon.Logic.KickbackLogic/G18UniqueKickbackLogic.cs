using System;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Utils.Player;
using Assets.Sources.Utils.Weapon;
using math;

namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

internal class G18UniqueKickbackLogic : IKickbackLogic, IParamParse
{
	public float[] ak47UniqueRun;

	public float[] ak47UniqueAir;

	public float[] ak47UniqueDuck;

	public float[] ak47UniqueDefault;

	public const int UpmaxLength2D = 300;

	public static int AK47_ACCURACY_FLAG = 8;

	public static int G18_ACCURACY_FLAG = 2048;

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		float[] array = ((!isAccuracyActive(currentWeapon) && IsRunKickBack(player, isWeightlessness)) ? ak47UniqueRun : ((!isAccuracyActive(currentWeapon) && !player.OnGround()) ? ak47UniqueAir : ((player.DuckState() != 0) ? ak47UniqueDefault : ak47UniqueDuck)));
		BaseKickBack(player, currentWeapon, seed, array[0], array[1], array[2], array[3], array[4], array[5], array[6]);
	}

	private bool isAccuracyActive(WeaponEntity currentWeapon)
	{
		if ((currentWeapon.special.EffectLevel & AK47_ACCURACY_FLAG) <= 0)
		{
			return (currentWeapon.special.EffectLevel & G18_ACCURACY_FLAG) > 0;
		}
		return true;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 28);
		ak47UniqueRun = new float[7];
		ak47UniqueAir = new float[7];
		ak47UniqueDuck = new float[7];
		ak47UniqueDefault = new float[7];
		Array.Copy(restlts, 0, ak47UniqueRun, 0, 7);
		Array.Copy(restlts, 7, ak47UniqueAir, 0, 7);
		Array.Copy(restlts, 14, ak47UniqueDuck, 0, 7);
		Array.Copy(restlts, 21, ak47UniqueDefault, 0, 7);
	}

	private void BaseKickBack(PlayerEntity player, WeaponEntity weapon, int seed, float upBase, float lateralBase, float upModifier, float lateralModifier, float upMax, float lateralMax, float directionChang)
	{
		IEntitsWeaponInfo info = weapon.basicInfo.Info;
		float num = (float)FireUtility.CalShotsFiredSpread(info.ShotsFiredSpreadMin, info.ShotsFiredSpreadMax, info.ShotsFiredSpreadTime, weapon.attack.ShotsFired, info.AttackInterval);
		float num2;
		float num3;
		if (weapon.attack.ShotsFired == 1)
		{
			num2 = upBase;
			num3 = lateralBase;
		}
		else
		{
			num2 = upBase + (float)weapon.attack.ShotsFired * upModifier;
			num3 = lateralBase + (float)weapon.attack.ShotsFired * lateralModifier;
		}
		num2 *= num;
		num3 *= num;
		float punchYaw = player.GetPunchYaw();
		float punchPitch = player.GetPunchPitch();
		bool flag = false;
		punchPitch += num2;
		if ((double)punchPitch > (double)upMax + (double)weapon.basicInfo.Info.AttackInterval * 0.01)
		{
			punchPitch = upMax;
			flag = true;
		}
		if (PlayerUtility.PlayerLength2D(player) > 300f && flag)
		{
			player.move.RunUpMax = true;
		}
		if (weapon.direction.Direction)
		{
			punchYaw += num3;
			if (punchYaw > lateralMax)
			{
				punchYaw = lateralMax;
			}
		}
		else
		{
			punchYaw -= num3;
			if (punchYaw < -1f * lateralMax)
			{
				punchYaw = -1f * lateralMax;
			}
		}
		if (UniformRandom.RandomInt(seed, 0, (int)directionChang) == 0)
		{
			weapon.direction.Direction = !weapon.direction.Direction;
		}
		if (flag)
		{
			player.decay.DecayTime = weapon.basicInfo.Info.AttackInterval / 2;
		}
		player.punchOrientation.PunchYaw = punchYaw * (1f - (float)player.basicInfo.Current.StabilizeValue * 0.001f);
		player.punchOrientation.PunchPitch = punchPitch * (1f - (float)player.basicInfo.Current.StabilizeValue * 0.001f);
	}

	protected bool IsRunKickBack(PlayerEntity player, bool isWeightlessness)
	{
		if (player.RunUpMax() || PlayerUtility.PlayerLength2D(player) > 300f || (!player.OnGround() && isWeightlessness))
		{
			return true;
		}
		return false;
	}
}
