using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Constant;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PlugInPlayerListHandler : ApcPacketHandler<PluginPlayerListData>
{
	private GameRuleContext _gameRuleContext;

	public PlugInPlayerListHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 107;
	}

	public override void Handle(PluginPlayerListData data)
	{
		ReportVisibleComponent reportVisible = _gameRuleContext.reportVisible;
		List<ReportVisibleComponent.ReportPlayer> list = new List<ReportVisibleComponent.ReportPlayer>();
		foreach (PluginPlayerData item in data.List)
		{
			list.Add(new ReportVisibleComponent.ReportPlayer
			{
				Cid = item.Cid,
				Name = item.PlayerName,
				Reported = reportVisible.IsReported(item.PlayerName),
				Weight = item.Weight,
				Selected = reportVisible.IsSelected(item.PlayerName),
				Team = item.Team
			});
		}
		list.Sort(delegate(ReportVisibleComponent.ReportPlayer a, ReportVisibleComponent.ReportPlayer b)
		{
			if (a.Weight > b.Weight)
			{
				return -1;
			}
			return (a.Weight < b.Weight) ? 1 : 0;
		});
		reportVisible.PlayerList.Clear();
		reportVisible.tPlayerList.Clear();
		reportVisible.ctPlayerList.Clear();
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		for (int i = 0; i < list.Count; i++)
		{
			reportVisible.PlayerList.Add(list[i]);
			ReportVisibleComponent.ReportPlayer reportPlayer = list[i];
			if (RuleUtilty.IsPersonlKillInfo(raceType))
			{
				if (reportVisible.tPlayerList.Count < 8)
				{
					reportVisible.tPlayerList.Add(reportPlayer);
				}
				else if (reportVisible.ctPlayerList.Count < 8)
				{
					reportVisible.ctPlayerList.Add(reportPlayer);
				}
			}
			else if (reportPlayer.Team == 2)
			{
				if (reportVisible.tPlayerList.Count < 8)
				{
					reportVisible.tPlayerList.Add(reportPlayer);
				}
			}
			else if (reportVisible.ctPlayerList.Count < 8)
			{
				reportVisible.ctPlayerList.Add(reportPlayer);
			}
		}
		reportVisible.Visible = true;
	}
}
