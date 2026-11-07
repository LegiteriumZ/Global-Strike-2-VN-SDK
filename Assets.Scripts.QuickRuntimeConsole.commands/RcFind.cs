using Sharpen;
using UnityEngine;

namespace Assets.Scripts.QuickRuntimeConsole.commands;

public class RcFind : IRuntimeCommand
{
	public string Name => "find";

	public void Execute(string[] args, ref string output, ref string location)
	{
		if (args.Length < 1 || string.IsNullOrEmpty(args[0]))
		{
			ConsoleStatus.ObjList.Clear();
			location = "";
			output = output + location + ">\n";
			return;
		}
		if (args[0].Replace('/', '.') == "..")
		{
			if (ConsoleStatus.ObjList.Count != 0)
			{
				ConsoleStatus.ObjList.RemoveLast();
				location = location.Substring(0, location.LastIndexOf("."));
				output = output + location + ">\n";
			}
			return;
		}
		string text = string.Join(" ", args).Replace('.', '/');
		if (text.StartsWith("/"))
		{
			string[] array = text.Split('/');
			ConsoleStatus.ObjList.Clear();
			location = "";
			for (int i = 1; i < array.Length; i++)
			{
				GameObject item;
				if (i == 1)
				{
					item = GameObject.Find(array[i]);
				}
				else
				{
					GameObject gameObject = ConsoleStatus.CurrObject as GameObject;
					if (gameObject.transform.Find(array[i]) == null)
					{
						break;
					}
					item = gameObject.transform.Find(array[i]).gameObject;
				}
				location = location + "." + array[i].Replace('/', '.');
				ConsoleStatus.ObjList.Add(item);
			}
			output = output + location + ">\n";
		}
		else
		{
			if (!(ConsoleStatus.CurrObject is GameObject))
			{
				return;
			}
			string[] array2 = text.Split('/');
			for (int j = 0; j < array2.Length; j++)
			{
				GameObject gameObject2 = ConsoleStatus.CurrObject as GameObject;
				if (gameObject2.transform.Find(array2[j]) == null)
				{
					break;
				}
				GameObject item = gameObject2.transform.Find(array2[j]).gameObject;
				location = location + "." + array2[j].Replace('/', '.');
				ConsoleStatus.ObjList.Add(item);
			}
			output = output + location + ">\n";
		}
	}
}
