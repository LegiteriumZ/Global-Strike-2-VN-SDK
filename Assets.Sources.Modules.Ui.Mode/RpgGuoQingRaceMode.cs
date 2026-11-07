using Assets.Sources.Ui.Model.RpgGuoQingRace;

namespace Assets.Sources.Modules.Ui.Mode;

public class RpgGuoQingRaceMode : RpgMode
{
	public RpgGuoQingRaceMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new RpgGuoQingGameProgressModel());
	}
}
