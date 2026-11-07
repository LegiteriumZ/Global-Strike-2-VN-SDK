using System;
using Assets.Sources.Components.Interface;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class ZiLvShouWeiEffectRender : AbstractPlayerShowEffectRender
{
	private string WEAPON_EFFECT1 = "zishentexiao_effect2";

	private string WEAPON_EFFECT2 = "zishentexiao__pj_effect2";

	private string WEAPON_EFFECT3 = "zishentexiao_effect3";

	private string WEAPON_EFFECT4 = "zishentexiao_pj_effect3";

	private string WEAPON_EFFECT5 = "zishentexiao_effect4";

	private string WEAPON_EFFECT6 = "zishentexiao_pj_effect4";

	private string WEAPON_EFFECT7 = "qiangkouhuohua";

	private string WEAPON_EFFECT8 = "qiangkouhuohua_pj";

	private string WEAPON_EFFECT9 = "dun";

	private string WEAPON_EFFECT10 = "dunposui";

	private bool _showEffect;

	private SkinnedMeshRenderer _skin1;

	private SkinnedMeshRenderer _skin2;

	private SkinnedMeshRenderer _skin3;

	private SkinnedMeshRenderer _skin4;

	private SkinnedMeshRenderer _skin5;

	private SkinnedMeshRenderer _skin6;

	protected Func<PlayerEntity, string, string, int> Func;

	public override void Init(PlayerEntity player)
	{
		if (player != null)
		{
			_skin1 = player.thirdPersonUnityObjects.Animator.GetBone("zlsw_a1").GetComponent<SkinnedMeshRenderer>();
			_skin2 = player.thirdPersonUnityObjects.Animator.GetBone("zlsw_b1").GetComponent<SkinnedMeshRenderer>();
			_skin3 = player.thirdPersonUnityObjects.Animator.GetBone("zlsw_a2").GetComponent<SkinnedMeshRenderer>();
			_skin4 = player.thirdPersonUnityObjects.Animator.GetBone("zlsw_b2").GetComponent<SkinnedMeshRenderer>();
			_skin5 = player.thirdPersonUnityObjects.Animator.GetBone("zlsw_a3").GetComponent<SkinnedMeshRenderer>();
			_skin6 = player.thirdPersonUnityObjects.Animator.GetBone("zlsw_b3").GetComponent<SkinnedMeshRenderer>();
		}
	}

	public override void Render(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		if (_skin1 == null)
		{
			Init(targetPlayer);
		}
		if (targetPlayer != null)
		{
			int currentWeaponEffectLevel = targetPlayer.GetCurrentWeaponEffectLevel();
			_skin1.enabled = true;
			_skin2.enabled = true;
			_skin3.enabled = true;
			_skin4.enabled = true;
			_skin5.enabled = true;
			_skin6.enabled = true;
			if ((currentWeaponEffectLevel & 4) > 0)
			{
				_skin1.enabled = false;
			}
			else
			{
				_skin2.enabled = false;
			}
			if ((currentWeaponEffectLevel & 1) > 0)
			{
				_skin3.enabled = false;
			}
			else
			{
				_skin4.enabled = false;
			}
			if ((currentWeaponEffectLevel & 2) > 0)
			{
				_skin5.enabled = false;
			}
			else
			{
				_skin6.enabled = false;
			}
			if (Func == null)
			{
				Func = SetEffectFlag;
			}
			SetParticleActiveBySkinName(targetPlayer, SetEffectFlag);
		}
	}

	private int SetEffectFlag(PlayerEntity player, string skin, string particle)
	{
		if (particle.Equals(WEAPON_EFFECT10))
		{
			if (_showEffect && (player.GetCurrentWeaponEffectLevel() & 8) == 0)
			{
				return 1;
			}
			return 0;
		}
		if (skin.Equals("player_particle_effect2"))
		{
			if (particle.Equals(WEAPON_EFFECT1) && (player.GetCurrentWeaponEffectLevel() & 2) == 0)
			{
				return 1;
			}
			if (particle.Equals(WEAPON_EFFECT2) && (player.GetCurrentWeaponEffectLevel() & 2) > 0)
			{
				return 1;
			}
			return 0;
		}
		if (skin.Equals("player_particle_effect3"))
		{
			if (particle.Equals(WEAPON_EFFECT10))
			{
				return 0;
			}
			if (particle.Equals(WEAPON_EFFECT3) && (player.GetCurrentWeaponEffectLevel() & 4) == 0)
			{
				return 1;
			}
			if (particle.Equals(WEAPON_EFFECT4) && (player.GetCurrentWeaponEffectLevel() & 4) > 0)
			{
				return 1;
			}
			if (particle.Equals(WEAPON_EFFECT9) && (player.GetCurrentWeaponEffectLevel() & 8) > 0)
			{
				_showEffect = true;
				return 1;
			}
			return 0;
		}
		if (skin.Equals("player_particle_effect4"))
		{
			if (particle.Equals(WEAPON_EFFECT5) && (player.GetCurrentWeaponEffectLevel() & 4) == 0)
			{
				return 1;
			}
			if (particle.Equals(WEAPON_EFFECT6) && (player.GetCurrentWeaponEffectLevel() & 4) > 0)
			{
				return 1;
			}
			return 0;
		}
		if (skin.Equals("player_particle_effect1"))
		{
			if (particle.Equals(WEAPON_EFFECT7) && player.HasStatus(PlayerInfoStatusConstant.RPG_ZILVSHOUWEI_QIAOKOU.ID))
			{
				return 1;
			}
			if (particle.Equals(WEAPON_EFFECT8) && player.HasStatus(PlayerInfoStatusConstant.RPG_ZILVSHOUWEI_QIAOKOU_PJ.ID))
			{
				return 1;
			}
		}
		return 0;
	}
}
