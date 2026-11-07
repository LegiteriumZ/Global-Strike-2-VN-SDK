using Assets.Sources.Components.Interface.Info.Quest;

namespace Assets.Sources.Info.Quest;

public class AcgQuest : IAcgQuest
{
	public int id { get; set; }

	public bool isCleared { get; set; }

	public int time { get; set; }
}
