using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Weapon.Attach;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class M4A1Legend : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (currentWeapon.attach.Data is M4A1LegendAttach m4A1LegendAttach)
		{
			UpdateAttachData(currentWeapon, player);
			IPaticlePrefabInstancecs paticleBySkinName = GetPaticleBySkinName(player, "weapon_dummy_particle_effect2");
			IPaticlePrefabInstancecs paticleBySkinName2 = GetPaticleBySkinName(player, "weapon_dummy_particle_effect3");
			if (IsInPhrase1Effect(m4A1LegendAttach, player))
			{
				paticleBySkinName?.SetInsScale(GetCiEffectTargetScale(m4A1LegendAttach, player));
				paticleBySkinName2?.SetInsScale(GetDaorenEffectTargetScale(m4A1LegendAttach, player));
				SetShanGuangActive(player, status: false);
			}
			else if (IsInPhrase2Effect(m4A1LegendAttach, player))
			{
				SetShanGuangActive(player, status: true);
			}
			else
			{
				paticleBySkinName?.SetInsScale(GetCiEffectTargetScale(player.GetCurrentWeaponEffectLevel()));
				paticleBySkinName2?.SetInsScale(GetDorenEffectTargetScale(player.GetCurrentWeaponEffectLevel()));
				SetShanGuangActive(player, status: false);
			}
		}
	}

	private void SetShanGuangActive(PlayerEntity player, bool status)
	{
		SetParticleActiveParticleName(player, "11852_jinjieshanguang", status);
	}

	private void UpdateAttachData(WeaponEntity currentWeapon, PlayerEntity player)
	{
		M4A1LegendAttach m4A1LegendAttach = currentWeapon.attach.Data as M4A1LegendAttach;
		if (currentWeapon.special.EffectLevel == m4A1LegendAttach.TargetLevel && m4A1LegendAttach.TargetLevel == m4A1LegendAttach.OriginalLevel)
		{
			return;
		}
		if (currentWeapon.special.EffectLevel != m4A1LegendAttach.TargetLevel)
		{
			m4A1LegendAttach.TargetLevel = currentWeapon.special.EffectLevel;
			m4A1LegendAttach.StartTime = player.clientTime.ClientTime;
			PaticlePrefabInstancecs paticlePrefabInstancecs = GetPaticleBySkinName(player, "weapon_dummy_particle_effect2") as PaticlePrefabInstancecs;
			PaticlePrefabInstancecs paticlePrefabInstancecs2 = GetPaticleBySkinName(player, "weapon_dummy_particle_effect3") as PaticlePrefabInstancecs;
			if (paticlePrefabInstancecs != null)
			{
				m4A1LegendAttach.OriginalCiScale = paticlePrefabInstancecs.LocalScala.x;
			}
			if (paticlePrefabInstancecs2 != null)
			{
				m4A1LegendAttach.OriginalDaorenScale = paticlePrefabInstancecs2.LocalScala.x;
			}
		}
		if (m4A1LegendAttach.OriginalLevel != m4A1LegendAttach.TargetLevel && player.clientTime.ClientTime - m4A1LegendAttach.StartTime > 500)
		{
			m4A1LegendAttach.OriginalLevel = m4A1LegendAttach.TargetLevel;
		}
	}

	private bool IsInPhrase1Effect(M4A1LegendAttach attachData, PlayerEntity player)
	{
		if (attachData.TargetLevel != attachData.OriginalLevel)
		{
			return player.clientTime.ClientTime - attachData.StartTime < 500;
		}
		return false;
	}

	private bool IsInPhrase2Effect(M4A1LegendAttach attachData, PlayerEntity player)
	{
		if ((attachData.TargetLevel == 2 || attachData.TargetLevel == 4) && attachData.TargetLevel == attachData.OriginalLevel && player.clientTime.ClientTime - attachData.StartTime > 500)
		{
			return player.clientTime.ClientTime - attachData.StartTime < 1000;
		}
		return false;
	}

	private float GetCiEffectTargetScale(M4A1LegendAttach attach, PlayerEntity player)
	{
		return Mathf.Lerp(attach.OriginalCiScale, GetCiEffectTargetScale(attach.TargetLevel), (float)(player.clientTime.ClientTime - attach.StartTime) * 1f / 500f);
	}

	private float GetCiEffectTargetScale(int effectLevel)
	{
		if ((effectLevel & 1) > 0)
		{
			return 0.8f;
		}
		if ((effectLevel & 2) > 0)
		{
			return 0.9f;
		}
		if ((effectLevel & 4) > 0)
		{
			return 1.1f;
		}
		return 0f;
	}

	private float GetDaorenEffectTargetScale(M4A1LegendAttach attach, PlayerEntity player)
	{
		return Mathf.Lerp(attach.OriginalDaorenScale, GetDorenEffectTargetScale(attach.TargetLevel), (float)(player.clientTime.ClientTime - attach.StartTime) * 1f / 500f);
	}

	private float GetDorenEffectTargetScale(int effectLevel)
	{
		if ((effectLevel & 1) > 0)
		{
			return 0.7f;
		}
		if ((effectLevel & 2) > 0)
		{
			return 0.9f;
		}
		if ((effectLevel & 4) > 0)
		{
			return 1f;
		}
		return 0.5f;
	}
}
