using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Scripts.Utility;
using Assets.Sources.Snapshots;
using Assets.Sources.Utils.EventLogger;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJNetworking.BattleServer;
using SSJJNetworking.Network;
using UnityEngine;

namespace Assets.Sources.Networking.Server;

public class BattleServer : BaseBattleServer
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(BattleServer));

	public BattleServer(ISnapShotCompress snapShotCompress, List<int> ignoreTcpList, bool debugUdpBytes, bool auto = true)
		: base(snapShotCompress, ignoreTcpList, debugUdpBytes, auto)
	{
		NetByteFactory.Instance.InitBytes();
	}

	protected override void TcpSocketDisconnect(CloseType type, SocketPhase phase, int socketCode, string socketMessage)
	{
		_logger.Error(string.Concat("tcp socket error,CloseType :", type, " phase : ", phase, ", code : ", socketCode, ", msg : ", socketMessage));
		if (!_isKill)
		{
			return;
		}
		UnityMainThreadDispatcher.Enqueue(delegate
		{
			try
			{
				ForceUnloadResUtility.UnloadRes();
			}
			catch (Exception)
			{
			}
			finally
			{
				BaseAsyncManager.Instance.StartCoRoutine(KillGame());
			}
		});
	}

	private IEnumerator KillGame()
	{
		yield return Yielders.GetWaitForSeconds(1.5f);
		if (Contexts.sharedInstance.battleRoom.hasRoomData)
		{
			RoomData data = Contexts.sharedInstance.battleRoom.roomData.Data;
			if (data != null && data.SceneId > 0)
			{
				TotalMemoryUtility.SumMemory(isGameOver: true);
			}
		}
		MonoBehaviourSingleton<GameExitManager>.Instance.ExitGame();
		ExecuteGG.CloseNPGameMon();
		if (!Application.isEditor)
		{
			Process.GetCurrentProcess().Kill();
		}
	}

	public override void ForceUseTcp()
	{
		base.ForceUseTcp();
		EventLogger.Instance.StageLogger("Connect Tcp For SnapShot", StartStageEnum.LoadSnapShot);
		base.ConnectionId = -1;
	}
}
