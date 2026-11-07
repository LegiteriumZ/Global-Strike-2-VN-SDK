using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BioZ_Update_Diff_Weapon_PanelHandler : ApcPacketHandler<NBioZDiffWeaponData>
{
	private GameRuleContext _gameRuleContext;

	public BioZ_Update_Diff_Weapon_PanelHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1111;
	}

	public override void Handle(NBioZDiffWeaponData data)
	{
		Contexts.sharedInstance.message.bioZInit.BioZDiffWeaponData = data;
		NotifyManager.ForceInvoke(126);
	}
}
