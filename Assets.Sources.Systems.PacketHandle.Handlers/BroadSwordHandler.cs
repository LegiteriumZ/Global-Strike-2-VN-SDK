using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BroadSwordHandler : ApcPacketHandler<BroadSwordMessageData>
{
	private GameRuleContext _gameRuleContext;

	public BroadSwordHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 335;
	}

	public override void Handle(BroadSwordMessageData data)
	{
		if (data.Type == BroadSwordMessageType.LVUP)
		{
			_gameRuleContext.broadSword.LevelUpCurrentTime = 0;
			_gameRuleContext.broadSword.LevelUpAllTime = 3000;
		}
		else if (data.Type == BroadSwordMessageType.STATE2)
		{
			_gameRuleContext.broadSword.State2CurrentTime = 0;
			_gameRuleContext.broadSword.State2AllTime = 3000;
		}
		else if (data.Type == BroadSwordMessageType.STAGE4)
		{
			_gameRuleContext.broadSword.FinalStateCurrentTime = 0;
			_gameRuleContext.broadSword.FinalStateAllTime = 300000000;
		}
		else if (data.Type == BroadSwordMessageType.POWERSTATUS)
		{
			if ((data.IntData[0] > _gameRuleContext.broadSword.PowerLevel || data.IntData[1] > _gameRuleContext.broadSword.PowerPercent) && !data.BoolData[0])
			{
				_gameRuleContext.broadSword.LevelUpLiuGuangTime = 0;
			}
			_gameRuleContext.broadSword.IsRedBufferPower = data.BoolData[0];
			_gameRuleContext.broadSword.PowerLevel = data.IntData[0];
			_gameRuleContext.broadSword.PowerPercent = data.IntData[1];
			if (_gameRuleContext.broadSword.IsRedBufferPower)
			{
				_gameRuleContext.broadSword.RedShineTime = 0;
			}
		}
		else if (data.Type == BroadSwordMessageType.CANPICKSTATUS)
		{
			_gameRuleContext.broadSword.IsEShow = data.BoolData[0];
		}
		else if (data.Type == BroadSwordMessageType.FINALTIMECOMING)
		{
			_gameRuleContext.broadSword.IsShowFinalComingCal = true;
			_gameRuleContext.broadSword.FinalComingNowTime = data.IntData[0];
		}
		else if (data.Type == BroadSwordMessageType.WAITSTATUS)
		{
			_gameRuleContext.broadSword.IsShowWaitingPlayer = data.BoolData[0];
			if (_gameRuleContext.broadSword.IsShowWaitingPlayer)
			{
				_gameRuleContext.broadSword.ShowWaitingPlayerCount = data.IntData[0];
			}
		}
	}
}
