using System;
using Assets.Sources.Info.Effect.PlayerEffect.Render;

namespace Assets.Sources.Info.Effect.PlayerEffect.PlayerStatusEffect;

public class PlayerViewStatusEffectInfo : CommonPlayerStatusEffectInfo
{
	private readonly int _statusId;

	public PlayerViewStatusEffectInfo(int statusId)
		: base(statusId)
	{
		_statusId = statusId;
	}

	public override string GetUniqueId()
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.showX + "|" + StatusInfoData.showY + "|" + StatusInfoData.showZ + "|" + StatusInfoData.EffectScale + "|" + StatusInfoData.changeScale;
		}
		return "";
	}

	public override Type GetThirdRenderType()
	{
		return typeof(ViewPlayerStatusRender);
	}
}
