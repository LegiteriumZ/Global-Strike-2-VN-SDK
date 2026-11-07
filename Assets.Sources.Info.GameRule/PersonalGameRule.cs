using NetData;

namespace Assets.Sources.Info.GameRule;

public class PersonalGameRule : DefaultGameRule
{
	public PersonalGameRule()
	{
		RoomData data = Contexts.sharedInstance.battleRoom.roomData.Data;
		ModeConfig = data.RaceType + ((data.SubRaceType > 0) ? ("_" + data.SubRaceType) : "_51");
	}
}
