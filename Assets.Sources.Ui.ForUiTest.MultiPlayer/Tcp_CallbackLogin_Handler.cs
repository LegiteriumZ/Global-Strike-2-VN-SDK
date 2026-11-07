using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Systems.PacketHandle.Handlers;
using NetData;

namespace Assets.Sources.Ui.ForUiTest.MultiPlayer;

public class Tcp_CallbackLogin_Handler : ApcPacketHandler<CallBackLoginData>
{
	private MultiPlayerBattleServer _server;

	public Tcp_CallbackLogin_Handler(MultiPlayerBattleServer server)
	{
		_server = server;
	}

	public override int MethodId()
	{
		return 1;
	}

	public override void Handle(CallBackLoginData data)
	{
		if (data.Res)
		{
			_server.GameState = BattleGameState.WaitingP2P;
		}
	}
}
