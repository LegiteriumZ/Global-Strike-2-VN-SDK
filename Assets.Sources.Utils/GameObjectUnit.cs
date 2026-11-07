namespace Assets.Sources.Utils;

public class GameObjectUnit
{
	public string UnitName;

	public string InstanceId;

	public string ParentInstanceId;

	public string ToSave()
	{
		return UnitName + "{_}" + InstanceId + "{_}" + ParentInstanceId + "{_}";
	}
}
