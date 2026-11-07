using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class M4A1Legend : AbstractThirdWeaponEffectLogic
{
	private const int Level1 = 1;

	private const int Level2 = 2;

	private const int Level3 = 4;

	private const int MaxEffectTime = 500;

	private int _startTime;

	private int _originalLevel;

	private int _targetLevel;

	private float _originalCiScale;

	private float _originalDaorenScale = 0.5f;

	public override void Update(PlayerEntity player, int raceType)
	{
		UpdateAttachData(player);
		IPaticlePrefabInstancecs paticleBySkinName = GetPaticleBySkinName(player, "weapon_particle_effect2");
		IPaticlePrefabInstancecs paticleBySkinName2 = GetPaticleBySkinName(player, "weapon_particle_effect3");
		if (IsInPhrase1Effect(player))
		{
			paticleBySkinName?.SetInsScale(GetCiEffectTargetScale(player));
			paticleBySkinName2?.SetInsScale(GetDaorenEffectTargetScale(player));
			SetShanGuangActive(player, status: false);
		}
		else if (IsInPhrase2Effect(player))
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

	private void SetShanGuangActive(PlayerEntity player, bool status)
	{
		SetParticleActiveParticleName(player, "11852_jinjieshanguang", status);
	}

	private void UpdateAttachData(PlayerEntity player)
	{
		if (player.GetCurrentWeaponEffectLevel() == _targetLevel && _targetLevel == _originalLevel)
		{
			return;
		}
		TimeComponent time = Contexts.sharedInstance.time.time;
		if (player.GetCurrentWeaponEffectLevel() != _targetLevel)
		{
			_targetLevel = player.GetCurrentWeaponEffectLevel();
			_startTime = time.ClientRealTime;
			PaticlePrefabInstancecs paticlePrefabInstancecs = GetPaticleBySkinName(player, "weapon_particle_effect2") as PaticlePrefabInstancecs;
			PaticlePrefabInstancecs paticlePrefabInstancecs2 = GetPaticleBySkinName(player, "weapon_particle_effect3") as PaticlePrefabInstancecs;
			if (paticlePrefabInstancecs != null)
			{
				_originalCiScale = paticlePrefabInstancecs.LocalScala.x;
			}
			if (paticlePrefabInstancecs2 != null)
			{
				_originalDaorenScale = paticlePrefabInstancecs2.LocalScala.x;
			}
		}
		if (_originalLevel != _targetLevel && time.ClientRealTime - _startTime > 500)
		{
			_originalLevel = _targetLevel;
		}
	}

	private bool IsInPhrase1Effect(PlayerEntity player)
	{
		if (_targetLevel != _originalLevel)
		{
			return Contexts.sharedInstance.time.time.ClientRealTime - _startTime < 500;
		}
		return false;
	}

	private bool IsInPhrase2Effect(PlayerEntity player)
	{
		if ((_targetLevel == 2 || _targetLevel == 4) && _targetLevel == _originalLevel && Contexts.sharedInstance.time.time.ClientRealTime - _startTime > 500)
		{
			return Contexts.sharedInstance.time.time.ClientRealTime - _startTime < 1000;
		}
		return false;
	}

	private float GetCiEffectTargetScale(PlayerEntity player)
	{
		return Mathf.Lerp(_originalCiScale, GetCiEffectTargetScale(_targetLevel), (float)(Contexts.sharedInstance.time.time.ClientRealTime - _startTime) * 1f / 500f);
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

	private float GetDaorenEffectTargetScale(PlayerEntity player)
	{
		return Mathf.Lerp(_originalDaorenScale, GetDorenEffectTargetScale(_targetLevel), (float)(Contexts.sharedInstance.time.time.ClientRealTime - _startTime) * 1f / 500f);
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
