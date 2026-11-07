using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerCrownEffectInfo : IPlayerShowEffectInfo
{
	public bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		int raceType = room.GetRaceType();
		string freeType = room.GetFreeType();
		string name = player.basicInfo.CareerInfo.Name;
		if (raceType == 100 && !string.IsNullOrEmpty(freeType) && freeType.Equals("deformedmen", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(name))
		{
			if (!name.Equals("chicken", StringComparison.OrdinalIgnoreCase) && !name.Equals("cat", StringComparison.OrdinalIgnoreCase))
			{
				return name.Equals("pig", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}
		return false;
	}

	public Type GetRenderType()
	{
		return typeof(PlayerCrownRender);
	}
}
