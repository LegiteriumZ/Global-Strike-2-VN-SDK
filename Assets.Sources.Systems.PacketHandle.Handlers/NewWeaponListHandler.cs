using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class NewWeaponListHandler : ApcPacketHandler<OnGameinitData>
{
	public NewWeaponListHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 40;
	}

	public override void Handle(OnGameinitData data)
	{
	}
}
