using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Common;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GameEmojiHandler : ApcPacketHandler<GameEmojiData>
{
	private GameRuleContext _gameRuleContext;

	public GameEmojiHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 96;
	}

	public override void Handle(GameEmojiData data)
	{
		if (_gameRuleContext.personalized.ShowExpressions == null)
		{
			_gameRuleContext.personalized.ShowExpressions = new List<ShowExpression>();
		}
		ShowExpression showExpression = null;
		for (int i = 0; i < _gameRuleContext.personalized.ShowExpressions.Count; i++)
		{
			ShowExpression showExpression2 = _gameRuleContext.personalized.ShowExpressions[i];
			if (showExpression2.Id == data.PlayerId)
			{
				showExpression = showExpression2;
				break;
			}
		}
		if (showExpression == null)
		{
			showExpression = new ShowExpression();
			showExpression.Id = data.PlayerId;
			_gameRuleContext.personalized.ShowExpressions.Add(showExpression);
		}
		showExpression.CodeName = data.CodeName;
		showExpression.RemainTime = 2000;
	}
}
