using System;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public interface IPlayerShowEffectInfo
{
	bool IsEffectOn(PlayerEntity player, IBattleRoom room);

	Type GetRenderType();
}
