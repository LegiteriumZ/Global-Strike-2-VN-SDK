namespace Assets.Scripts.QuickRuntimeConsole.commands;

public interface IRuntimeCommand
{
	string Name { get; }

	void Execute(string[] args, ref string output, ref string location);
}
