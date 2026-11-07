using Assets.Sources.Components.Interface;
using SSJJBase.Extensions;
using UnityEngine;
using config;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class UseAntidoteEffectRender : AbstractPlayerEffectRender
{
	private int _time;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_time = 2000;
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		_time -= frameTime;
		if (_time <= 0)
		{
			targetPlayer.GetPlayerInfo().UseingAntidote = false;
		}
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		float ssjjScaleX = EffectObject.transform.GetSsjjScaleX();
		double z = BoundBoxConfig.GetBoundsMaxForNormalPlayer("").z;
		int teamSuggestFlag = battleRoom.GetTeamSuggestFlag();
		z = ((teamSuggestFlag == 0) ? (z + (double)(ssjjScaleX * 20f)) : ((2 != teamSuggestFlag) ? (z + (double)(ssjjScaleX * 12f)) : (z + (double)(ssjjScaleX * 13f))));
		return new Vector3(0f, 0f, (float)z);
	}
}
