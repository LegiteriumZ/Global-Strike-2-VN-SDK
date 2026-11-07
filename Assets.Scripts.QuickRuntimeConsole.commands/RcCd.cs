using System;
using System.Reflection;
using Sharpen;

namespace Assets.Scripts.QuickRuntimeConsole.commands;

public class RcCd : IRuntimeCommand
{
	public string Name => "cd";

	public void Execute(string[] args, ref string output, ref string location)
	{
		if (args.Length < 1 || string.IsNullOrEmpty(args[0]))
		{
			ConsoleStatus.ObjList.Clear();
			location = "";
			output = output + location + ">\n";
			return;
		}
		args[0] = args[0].Replace('/', '.');
		if (args[0] == "..")
		{
			if (ConsoleStatus.ObjList.Count != 0)
			{
				ConsoleStatus.ObjList.RemoveLast();
				location = location.Substring(0, location.LastIndexOf("."));
				output = output + location + ">\n";
			}
			return;
		}
		if (args[0] == ".contexts")
		{
			location = ".contexts";
			ConsoleStatus.ObjList.Add(Contexts.sharedInstance);
			output = output + location + ">\n";
			return;
		}
		if (args[0].StartsWith("."))
		{
			string key = args[0].Substring(1);
			if (ConsoleStatus.VariableTable.ContainsKey(key))
			{
				ConsoleStatus.ObjList.Clear();
				ConsoleStatus.ObjList.Add(ConsoleStatus.VariableTable[key]);
				location = args[0];
				output = output + location + ">\n";
				return;
			}
		}
		if (ConsoleStatus.CurrObject == null)
		{
			return;
		}
		string[] array = args[0].Split('.');
		object obj = ConsoleStatus.CurrObject;
		for (int i = 0; i < array.Length; i++)
		{
			if (obj == null)
			{
				break;
			}
			Type type = obj.GetType();
			PropertyInfo property = type.GetProperty(array[i]);
			if (property != null)
			{
				obj = property.GetValue(obj, null);
				location = location + "." + array[i];
				ConsoleStatus.ObjList.Add(obj);
			}
			FieldInfo field = type.GetField(array[i]);
			if (field != null)
			{
				obj = field.GetValue(obj);
				location = location + "." + array[i];
				ConsoleStatus.ObjList.Add(obj);
			}
			if (array[i].StartsWith("[") && array[i].EndsWith("]"))
			{
				object key2 = ConsoleUtils.GetKey(args[0]);
				obj = ConsoleUtils.GetValue(obj, key2);
				if (obj != null)
				{
					location = location + "." + array[i];
					ConsoleStatus.ObjList.Add(obj);
				}
			}
		}
		output = output + location + ">\n";
	}
}
