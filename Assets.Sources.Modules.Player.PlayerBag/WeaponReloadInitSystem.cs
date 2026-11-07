using Assets.Sources.Components.Weapon;
using NetData;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class WeaponReloadInitSystem : WeaponInitSystemBase<ReloadComponent>
{
	public WeaponReloadInitSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override ReloadComponent GetComponent(WeaponEntity entity)
	{
		return entity.reload;
	}

	protected override void InitComponent(ReloadComponent comp, BaseWeaponData data)
	{
		comp.IsStartReload = data.IsStartReload;
		comp.ReloadEndTime = data.ReloadEndTime;
	}
}
