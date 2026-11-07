namespace Assets.Sources.Modules.Player.Attack.Action;

public class PistolFrameAction : AbstractFrameAction
{
	public PistolFrameAction(Contexts contexts, IIdleCmdAction action)
		: base(contexts, action)
	{
	}

	protected override bool IsPistol()
	{
		return true;
	}
}
