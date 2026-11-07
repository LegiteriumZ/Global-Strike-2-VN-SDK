using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class TeamRaceUiMessageHandler : ApcPacketHandler<TeamRacesInfoDataList>
{
	private GameRuleContext _gameRuleContext;

	public TeamRaceUiMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 231;
	}

	public override void Handle(TeamRacesInfoDataList data)
	{
		Dictionary<int, TeamRacesInfoData> data2 = _gameRuleContext.teamRaceUi.Data;
		foreach (TeamRacesInfoData item in data.List)
		{
			data2[item.Type] = item;
		}
	}
}
