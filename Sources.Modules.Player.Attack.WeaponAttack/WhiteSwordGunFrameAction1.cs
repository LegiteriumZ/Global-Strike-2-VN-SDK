using System;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using Entitas;
using I2.Loc;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJPhysics;
using UnityEngine;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class WhiteSwordGunFrameAction1 : IFrameCmdAction, ICmdAction
{
	private readonly IGroup<SceneObjectEntity> _effectGroup;

	private readonly MessageContext _messageContext;

	private static readonly int TraceDistance = 999999;

	private static readonly float[] Zero = new float[3];

	private static Vector3 _tracePos = Vector3.zero;

	public WhiteSwordGunFrameAction1(Contexts contexts)
	{
		_messageContext = contexts.message;
		_effectGroup = Contexts.sharedInstance.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PredictionEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	private bool IsSkill1Active(WeaponEntity currentWeapon)
	{
		return currentWeapon.basicInfo.Data.RpgMaxPower == 1;
	}

	public virtual bool Action(ref CommonWeaponArg arg)
	{
		if (IsSkill1Active(arg.CurrentWeapon))
		{
			MouseLogic(arg.Player, arg.CurrentWeapon);
		}
		return true;
	}

	protected void MouseLogic(PlayerEntity player, WeaponEntity currentWeapon)
	{
		Vector3 endPos = FireUtility.TraceWorldInDistance(player, currentWeapon);
		if (!endPos.Equals(Vector3.zero))
		{
			AddSkillMarkEntity(endPos, currentWeapon);
		}
	}

	public static Vector3 TraceWorldInDistance(PlayerEntity player, WeaponEntity currentWeapon)
	{
		TraceResult traceResult = FireUtility.Fire(player, currentWeapon, 0, TraceDistance, Zero, Zero);
		if (traceResult.EntityId != -1)
		{
			PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(traceResult.EntityId);
			if (entityWithEntityId != null)
			{
				if (player.OnGround())
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

	protected virtual void MarkFailedHint()
	{
		_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("OUT_OF_RANGE"), 100);
		NotifyManager.ForceInvoke(38);
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
			AssetInfo markEffectAsset = GetMarkEffectAsset(currentWeapon);
			sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(markEffectAsset), -1);
			sceneObjectEntity.isPredictionEffect = true;
		}
		sceneObjectEntity.ReplaceLifeTime(DateTime.Now, 100);
		sceneObjectEntity.ReplacePosition(endPos);
	}

	protected virtual AssetInfo GetMarkEffectAsset(WeaponEntity currentWeapon)
	{
		return new AssetInfo("weapon/" + currentWeapon.basicInfo.Data.WeaponName, $"Assets/Res/Assets/weapon/{currentWeapon.basicInfo.Data.WeaponName}/effect/11470_biaoji/Prefab/11470_biaoji.prefab");
	}
}
