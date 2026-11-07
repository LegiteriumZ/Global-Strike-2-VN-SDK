using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BigHeadMessageHandler : ApcPacketHandler<BigHeadMessageData>
{
	private MessageContext _messageContext;

	public BigHeadMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 65;
	}

	public override void Handle(BigHeadMessageData data)
	{
		_messageContext.bigHeadMessage.BigHeadMessages.Clear();
		_messageContext.bigHeadMessage.BigHeadMessages.Add(data);
		NotifyManager.ForceInvoke(52);
		_messageContext.bigHeadMessage.Changed = true;
		NotifyManager.ForceInvoke(55);
		_messageContext.bigHeadMessage.Type = data.Type;
		switch (data.Type)
		{
		case BigHeadMessageType.MAXHERO:
			_messageContext.bigHeadMessage.CanChangeHero = false;
			_messageContext.bigHeadMessage.WateHeroDebut = false;
			break;
		case BigHeadMessageType.CANHERODEBUT:
			_messageContext.bigHeadMessage.CanChangeHero = true;
			_messageContext.bigHeadMessage.WateHeroDebut = false;
			break;
		case BigHeadMessageType.WATEHERODEBUT:
			_messageContext.bigHeadMessage.WateHeroDebut = true;
			break;
		case BigHeadMessageType.LASTTIME:
			_messageContext.bigHeadMessage.LastTime = true;
			break;
		case BigHeadMessageType.SHOWHERO:
			_messageContext.bigHeadMessage.BigHeadKingNum = data.BigHeadKingNum;
			_messageContext.bigHeadMessage.MaxHeroNum = data.MaxHeroNum;
			break;
		case BigHeadMessageType.HERODEBUT:
		case BigHeadMessageType.BIGHEADKING:
		case BigHeadMessageType.SHOWTREATMENT:
			break;
		}
	}
}
