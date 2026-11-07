using Assets.Sources.Systems.PacketHandle.Handlers;
using SSJJ.Data;
using SSJJBase.Logger;

namespace Assets.Sources.Ui.ForUiTest.MultiPlayer;

public class Tcp_TcpConnectionId_Handler : ApcPacketHandler<TcpConnectionIDData>
{
	private MultiPlayerBattleServer _server;

	public Tcp_TcpConnectionId_Handler(MultiPlayerBattleServer server)
	{
		_server = server;
	}

	public override int MethodId()
	{
		return 1000;
	}

	public override void Handle(TcpConnectionIDData data)
	{
		this.Info("Tcp_TcpConnectionId_Handler recieved tcpId: " + data.Id);
		_server.ConnectionId = data.Id;
	}
}
