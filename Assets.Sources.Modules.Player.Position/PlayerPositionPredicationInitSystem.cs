using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using SSJJBase.Obscure;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Position;

public class PlayerPositionPredicationInitSystem : PredicationInitSystemBase<FposComponent>
{
	private PlayerContext _playerContext;

	private TimeContext _timeContext;

	public override FposComponent CurrentComponent => _playerContext.predictionEntity.fpos;

	public PlayerPositionPredicationInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_timeContext = contexts.time;
	}

	public override void GetComponentFromSnapshot(FposComponent comp)
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		comp.Sp(new Vector3(predictionEntity.basicInfo.Current.X, predictionEntity.basicInfo.Current.Y, predictionEntity.basicInfo.Current.Z));
	}

	public override void OnPredicatoinError(int cmdSeq)
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		FposComponent history = GetHistory(cmdSeq);
		GetComponentFromSnapshot(TempValue);
		if (TempValue != null && history != null)
		{
			Vector3 errorOffset = Seed.Instance.GetPos(TempValue.Gp()) - Seed.Instance.GetPos(history.Gp());
			if (IsNeedIn(predictionEntity, errorOffset))
			{
				float num = (100f - (float)(_timeContext.time.ClientRealTime - predictionEntity.postionErrorSmooth.PredictedErrorTime)) / 100f;
				num = ((num < 0f) ? 0f : num);
				Vector3 vector = predictionEntity.postionErrorSmooth.PredictedErrorOffet * num;
				predictionEntity.postionErrorSmooth.PredictedErrorTime = _timeContext.time.ClientRealTime;
				predictionEntity.postionErrorSmooth.PredictedErrorOffet = Seed.Instance.GetPos(history.Gp()) - Seed.Instance.GetPos(TempValue.Gp()) + vector;
			}
		}
	}

	private bool IsNeedIn(PlayerEntity player, Vector3 errorOffset)
	{
		if ((double)errorOffset.magnitude <= 0.1)
		{
			return false;
		}
		if (!player.basicInfo.IsDead && player.state.GetPlayerStateType(268435456))
		{
			return true;
		}
		if (errorOffset.magnitude < 200f || player.move.ImpulseTime > 0 || player.move.ImpulseTime2 > 0)
		{
			return true;
		}
		return false;
	}
}
