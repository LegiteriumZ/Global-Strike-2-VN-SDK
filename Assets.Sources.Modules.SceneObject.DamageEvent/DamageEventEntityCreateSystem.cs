using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Info.PlayerBuff;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.DamageEvent;

public class DamageEventEntityCreateSystem : IEntityCreateSystem
{
	private readonly SnapshotContext _snapshotContext;

	private readonly SceneObjectContext _damageEventContext;

	private readonly PlayerContext _playerContext;

	private readonly GameRuleContext _gameRuleContext;

	private readonly AssetInfo _damageHintAsset = new AssetInfo("playereffectprefab/damagehinttext", "DamageHintText", typeof(GameObject));

	public DamageEventEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_damageEventContext = contexts.sceneObject;
		_playerContext = contexts.player;
		_gameRuleContext = contexts.gameRule;
	}

	public void OnEntityCreate()
	{
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, ShowDamageEventEntityData> item in latestSnapshot.ShowDamageEventEntityDataDict)
		{
			ShowDamageEventEntityData value = item.Value;
			if (_damageEventContext.GetEntityWithEntityId(value.BaseEventEntity.Id) == null)
			{
				SceneObjectEntity sceneObjectEntity = _damageEventContext.CreateEntity();
				sceneObjectEntity.AddEntityId(value.BaseEventEntity.Id);
				sceneObjectEntity.AddDamageEvent(value.TargetId, value.Damage, value.DamageAdd, value.Headshot, value.IsTreatment, value.IsCrit, value.Immune, value.IsTop, value.IsDun, value.MeshSpecial, value.MeshNormal, value.ShowType, value.Elemental, null, null, null, null, null, null, null, null, null, null, null, 0, 0, 0, 0, 0, 0, Vector3.zero, Vector3.zero, 0, value.CritType);
				sceneObjectEntity.AddPosition(new Vector3(value.BaseEventEntity.X, value.BaseEventEntity.Y, value.BaseEventEntity.Z));
				sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(_damageHintAsset), value.BaseEventEntity.Id);
				if (value.TargetId > 0)
				{
					_gameRuleContext.hpProgressData.TargetId = value.TargetId;
				}
			}
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(value.TargetId);
			if (entityWithEntityId != null && value.IsTreatment)
			{
				if (!entityWithEntityId.buff.Buffs.ContainsKey("IsTreatmentPlayer"))
				{
					entityWithEntityId.buff.Buffs.Add("IsTreatmentPlayer", new DefaultPlayerBuff("IsTreatmentPlayer", 2000));
				}
				entityWithEntityId.buff.SetBuff("IsTreatmentPlayer", 2000);
			}
			entityWithEntityId?.ReplaceBeAttack(2000);
			if (value.TargetId > 0)
			{
				_gameRuleContext.hpProgressData.AttackId = value.TargetId;
			}
		}
	}
}
