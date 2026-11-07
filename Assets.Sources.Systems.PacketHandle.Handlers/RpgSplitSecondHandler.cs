using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgSplitSecondHandler : ApcPacketHandler<SplitSecondData>
{
	private GameRuleContext _gmGameRuleContext;

	public RpgSplitSecondHandler(Contexts contexts)
	{
		_gmGameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 278;
	}

	public override void Handle(SplitSecondData data)
	{
		if (data.Type == SplitSecondType.DESTINATION)
		{
			_gmGameRuleContext.splitSecond.AriveFirstPoint = data.Destination;
			_gmGameRuleContext.splitSecond.AriveAllPoint = data.MaxDestination;
		}
		else if (data.Type == SplitSecondType.RESTPLACES)
		{
			_gmGameRuleContext.splitSecond.Rank = data.ResPlaces;
		}
		else if (data.Type == SplitSecondType.JETPACKTIP)
		{
			_gmGameRuleContext.splitSecond.GetSpeedAllTime = 3000;
		}
		else if (data.Type == SplitSecondType.WINDYFRUITTIP)
		{
			_gmGameRuleContext.splitSecond.CancelCollsionAllTime = 3000;
		}
	}
}
