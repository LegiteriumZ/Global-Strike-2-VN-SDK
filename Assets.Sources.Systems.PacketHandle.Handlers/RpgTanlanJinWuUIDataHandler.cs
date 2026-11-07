using Assets.Sources.Components.GameRule.RpgTanlan;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgTanlanJinWuUIDataHandler : ApcPacketHandler<JinWuData>
{
	private RpgTanlanJinWuComponent tanlan;

	public RpgTanlanJinWuUIDataHandler(Contexts contexts)
	{
		tanlan = Contexts.sharedInstance.gameRule.rpgTanlanJinWu;
	}

	public override int MethodId()
	{
		return 1210;
	}

	public override void Handle(JinWuData data)
	{
		tanlan.IsUIShow = data.Show;
		tanlan.UIChange = true;
		if (data.Show)
		{
			tanlan.KeyList = data.KeyList;
			tanlan.TotalWave = data.TotalWave;
			tanlan.Wave = data.Wave;
			tanlan.WaveEndServerTime = data.Time;
		}
	}
}
