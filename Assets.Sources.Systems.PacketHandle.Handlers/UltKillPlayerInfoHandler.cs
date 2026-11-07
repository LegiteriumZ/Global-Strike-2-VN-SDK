using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class UltKillPlayerInfoHandler : ApcPacketHandler<UltKillPlayerData>
{
	private GameRuleContext _gameRuleContext;

	public UltKillPlayerInfoHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 237;
	}

	public override void Handle(UltKillPlayerData data)
	{
		_gameRuleContext.killPlayerInfo.UltKillInfoList.Add(data);
		_gameRuleContext.killPlayerInfo.Changed = true;
	}
}
