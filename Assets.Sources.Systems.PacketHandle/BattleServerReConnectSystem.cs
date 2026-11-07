using System;
using Assets.Sources.Components.BattleServer;
using Assets.Sources.Utils;
using Entitas;

namespace Assets.Sources.Systems.PacketHandle;

public class BattleServerReConnectSystem : IExecuteSystem, ISystem
{
	private readonly BattleServerContext _battleServerContext;

	private readonly SnapshotContext _snapshotContext;

	public BattleServerReConnectSystem(Contexts contexts)
	{
		_battleServerContext = contexts.battleServer;
		_snapshotContext = contexts.snapshot;
	}

	public void Execute()
	{
		if (GameController.Instance == null || _battleServerContext.battleServer.Server == null)
		{
			return;
		}
		HealthComponent health = _battleServerContext.battleServerEntity.health;
		if (_snapshotContext.snapshots.LatestSnapshot == null)
		{
			return;
		}
		if (DateTime.Now.Subtract(_snapshotContext.snapshots.ReceiveSnapshotTime).TotalMilliseconds > 2000.0)
		{
			health.IsConnected = false;
			long num = TimeUtility.UnixTimeNow();
			if (num - health.ReConnectStartTime > 10000)
			{
				health.ReConnectCount++;
				health.ReConnectStartTime = num;
			}
		}
		else
		{
			health.IsConnected = true;
			health.ReConnectCount = 0;
			health.ReConnectStartTime = 0L;
		}
	}
}
