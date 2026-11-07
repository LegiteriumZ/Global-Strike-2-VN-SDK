using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Dead;

public class PlayerDeadHideThirdWeaponSystem : IRenderSystem
{
	private IGroup<PlayerEntity> _group;

	public PlayerDeadHideThirdWeaponSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _group)
		{
			bool flag = item.isHideWeapon || item.basicInfo.IsDead;
			if (item.thirdPersonUnityObjects.ThirdTran.WeaponObj.IsActiveSelf() == flag)
			{
				item.thirdPersonUnityObjects.ThirdTran.WeaponObj.SetObjectActive(!flag);
			}
		}
	}
}
