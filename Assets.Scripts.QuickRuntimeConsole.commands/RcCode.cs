using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.CSharp;

namespace Assets.Scripts.QuickRuntimeConsole.commands;

public class RcCode : IRuntimeCommand
{
	private Dictionary<string, string> _savedCodes = new Dictionary<string, string>();

	private string _code;

	private string _clsName;

	public string Name => "code";

	public void Execute(string[] args, ref string output, ref string location)
	{
		if (args.Length < 1 || string.IsNullOrEmpty(args[0]))
		{
			return;
		}
		if (ConsoleStatus.LockCommand != null)
		{
			if (args[0] == "end" || string.Join(" ", args).StartsWith("code end"))
			{
				ConsoleStatus.LockCommand = null;
				_code = ConsoleStatus.EditText;
				ConsoleStatus.ShowEditView = false;
				_savedCodes[_clsName] = _code;
				output = output + _code + "}code end\n";
			}
		}
		else if (args[0] == "begin")
		{
			if (args.Length >= 2)
			{
				_clsName = args[1];
				ConsoleStatus.LockCommand = this;
				if (!_savedCodes.TryGetValue(_clsName, out _code))
				{
					_code = $"using System;\r\nnamespace QuickRuntimeConsole{{\r\n    public class {_clsName}{{\r\n        public void Run(ref string output){{\r\n            output += \"My Name is \" + Contexts.sharedInstance.player.myPlayerEntity.basicInfo.PlayerName + \"\\n\";\r\n        }}\r\n    }}\r\n}}\r\n";
				}
				ConsoleStatus.EditText = _code;
				ConsoleStatus.ShowEditView = true;
				output = output + "class " + _clsName + " begin {\n";
			}
		}
		else if (args[0] == "get")
		{
			if (args.Length == 2)
			{
				_clsName = args[1];
				_code = _savedCodes[args[1]];
			}
			output += _code;
		}
		else
		{
			if (!(args[0] == "run") || string.IsNullOrEmpty(_code))
			{
				return;
			}
			ICodeCompiler codeCompiler = new CSharpCodeProvider().CreateCompiler();
			CompilerParameters compilerParameters = new CompilerParameters();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				if (assembly.CodeBase.EndsWith(".dll"))
				{
					compilerParameters.ReferencedAssemblies.Add(assembly.CodeBase);
				}
			}
			compilerParameters.GenerateExecutable = false;
			compilerParameters.GenerateInMemory = true;
			CompilerResults compilerResults = codeCompiler.CompileAssemblyFromSource(compilerParameters, _code);
			if (compilerResults.Errors.HasErrors)
			{
				output += "compile error：\n";
				{
					foreach (CompilerError error in compilerResults.Errors)
					{
						output = output + error.ErrorText + "\n";
					}
					return;
				}
			}
			output += "compile success:\n";
			object obj = compilerResults.CompiledAssembly.CreateInstance("QuickRuntimeConsole." + _clsName);
			MethodInfo method = obj.GetType().GetMethod("Run");
			string[] array = new string[1] { output };
			object[] parameters = array;
			method.Invoke(obj, parameters);
			output = array[0];
		}
	}
}
