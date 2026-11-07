using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AcgPowerUpHandlerHandler : ApcPacketHandler<BuySkillResponse>
{
	private GameRuleContext _gameruleContext;

	public AcgPowerUpHandlerHandler(Contexts contexts)
	{
		_gameruleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1101;
	}

	public override void Handle(BuySkillResponse data)
	{
		if (_gameruleContext.hasAcgPowerUp)
		{
			if (_gameruleContext.acgPowerUp.Ids == null || _gameruleContext.acgPowerUp.Ids.Length < 3)
			{
				_gameruleContext.acgPowerUp.Ids = new int[3] { data.Id1, data.Id2, data.Id3 };
			}
			else
			{
				_gameruleContext.acgPowerUp.Ids[0] = data.Id1;
				_gameruleContext.acgPowerUp.Ids[1] = data.Id2;
				_gameruleContext.acgPowerUp.Ids[2] = data.Id3;
			}
			NotifyManager.ForceInvoke(103);
		}
	}
}
