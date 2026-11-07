using System;
using System.Collections.Generic;
using Assets.Scripts.QuickRuntimeConsole.commands;
using Entitas.Utils;

namespace Assets.Scripts.QuickRuntimeConsole;

public static class CommandFactory
{
	private static Dictionary<string, IRuntimeCommand> _commands = new Dictionary<string, IRuntimeCommand>();

	public static IRuntimeCommand GetCommand(string name)
	{
		if (_commands.ContainsKey(name))
		{
			return _commands[name];
		}
		return null;
	}

	public static void ForeachType(Type x)
	{
		if (_commands == null)
		{
			_commands = new Dictionary<string, IRuntimeCommand>();
		}
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<IRuntimeCommand>())
		{
			IRuntimeCommand runtimeCommand = Activator.CreateInstance(x) as IRuntimeCommand;
			_commands.Add(runtimeCommand.Name, runtimeCommand);
		}
	}

	public static void InitTypes()
	{
		RcVar rcVar = new RcVar();
		_commands.Add(rcVar.Name, rcVar);
		RcShow rcShow = new RcShow();
		_commands.Add(rcShow.Name, rcShow);
		RcInvoke rcInvoke = new RcInvoke();
		_commands.Add(rcInvoke.Name, rcInvoke);
		RcFind rcFind = new RcFind();
		_commands.Add(rcFind.Name, rcFind);
		RcCode rcCode = new RcCode();
		_commands.Add(rcCode.Name, rcCode);
		RcCmp rcCmp = new RcCmp();
		_commands.Add(rcCmp.Name, rcCmp);
		RcClear rcClear = new RcClear();
		_commands.Add(rcClear.Name, rcClear);
		RcCd rcCd = new RcCd();
		_commands.Add(rcCd.Name, rcCd);
	}

	public static string CheckInitType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<IRuntimeCommand>())
		{
			return string.Format("var cmd{0} = new {0}(); _commands.Add(cmd{0}.Name, cmd{0});", x.Name);
		}
		return "";
	}

	public static void Clear()
	{
		_commands.Clear();
	}
}
