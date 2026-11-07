using System;
using Assets.Scripts;
using Assets.Sources.Config;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Thread;
using SSJJNetworking.BattleServer;

public class ConnectToServerUtility
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(ConnectToServerUtility));

	public static void GetServerInfo(out string remoteAddress, out int tcpPort, out int udpPort)
	{
		if (GameEnvironment.IsLocalBattleServer)
		{
			remoteAddress = "127.0.0.1";
			tcpPort = 1800;
			udpPort = tcpPort + 150;
		}
		else
		{
			remoteAddress = TplManager.Instance.GetBootConfig().BattleServerIp;
			tcpPort = TplManager.Instance.GetBootConfig().BattleServerTcpPort;
			udpPort = TplManager.Instance.GetBootConfig().BattleServerUdpPort;
		}
	}

	public static void Connect()
	{
		GetServerInfo(out var remoteAddress, out var tcpPort, out var udpPort);
		IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
		IBattleServer battleServer = server;
		battleServer.ConnectEvent = (BattleServerConnectDelegate)Delegate.Combine(battleServer.ConnectEvent, (BattleServerConnectDelegate)delegate(int success, string message)
		{
			UnityMainThreadDispatcher.Enqueue(delegate
			{
				if (success == 0)
				{
					if (TplManager.Instance.GetBootConfig().RoomId > 0)
					{
						LoginData loginData = new LoginData
						{
							RoomId = TplManager.Instance.GetBootConfig().RoomId,
							UserId = TplManager.Instance.GetBootConfig().CharId,
							Timestamp = TplManager.Instance.GetBootConfig().Timestamp,
							Sign = TplManager.Instance.GetBootConfig().Sign,
							LoginType = LoginDataType.Unity,
							NpGray = TplManager.Instance.GameBootConfig.NpOpen
						};
						_logger.InfoFormat("Connect Tcp,Now Send LoginData To Server,RoomId {0} UserId {1} TimeStamp {2} Sign {3} LoginType {4}", loginData.RoomId, loginData.UserId, loginData.Timestamp, loginData.Sign, loginData.LoginType);
						server.SendTcpMessage(2, loginData);
					}
					else
					{
						server.SendTcpMessage(32);
					}
				}
			});
		});
		server.Connect(remoteAddress, tcpPort, udpPort);
	}
}
