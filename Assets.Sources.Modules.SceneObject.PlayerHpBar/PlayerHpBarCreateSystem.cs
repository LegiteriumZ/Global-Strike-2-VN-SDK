using Assets.Sources.Components.Interface;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.PlayerHpBar;
using Assets.Sources.Modules.BattleRoom;
using Entitas;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PlayerHpBar;

public class PlayerHpBarCreateSystem : IEntityCreateSystem
{
	private IGroup<PlayerEntity> _playerGroup;

	private SceneObjectContext _sceneObjectContext;

	private IBattleRoom _battleRoomAdapter;

	public PlayerHpBarCreateSystem(Contexts contexts)
	{
		_playerGroup = contexts.player.GetGroup(PlayerMatcher.AnyOf(PlayerMatcher.BasicInfo, PlayerMatcher.PartBasicInfo));
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
	}

	public void OnEntityCreate()
	{
		int frameCount = Time.frameCount;
		int num = 0;
		foreach (PlayerEntity item in _playerGroup)
		{
			if ((frameCount - num++) % 10 == 0)
			{
				CreatePlayerHpBar(item);
			}
		}
	}

	private static string GetEffectEntityId(int playerEntityId, string effectName)
	{
		return $"{playerEntityId}@{effectName}";
	}

	private void CreatePlayerHpBar(PlayerEntity player)
	{
		if (PlayerHpBarEffectInfo.Instance.IsEffectOn(player, _battleRoomAdapter))
		{
			AddHpBar(player);
		}
	}

	private void AddHpBar(PlayerEntity player)
	{
		PlayerHpBarEffectInfo instance = PlayerHpBarEffectInfo.Instance;
		EntityEffectId entityEffectId = new EntityEffectId(player.basicInfo.Cid, "PlayerHpBar");
		if (_sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId) == null)
		{
			AssetInfo assetInfo = instance.GetAssetInfo();
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
			sceneObjectEntity.AddPlayerEffectId(entityEffectId);
			sceneObjectEntity.AddPosition(Vector3.zero);
			sceneObjectEntity.AddScale(Vector3.one);
			sceneObjectEntity.AddPlayerHpBar(player.basicInfo.Cid, null);
			sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(assetInfo), entityEffectId);
		}
	}
}
