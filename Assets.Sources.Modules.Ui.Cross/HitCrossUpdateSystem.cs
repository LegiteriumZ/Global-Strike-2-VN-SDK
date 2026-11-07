using Assets.Sources.Components.Time;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Ui.Cross;

public class HitCrossUpdateSystem : IPlaybackSystem
{
	private CrossContext _crossContext;

	private TimeComponent _time;

	public HitCrossUpdateSystem(Contexts contexts)
	{
		_crossContext = contexts.cross;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (_crossContext.hitCross.ChangRedTime > 0)
		{
			_crossContext.hitCross.ChangRedTime -= _time.FrameInterval;
		}
	}
}
