using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

public class MyStoryMode : RpgMode
{
	public MyStoryMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new RpgSkillStateModel());
		AddPlaybackSystem(new PlayerBagModel());
	}
}
