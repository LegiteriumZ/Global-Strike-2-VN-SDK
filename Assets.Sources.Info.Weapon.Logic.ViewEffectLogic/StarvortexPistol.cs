using Assets.Res.Assets.Scripts;
using Spine.Unity;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class StarvortexPistol : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		GameObject skin = getSkin(player);
		if (!(skin != null))
		{
			return;
		}
		if (player.GetViewAnimId() == 44)
		{
			if (player.viewAnim.RemainTime > 1000 && player.viewAnim.RemainTime < 3300)
			{
				skin.gameObject.SetObjectActive(isactive: true);
			}
			else
			{
				skin.gameObject.SetObjectActive(isactive: false);
			}
		}
		if (player.GetViewAnimId() == 28)
		{
			if (player.viewAnim.RemainTime > 200 && player.viewAnim.RemainTime < 1200)
			{
				skin.gameObject.SetObjectActive(isactive: true);
			}
			else
			{
				skin.gameObject.SetObjectActive(isactive: false);
			}
		}
	}

	private GameObject getSkin(PlayerEntity player)
	{
		if (player.hasFirstPersonUnityObjects)
		{
			Transform transform = player.firstPersonUnityObjects.AllTransforms["uv2_live2D_liuguang"];
			if ((bool)transform)
			{
				transform.gameObject.GetComponent<Uvlive2DEffect>().hasLiuguang = true;
				transform.gameObject.GetComponentInChildren<SkeletonAnimation>().AnimationName = "idle";
				return transform.gameObject;
			}
		}
		return null;
	}
}
