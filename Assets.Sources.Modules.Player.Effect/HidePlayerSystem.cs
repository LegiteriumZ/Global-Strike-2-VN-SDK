using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Effect;

public class HidePlayerSystem : IPreRenderSystem
{
	private IGroup<PlayerEntity> _group;

	public HidePlayerSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.State, PlayerMatcher.ThirdPersonUnityObjects).NoneOf(PlayerMatcher.CameraOwner));
	}

	public void OnPreRender()
	{
		foreach (PlayerEntity item in _group)
		{
			bool flag = (item.isHide = item.state.GetPlayerStateType(131072));
			if (item.thirdPersonUnityObjects.ThirdTran.RootContainer.IsActiveSelf() != !flag)
			{
				item.thirdPersonUnityObjects.ThirdTran.RootContainer.SetObjectActive(!flag);
			}
		}
	}
}
