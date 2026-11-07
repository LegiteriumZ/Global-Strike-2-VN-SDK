using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

internal class M96SHADOW : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		if (player == null || !player.hasThirdPersonUnityObjects)
		{
			return;
		}
		IGroupModelTextureSheetAnimation[] groupTSA = player.thirdPersonUnityObjects.Cache.GroupTSA;
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
