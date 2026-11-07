using Assets.Sources.Ui.Model.Pve;

namespace Assets.Sources.Modules.Ui.Mode;

internal class LostGraveMode : AbstractMode
{
	public LostGraveMode(Contexts contexts)
		: base(contexts)
	{
		AbstractMode.AddTowerDefenseGui(this);
		AddPlaybackSystem(new Td5SpidereggnumModel());
		AddPlaybackSystem(new Td5MaskModel());
	}
}
