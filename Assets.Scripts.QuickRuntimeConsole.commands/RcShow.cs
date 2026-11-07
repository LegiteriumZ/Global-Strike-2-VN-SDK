using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Assets.Scripts.QuickRuntimeConsole.commands;

public class RcShow : IRuntimeCommand
{
	public string Name => "show";

	public void Execute(string[] args, ref string output, ref string location)
	{
		if (ConsoleStatus.CurrObject == null)
		{
			return;
		}
		object currObject = ConsoleStatus.CurrObject;
		Type type = currObject.GetType();
		string text = "";
		if (args.Length == 0 || string.IsNullOrEmpty(args[0]) || args[0] == ".")
		{
			text = currObject.ToString();
		}
		else if (args[0].Replace("/", ".") == ".")
		{
			foreach (KeyValuePair<string, object> item in ConsoleStatus.VariableTable)
			{
				text = string.Concat(text, item.Key, "=", item.Value, "\n");
			}
			text = string.Concat(text, "contexts=", Contexts.sharedInstance, "\n");
		}
		else if (args[0] == "-a")
		{
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				try
				{
					text = string.Concat(text, propertyInfo.Name, "=", propertyInfo.GetValue(currObject, null), "\n");
				}
				catch
				{
				}
			}
			FieldInfo[] fields = type.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				try
				{
					text = string.Concat(text, fieldInfo.Name, "=", fieldInfo.GetValue(currObject), "\n");
				}
				catch
				{
				}
			}
		}
		else if (args[0].StartsWith("[") && args[0].EndsWith("]"))
		{
			object key = ConsoleUtils.GetKey(args[0]);
			object value = ConsoleUtils.GetValue(currObject, key);
			text += $"[{key.ToString()}]={value}, ";
		}
		else
		{
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo propertyInfo2 in properties)
			{
				if (Regex.IsMatch(propertyInfo2.Name, args[0]))
				{
					try
					{
						text = string.Concat(text, propertyInfo2.Name, "=", propertyInfo2.GetValue(currObject, null), "\n");
					}
					catch
					{
					}
				}
			}
			FieldInfo[] fields = type.GetFields();
			foreach (FieldInfo fieldInfo2 in fields)
			{
				if (Regex.IsMatch(fieldInfo2.Name, args[0]))
				{
					try
					{
						text = string.Concat(text, fieldInfo2.Name, "=", fieldInfo2.GetValue(currObject), "\n");
					}
					catch
					{
					}
				}
			}
		}
		output = output + location + ">" + text + "\n";
	}
}
