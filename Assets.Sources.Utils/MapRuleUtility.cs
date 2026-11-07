namespace Assets.Sources.Utils;

public static class MapRuleUtility
{
	public static bool IsUnityScene(int mapId)
	{
		if (mapId >= 3000)
		{
			return mapId < 5000;
		}
		return false;
	}
}
