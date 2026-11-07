namespace Assets.Sources.Modules.Player.Sound;

internal class ThirdFootstepsPlaybackSystem : FootstepsPlaybackSystem
{
	public ThirdFootstepsPlaybackSystem(Contexts contexts)
	{
		Players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Fpos, PlayerMatcher.Move, PlayerMatcher.ThirdPersonUnityObjects));
	}

	protected override FootstepControl GetFootstepControl(PlayerEntity playerEntity)
	{
		return playerEntity.thirdPersonUnityObjects.AudioSouce.GetComponent<FootstepControl>();
	}
}
