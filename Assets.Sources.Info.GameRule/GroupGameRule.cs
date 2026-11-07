using NetData;

namespace Assets.Sources.Info.GameRule;

public class GroupGameRule : DefaultGameRule
{
	public GroupGameRule()
	{
		RoomData data = Contexts.sharedInstance.battleRoom.roomData.Data;
		ModeConfig = data.RaceType + ((data.SubRaceType > 0) ? ("_" + data.SubRaceType) : "");
	}

	public override bool CanShowAddHpCross()
	{
		return false;
	}

	public override bool IsShowKiller()
	{
		return true;
	}
}
