using Assets.Res.Assets.Scripts;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class DoubleScythe : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		GroupModelTextureSheetAnimation[] componentsInChildren = player.firstPersonUnityObjects.WeaponGameObject.GetComponentsInChildren<GroupModelTextureSheetAnimation>();
		if (componentsInChildren != null)
		{
			GroupModelTextureSheetAnimation[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Group = ((currentWeapon.special.Level > 3) ? 3 : currentWeapon.special.Level);
			}
		}
	}
}
