using System.Collections.Generic;

namespace Assets.Sources.Utils;

public class SceneUnit
{
	public List<GameObjectUnit> Units = new List<GameObjectUnit>();

	public string SceneName;

	public override string ToString()
	{
		return SceneName + " : " + Units.Count;
	}

	public string ToSave()
	{
		string text = SceneName + "{|}" + Units.Count + "{|}";
		for (int i = 0; i < Units.Count; i++)
		{
			text = text + Units[i].ToSave() + "{|}";
		}
		return text;
	}
}
