using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Entitas;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.ParticleLoop;

public class PlayerInfoParticleLoopEffectCreateSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _playerGroup;

	private readonly IBattleRoom _battleRoomAdapter;

	private readonly SceneObjectContext _sceneObjectContext;

	public PlayerInfoParticleLoopEffectCreateSystem(Contexts contexts)
	{
		_playerGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
	}

	public void OnEntityCreate()
	{
		int frameCount = Time.frameCount;
		int num = 0;
		foreach (PlayerEntity item in _playerGroup)
		{
			if (item.isCameraOwner || (frameCount - num++) % 10 == 0)
			{
				CreatePlayerEffect(item);
			}
		}
	}

	public void OnPlayback()
	{
		OnEntityCreate();
	}

	private void CreatePlayerEffect(PlayerEntity player)
	{
		if (player.IsDead() || !player.hasSkill || player.skill.Status == null)
		{
			return;
		}
		foreach (KeyValuePair<int, PlayerInfoComponent.StatusDes> item in player.skill.Status)
		{
			PlayerInfoParticleLoopEffectData playerInfoParticleLoopEffectData = ParticleManager.Instance().GetPlayerInfoParticleLoopEffectData(item.Key);
			if (playerInfoParticleLoopEffectData == null)
			{
				continue;
			}
			string name = playerInfoParticleLoopEffectData.GetName();
			EntityEffectId entityEffectId = new EntityEffectId(player.entityId.Value, name);
			SceneObjectEntity entityWithPlayerEffectId = _sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId);
			if (entityWithPlayerEffectId == null)
			{
				LoadRequests loadRequests = new LoadRequests();
				List<string> womanEffectList = playerInfoParticleLoopEffectData.WomanEffectList;
				string text = "";
				text = ((playerInfoParticleLoopEffectData.isWeaponSkin != 0) ? string.Format("{0}{1}", "weaponskin/", player.currentWeapon.SkinName) : string.Format("{0}{1}", "weapon/", player.currentWeapon.WeaponInfo.Name));
				for (int i = 0; i < womanEffectList.Count; i++)
				{
					loadRequests.AddAsset(womanEffectList[i], new AssetInfo(text, playerInfoParticleLoopEffectData.GetName() + "_" + womanEffectList[i], typeof(GameObject)));
				}
				entityWithPlayerEffectId = _sceneObjectContext.CreateEntity();
				entityWithPlayerEffectId.AddPlayerEffectId(entityEffectId);
				entityWithPlayerEffectId.AddPosition(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()));
				entityWithPlayerEffectId.AddScale(Vector3.one);
				List<int> effectList = playerInfoParticleLoopEffectData.GetEffectList();
				List<bool> list = new List<bool>();
				for (int j = 0; j < effectList.Count; j++)
				{
					list.Add(item: false);
				}
				entityWithPlayerEffectId.AddPlayerParticleLoopEffect(player.entityId.Value, item.Key, 0, 860, effectList, list, womanEffectList);
				entityWithPlayerEffectId.AddLoadUnityObjects(loadRequests, entityEffectId);
			}
		}
	}
}
