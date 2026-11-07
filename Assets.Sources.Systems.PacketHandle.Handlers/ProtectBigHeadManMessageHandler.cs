using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class ProtectBigHeadManMessageHandler : ApcPacketHandler<ProtectBigHeadMessageData>
{
	private GameRuleContext _gameRuleContext;

	public ProtectBigHeadManMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 802;
	}

	public override void Handle(ProtectBigHeadMessageData data)
	{
		if (data.Type == ProtectBigHeadMessageType.CHANGEBIGHEADMAN)
		{
			_gameRuleContext.protectBigHeadCareer.tipShowTime = 3000f;
			return;
		}
		_gameRuleContext.protectBigHeadCareer.hasData = true;
		_gameRuleContext.protectBigHeadCareer.team1Data = data.BigHeadMan1;
		_gameRuleContext.protectBigHeadCareer.team2Data = data.BigHeadMan2;
	}
}
