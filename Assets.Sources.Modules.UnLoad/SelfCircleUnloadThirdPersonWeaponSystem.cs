using System.Collections.Generic;
using Assets.Scripts.Utility;
using Assets.Sources.Components.Unload;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Modules.UnLoad;

public class SelfCircleUnloadThirdPersonWeaponSystem : IEntityDestroySystem
{
	private readonly IGroup<UnloadEntity> _unloads;

	private int _circleMaxTime = 200;

	private bool _isPvp;

	public SelfCircleUnloadThirdPersonWeaponSystem(Contexts contexts)
	{
		_unloads = contexts.unload.GetGroup(UnloadMatcher.AllOf(UnloadMatcher.UnloadThirdWeaponRes));
		_isPvp = !RuleUtilty.IsPve(contexts.battleRoom.roomData.Data.RaceType);
	}

	public void OnEntityDestroy()
	{
		if (!UnloadSign.UnloadThirdRes || _isPvp)
		{
			return;
		}
		this.Info("self circle check");
		foreach (UnloadEntity unload in _unloads)
		{
			if (unload.unloadThirdWeaponRes.RecircleWeapons == null)
			{
				unload.unloadThirdWeaponRes.RecircleWeapons = new List<string>();
			}
			List<string> recircleWeapons = unload.unloadThirdWeaponRes.RecircleWeapons;
			List<UnloadThirdWeaponResComponent.RecordRes> resRecords = unload.unloadThirdWeaponRes.ResRecords;
			if (resRecords != null)
			{
				foreach (UnloadThirdWeaponResComponent.RecordRes item in resRecords)
				{
					if (!item.IsUsing && Time.time - (float)item.LastUseTime >= (float)_circleMaxTime && !recircleWeapons.Contains(item.WeaponName))
					{
						recircleWeapons.Add(item.WeaponName);
					}
				}
				foreach (UnloadThirdWeaponResComponent.RecordRes item2 in resRecords)
				{
					if ((item2.IsUsing || Time.time - (float)item2.LastUseTime < (float)_circleMaxTime) && recircleWeapons.Contains(item2.WeaponName))
					{
						recircleWeapons.Remove(item2.WeaponName);
					}
				}
			}
			if (recircleWeapons != null && recircleWeapons.Count > 0)
			{
				TotalMemoryUtility.SetSelfCircle(recircleWeapons.Count);
			}
		}
	}
}
