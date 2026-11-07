using System.Collections.Generic;
using Assets.Sources.Components.SceneObject.EngineEntityHpBar;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using NetData;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.EngineEntity;

internal class EngineEntityHpBarUpdateSystem : IPlaybackSystem
{
	private SnapshotContext _snapshotContext;

	private BattleRoomContext _battleRoomContext;

	private SceneObjectContext _sceneObjectContext;

	private PlayerContext _playerContext;

	public EngineEntityHpBarUpdateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_battleRoomContext = contexts.battleRoom;
		_sceneObjectContext = contexts.sceneObject;
		_playerContext = contexts.player;
	}

	public void OnPlayback()
	{
		if (RuleUtilty.IsPitRule(_battleRoomContext) || !_snapshotContext.hasSnapshots || _snapshotContext.snapshots.NowSnapshot == null || Contexts.sharedInstance.weapon.currentWeaponEntity == null || !_playerContext.isCameraOwner)
		{
			return;
		}
		int entityId = _playerContext.cameraOwnerEntity.normalTrace.EntityId;
		foreach (KeyValuePair<int, SimpleEngineEntityData> item in _snapshotContext.snapshots.NowSnapshot.SimpleEngineEntityDataDict)
		{
			SceneObjectEntity sceneObjectEntity = ContextsExtensions.GetEntityWithPlayerEffectId(Id: new EntityEffectId(item.Value.Id, "EngineEntity"), context: _sceneObjectContext);
			SimpleEngineEntityData value = item.Value;
			if (sceneObjectEntity == null)
			{
				continue;
			}
			EngineEntityHpBarComponent engineEntityHpBar = sceneObjectEntity.engineEntityHpBar;
			if (!(engineEntityHpBar.HpBarTran != null))
			{
				continue;
			}
			if (entityId != value.Id)
			{
				if (engineEntityHpBar.UnderCross)
				{
					engineEntityHpBar.UnderCross = false;
					engineEntityHpBar.HpBarObj.SetActive(value: false);
				}
				continue;
			}
			if (!engineEntityHpBar.UnderCross)
			{
				engineEntityHpBar.UnderCross = true;
				engineEntityHpBar.HpBarObj.SetActive(value: true);
			}
			float num = ((value.MaxHp > 0) ? ((float)value.Hp / (float)value.MaxHp) : 0f);
			if (num > 0.66f)
			{
				if (engineEntityHpBar.CurrSprite != 1)
				{
					engineEntityHpBar.CurrSprite = 1;
					engineEntityHpBar.HpBarSprite.sprite = engineEntityHpBar.SpriteList[0];
				}
			}
			else if (num > 0.33f)
			{
				if (engineEntityHpBar.CurrSprite != 2)
				{
					engineEntityHpBar.CurrSprite = 2;
					engineEntityHpBar.HpBarSprite.sprite = engineEntityHpBar.SpriteList[1];
				}
			}
			else if (engineEntityHpBar.CurrSprite != 3)
			{
				engineEntityHpBar.CurrSprite = 3;
				engineEntityHpBar.HpBarSprite.sprite = engineEntityHpBar.SpriteList[2];
			}
			float num2 = (float)value.Hp / (float)value.MaxHp;
			if (num2 != engineEntityHpBar.HpPercent)
			{
				engineEntityHpBar.HpBarSprite.fillAmount = num2;
				engineEntityHpBar.HpPercent = num2;
			}
			SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(engineEntityHpBar.EntityId);
			Vector3 vector = VectorCoordConverter.SsjjToUnity(entityWithEntityId.position.Origin + new Vector3(0f, 0f, entityWithEntityId.hasSceneObjectPyhsics ? ((float)(entityWithEntityId.sceneObjectPyhsics.Brushs[0].maxs.z - entityWithEntityId.sceneObjectPyhsics.Brushs[0].mins.z)) : 250f));
			if (sceneObjectEntity.position.Origin != vector)
			{
				sceneObjectEntity.position.Origin = vector;
				engineEntityHpBar.HpBarTran.localPosition = vector;
			}
		}
	}
}
