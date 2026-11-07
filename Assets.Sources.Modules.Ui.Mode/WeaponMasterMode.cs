using Assets.Sources.Ui.Model.WeaponMaster;

namespace Assets.Sources.Modules.Ui.Mode;

public class WeaponMasterMode : DeathMatchMode
{
	public WeaponMasterMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new WeaponMasterSelectWeaponTypeModel());
		AddPlaybackSystem(new WeaponMasterSelectWeaponModel());
	}
}
