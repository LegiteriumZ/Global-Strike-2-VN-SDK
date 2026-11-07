namespace Assets.Sources.Utils.Player;

public static class AccessoryNameUtility
{
	public static string GetAccessoryName(string accessoryName, int team)
	{
		if (accessoryName == "accessorybigsword")
		{
			switch (team)
			{
			case 1:
				return accessoryName + "t";
			case 2:
				return accessoryName + "ct";
			}
		}
		return accessoryName;
	}
}
