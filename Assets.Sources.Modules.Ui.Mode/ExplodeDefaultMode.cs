using Assets.Sources.Ui.Model.Blast;

namespace Assets.Sources.Modules.Ui.Mode;

public class ExplodeDefaultMode : AbstractMode
{
	public ExplodeDefaultMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new BlastTacticsSoundModel());
	}
}
