namespace Assets.Res.Assets.Scripts.PrefabInstance;

public class AccessoryStatusParticleInstance : AccessoryParticleInstance
{
	public int StatusId;

	public bool isNot;

	public void parseStatus(string str)
	{
		if (str.StartsWith("!"))
		{
			isNot = true;
			str = str.Substring(1);
		}
		else
		{
			isNot = false;
		}
		StatusId = int.Parse(str);
	}
}
