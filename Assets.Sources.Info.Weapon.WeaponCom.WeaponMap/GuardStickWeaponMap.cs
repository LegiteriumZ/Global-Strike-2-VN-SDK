using System.Collections.Generic;
using Assets.Sources.Info.Weapon.WeaponCom.Conditions;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom.WeaponMap;

public class GuardStickWeaponMap
{
	private readonly List<IWeaponAction> _actions = new List<IWeaponAction>();

	private readonly TriggerAction _leftFireTriggerAction;

	private readonly TriggerAction _rightFireTriggerAction;

	public GuardStickWeaponMap(Contexts contexts)
	{
		FireAction doAction = new FireAction(contexts);
		BaseWeaponAction baseWeaponAction = new BaseWeaponAction();
		baseWeaponAction.AddAction(new SetNextAttackTimerAction(1000));
		baseWeaponAction.AddAction(new SetNextSecondaryAttackTimerAction(1000));
		baseWeaponAction.AddAction(new PlayerViewAction(31));
		baseWeaponAction.AddAction(new PlayerTorsoAction(15));
		baseWeaponAction.AddAction(new CreateEventAction(doAction, _actions, 300));
		baseWeaponAction.AddAction(new CreateEventAction(doAction, _actions, 600));
		BaseWeaponAction baseWeaponAction2 = new BaseWeaponAction();
		baseWeaponAction2.AddAction(new SetNextAttackTimerAction(1000));
		baseWeaponAction2.AddAction(new SetNextSecondaryAttackTimerAction(1000));
		baseWeaponAction2.AddAction(new PlayerViewAction(20));
		baseWeaponAction2.AddAction(new PlayerTorsoAction(15));
		baseWeaponAction2.AddAction(new CreateEventAction(doAction, _actions, 800));
		baseWeaponAction2.AddAction(new CreateEventAction(doAction, _actions, 1100));
		ButtonWeaponCondition condition = new ButtonWeaponCondition(64);
		AndCondition andCondition = new AndCondition();
		andCondition.AddCondition(condition);
		andCondition.AddCondition(new NextAttackTimerCondition());
		ButtonWeaponCondition condition2 = new ButtonWeaponCondition(512);
		AndCondition andCondition2 = new AndCondition();
		andCondition2.AddCondition(condition2);
		andCondition2.AddCondition(new NextSecondaryAttackTimerCondition());
		_leftFireTriggerAction = new TriggerAction();
		_leftFireTriggerAction.SetTiggerCon(andCondition);
		_leftFireTriggerAction.SetDoLogic(baseWeaponAction);
		_rightFireTriggerAction = new TriggerAction();
		_rightFireTriggerAction.SetTiggerCon(andCondition2);
		_rightFireTriggerAction.SetDoLogic(baseWeaponAction2);
	}

	public void WeaponLogic(ref CommonWeaponArg arg)
	{
		for (int num = _actions.Count - 1; num >= 0; num--)
		{
			if (_actions[num].DoAction(ref arg) == WeaponActionResult.ACTION_RESULT.DONE)
			{
				_actions.RemoveAt(num);
			}
		}
		_leftFireTriggerAction.DoFrameAction(ref arg);
		_rightFireTriggerAction.DoFrameAction(ref arg);
	}
}
