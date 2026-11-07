using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Framework;
using Entitas;
using SSJJAnim.AnimState;

namespace Assets.Sources.Modules.Player.Anim.FirstPerson;

public class PlayerViewAnimInitSystem : PredicationInitSystemBase<ViewAnimComponent>, IPlaybackInitSystem
{
	private PlayerContext _playerContext;

	private IGroup<PlayerEntity> _group;

	public override ViewAnimComponent CurrentComponent => _playerContext.predictionEntity.viewAnim;

	public PlayerViewAnimInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ViewAnim));
	}

	public override void GetComponentFromSnapshot(ViewAnimComponent comp)
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		InitComponent(comp, predictionEntity);
	}

	private static void InitComponent(ViewAnimComponent comp, PlayerEntity player)
	{
		IViewAnimStateInfo viewAnimInfo = AnimStateInfoFactory.Instance.GetViewAnimInfo(player.basicInfo.Current.ViewAnim);
		IViewAnimStateInfo viewAnimInfo2 = AnimStateInfoFactory.Instance.GetViewAnimInfo(player.basicInfo.Current.LeftViewAnim);
		if (viewAnimInfo != comp.ViewAnimInfo)
		{
			comp.RightCurrentTime = 0;
		}
		if (viewAnimInfo2 != comp.LeftViewAnimInfo)
		{
			comp.LeftCurrentTime = 0;
		}
		comp.ViewAnimInfo = viewAnimInfo;
		comp.LeftViewAnimInfo = viewAnimInfo2;
		comp.RemainTime = player.basicInfo.Current.ViewAnimationTimer;
		comp.LeftRemainTime = player.basicInfo.Current.LeftViewAnimationTimer;
		comp.SnapshotRemainTime = player.basicInfo.Current.ViewAnimationTimer;
		comp.SnapshotLeftRemainTime = player.basicInfo.Current.LeftViewAnimationTimer;
		comp.RightSpeed = player.basicInfo.Current.ViewAnimSpeed;
		comp.LeftSpeed = player.basicInfo.Current.LeftViewAnimSpeed;
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _group)
		{
			if (!item.isPrediction)
			{
				InitComponent(item.viewAnim, item);
			}
		}
	}
}
