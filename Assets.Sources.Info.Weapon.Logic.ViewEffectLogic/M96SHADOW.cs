using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class M96SHADOW : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (player == null || !player.hasFirstPersonUnityObjects)
		{
			return;
		}
		IGroupModelTextureSheetAnimation[] groupTSA = player.firstPersonUnityObjects.Cache.GroupTSA;
		if (groupTSA != null)
		{
			IGroupModelTextureSheetAnimation[] array = groupTSA;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].setGroup(player.GetCurrentWeaponLevel());
			}
		}
	}
}
