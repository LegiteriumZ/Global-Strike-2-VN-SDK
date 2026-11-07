using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.FirstPlayerEffect;
using Assets.Sources.Modules.BattleRoom;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.FirstPlayerEffect;

public class FirstPlayerEffectCreateSystem : IEntityCreateSystem
{
	private SceneObjectContext _sceneObjectContext;

	private BattleRoomContext _battleRoomContext;

	private IBattleRoom _battleRoomAdapter;

	private PlayerContext _playerContext;

	public FirstPlayerEffectCreateSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomContext = contexts.battleRoom;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
	}

	public void OnEntityCreate()
	{
		if (_playerContext.isMyPlayer)
		{
			CreatePlayerEffect(_playerContext.myPlayerEntity);
		}
	}

	private static string GetEffectEntityId(int playerEntityId, string effectName)
	{
		return $"{playerEntityId}@{effectName}";
	}

	private void CreatePlayerEffect(PlayerEntity player)
	{
		foreach (IFirstPlayerEffectInfo playerInfo in FirstPlayerEffectInfoFactory.Instance.PlayerInfoList)
		{
			if (playerInfo.IsEffectOn(player, _battleRoomAdapter))
			{
				AddEffect(player, playerInfo);
			}
		}
	}

	private void AddEffect(PlayerEntity player, IFirstPlayerEffectInfo effectInfo)
	{
		EntityEffectId entityEffectId = new EntityEffectId(player.entityId.Value, effectInfo.GetType().ToString());
		if (_sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId) == null)
		{
			this.DebugFormat("Create PlayerEffect {0}", entityEffectId);
			AssetInfo firstEffectAssetInfo = effectInfo.GetFirstEffectAssetInfo(player, _battleRoomContext.roomData.Data.RaceType);
			firstEffectAssetInfo.AssetType = typeof(GameObject);
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
			sceneObjectEntity.AddPlayerEffectId(entityEffectId);
			sceneObjectEntity.AddPosition(Vector3.zero);
			sceneObjectEntity.AddScale(Vector3.one);
			sceneObjectEntity.AddFirstPlayerEffect(player.entityId.Value, effectInfo);
			sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(firstEffectAssetInfo), entityEffectId);
		}
	}
}
