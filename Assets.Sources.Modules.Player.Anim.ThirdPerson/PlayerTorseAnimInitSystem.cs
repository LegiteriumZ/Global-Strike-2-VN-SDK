using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Framework;
using Entitas;
using NetData;
using SSJJAnim.AnimState;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerTorseAnimInitSystem : PredicationInitSystemBase<TorseAnimComponent>, IPlaybackInitSystem
{
	private readonly PlayerContext _playerContext;

	private readonly TimeContext _time;

	private IGroup<PlayerEntity> _group;

	public override TorseAnimComponent CurrentComponent => _playerContext.predictionEntity.torseAnim;

	public PlayerTorseAnimInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_time = contexts.time;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.TorseAnim));
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _group)
		{
			if (!item.isPrediction)
			{
				InitComponent(item.torseAnim, item);
			}
		}
	}

	public override void GetComponentFromSnapshot(TorseAnimComponent comp)
	{
		InitComponent(comp, _playerContext.predictionEntity);
	}

	private void InitComponent(TorseAnimComponent comp, PlayerEntity player)
	{
		PlayerEntityData current = player.basicInfo.Current;
		comp.TorsoAnimInfo = AnimStateInfoFactory.Instance.GetTorseAnimInfo(current.TorsoAnim);
		comp.EclipsedTime = _time.time.RenderTime - current.TorsoAnimStartTime;
		comp.RemainTime = current.TorsoAnimationTimer;
	}
}
