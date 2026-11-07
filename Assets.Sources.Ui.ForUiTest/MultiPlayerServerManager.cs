using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Sources.Networking.Packet;
using Assets.Sources.Snapshots;
using Assets.Sources.Systems.PacketHandle;
using Assets.Sources.Ui.ForUiTest.MultiPlayer;
using Assets.Sources.Utils;
using SSJJNetworking.BattleServer;
using SSJJNetworking.Network;

namespace Assets.Sources.Ui.ForUiTest;

public static class MultiPlayerServerManager
{
	public static bool IsSelfMove = true;

	public static bool Open;

	private static List<MultiPlayerBattleServer> _battleServers = new List<MultiPlayerBattleServer>();

	public static List<int> ConnectSelected = new List<int>();

	public static bool SimpleCopy = true;

	public static List<object> MultiPlayerInstances = new List<object>();

	private static TcpSocket _socket;

	public static void Init()
	{
		if (_socket != null)
		{
			return;
		}
		IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
		_socket = server.GetType().GetField("_tcpSocket", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(server) as TcpSocket;
		TcpSocket socket = _socket;
		socket.DisconnectEvent = (TcpSocketDisconnectDelegate)Delegate.Combine(socket.DisconnectEvent, (TcpSocketDisconnectDelegate)delegate
		{
			foreach (MultiPlayerBattleServer battleServer in _battleServers)
			{
				battleServer.Disconnect();
			}
		});
	}

	public static BaseBattleServer Add()
	{
		Init();
		MultiPlayerBattleServer server = new MultiPlayerBattleServer(new SnapShotCompress(), ClientTcpMethod.IgnoreTcpList, SpecailDebug.Instance.GetUdpBytes);
		_battleServers.Add(server);
		MultiPlayerBattleServer multiPlayerBattleServer = server;
		multiPlayerBattleServer.ConnectEvent = (BattleServerConnectDelegate)Delegate.Combine(multiPlayerBattleServer.ConnectEvent, (BattleServerConnectDelegate)delegate(int success, string message)
		{
			ConnectEventHandler.Handle(server, success, message);
		});
		AddUdpHandler(server, new Udp_P2P_Handler(server));
		AddUdpHandler(server, new Udp_Shapshot_Handler(server));
		AddTcpHandler(server, new Tcp_CallbackLogin_Handler(server));
		AddTcpHandler(server, new Tcp_TcpConnectionId_Handler(server));
		ConnectToServerUtility.GetServerInfo(out var remoteAddress, out var tcpPort, out var udpPort);
		server.Connect(remoteAddress, tcpPort, udpPort);
		return server;
	}

	private static void AddTcpHandler<T>(MultiPlayerBattleServer server, IPacketHandler<T> sub)
	{
		server.RegisterTcpHandler(sub.MethodId(), sub.Handle, sub.Parser);
	}

	private static void AddUdpHandler<T>(MultiPlayerBattleServer server, IPacketHandler<T> sub)
	{
		server.RegisterUdpHandler(sub.MethodId(), sub.Handle, sub.Parser);
	}

	public static void Update()
	{
		foreach (MultiPlayerBattleServer battleServer in _battleServers)
		{
			battleServer.Update();
		}
	}

	public static void Remove(int id)
	{
		MultiPlayerBattleServer multiPlayerBattleServer = Get(id);
		if (multiPlayerBattleServer != null)
		{
			_battleServers.Remove(multiPlayerBattleServer);
			multiPlayerBattleServer.Disconnect();
		}
	}

	public static MultiPlayerBattleServer Get(int id)
	{
		foreach (MultiPlayerBattleServer battleServer in _battleServers)
		{
			if (battleServer.ConnectionId == id)
			{
				return battleServer;
			}
		}
		return null;
	}

	public static List<MultiPlayerBattleServer> GetList()
	{
		return _battleServers;
	}
}
