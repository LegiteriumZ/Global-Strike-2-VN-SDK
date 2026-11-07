using Assets.Sources.Utils.Player;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class ShowHpHandler : ApcPacketHandler<ShowHpData>
{
	public ShowHpHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 226;
	}

	public override void Handle(ShowHpData data)
	{
		PlayerEntity playerEntityById = PlayerUtility.GetPlayerEntityById(data.Id);
		if (playerEntityById != null)
		{
			if (data.Type == 0)
			{
				playerEntityById.hpShow.ShowPlayerHpTime = data.Time;
			}
			else if (data.Type == 1)
			{
				playerEntityById.hpShow.ShowMechHpTime = data.Time;
			}
		}
	}
}
