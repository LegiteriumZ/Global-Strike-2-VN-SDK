using Assets.Sources.Utils.Player;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class MeshGiddyHandler : ApcPacketHandler<ShowHpData>
{
	public MeshGiddyHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 227;
	}

	public override void Handle(ShowHpData data)
	{
		PlayerEntity playerEntityById = PlayerUtility.GetPlayerEntityById(data.Id);
		if (playerEntityById != null)
		{
			playerEntityById.hpShow.MechMaxRepelTime = data.Time;
			playerEntityById.hpShow.MechRepelTime = data.Time;
		}
	}
}
