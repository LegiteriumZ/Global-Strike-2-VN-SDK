using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.PlayerBag.SwitchWeapon;

internal class PhotonPistolComSwitchWeaponPredicationSystem : DefaultSwitchWeaponPredicationSystem
{
	private readonly MessageContext _messageContext;

	public PhotonPistolComSwitchWeaponPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		_messageContext = contexts.message;
	}

	protected override void ChangeWeapon(PlayerEntity player, int slot, int clientTime)
	{
		if (slot == 2)
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("PHOTO_SWORD_COMBINATION_USEKNIFE"), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else
		{
			base.ChangeWeapon(player, slot, clientTime);
		}
	}
}
