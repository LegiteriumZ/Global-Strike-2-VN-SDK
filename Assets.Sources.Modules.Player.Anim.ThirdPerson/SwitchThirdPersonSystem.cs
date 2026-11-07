using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class SwitchThirdPersonSystem : IPreRenderSystem
{
	private readonly IGroup<PlayerEntity> _players;

	public SwitchThirdPersonSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.CameraOwner));
	}

	public void OnPreRender()
	{
		foreach (PlayerEntity player in _players)
		{
			bool flag = player.isThirdPersonView && !player.state.GetPlayerStateType(131072) && (player.basicInfo.Current.ControlEntityId == 0 || !player.basicInfo.Current.ControlEntityHideSelf);
			if (!flag && player.thirdPersonUnityObjects.ThirdTran.RootContainer.IsActiveSelf())
			{
				player.thirdPersonUnityObjects.ThirdTran.RootContainer.SetObjectActive(isactive: false);
			}
			else if (flag && !player.thirdPersonUnityObjects.ThirdTran.RootContainer.IsActiveSelf())
			{
				player.thirdPersonUnityObjects.ThirdTran.RootContainer.SetObjectActive(isactive: true);
			}
		}
	}
}
