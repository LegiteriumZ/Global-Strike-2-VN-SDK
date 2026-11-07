using System;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Utils.Player;
using Assets.Sources.Utils.Weapon;
using math;

namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

public class HunterVssKickbackLogic : IKickbackLogic, IParamParse
{
	public const int UpmaxLength2D = 300;

	internal float[] KickbackParams { get; set; }

	internal float[] KickbackParamsRun { get; set; }

	internal float[] KickbackParamsDuck { get; set; }

	internal float[] KickbackParamsAir { get; set; }

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if (!currentWeapon.special.SpecialMode)
		{
			float[] array = (IsRunKickBack(player, isWeightlessness) ? KickbackParamsRun : ((!player.OnGround()) ? KickbackParamsAir : ((player.DuckState() != 0) ? KickbackParams : KickbackParamsDuck)));
			BaseKickBack(player, currentWeapon, seed, array[0], array[1], array[2], array[3], array[4], array[5], array[6]);
		}
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 28);
		KickbackParamsRun = new float[7];
		Array.Copy(restlts, 0, KickbackParamsRun, 0, 7);
		KickbackParamsAir = new float[7];
		Array.Copy(restlts, 7, KickbackParamsAir, 0, 7);
		KickbackParamsDuck = new float[7];
		Array.Copy(restlts, 14, KickbackParamsDuck, 0, 7);
		KickbackParams = new float[7];
		Array.Copy(restlts, 21, KickbackParams, 0, 7);
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
