using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Constant;
using Assets.Sources.Framework.System;
using Entitas;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.BulletHole;

public class BulletHoleResourceInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	private BattleServerContext _battleServerContext;

	public BulletHoleResourceInitSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
		_battleServerContext = contexts.battleServer;
	}

	private void LoadBulletHole(SceneObjectEntity entity)
	{
		Vector3 vector = VectorCoordConverter.SsjjToUnity(entity.position.Origin);
		Vector3 vector2 = VectorCoordConverter.SsjjToUnity(entity.normal.Normal);
		float num = 0f;
		foreach (LoadResults.MultiTV loadResult in entity.unityObjects.LoadResults)
		{
			GameObject gameObject = loadResult.Value.GameObject;
			gameObject.transform.position = vector + num * vector2;
			gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, vector2);
			BulletHoleEffect component = gameObject.GetComponent<BulletHoleEffect>();
			if (component != null)
			{
				component.UpdateScaleAndOrientatio();
			}
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (!_battleServerContext.battleServer.Server.IsInLocalNetwork || RuleUtilty.IsFlyingKnife(raceType))
			{
				continue;
			}
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				string name = renderer.material.shader.name;
				if (name == "SSJJ/ServerBulletHole" || name == "SSJJ/Diffuse")
				{
					renderer.material.shader = Shader.Find(entity.bulletHole.IsServer ? "SSJJ/ServerBulletHole" : "SSJJ/Diffuse");
					Color color = new Color(1f, 0f, 0f, 0.5f);
					renderer.material.color = (entity.bulletHole.IsServer ? color : Color.white);
					renderer.material.renderQueue = (entity.bulletHole.IsServer ? 3002 : 3001);
				}
			}
		}
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		if (entity.hasBulletHole && entity.hasUnityObjects)
		{
			return entity.hasPosition;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			LoadBulletHole(entity);
		}
	}
}
