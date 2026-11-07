using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class PhotonCombinationPredicationSystem : AbstractAttackPredicationSystem
{
	public class PhotonCombinationRightAction : IRightCmdAction, ICmdAction
	{
		private readonly MessageContext _messageContext;

		public PhotonCombinationRightAction(Contexts contexts)
		{
			_messageContext = contexts.message;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.Level <= 0)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("PHOTO_SWORD_COMBINATION_NOENERGY"));
				NotifyManager.ForceInvoke(38);
				return false;
			}
			return !((float)arg.ClientTime < arg.CurrentWeapon.attack.NextSecondaryAttackTimer);
		}
	}

	public PhotonCombinationPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RifleLeftAction(contexts));
		RightActions.Add(new PhotonCombinationRightAction(contexts));
	}
}
