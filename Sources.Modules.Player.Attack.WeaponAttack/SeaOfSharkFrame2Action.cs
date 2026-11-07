using System;
using Assets.Scripts.Effect.Level;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using Entitas;
using SSJJAsset.Asset;
using SSJJPhysics;
using UnityEngine;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class SeaOfSharkFrame2Action : IFrameCmdAction, ICmdAction
{
	private enum ParticleType
	{
		None,
		Hong,
		Lan
	}

	private readonly IGroup<SceneObjectEntity> _effectGroup;

	private readonly MessageContext _messageContext;

	private Vector3 _startPos;

	private readonly int TraceDistance = 999999;

	private readonly float[] _zero = new float[3];

	private Vector3 _tracePos = Vector3.zero;

	private ParticleType _type;

	public SeaOfSharkFrame2Action(Contexts contexts)
	{
		_messageContext = contexts.message;
		_effectGroup = Contexts.sharedInstance.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PredictionEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (SeaOfSharkLeftAction.IsMiaoZhun(ref arg))
		{
			MouseLogic(ref arg);
		}
		else
		{
			SceneObjectEntity sceneObjectEntity = null;
			using (IGroup<SceneObjectEntity>.Enumator enumator = _effectGroup.GetEnumerator())
			{
				if (enumator.MoveNext())
				{
					sceneObjectEntity = enumator.Current;
				}
			}
			if (sceneObjectEntity != null && sceneObjectEntity.hasUnityObjects)
			{
				GameObject gameObject = sceneObjectEntity.unityObjects.LoadResults[2].GameObject;
				GameObject gameObject2 = sceneObjectEntity.unityObjects.LoadResults[1].GameObject;
				if (gameObject != null)
				{
					gameObject.SetObjectActive(isactive: false);
					sceneObjectEntity.ReplaceLifeTime(DateTime.Now, 100);
				}
				if (gameObject2 != null)
				{
					gameObject2.SetObjectActive(isactive: false);
					sceneObjectEntity.ReplaceLifeTime(DateTime.Now, 100);
				}
			}
		}
		return true;
	}

	private void MouseLogic(ref CommonWeaponArg arg)
	{
		Vector3 endPos = TraceWorldInDistance(arg.Player, arg.CurrentWeapon);
		_startPos.x = arg.Player.GetCompenstatePos(arg.Player.fpos.Change.GetPosIndex()).x;
		_startPos.y = arg.Player.GetCompenstatePos(arg.Player.fpos.Change.GetPosIndex()).y;
		_startPos.z = (float)((double)arg.Player.GetCompenstatePos(arg.Player.fpos.Change.GetPosIndex()).z + arg.Player.move.PyPlayerMove.GetViewHeight());
		AddSkillMarkEntity(_startPos, endPos, arg.CurrentWeapon);
	}

	private Vector3 TraceWorldInDistance(PlayerEntity player, WeaponEntity currentWeapon)
	{
		TraceResult traceResult = FireUtility.Fire(player, currentWeapon, 0, TraceDistance, _zero, _zero);
		if (traceResult.EntityId != -1)
		{
			PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(traceResult.EntityId);
			if (entityWithEntityId != null)
			{
				if (entityWithEntityId.OnGround())
				{
					return entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex());
				}
			}
			else if ((double)traceResult.Plane.normal[2] > 0.7 && traceResult.Fraction < 1f)
			{
				_tracePos.x = traceResult.EndPos[0];
				_tracePos.y = traceResult.EndPos[1];
				_tracePos.z = traceResult.EndPos[2];
				return _tracePos;
			}
		}
		return Vector3.zero;
	}

	private AssetInfo GetInfo(WeaponEntity currentWeapon, ParticleType type)
	{
		return new AssetInfo("weapon/" + currentWeapon.basicInfo.Data.WeaponName, string.Format("Assets/Res/Assets/weapon/{0}/effect/guangquan_{1}/Prefab/guangquan_{1}.prefab", currentWeapon.basicInfo.Data.WeaponName, type.ToString()));
	}

	private void AddSkillMarkEntity(Vector3 startPos, Vector3 endPos, WeaponEntity currentWeapon)
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
			sceneObjectEntity.isPredictionEffect = true;
			LoadRequests loadRequests = new LoadRequests();
			loadRequests.AddAsset(1, GetInfo(currentWeapon, ParticleType.Hong));
			loadRequests.AddAsset(2, GetInfo(currentWeapon, ParticleType.Lan));
			sceneObjectEntity.AddLoadUnityObjects(loadRequests, -1);
			if (sceneObjectEntity.hasUnityObjects)
			{
				GameObject gameObject = sceneObjectEntity.unityObjects.LoadResults[2].GameObject;
				GameObject gameObject2 = sceneObjectEntity.unityObjects.LoadResults[1].GameObject;
				gameObject.SetObjectActive(isactive: false);
				gameObject2.SetObjectActive(isactive: false);
			}
		}
		ParticleType markEffectAsset = GetMarkEffectAsset(startPos, endPos, currentWeapon);
		if (sceneObjectEntity.hasUnityObjects)
		{
			_type = markEffectAsset;
			GameObject gameObject3 = sceneObjectEntity.unityObjects.LoadResults[2].GameObject;
			GameObject gameObject4 = sceneObjectEntity.unityObjects.LoadResults[1].GameObject;
			gameObject3.SetObjectActive(_type == ParticleType.Lan);
			gameObject4.SetObjectActive(_type == ParticleType.Hong);
			ParticleEffectUtility.InitSceneParticle(gameObject3, sceneObjectEntity.unityObjects.LoadResults[2].AssetInfo.AssetName);
			ParticleEffectUtility.InitSceneParticle(gameObject4, sceneObjectEntity.unityObjects.LoadResults[1].AssetInfo.AssetName);
		}
		sceneObjectEntity.ReplaceLifeTime(DateTime.Now, 100);
		sceneObjectEntity.ReplacePosition(endPos);
	}

	private ParticleType GetMarkEffectAsset(Vector3 startPos, Vector3 endPos, WeaponEntity currentWeapon)
	{
		if (Vector3.Distance(startPos, endPos) > (float)currentWeapon.power.RpgMaxPower)
		{
			return ParticleType.Hong;
		}
		return ParticleType.Lan;
	}
}
