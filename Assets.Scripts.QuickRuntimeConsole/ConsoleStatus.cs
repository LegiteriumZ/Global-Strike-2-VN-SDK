using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.QuickRuntimeConsole.commands;

namespace Assets.Scripts.QuickRuntimeConsole;

public static class ConsoleStatus
{
	public static bool ConsoleOpened;

	public static List<object> ObjList = new List<object>();

	public static IRuntimeCommand LockCommand;

	public static bool ShowEditView;

	public static string EditText;

	public static Dictionary<string, object> VariableTable = new Dictionary<string, object>();

	public static object CurrObject
	{
		get
		{
			if (ObjList.Count > 0)
			{
				return ObjList.Last();
			}
			return null;
		}
	}
}
