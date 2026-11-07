using Assets.Sources.Info.Weapon.WeaponCom.Conditions;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public class ConditionAction : IWeaponAction
{
	private IWeaponCondition _canDoCondition;

	private IWeaponAction _trueAction;

	private IWeaponAction _falseAction;

	public ConditionAction SetCanDo(IWeaponCondition canDo)
	{
		_canDoCondition = canDo;
		return this;
	}

	public IWeaponAction SetTrueLogic(IWeaponAction trueLogic)
	{
		_trueAction = trueLogic;
		return this;
	}

	public IWeaponAction SetFalseLogic(IWeaponAction falseLogic)
	{
		_falseAction = falseLogic;
		return this;
	}

	public WeaponActionResult.ACTION_RESULT DoAction(ref CommonWeaponArg arg)
	{
		if (_canDoCondition == null || !_canDoCondition.DoCondition(ref arg))
		{
			if (_falseAction != null)
			{
				_falseAction.DoAction(ref arg);
			}
			return WeaponActionResult.ACTION_RESULT.WAIT;
		}
		if (_trueAction != null)
		{
			_trueAction.DoAction(ref arg);
		}
		return WeaponActionResult.ACTION_RESULT.DONE;
	}
}
