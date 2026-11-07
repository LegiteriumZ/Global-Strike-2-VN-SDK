using System;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using Assets.Sources.Utils.Player;
using Assets.Sources.Utils.Weapon;
using UnityEngine;
using math;

namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

[Serializable]
public class M4a1LegendKickbackLogic : IKickbackLogic, IParamParse
{
	public const int UpmaxLength2D = 300;

	public RunGroundDuckKickBack defalutKickback;

	public RunGroundDuckKickBack step1Kickback;

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if ((currentWeapon.special.EffectLevel & M4a1EffectLevelConst.JIN_JIE_A_EFFECT_LEVEL) > 0 || (currentWeapon.special.EffectLevel & M4a1EffectLevelConst.JIN_JIE_B_EFFECT_LEVEL) > 0 || (currentWeapon.special.EffectLevel & M4a1EffectLevelConst.JIN_JIE_C_EFFECT_LEVEL) > 0)
		{
			step1Kickback.KickBack(seed, player, currentWeapon, isWeightlessness);
		}
		else
		{
			defalutKickback.KickBack(seed, player, currentWeapon, isWeightlessness);
		}
	}

	private static void BaseKickBack(PlayerEntity player, WeaponEntity weapon, int seed, float upBase, float lateralBase, float upModifier, float lateralModifier, float upMax, float lateralMax, float directionChang)
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

	public static void setKickBackToWeapon(int seed, PlayerEntity player, WeaponEntity currentWeapon, KickBackData kickBackData)
	{
		BaseKickBack(player, currentWeapon, seed, kickBackData.upBase, kickBackData.lateralBase, kickBackData.upModifier, kickBackData.lateralModifier, kickBackData.upMax, kickBackData.lateralMax, kickBackData.directionChang);
	}

	public void Parse(string param)
	{
		JsonUtility.FromJsonOverwrite(param, this);
	}
}
