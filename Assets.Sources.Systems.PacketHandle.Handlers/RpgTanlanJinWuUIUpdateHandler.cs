using Assets.Sources.Components.GameRule.RpgTanlan;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgTanlanJinWuUIUpdateHandler : ApcPacketHandler<JinWuKeyData>
{
	private RpgTanlanJinWuComponent tanlan;

	public RpgTanlanJinWuUIUpdateHandler(Contexts contexts)
	{
		tanlan = Contexts.sharedInstance.gameRule.rpgTanlanJinWu;
	}

	public override int MethodId()
	{
		return 1211;
	}

	public override void Handle(JinWuKeyData data)
	{
		if (!tanlan.IsUIShow)
		{
			return;
		}
		for (int i = 0; i < tanlan.KeyList.Count; i++)
		{
			if (tanlan.KeyList[i].Pos == data.Pos)
			{
				tanlan.KeyList[i] = data;
				tanlan.UIChange = true;
				break;
			}
		}
	}
}
