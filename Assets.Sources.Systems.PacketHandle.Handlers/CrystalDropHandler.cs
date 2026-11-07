using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class CrystalDropHandler : ApcPacketHandler<CrystalDropData>
{
	private GameRuleContext _gameRuleContext;

	public CrystalDropHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 36;
	}

	public override void Handle(CrystalDropData data)
	{
		_gameRuleContext.crystalDropData.FirstDrop = data.FirstDrop;
		_gameRuleContext.crystalDropData.CrystalNum = data.Num;
		NotifyManager.ForceInvoke(33);
	}
}
