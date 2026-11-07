using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Framework;
using Entitas;
using NetData;
using SSJJAnim.AnimState;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerLegAnimInitSystem : PredicationInitSystemBase<LegAnimComponent>, IPlaybackInitSystem
{
	private PlayerContext _playerContext;

	private IGroup<PlayerEntity> _group;

	public override LegAnimComponent CurrentComponent => _playerContext.predictionEntity.legAnim;

	public PlayerLegAnimInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.LegAnim));
	}

	public override void GetComponentFromSnapshot(LegAnimComponent comp)
	{
		InitComponent(comp, _playerContext.predictionEntity);
	}

	private static void InitComponent(LegAnimComponent comp, PlayerEntity player)
	{
		PlayerEntityData current = player.basicInfo.Current;
		ILegAnimStateInfo legAnimInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(current.LegsAnim);
		if (legAnimInfo != comp.LegsAnimInfo)
		{
			comp.LastLegAnimInfo = comp.LegsAnimInfo;
		}
		comp.LegsAnimInfo = legAnimInfo;
		comp.RemainTime = current.LegsAnimationTimer;
		comp.ScaledEclipsedTime = current.LegsSpeedAnimTime;
		comp.WrapPassTime = current.LegsAnimProcess;
		comp.setServerTime(player.basicInfo.SnapsotServerTime);
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _group)
		{
			if (!item.isPrediction)
			{
				InitComponent(item.legAnim, item);
			}
		}
	}
}
