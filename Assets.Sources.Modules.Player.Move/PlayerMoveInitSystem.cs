using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using Entitas;
using NetData;
using SSJJMath;

namespace Assets.Sources.Modules.Player.Move;

public class PlayerMoveInitSystem : PredicationInitSystemBase<MoveComponent>, IPlaybackInitSystem
{
	private readonly PlayerContext _playerContext;

	private IGroup<PlayerEntity> _group;

	public override MoveComponent CurrentComponent => _playerContext.predictionEntity.move;

	public PlayerMoveInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.Move));
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _group)
		{
			if (!item.isPrediction)
			{
				InitComponent(item.move, item);
			}
			item.move.wingSpeedEN = item.basicInfo.Current.WingSpeedEN;
		}
	}

	public override void AfterPredicationInit()
	{
	}

	public override void GetComponentFromSnapshot(MoveComponent comp)
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		InitComponent(comp, predictionEntity);
	}

	private void InitComponent(MoveComponent comp, PlayerEntity player)
	{
		PlayerEntityData current = player.basicInfo.Current;
		comp.OnGround = current.OnGround;
		comp.Velocity = VectorTypeConverter.Net2Unity(current.Velocity);
		comp.setPreVelocity2D(comp.Velocity2D);
		comp.Velocity2D = current.Velocity2D;
		comp.Moving = current.Moving;
		comp.Stamina = current.Stamina;
		comp.ImpulseTime = current.ImpulseTime;
		comp.ImpulseTime2 = current.ImpulseTime2;
		comp.DuckState = current.DuckState;
		comp.DuckTime = current.DuckTime;
		comp.ViewHeightBase = current.ViewHeight;
		comp.BeingHitFriction = current.BeingHitFriction;
		comp.AnimPosition = current.AnimPosition;
		comp.AnimMoveTime = current.AnimMoveTime;
		comp.ActThirdMove = current.ActThirdMove;
		comp.limitSpeedInJumpRule = current.LimitSpeedInJumpRule;
		comp.ctrlDuck = current.CtrlDuck;
		comp.keepFly = current.KeepFly;
		comp.wingMaxSpeed = current.WingMaxSpeed;
		comp.wingMaxSpeedEN = current.WingMaxSpeedEN;
		comp.wingSpeedEN = current.WingSpeedEN;
		comp.wingSteeringSpeed = current.WingSteeringSpeed;
	}
}
