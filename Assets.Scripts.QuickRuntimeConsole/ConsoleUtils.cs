using System.Collections;
using System.Net.NetworkInformation;
using CommonUtils;
using Entitas.Utils;

namespace Assets.Scripts.QuickRuntimeConsole;

public static class ConsoleUtils
{
	public static object GetValue(object obj, object key)
	{
		if (obj.GetType().ImplementsInterface<IList>())
		{
			return ((IList)obj)[(int)key];
		}
		if (obj.GetType().ImplementsInterface<IDictionary>())
		{
			return ((IDictionary)obj)[key];
		}
		return null;
	}

	public static bool SetValue(object obj, object key, object value)
	{
		if (obj.GetType().ImplementsInterface<IList>() && (int)key >= 0 && (int)key <= ((IList)obj).Count)
		{
			((IList)obj)[(int)key] = value;
			return true;
		}
		if (obj.GetType().ImplementsInterface<IDictionary>())
		{
			((IDictionary)obj)[key] = value;
			return true;
		}
		return false;
	}

	public static object GetKey(string arg)
	{
		string[] array = arg.Split(':');
		if (array.Length < 2)
		{
			return null;
		}
		if (array[0].StartsWith("["))
		{
			array[0] = array[0].Substring(1);
		}
		if (array[1].EndsWith("]"))
		{
			array[1] = array[1].Substring(0, array[1].Length - 1);
		}
		string obj = array[0];
		object obj2 = array[1];
		switch (obj.ToString())
		{
		case "int":
			obj2 = int.Parse((string)obj2);
			break;
		case "string":
			obj2 = obj2.ToString();
			break;
		case "var":
			obj2 = ConsoleStatus.VariableTable[(string)obj2];
			break;
		}
		return obj2;
	}

	public static string GetMacAddress()
	{
		string text = "";
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface networkInterface in allNetworkInterfaces)
		{
			DebugLogger.Log(networkInterface.Description);
			if (networkInterface.Description == "en0")
			{
				text = networkInterface.GetPhysicalAddress().ToString();
				break;
			}
			text = networkInterface.GetPhysicalAddress().ToString();
			if (text != "")
			{
				break;
			}
		}
		return text;
	}
}
