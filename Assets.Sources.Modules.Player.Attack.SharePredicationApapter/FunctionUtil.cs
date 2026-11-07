using System;
using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class FunctionUtil : IFunctionUtil
{
	public static IFunctionUtil Instance = new FunctionUtil();

	public bool ApplyGetBoolean(Func<ICommonWeaponArgs, bool> action, ICommonWeaponArgs arg)
	{
		return action(arg);
	}

	public void Apply(Action<ICommonWeaponArgs> action, ICommonWeaponArgs arg)
	{
		action(arg);
	}
}
