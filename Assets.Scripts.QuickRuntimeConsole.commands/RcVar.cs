namespace Assets.Scripts.QuickRuntimeConsole.commands;

public class RcVar : IRuntimeCommand
{
	public string Name => "var";

	public void Execute(string[] args, ref string output, ref string location)
	{
		if (args.Length >= 1 && !string.IsNullOrEmpty(args[0]) && ConsoleStatus.CurrObject != null)
		{
			ConsoleStatus.VariableTable[args[0]] = ConsoleStatus.CurrObject;
			output = output + location + "> define var " + args[0] + "\n";
		}
	}
}
