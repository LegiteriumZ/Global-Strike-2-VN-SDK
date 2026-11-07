using Assets.Sources.Ui.Model.Pve;

namespace Assets.Sources.Modules.Ui.Mode;

public class TitanLaboratoryMode : AbstractMode
{
	public TitanLaboratoryMode(Contexts contexts)
		: base(contexts)
	{
		AbstractMode.AddTowerDefenseGui(this);
		AddPlaybackSystem(new EnergydevicetowardModel());
	}
}
