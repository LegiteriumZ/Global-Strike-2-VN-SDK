using SSJJPhysics;
using data;
using physics;
using physics.engine;
using physics.engine.business;
using physics.engine.entity;
using physics.impl;
using physics.trace;

namespace SSJJPhysicsExtensions;

public class WeEngineHandler : DefaultWeEngineHandler
{
	private readonly Contexts _contexts;

	public WeEngineHandler(Contexts contexts)
	{
		_contexts = contexts;
	}

	public override ISceneMoveData CreateSceneMoveData()
	{
		return new SceneMoveData();
	}

	public override WeTrace CreateTrace(WeScene scene, IPyEntityManager entityManager, EngineProfiler profiler)
	{
		return new WeTraceEx(_contexts, scene, entityManager, profiler);
	}

	public override IPyWorld CreateWorld(IPyTrace trace, IPyClipMap clipMap, ISceneMoveData moveData)
	{
		return new WeWorld(clipMap, trace, moveData);
	}

	public override IPyMove CreatePmove(IPyEntityMove entityMove, IPyWorld world, IPyEntityManager entityManager)
	{
		return new Pmove(entityMove, world, entityManager);
	}

	public override IWeShapeFlagHelper CreateShapeFlagHelper()
	{
		return new WeShapeFlagHelper(_contexts.battleRoom.roomData.Data.RaceType);
	}

	public override float[] GetObfuscatorSeed()
	{
		return _contexts.battleRoom.roomData.ObfuscatorSeed;
	}
}
