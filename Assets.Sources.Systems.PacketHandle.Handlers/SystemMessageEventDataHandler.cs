using Assets.Sources.Components.Message.Rpg;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class SystemMessageEventDataHandler : ApcPacketHandler<SystemMessageEventData>
{
	private MessageContext _messageContext;

	public SystemMessageEventDataHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 218;
	}

	public override void Handle(SystemMessageEventData data)
	{
		int typeId = data.TypeId;
		switch (typeId)
		{
		case 1001:
		case 1002:
		{
			RpgPopMsgComponent.PopMsg item5 = default(RpgPopMsgComponent.PopMsg);
			item5.Text = data.Args1;
			item5.SameTeam = typeId == 1001;
			_messageContext.rpgPopMsg.MsgQueue.Enqueue(item5);
			break;
		}
		case 1003:
		{
			RpgPopMsgComponent.PopMsg item4 = default(RpgPopMsgComponent.PopMsg);
			item4.Text = data.Args1;
			item4.IsRightDown = true;
			_messageContext.rpgPopMsg.RightDownQueue.Enqueue(item4);
			break;
		}
		case 1004:
		{
			RpgPopMsgComponent.PopMsg item3 = default(RpgPopMsgComponent.PopMsg);
			item3.Text = data.Args1;
			item3.SameTeam = true;
			item3.Type = typeId;
			item3.IsTime = true;
			_messageContext.rpgPopMsg.TimeQueue.Enqueue(item3);
			break;
		}
		case 1005:
		{
			RpgPopMsgComponent.PopMsg item2 = default(RpgPopMsgComponent.PopMsg);
			item2.Text = data.Args1;
			item2.SameTeam = false;
			item2.Type = typeId;
			item2.IsTime = true;
			_messageContext.rpgPopMsg.TimeQueue.Enqueue(item2);
			break;
		}
		case 1006:
		{
			RpgPopMsgComponent.PopMsg item = default(RpgPopMsgComponent.PopMsg);
			item.Text = data.Args1;
			item.SameTeam = false;
			item.Type = typeId;
			item.IsTime = true;
			_messageContext.rpgPopMsg.TimeQueue.Enqueue(item);
			break;
		}
		}
	}
}
