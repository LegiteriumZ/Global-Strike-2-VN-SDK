using System;
using System.Reflection;

namespace Assets.Scripts.QuickRuntimeConsole.commands;

public class RcInvoke : IRuntimeCommand
{
	public string Name => "invoke";

	public void Execute(string[] args, ref string output, ref string location)
	{
		if (args.Length < 1 || string.IsNullOrEmpty(args[0]))
		{
			return;
		}
		object currObject = ConsoleStatus.CurrObject;
		if (currObject == null)
		{
			return;
		}
		Type type = currObject.GetType();
		object[] array = new object[args.Length - 1];
		for (int i = 1; i < args.Length; i++)
		{
			array[i - 1] = ConsoleUtils.GetKey(args[i]);
		}
		MethodInfo method = type.GetMethod(args[0]);
		if (method != null)
		{
			object obj = method.Invoke(currObject, array);
			output = string.Concat(output, location, ">", obj, "\n");
			return;
		}
		PropertyInfo property = type.GetProperty(args[0]);
		if (property != null)
		{
			property.SetValue(currObject, array[0], null);
			output = string.Concat(output, location, ">", args[0], "=", array[0], "\n");
			return;
		}
		FieldInfo field = type.GetField(args[0]);
		if (field != null)
		{
			field.SetValue(currObject, array[0]);
			output = string.Concat(output, location, ">", args[0], "=", array[0], "\n");
		}
		else if (args[0].StartsWith("[") && args[0].EndsWith("]"))
		{
			object key = ConsoleUtils.GetKey(args[0]);
			if (ConsoleUtils.SetValue(currObject, key, array[0]))
			{
				output = string.Concat(output, location, ">", args[0], "=", array[0], "\n");
			}
		}
	}
}
