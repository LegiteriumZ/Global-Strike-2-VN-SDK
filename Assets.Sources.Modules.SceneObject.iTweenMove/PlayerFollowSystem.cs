using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;
using SSJJPhysics;
using SSJJUserCmd;
using UnityEngine;
using config;
using physics.data;
using physics.entity;
using physics.trace;
using share;
using share.utility;
using wooduanITween.confData;

namespace Assets.Sources.Modules.SceneObject.iTweenMove;

public class PlayerFollowSystem : IPredicateSystem
{
	private IGroup<SceneObjectEntity> _group;

	private BattleRoomContext _battleRoomContext;

	private List<CBrush> _brushes = new List<CBrush>(8);

	public PlayerFollowSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.iTweenMove, SceneObjectMatcher.SceneObjectPyhsics, SceneObjectMatcher.TweenMoveHistory));
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		foreach (SceneObjectEntity item in _group)
		{
			CheckFollow(player, item, cmd);
		}
	}

	private List<CBrush> GetBrush(SceneObjectEntity sceneItem)
	{
		_brushes.Clear();
		if (sceneItem.sceneObjectPyhsics.PhysicsEntity is BasePyPlayerAdapter basePyPlayerAdapter)
		{
			_brushes.Add(basePyPlayerAdapter.GetBrush());
			return _brushes;
		}
		IPyEntity physicsEntity = sceneItem.sceneObjectPyhsics.PhysicsEntity;
		if (physicsEntity is IPyItweenMoveEntity)
		{
			(physicsEntity as IPyItweenMoveEntity).GetItemBrushList();
		}
		else
		{
			physicsEntity.GetBrush();
		}
		return sceneItem.sceneObjectPyhsics.Brushs;
	}

	private void CheckFollow(PlayerEntity player, SceneObjectEntity sceneItem, IUserCmd cmd)
	{
		bool flag = true;
		if ((sceneItem.iTweenMove.MoveToTweenEntity != null && sceneItem.iTweenMove.MoveToTweenEntity.GetIsLoopRestart()) || (sceneItem.iTweenMove.RotateToTweenEntity != null && sceneItem.iTweenMove.RotateToTweenEntity.GetIsLoopRestart()) || (sceneItem.iTweenMove.PathTweenEntity != null && sceneItem.iTweenMove.PathTweenEntity.GetIsLoopRestart()))
		{
			flag = IsSolidNearBrush(player, sceneItem);
		}
		bool flag2 = false;
		if (flag)
		{
			if (player.move.getPml().groundTrace.entityId == sceneItem.entityId.Value)
			{
				flag2 = true;
			}
			else if (!player.OnGround())
			{
				List<CBrush> brush = GetBrush(sceneItem);
				for (int i = 0; i < brush.Count; i++)
				{
					CBrush cBrush = brush[i];
					if (sceneItem.tweenMoveHistory.LastOrigin.z + cBrush.bounds[1][2] >= player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z && IsSolidNearBrush(player, sceneItem))
					{
						flag2 = true;
						break;
					}
				}
			}
		}
		Vector3 origin = sceneItem.position.Origin;
		Vector3 eulerAngles = sceneItem.rotation.EulerAngles;
		Vector3 lastOrigin = sceneItem.tweenMoveHistory.LastOrigin;
		Vector3 lastAngle = sceneItem.tweenMoveHistory.LastAngle;
		Vector3 vector = origin - lastOrigin;
		Vector3 vector2 = eulerAngles - lastAngle;
		if (flag2)
		{
			Matrix3D offsetMatrix = sceneItem.tweenMoveHistory.getOffsetMatrix();
			BeControllerEntity beControllerEntity = sceneItem.tweenMoveHistory.getBeControllerEntity();
			if (beControllerEntity.GetRotation() == null)
			{
				beControllerEntity.SetRotation(new Vector3D());
			}
			beControllerEntity.GetRotation().SetTo(eulerAngles.x, eulerAngles.y, eulerAngles.z);
			SceneItweenEntityUtility.UpdateFollowPlayer(player.move.PyPlayerMove.GetEntity() as IPyPlayerEntity, (IPySceneItweenMoveEntity)sceneItem.sceneObjectPyhsics.PhysicsEntity, _battleRoomContext.pyEngine.PyEngine, _battleRoomContext.pyEngine.PyEngine.GetWorld(), beControllerEntity, origin.x, origin.y, origin.z, offsetMatrix, vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, lastOrigin.x, lastOrigin.y, lastOrigin.z);
			player.postionErrorSmooth.Clear();
		}
	}

	public bool IsSolidNearBrush(PlayerEntity player, SceneObjectEntity sceneItem)
	{
		if (!(player.move.PyPlayerMove.GetEntity() is IPyPlayerEntity pyPlayerEntity))
		{
			return false;
		}
		List<CBrush> brush = GetBrush(sceneItem);
		IPyWorld world = _battleRoomContext.pyEngine.PyEngine.GetWorld();
		Trace trace = TraceObjectPool.AllocateTrace();
		Vector3D vec = TraceObjectPool.AllocateVector3D();
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		float[] array3 = TraceObjectPool.AllocateFloat3();
		float[] array4 = TraceObjectPool.AllocateFloat3();
		try
		{
			Vector3D boundsMinForPlayer = BoundBoxConfig.GetBoundsMinForPlayer(pyPlayerEntity.GetCareer(), pyPlayerEntity.GetDuckState());
			Vector3D boundsMaxForPlayer = BoundBoxConfig.GetBoundsMaxForPlayer(pyPlayerEntity.GetCareer(), pyPlayerEntity.GetDuckState());
			VectorUtils.Vector3DToFloat3(boundsMinForPlayer, array2);
			VectorUtils.Vector3DToFloat3(boundsMaxForPlayer, array3);
			array[0] = (float)pyPlayerEntity.GetX();
			array[1] = (float)pyPlayerEntity.GetY();
			array[2] = (float)pyPlayerEntity.GetZ();
			array4[0] = (float)pyPlayerEntity.GetX();
			array4[1] = (float)pyPlayerEntity.GetY();
			array4[2] = (float)pyPlayerEntity.GetZ() - 1f;
			for (int i = 0; i < brush.Count; i++)
			{
				CBrush cBrush = brush[i];
				cBrush.UpdateBrushSide(null);
				world.BrushTrace(trace, array, array4, array2, array3, cBrush);
				if (trace.fraction < 1f)
				{
					return true;
				}
			}
			return false;
		}
		finally
		{
			TraceObjectPool.ReturnTrace(trace);
			TraceObjectPool.ReturnVector3D(vec);
			TraceObjectPool.ReturnFloat3(array);
			TraceObjectPool.ReturnFloat3(array2);
			TraceObjectPool.ReturnFloat3(array3);
			TraceObjectPool.ReturnFloat3(array4);
		}
	}
}
