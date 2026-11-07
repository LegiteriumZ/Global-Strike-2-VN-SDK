using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Entitas;
using SSJJPhysics;
using UnityEngine;
using config;
using physics.trace;
using share;
using share.constant;

public class bioUnionBaseSoulUIProvider : IbioUnionBaseSoulUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	protected BattleRoomContext _battleRooomContext;

	public readonly int VISIBLE_FOOT = 1;

	public readonly int VISIBLE_HEAD = 2;

	public readonly int VISIBLE_BELLY = 4;

	public readonly int VISIBLE_CHEST = 8;

	public readonly int VISIBLE_ALL = 15;

	public readonly int VISIBLE_UNDEFINED = 16;

	private bool isGhost;

	private bool inViewLastFrame;

	public bioUnionBaseSoulUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_battleRooomContext = contexts.battleRoom;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.bioUnionBaseData.changeToGhostCountDown > 0)
		{
			_gameRuleContext.bioUnionBaseData.changeToGhostCountDown -= time.FrameInterval;
		}
		if (_playerContext.myPlayerEntity != null)
		{
			isGhost = _playerContext.myPlayerEntity.HasStatus(PlayerInfoStatusConstant.NO_CLIP_BOUND.ID);
			if (isGhost)
			{
				inViewLastFrame = checkIsInView();
			}
		}
	}

	public bool checkRootShow()
	{
		return isGhost;
	}

	private bool checkIsInView()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		List<IEntity> entities = _playerContext.GetEntities();
		World world = _battleRooomContext.pyEngine.PyEngine.GetWorld() as World;
		for (int i = 0; i < entities.Count; i++)
		{
			if (entities[i] != myPlayerEntity && isEntityVisible(world, myPlayerEntity, entities[i] as PlayerEntity, 360.0, VISIBLE_ALL) > 0)
			{
				return true;
			}
		}
		return false;
	}

	public int isEntityVisible(World world, PlayerEntity viewer, PlayerEntity target, double fov, int flags)
	{
		int num = 0;
		float viewYaw = viewer.GetViewYaw();
		float viewPitch = viewer.GetViewPitch();
		new Vector3D(viewYaw, viewPitch, 0.0);
		Vector3D boundsMaxForPlayer = BoundBoxConfig.GetBoundsMaxForPlayer(target.GetCareer(), target.GetDuckState());
		Vector3D boundsMinForPlayer = BoundBoxConfig.GetBoundsMinForPlayer(target.GetCareer(), target.GetDuckState());
		Vector3D vector3D = new Vector3D(target.GetX(), target.GetY(), target.GetZ());
		Vector3D vector3D2 = new Vector3D(vector3D.x, vector3D.y, vector3D.z);
		Vector3D vector3D3 = new Vector3D(vector3D.x, vector3D.y, vector3D.z);
		Vector3D vector3D4 = new Vector3D();
		Vector3D.Add(boundsMaxForPlayer, boundsMinForPlayer, vector3D4);
		Vector3D.Scale(vector3D4, 0.5, vector3D4);
		Vector3D.Add(vector3D, vector3D4, vector3D4);
		Vector3D vector3D5 = vector3D4.Clone();
		vector3D5.z += (boundsMaxForPlayer.z - boundsMinForPlayer.z) / 4.0;
		vector3D3.z = vector3D4.z + (boundsMaxForPlayer.z - boundsMinForPlayer.z) / 2.0;
		vector3D2.z = vector3D4.z - (boundsMaxForPlayer.z - boundsMinForPlayer.z) / 2.0;
		float num2 = 0f;
		num2 = ((viewer.GetDuckState() != 1) ? ((float)ViewHeight.GetNormalViewHeight(viewer.GetCareer())) : ((float)ViewHeight.GetDuckViewHeight(viewer.GetCareer())));
		Vector3D boundsMinForPlayer2 = BoundBoxConfig.GetBoundsMinForPlayer(viewer.GetCareer(), viewer.GetDuckState());
		Vector3D start = new Vector3D(viewer.GetX(), viewer.GetY(), viewer.GetZ() + boundsMinForPlayer2.z + (double)num2);
		Trace trace = TraceObjectPool.AllocateTrace();
		Trace trace2 = TraceObjectPool.AllocateTrace();
		Trace trace3 = TraceObjectPool.AllocateTrace();
		Trace trace4 = TraceObjectPool.AllocateTrace();
		try
		{
			if ((flags & VISIBLE_FOOT) > 0)
			{
				world.RayTraceByPlayerTeam(trace, start, vector3D2, target.GetTeam());
				if (trace.fraction >= 1f || trace.entityId == target.GetId())
				{
					num |= VISIBLE_FOOT;
				}
			}
			if ((flags & VISIBLE_BELLY) > 0)
			{
				world.RayTraceByPlayerTeam(trace2, start, vector3D4, target.GetTeam());
				if (trace2.fraction >= 1f || trace2.entityId == target.GetId())
				{
					num |= VISIBLE_BELLY;
				}
			}
			if ((flags & VISIBLE_HEAD) > 0)
			{
				world.RayTraceByPlayerTeam(trace3, start, vector3D3, target.GetTeam());
				if (trace3.fraction >= 1f || trace3.entityId == target.GetId())
				{
					num |= VISIBLE_HEAD;
				}
			}
			if ((flags & VISIBLE_CHEST) > 0)
			{
				world.RayTraceByPlayerTeam(trace4, start, vector3D5, target.GetTeam());
				if (trace4.fraction >= 1f || trace4.entityId == target.GetId())
				{
					num |= VISIBLE_CHEST;
				}
			}
		}
		finally
		{
			if (trace != null)
			{
				TraceObjectPool.ReturnTrace(trace);
			}
			if (trace2 != null)
			{
				TraceObjectPool.ReturnTrace(trace2);
			}
			if (trace3 != null)
			{
				TraceObjectPool.ReturnTrace(trace3);
			}
			if (trace4 != null)
			{
				TraceObjectPool.ReturnTrace(trace4);
			}
		}
		return num;
	}

	public bool checkInViewtShow()
	{
		return inViewLastFrame;
	}

	public bool checkOutViewtShow()
	{
		return !inViewLastFrame;
	}

	public float updateTimeCount()
	{
		return Mathf.Ceil((float)_gameRuleContext.bioUnionBaseData.changeToGhostCountDown / 1000f);
	}

	public string updateCareerImg()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		return ("/ui/GameGUIRes/halfLoadedRes/bio3SelectVariant/" + myPlayerEntity.GetCareer()) ?? "";
	}
}
