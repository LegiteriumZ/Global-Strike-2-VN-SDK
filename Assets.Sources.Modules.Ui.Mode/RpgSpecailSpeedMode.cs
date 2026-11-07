using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Modules.Ui.Mode;

public class RpgSpecailSpeedMode : RpgMode
{
	public RpgSpecailSpeedMode(Contexts contexts)
		: base(contexts)
	{
		RemovePlayerbackSystem<CommonGameOverModel>();
	}
}
