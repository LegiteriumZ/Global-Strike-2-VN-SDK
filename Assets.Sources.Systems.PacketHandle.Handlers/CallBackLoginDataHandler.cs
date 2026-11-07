using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Config;
using NetData;
using SSJJBase.Logger;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class CallBackLoginDataHandler : ApcPacketHandler<CallBackLoginData>
{
	private readonly BattleRoomContext _battleGameContext;

	public CallBackLoginDataHandler(Contexts contexts)
	{
		_battleGameContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 1;
	}

	public override void Handle(CallBackLoginData data)
	{
		this.Debug("OnLoginCallback");
		if (data.Res)
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(23, new UnityProxyData
			{
				Type = UnityProxyType.CALLMSG,
				Func = "LoginSucc",
				Key = TplManager.Instance.GameBootConfig.Sign
			});
			_battleGameContext.gameState.State = BattleGameState.WaitingP2P;
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(23, new UnityProxyData
			{
				Type = UnityProxyType.CALLMSG,
				Func = "getRoomInfo",
				Key = TplManager.Instance.GameBootConfig.Sign
			});
		}
	}
}
