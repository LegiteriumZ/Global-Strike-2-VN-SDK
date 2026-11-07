using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class NewNpcListHandler : ApcPacketHandler<OnGameinitData>
{
	public NewNpcListHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 129;
	}

	public override void Handle(OnGameinitData data)
	{
	}
}
