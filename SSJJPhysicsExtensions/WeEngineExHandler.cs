using SSJJPhysics;
using physics;
using physics.engine;
using physics.engine.business;
using physics.engine.entity;

namespace SSJJPhysicsExtensions;

public class WeEngineExHandler : BaseWeEngineExHandler
{
	public WeEngineExHandler(Contexts contexts)
		: base(contexts)
	{
	}

	public override IWeShapeFlagHelper CreateShapeFlagHelper()
	{
		return new WeShapeFlagHelper(_contexts.battleRoom.roomData.Data.RaceType);
	}

	public override WeTrace CreateTrace(WeScene scene, IPyEntityManager entityManager, EngineProfiler profiler)
	{
		return new WeTraceEx(_contexts, scene, entityManager, profiler);
	}
}
