using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class NewPlayerListHandler : ApcPacketHandler<OnGameinitData>
{
	public NewPlayerListHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 39;
	}

	public override void Handle(OnGameinitData data)
	{
	}
}
