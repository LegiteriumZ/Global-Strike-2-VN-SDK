using UnityEngine;

namespace Assets.Scripts.QuickRuntimeConsole.commands;

public class RcCmp : IRuntimeCommand
{
	public string Name => "cmp";

	public void Execute(string[] args, ref string output, ref string location)
	{
		if (args.Length >= 1 && !string.IsNullOrEmpty(args[0]) && ConsoleStatus.CurrObject is GameObject)
		{
			Component component = (ConsoleStatus.CurrObject as GameObject).GetComponent(args[0]);
			if (!(component == null))
			{
				ConsoleStatus.ObjList.Add(component);
				location = location + "." + args[0];
				output = output + location + ">\n";
			}
		}
	}
}
