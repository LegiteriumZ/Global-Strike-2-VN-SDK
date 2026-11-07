using System;
using Assets.Scripts.QuickRuntimeConsole;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Snapshot;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.CameraEffect;
using Assets.Sources.Info.Effect.FirstPlayerEffect;
using Assets.Sources.Info.Effect.PlayerEffect;
using Assets.Sources.Info.Effect.SceneBufferEffect;
using Assets.Sources.Info.LinkObject;
using Assets.Sources.Info.MoveObject;
using Assets.Sources.Info.Npc;
using Assets.Sources.Modules.WorldCamera;

namespace Assets.Sources.Modules.BattleRoom;

public class BattleBeginSystem : IPreRenderSystem
{
	private readonly Contexts _contexts;

	public BattleBeginSystem(Contexts contexts)
	{
		_contexts = contexts;
		InitTypes();
	}

	private void InitTypes()
	{
		CommandFactory.InitTypes();
		CameraEffectInfoFactory.InitTypes();
		FirstPlayerEffectInfoFactory.InitTypes();
		PlayerEffectInfoFactory.InitTypes();
		LinkObjectInfoFactory.InitTypes();
		NpcInfoFactory.InitTypes();
		MoveObjectInfoFactory.InitTypes();
		SceneBuffEffectInfoFactory.InitTypes();
		CameraLogicFactory.InitTypes();
		CameraLogicFactory.ForeachDone();
	}

	public void OnPreRender()
	{
		GameStart(_contexts.snapshot.snapshots, _contexts.battleRoom, _contexts.time.time);
	}

	private void GameStart(SnapshotsComponent snapshotsComp, BattleRoomContext battleRoomContext, TimeComponent timeComp)
	{
		GameStateComponent gameState = battleRoomContext.gameState;
		if (gameState.State == BattleGameState.WaitingSnapshot && snapshotsComp.AnySnapshotReceived && battleRoomContext.hasRoomData)
		{
			gameState.State = BattleGameState.Gaming;
			timeComp.GameBeginTime = DateTime.Now;
		}
		if (OfflineGameController.setting != null && OfflineGameController.setting.TurnOn)
		{
			gameState.State = BattleGameState.Gaming;
		}
	}
}
