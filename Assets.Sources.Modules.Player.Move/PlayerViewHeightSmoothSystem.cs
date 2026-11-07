using System;
using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Move;

public class PlayerViewHeightSmoothSystem : IAfterPredicationSystem
{
	private readonly PlayerContext _playerContext;

	public const int ViewHeightSmoothTime = 200;

	public const float ViewHeightSmoothMinDiff = 12.7f;

	public PlayerViewHeightSmoothSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnAfterPredication()
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		if (predictionEntity == null)
		{
			return;
		}
		ViewHeightComponent viewHeight = predictionEntity.viewHeight;
		if (viewHeight.getCheckWalkStep())
		{
			viewHeight.setCheckWalkStep(value: false);
			float num = viewHeight.getLastPositionZ() - predictionEntity.GetCompenstatePos(predictionEntity.fpos.Change.GetPosIndex()).z;
			if (Math.Abs(num) > 12.7f)
			{
				UpdateRemain(predictionEntity.viewHeight);
				predictionEntity.viewHeight.ViewHeightSmoothTotal = predictionEntity.viewHeight.ViewHeightSmoothRemain + num;
				predictionEntity.viewHeight.SmoothStartTime = (int)(Time.time * 1000f);
			}
		}
		UpdateRemain(predictionEntity.viewHeight);
		predictionEntity.viewHeight.setLastPositionZ(predictionEntity.GetCompenstatePos(predictionEntity.fpos.Change.GetPosIndex()).z);
	}

	private static void UpdateRemain(ViewHeightComponent vc)
	{
		int num = (int)(Time.time * 1000f);
		if (num < vc.SmoothStartTime + 200)
		{
			float num2 = (float)(num - vc.SmoothStartTime) / 200f;
			vc.ViewHeightSmoothRemain = vc.ViewHeightSmoothTotal * (1f - num2);
		}
		else
		{
			vc.ViewHeightSmoothRemain = 0f;
		}
	}
}
