using Assets.Sources.Config;
using NetData;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GameWinDataHandler : ApcPacketHandler<object>
{
	private readonly LoggerAdapter _loggerAdapter = new LoggerAdapter(typeof(GameWinDataHandler));

	public override int MethodId()
	{
		return 5;
	}

	public override void Handle(object data)
	{
		Debug.LogError("收到win消息");
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(23, new UnityProxyData
		{
			Type = UnityProxyType.EVENT,
			Func = "GAME_WIN",
			Key = TplManager.Instance.GameBootConfig.Sign
		});
		_loggerAdapter.Info("Recive Game Over Handler, LogOut");
		Contexts.sharedInstance.battleServer.battleServer.Server.Disconnect();
	}
}
