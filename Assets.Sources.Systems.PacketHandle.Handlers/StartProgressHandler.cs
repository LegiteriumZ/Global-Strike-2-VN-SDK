using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class StartProgressHandler : ApcPacketHandler<ProgressData>
{
	private GameRuleContext _gameRuleContext;

	public StartProgressHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 15;
	}

	public override void Handle(ProgressData data)
	{
		if (data.SpeedSpecified && data.Type == ProgressType.SPEEDCHANGE)
		{
			_gameRuleContext.gameProgressData.Speed = data.Speed;
			return;
		}
		_gameRuleContext.gameProgressData.Speed = data.Speed;
		_gameRuleContext.gameProgressData.CurrentProgressTime = 0;
		_gameRuleContext.gameProgressData.ProgressTotalTime = data.Time;
		_gameRuleContext.gameProgressData.ProgressType = data.Type;
		NotifyManager.ForceInvoke(11);
		_gameRuleContext.gameProgressData.PlayerName = data.PlayerName;
		_gameRuleContext.gameProgressData.Details = data.Detail;
		if (data.CurrentTimeSpecified)
		{
			_gameRuleContext.gameProgressData.CurrentProgressTime = (int)data.CurrentTime;
		}
	}
}
