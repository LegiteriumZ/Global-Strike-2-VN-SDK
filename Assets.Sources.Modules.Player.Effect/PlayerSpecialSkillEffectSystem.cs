using System;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Weapon;
using Entitas;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerSpecialSkillEffectSystem : IPlaybackSystem
{
	private readonly IGroup<SceneObjectEntity> _effectGroup;

	public PlayerSpecialSkillEffectSystem(Contexts contexts)
	{
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PredictionEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		WeaponEntity currentWeaponEntity = Contexts.sharedInstance.weapon.currentWeaponEntity;
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		BaseWeaponData data = currentWeaponEntity.basicInfo.Data;
		if (data != null && data.HideCross)
		{
			Vector3 endPos = FireUtility.TraceWorldInDistance(myPlayerEntity, currentWeaponEntity);
			if (!endPos.Equals(Vector3.zero))
			{
				AddSkillMarkEntity(endPos, currentWeaponEntity);
			}
		}
	}

	private void AddSkillMarkEntity(Vector3 endPos, WeaponEntity currentWeapon)
	{
		endPos.z += 5f;
		SceneObjectEntity sceneObjectEntity = null;
		using (IGroup<SceneObjectEntity>.Enumator enumator = _effectGroup.GetEnumerator())
		{
			if (enumator.MoveNext())
			{
				sceneObjectEntity = enumator.Current;
			}
		}
		if (sceneObjectEntity == null)
		{
			sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
			sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(GetMarkEffectAsset()), -1);
			sceneObjectEntity.isPredictionEffect = true;
		}
		sceneObjectEntity.ReplaceLifeTime(DateTime.Now, 100);
		sceneObjectEntity.ReplacePosition(endPos);
	}

	private AssetInfo GetMarkEffectAsset()
	{
		return new AssetInfo("skill/role1006", $"Assets/Res/Assets/skill/role1006/effect/11470_biaoji/Prefab/11470_biaoji.prefab");
	}
}
