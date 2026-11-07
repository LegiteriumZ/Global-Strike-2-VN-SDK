using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Components.Unload;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.UnLoad;

public class UnloadThirdPersonResSystem : IEntityDestroySystem
{
	private readonly IGroup<UnloadEntity> _unloads;

	private TimeComponent _time;

	private float _unloadTime;

	public UnloadThirdPersonResSystem(Contexts contexts)
	{
		_unloads = contexts.unload.GetGroup(UnloadMatcher.AllOf(UnloadMatcher.UnloadThirdRes));
		_time = contexts.time.time;
	}

	public void OnEntityDestroy()
	{
		if (!canUnloadThirdRes())
		{
			return;
		}
		UnloadSign.UnloadThirdRes = false;
		_unloadTime = _time.ClientRealTime;
		foreach (UnloadEntity unload in _unloads)
		{
			ThirdResUnloadUtility.UnloadRes(unload.unloadThirdRes.UnloadEntityId);
			unload.isDestroy = true;
		}
		UnloadThirdWeaponResComponent unloadThirdWeaponRes = Contexts.sharedInstance.unload.unloadThirdWeaponResEntity.unloadThirdWeaponRes;
		if (unloadThirdWeaponRes != null)
		{
			List<string> recircleWeapons = unloadThirdWeaponRes.RecircleWeapons;
			List<UnloadThirdWeaponResComponent.RecordRes> resRecords = unloadThirdWeaponRes.ResRecords;
			if (recircleWeapons != null && resRecords != null)
			{
				foreach (string item in recircleWeapons)
				{
					ThirdResUnloadUtility.UnloadWeapon(item);
					for (int i = 0; i < resRecords.Count; i++)
					{
						if (resRecords[i].WeaponName == item)
						{
							resRecords.RemoveAt(i--);
						}
					}
				}
				recircleWeapons.Clear();
			}
		}
		Resources.UnloadUnusedAssets();
	}

	private bool canUnloadThirdRes()
	{
		if ((float)(_time.ClientRealTime - 180000) > _unloadTime)
		{
			return true;
		}
		return UnloadSign.UnloadThirdRes;
	}
}
