namespace Assets.Sources.Info.GameRule;

public class FreeCommonGameRule : DefaultGameRule
{
	public FreeCommonGameRule()
	{
		string freeType = Contexts.sharedInstance.battleRoom.roomData.Data.FreeType;
		ShowEnemyHpBar = freeType == "titForTat";
		HideRadarDeadImage = freeType == "titForTat";
		Relive = Relive && freeType != "survive";
	}
}
