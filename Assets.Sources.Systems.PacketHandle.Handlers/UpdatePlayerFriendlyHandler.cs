using Assets.Sources.Utils.Player;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class UpdatePlayerFriendlyHandler : ApcPacketHandler<UpdatePlayerFriendlyData>
{
	public UpdatePlayerFriendlyHandler(Contexts context)
	{
	}

	public override int MethodId()
	{
		return 57;
	}

	public override void Handle(UpdatePlayerFriendlyData data)
	{
		PlayerEntity playerByCid = PlayerUtility.GetPlayerByCid(data.Cid);
		if (playerByCid != null && playerByCid.hasFavor)
		{
			playerByCid.favor.Favor = data.Friendly;
		}
	}
}
