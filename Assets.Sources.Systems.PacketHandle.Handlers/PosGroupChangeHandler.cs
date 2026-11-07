using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PosGroupChangeHandler : ApcPacketHandler<PosGroupChangeData>
{
	public PosGroupChangeHandler(Contexts contexts)
	{
		contexts.worldCamera.SetPosGroupChange(null);
	}

	public override int MethodId()
	{
		return 217;
	}

	public override void Handle(PosGroupChangeData data)
	{
		Contexts.sharedInstance.worldCamera.posGroupChange.PosGroupChangeParam = data;
	}
}
