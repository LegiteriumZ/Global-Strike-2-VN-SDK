using Assets.Sources.Components.Weapon;
using NetData;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class WeaponClipInitSystem : WeaponInitSystemBase<ClipComponent>
{
	public WeaponClipInitSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override ClipComponent GetComponent(WeaponEntity entity)
	{
		return entity.clip;
	}

	protected override void InitComponent(ClipComponent comp, BaseWeaponData data)
	{
		comp.Clip = data.Clip;
		comp.Clip2 = data.Clip2;
		comp.CarryClip = data.CarryClip;
		comp.CarryClip2 = data.CarryClip2;
		comp.MaxClip = data.MaxClip;
	}
}
