using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class UpgradeWeaponLvHandler : ApcPacketHandler<IntData>
{
	private MessageContext _messageContext;

	public UpgradeWeaponLvHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 48;
	}

	public override void Handle(IntData data)
	{
		_messageContext.gunKingMessageData.Type = data.Data;
		NotifyManager.ForceInvoke(23);
	}
}
