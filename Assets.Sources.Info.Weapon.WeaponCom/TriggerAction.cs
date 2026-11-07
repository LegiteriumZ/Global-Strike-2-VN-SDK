using Assets.Sources.Info.Weapon.WeaponCom.Conditions;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public class TriggerAction : IWeaponFrameAction
{
	public enum TRIGGER_TYPE
	{
		TRIGGER,
		DOING
	}

	private IWeaponCondition _tiggerCon;

	private IWeaponCondition _canDo;

	private IWeaponAction _doLogic;

	private TRIGGER_TYPE _status;

	public void DoFrameAction(ref CommonWeaponArg arg)
	{
		if (_status == TRIGGER_TYPE.TRIGGER)
		{
			if (_tiggerCon == null || !_tiggerCon.DoCondition(ref arg))
			{
				return;
			}
			_status = TRIGGER_TYPE.DOING;
		}
		if (_status != TRIGGER_TYPE.DOING)
		{
			return;
		}
		if (_canDo == null || _canDo.DoCondition(ref arg))
		{
			if (_doLogic != null && _doLogic.DoAction(ref arg) == WeaponActionResult.ACTION_RESULT.DONE)
			{
				_status = TRIGGER_TYPE.TRIGGER;
			}
		}
		else
		{
			_status = TRIGGER_TYPE.TRIGGER;
		}
	}

	public TriggerAction SetTiggerCon(IWeaponCondition tiggerCon)
	{
		_tiggerCon = tiggerCon;
		return this;
	}

	public TriggerAction SetCanDo(IWeaponCondition canDo)
	{
		_canDo = canDo;
		return this;
	}

	public TriggerAction SetDoLogic(IWeaponAction doLogic)
	{
		_doLogic = doLogic;
		return this;
	}
}
