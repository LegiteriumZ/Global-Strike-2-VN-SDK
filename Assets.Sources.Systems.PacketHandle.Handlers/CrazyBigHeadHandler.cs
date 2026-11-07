using Assets.Sources.Components.GameRule.BigHead;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class CrazyBigHeadHandler : ApcPacketHandler<CrazyBigHeadMessageData>
{
	private readonly GameRuleContext _gameRuleContext;

	public CrazyBigHeadHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 270;
	}

	public override void Handle(CrazyBigHeadMessageData data)
	{
		_gameRuleContext.crazyBigHead.CrazyData = data;
		if (_gameRuleContext.crazyBigHead.CrazyTeamDic.Count == 0)
		{
			_gameRuleContext.crazyBigHead.CrazyTeamDic.Add(1, new CrazyBigHeadComponent.CrazyTeamData(1000, 30000));
			_gameRuleContext.crazyBigHead.CrazyTeamDic.Add(2, new CrazyBigHeadComponent.CrazyTeamData(1000, 30000));
		}
		if (data.Type != CrazyBigHeadMessageType.TEAMCRAZYEND)
		{
			CrazyBigHeadComponent.CrazyTeamData crazyTeamData = _gameRuleContext.crazyBigHead.CrazyTeamDic[data.IntValues[0]];
			crazyTeamData.CrazyTypeChange = true;
			crazyTeamData.CrazyType = data.Type;
			crazyTeamData.Score = data.IntValues[1];
			_gameRuleContext.crazyBigHead.CrazyTeamDic[data.IntValues[0]] = crazyTeamData;
		}
		NotifyManager.ForceInvoke(82);
	}
}
