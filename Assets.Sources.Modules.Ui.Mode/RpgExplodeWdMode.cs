using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Modules.Ui.Mode;

public class RpgExplodeWdMode : RpgMode
{
	public RpgExplodeWdMode(Contexts contexts)
		: base(contexts)
	{
		RemovePlayerbackSystem<CommonGameOverModel>();
	}
}
