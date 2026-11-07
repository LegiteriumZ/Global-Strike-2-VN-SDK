using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerAnimationEffectCreateSystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private PlayerContext _playerContext;

	private TimeComponent _time;

	public PlayerAnimationEffectCreateSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerAnimationEffect).NoneOf(SceneObjectMatcher.Destroy));
		_playerContext = contexts.player;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			int followEntityId = item.playerAnimationEffect.FollowEntityId;
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(followEntityId);
			if (entityWithEntityId == null || !entityWithEntityId.hasLegAnim || entityWithEntityId.legAnim.LegsAnimInfo == null)
			{
				continue;
			}
			if (!entityWithEntityId.legAnim.Equals(item.playerAnimationEffect.AnimationId))
			{
				item.playerAnimationEffect.EclipseTime = 0;
				continue;
			}
			if (item.playerAnimationEffect.EclipseTime >= item.playerAnimationEffect.DelayTime && item.playerAnimationEffect.CreateTime == 0)
			{
				item.AddLoadUnityObjects(new LoadRequests(item.playerAnimationEffect.AssetInfo), item.playerEffectId);
				item.playerAnimationEffect.CreateTime = _time.RenderTime;
			}
			item.playerAnimationEffect.EclipseTime += _time.FrameInterval;
		}
	}
}
