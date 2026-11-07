using Assets.Sources.Components.GameRule.RpgDuel;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class RpgDuelDataHandler : ApcPacketHandler<RoleRecipeShowPanelData>
{
	public RpgDuelDataHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 338;
	}

	public override void Handle(RoleRecipeShowPanelData data)
	{
		RpgDuelComponent rpgDuelComponent = (Contexts.sharedInstance.gameRule.hasRpgDuel ? Contexts.sharedInstance.gameRule.rpgDuel : null);
		if (rpgDuelComponent != null)
		{
			rpgDuelComponent.BagData = data.RoleRecipeList;
			rpgDuelComponent.IsBagShow = data.IsShow;
			rpgDuelComponent.RemainTime = data.HideTime;
		}
	}
}
