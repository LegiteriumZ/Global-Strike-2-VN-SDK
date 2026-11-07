namespace Assets.Sources.Systems.Time;

public sealed class TimeFeature : Feature
{
	public TimeFeature(Contexts contexts)
	{
		Add(new FrameTimeSystem(contexts));
		Add(new RenderTimeSystem(contexts));
	}
}
