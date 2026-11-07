using System;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public interface IPlayerViewShowEffectInfo
{
	bool IsEffectOn(PlayerEntity player, IBattleRoom room);

	Type GetRenderType();
}
