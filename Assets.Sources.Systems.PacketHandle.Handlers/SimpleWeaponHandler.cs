using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class SimpleWeaponHandler : ApcPacketHandler<SimpleWeaponMessageData>
{
	private readonly MessageContext _messageContext;

	public SimpleWeaponHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 401;
	}

	public override void Handle(SimpleWeaponMessageData data)
	{
		_messageContext.simpleWeapon.id = data.Id;
		_messageContext.simpleWeapon.intData32 = data.IntData32;
		_messageContext.simpleWeapon.intData64 = data.IntData64;
		_messageContext.simpleWeapon.stringData = data.StringData;
	}
}
