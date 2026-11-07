using Assets.Sources.Components.Time;

public class commonVideoHelpProvider : IcommonVideoHelpProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public commonVideoHelpProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isVideo()
	{
		return false;
	}

	public bool isSelectVideoSpeed(int index)
	{
		return false;
	}

	public bool isCrimialSuspectDead()
	{
		return false;
	}

	public bool isCrimialSuspectOut()
	{
		return false;
	}

	public float getCurrentSnapshotLength()
	{
		return 0f;
	}

	public float selectSnapshotIndex()
	{
		return 0f;
	}

	public float getProgress()
	{
		return 0f;
	}

	public string getStopOrContinue()
	{
		return null;
	}

	public float getTotalSnapshotLength()
	{
		return 0f;
	}
}
