using System;

namespace Assets.Sources.Ui.Model.QuickTest;

public class QuickTestAction
{
	public int Delay;

	public Action Action;

	public Func<bool> Condition;

	public readonly int Priority;

	public QuickTestAction(int delay, Action action, Func<bool> condition, int priority)
	{
		Action = action;
		Delay = delay;
		Condition = condition;
		Priority = priority;
	}
}
