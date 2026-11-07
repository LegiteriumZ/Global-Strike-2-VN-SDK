using SSJJBase.Singleton;

public class LodFrameTest : MonoBehaviourSingleton<LodFrameTest>
{
	public enum LodType
	{
		one,
		two,
		three
	}

	public LodType Type;

	public void Init()
	{
	}
}
