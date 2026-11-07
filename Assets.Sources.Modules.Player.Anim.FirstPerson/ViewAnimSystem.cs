using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Components.Player.UnityObjects;
using Assets.Sources.Framework;
using Assets.Sources.Info.WeaponAnim;
using Entitas;
using SSJJAnim.WeaponAnim;
using SSJJBase.Logger;

namespace Assets.Sources.Modules.Player.Anim.FirstPerson;

public class ViewAnimSystem : IRenderSystem
{
	private readonly IGroup<PlayerEntity> _players;

	public ViewAnimSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.CurrentWeapon, PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.FirstPersonView));
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			SetPlayViewAnimation(player);
		}
	}

	private void SetPlayViewAnimation(PlayerEntity entity)
	{
		IViewAnimStateInfo viewAnimInfo = entity.viewAnim.ViewAnimInfo;
		IViewAnimStateInfo leftViewAnimInfo = entity.viewAnim.LeftViewAnimInfo;
		FirstPersonUnityObjectsComponent firstPersonUnityObjects = entity.firstPersonUnityObjects;
		IEntitsWeaponInfo weaponInfo = entity.currentWeapon.WeaponInfo;
		IWeaponAnimInfo weaponAnimInfo = WeaponAnimInfoFactory.Instance.GetWeaponAnimInfo(weaponInfo);
		if (weaponAnimInfo == null)
		{
			this.LogErrorFormat("WeaponAnimInfo is Null when play view anim on weapon {0} ", weaponInfo.Name);
			return;
		}
		PlayHandAnimation(firstPersonUnityObjects.WeaponAnimator, firstPersonUnityObjects.HandAnimator, viewAnimInfo, ref entity.viewAnim.RightCurrentTime, entity.viewAnim.RemainTime, weaponAnimInfo);
		if (firstPersonUnityObjects.WeaponAnimator2 != null && firstPersonUnityObjects.HandAnimator2 != null)
		{
			PlayHandAnimation(firstPersonUnityObjects.WeaponAnimator2, firstPersonUnityObjects.HandAnimator2, leftViewAnimInfo, ref entity.viewAnim.LeftCurrentTime, entity.viewAnim.LeftRemainTime, weaponAnimInfo);
		}
		entity.viewAnim.LastViewAnimInfo = entity.viewAnim.ViewAnimInfo;
		entity.viewAnim.LastLeftViewAnimInfo = entity.viewAnim.LeftViewAnimInfo;
	}

	private void PlayHandAnimation(ISjAnimatior weaponAnimator, ISjAnimatior handAnimator, IViewAnimStateInfo viewInfo, ref int currentTime, int remainTime, IWeaponAnimInfo weaponAnimInfo)
	{
		if (viewInfo == null)
		{
			return;
		}
		bool isLoop = viewInfo.IsLoop;
		if (!isLoop)
		{
			int num = weaponAnimInfo.GetViewAnimDuration(viewInfo.StateId);
			if (num == 0)
			{
				num = (int)(weaponAnimator.GetAnimDuration(0, viewInfo.AnimationName) * 1000f);
			}
			currentTime = num - remainTime;
		}
		handAnimator.PlayAtFixedTime(0, viewInfo.AnimationName, (float)currentTime * 0.001f, 1f, isLoop);
		weaponAnimator.PlayAtFixedTime(0, viewInfo.AnimationName, (float)currentTime * 0.001f, 1f, isLoop);
	}
}
