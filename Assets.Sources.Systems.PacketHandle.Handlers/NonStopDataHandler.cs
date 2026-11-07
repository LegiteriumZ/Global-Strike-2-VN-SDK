using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class NonStopDataHandler : ApcPacketHandler<NonStopDanceData>
{
	private GameRuleContext _gameRuleContext;

	public NonStopDataHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 500;
	}

	public override void Handle(NonStopDanceData data)
	{
		if (data.Type == NonStopDanceMessageType.POSITION)
		{
			_gameRuleContext.nonStopData._show = true;
			_gameRuleContext.nonStopData._showOver = false;
			_gameRuleContext.nonStopData._positionList[0] = data.Pos1;
			_gameRuleContext.nonStopData._positionList[1] = data.Pos2;
			_gameRuleContext.nonStopData._positionList[2] = data.Pos3;
			_gameRuleContext.nonStopData._positionList[3] = data.Pos4;
			_gameRuleContext.nonStopData._positionList[4] = data.Pos5;
			for (int i = 0; i < 5; i++)
			{
				_gameRuleContext.nonStopData._positionResultList[i] = false;
			}
		}
		if (data.Type != NonStopDanceMessageType.RESULT)
		{
			return;
		}
		if (!data.Res)
		{
			_gameRuleContext.nonStopData._show = false;
			return;
		}
		if (data.ResPos == 5)
		{
			_gameRuleContext.nonStopData._showOver = true;
		}
		_gameRuleContext.nonStopData._positionResultList[data.ResPos - 1] = data.Res;
	}
}
