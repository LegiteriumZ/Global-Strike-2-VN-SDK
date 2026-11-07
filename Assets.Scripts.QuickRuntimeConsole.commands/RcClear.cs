namespace Assets.Scripts.QuickRuntimeConsole.commands;

public class RcClear : IRuntimeCommand
{
	public string Name => "clear";

	public void Execute(string[] args, ref string output, ref string location)
	{
		output = ">\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n>\n" + location + ">\n";
	}
}
