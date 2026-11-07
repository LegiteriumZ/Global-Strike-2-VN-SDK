using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RandomKingHandler : ApcPacketHandler<RandomKingData>
{
	private GameRuleContext _gameRuleContext;

	public RandomKingHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 279;
	}

	public override void Handle(RandomKingData data)
	{
		int num = _gameRuleContext.randomKing.TipId.IndexOf((int)data.Tip);
		if (!data.Display)
		{
			if (num != -1)
			{
				_gameRuleContext.randomKing.TipId.RemoveAt(num);
			}
			num = _gameRuleContext.randomKing.TipTimeID.IndexOf((int)data.Tip);
			if (num != -1)
			{
				_gameRuleContext.randomKing.TipTimeID.RemoveAt(num);
				_gameRuleContext.randomKing.TipTimeVaule.RemoveAt(num);
			}
		}
		else if (data.Time > 0)
		{
			num = _gameRuleContext.randomKing.TipTimeID.IndexOf((int)data.Tip);
			if (num == -1)
			{
				_gameRuleContext.randomKing.TipTimeID.Add((int)data.Tip);
				_gameRuleContext.randomKing.TipTimeVaule.Add(data.Time);
			}
			else
			{
				_gameRuleContext.randomKing.TipTimeVaule[num] = data.Time;
			}
		}
		else if (num == -1)
		{
			_gameRuleContext.randomKing.TipId.Add((int)data.Tip);
		}
	}
}
