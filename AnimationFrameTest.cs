using SSJJBase.Singleton;

public class AnimationFrameTest : MonoBehaviourSingleton<AnimationFrameTest>
{
	public enum AnimationType
	{
		Always,
		Normal,
		No
	}

	public AnimationType Type;

	public void Init()
	{
	}
}
