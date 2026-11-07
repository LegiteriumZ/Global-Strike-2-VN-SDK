using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.QuickRuntimeConsole.commands;
using UnityEngine;

namespace Assets.Scripts.QuickRuntimeConsole;

public class QuickRuntimeConsole : MonoBehaviour
{
	private bool _startConsole;

	private string _password = "";

	private bool _setFocus;

	private string _output = ">\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n";

	private string _input = "";

	private Vector2 scrollpos;

	private List<string> _cmdHistroy = new List<string>();

	private int _histroyIndex;

	private string _location = "";

	private void Start()
	{
		_startConsole = ConsoleUtils.GetMacAddress().EndsWith("7C75BB");
	}

	private void Update()
	{
		if (_startConsole && UnityEngine.Input.anyKey)
		{
			_password += UnityEngine.Input.inputString;
			if (_password.EndsWith("[cmd]"))
			{
				ConsoleStatus.ConsoleOpened = true;
				_setFocus = true;
			}
			if (_password.Length > 1000)
			{
				_password = _password.Substring(_password.Length - 20);
			}
		}
	}

	private void Execute(string str)
	{
		string[] array = _output.Split('\n');
		if (array.Length > 200)
		{
			_output = string.Join("\n", array.Skip(array.Length - 200).ToArray());
		}
		if (string.IsNullOrEmpty(str))
		{
			_output += $"{_location}>\n";
		}
		else
		{
			_cmdHistroy.Remove(str);
			_cmdHistroy.Add(str);
			_histroyIndex = _cmdHistroy.Count;
			string[] array2 = str.Split(' ');
			if (ConsoleStatus.LockCommand != null)
			{
				try
				{
					ConsoleStatus.LockCommand.Execute(array2, ref _output, ref _location);
				}
				catch
				{
				}
			}
			else
			{
				IRuntimeCommand command = CommandFactory.GetCommand(array2[0]);
				if (command != null)
				{
					try
					{
						command.Execute(array2.Skip(1).ToArray(), ref _output, ref _location);
					}
					catch
					{
					}
				}
				else
				{
					_output += $"{_location}> No command {array2[0]}\n";
				}
			}
		}
		scrollpos = new Vector2(0f, 2.1474836E+09f);
	}
}
