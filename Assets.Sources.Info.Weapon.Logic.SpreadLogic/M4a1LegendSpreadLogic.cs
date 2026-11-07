using System;
using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using Assets.Sources.Utils.Player;
using SSJJUserCmd;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

[Serializable]
public class M4a1LegendSpreadLogic : ISpreadLogic, IParamParse
{
	protected int Length2D1 = 350;

	protected int Length2D2 = 25;

	public float FovAddParam;

	public float DefaultParam;

	public float DuckParam;

	public float LengthParam2;

	public float LengthParam1;

	public float AirParam;

	public void Parse(string param)
	{
		M4a1LegendSpreadLogic m4a1LegendSpreadLogic = JsonUtility.FromJson<M4a1LegendSpreadLogic>(param);
		AirParam = m4a1LegendSpreadLogic.AirParam;
		Length2D1 = m4a1LegendSpreadLogic.Length2D1;
		Length2D2 = m4a1LegendSpreadLogic.Length2D2;
		DefaultParam = m4a1LegendSpreadLogic.DefaultParam;
		FovAddParam = m4a1LegendSpreadLogic.FovAddParam;
		DuckParam = m4a1LegendSpreadLogic.DuckParam;
		LengthParam1 = m4a1LegendSpreadLogic.LengthParam1;
		LengthParam2 = m4a1LegendSpreadLogic.LengthParam2;
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		if ((currentWeapon.special.EffectLevel & M4a1EffectLevelConst.JIN_JIE_A_EFFECT_LEVEL) > 0 || (currentWeapon.special.EffectLevel & M4a1EffectLevelConst.JIN_JIE_B_EFFECT_LEVEL) > 0 || (currentWeapon.special.EffectLevel & M4a1EffectLevelConst.JIN_JIE_C_EFFECT_LEVEL) > 0)
		{
			spread = DefaultParam * currentWeapon.accuracy.Accuracy;
			return;
		}
		float num = ((!player.OnGround() && !isWeightlessness) ? AirParam : ((PlayerUtility.PlayerLength2D(player) > (float)Length2D1) ? LengthParam1 : ((PlayerUtility.PlayerLength2D(player) > (float)Length2D2) ? LengthParam2 : ((player.DuckState() != 0) ? DefaultParam : DuckParam))));
		if (player.fov.Fov == 90)
		{
			num += FovAddParam;
		}
		spread = num * currentWeapon.accuracy.Accuracy;
	}
}
