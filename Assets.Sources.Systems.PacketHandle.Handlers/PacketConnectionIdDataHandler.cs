using SSJJ.Data;
using SSJJBase.Logger;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class PacketConnectionIdDataHandler : ApcPacketHandler<TcpConnectionIDData>
{
	private readonly BattleServerContext _context;

	public PacketConnectionIdDataHandler(Contexts contexts)
	{
		_context = contexts.battleServer;
	}

	public override int MethodId()
	{
		return 1000;
	}

	public override void Handle(TcpConnectionIDData data)
	{
		this.Info("PacketConnectionIdDataHandler recieved tcpId: " + data.Id);
		_context.battleServer.Server.ConnectionId = data.Id;
	}
}
