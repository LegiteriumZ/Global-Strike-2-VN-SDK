using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class HitMarkPlayerHandler : ApcPacketHandler<HitMarkInfoData>
{
	private MessageContext _messageContext;

	public HitMarkPlayerHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 230;
	}

	public override void Handle(HitMarkInfoData data)
	{
		_messageContext.hitMark.Damage = data.Damage;
		_messageContext.hitMark.HitMark = data.HitMark;
		_messageContext.hitMark.Changed = true;
	}
}
