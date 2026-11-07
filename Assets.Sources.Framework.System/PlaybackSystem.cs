using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public class PlaybackSystem : FrameworkSystemBase<IPlaybackSystem>
{
	private readonly TimeContext _timeContext;

	private List<IPlaybackSystem> _systems;

	public override List<IPlaybackSystem> Systems => _systems;

	public PlaybackSystem(Contexts contexts, IGameModule module)
	{
		_timeContext = contexts.time;
		_systems = module.PlaybackSystems;
		Init();
	}

	public override void SingleExecute(IPlaybackSystem module)
	{
		module.OnPlayback();
	}
}
