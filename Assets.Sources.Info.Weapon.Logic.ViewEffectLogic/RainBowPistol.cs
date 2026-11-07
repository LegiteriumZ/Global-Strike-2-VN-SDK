using Assets.Res.Assets.Scripts;
using Assets.Sources.Utils.PlayerAnim;
using Spine.Unity;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class RainBowPistol : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		GameObject skin = getSkin(player);
		if (!(skin != null))
		{
			return;
		}
		SkeletonAnimation componentInChildren = skin.GetComponentInChildren<SkeletonAnimation>();
		if (!(componentInChildren != null))
		{
			return;
		}
		bool hasLiuguang = false;
		string text = "idle";
		Uvlive2DEffect component = skin.GetComponent<Uvlive2DEffect>();
		if (player.GetViewAnimId() == 44)
		{
			int num = ((component.maskUseTime > 0) ? component.maskUseTime : 1000);
			PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, player.viewAnim.ViewAnimInfo.StateId);
			if (player.viewAnim.RemainTime > num)
			{
				text = "kaixin";
				hasLiuguang = true;
				component.tweenFactor(0f);
			}
			else
			{
				component.tweenFactor(1f);
			}
		}
		else if (player.GetViewAnimId() == 17)
		{
			int num2 = ((component.maskUseTime > 0) ? component.maskUseTime : 300);
			if (player.viewAnim.RemainTime > num2)
			{
				text = "haixiu";
				hasLiuguang = true;
				component.tweenFactor(0f);
			}
			else
			{
				component.tweenFactor(1f);
			}
		}
		else
		{
			component.tweenFactor(1f);
		}
		if (componentInChildren.AnimationName != text)
		{
			componentInChildren.AnimationName = text;
		}
		component.hasLiuguang = hasLiuguang;
	}

	private GameObject getSkin(PlayerEntity player)
	{
		if (player.hasFirstPersonUnityObjects)
		{
			Transform transform = player.firstPersonUnityObjects.AllTransforms["uv2_live2D_liuguang"];
			if ((bool)transform)
			{
				return transform.gameObject;
			}
		}
		return null;
	}
}
