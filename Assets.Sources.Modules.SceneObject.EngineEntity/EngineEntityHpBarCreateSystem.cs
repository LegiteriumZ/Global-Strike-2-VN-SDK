using System.Collections.Generic;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.EngineEntity;

internal class EngineEntityHpBarCreateSystem : IPlaybackSystem
{
	private SnapshotContext _snapshotContext;

	private BattleRoomContext _battleRoomContext;

	private SceneObjectContext _sceneObjectContext;

	public EngineEntityHpBarCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_battleRoomContext = contexts.battleRoom;
		_sceneObjectContext = contexts.sceneObject;
	}

	public void OnPlayback()
	{
		if (RuleUtilty.IsPitRule(_battleRoomContext) || !_snapshotContext.hasSnapshots || _snapshotContext.snapshots.NowSnapshot == null)
		{
			return;
		}
		_battleRoomContext.engineEntity.HeadList.Clear();
		foreach (KeyValuePair<int, SimpleEngineEntityData> item in _snapshotContext.snapshots.NowSnapshot.SimpleEngineEntityDataDict)
		{
			EntityEffectId entityEffectId = new EntityEffectId(item.Value.Id, "EngineEntity");
			if (_sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId) == null)
			{
				SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
				sceneObjectEntity.AddEtype(18);
				sceneObjectEntity.AddPlayerEffectId(entityEffectId);
				sceneObjectEntity.AddEngineEntityHpBar(item.Value.Id, null, null, null, null, 0, 1f, newUnderCross: false);
				sceneObjectEntity.AddPosition(Vector3.zero);
				sceneObjectEntity.AddScale(Vector3.one);
				sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(new AssetInfo("playereffectprefab/engineentityhpbar", "EngineEntityHpBar", typeof(GameObject))), entityEffectId);
			}
		}
	}
}
