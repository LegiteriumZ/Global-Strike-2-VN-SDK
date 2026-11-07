using System.Collections;
using System.Collections.Generic;
using SSJJBase.Thread;

namespace Assets.Sources.Modules.Player.Sound;

internal class PlayingSound
{
	private static List<PlayingSound> _caches = new List<PlayingSound>();

	private IEnumerator _coroutine;

	private FootstepControl _control;

	public FootstepControl Control => _control;

	public static PlayingSound Create(IEnumerator coroutine, FootstepControl control)
	{
		if (_caches.Count == 0)
		{
			PlayingSound playingSound = new PlayingSound();
			playingSound.Init(coroutine, control);
			return playingSound;
		}
		PlayingSound playingSound2 = _caches[0];
		_caches.RemoveAt(0);
		playingSound2.Init(coroutine, control);
		return playingSound2;
	}

	public static void Recircyle(PlayingSound c)
	{
		_caches.Add(c);
	}

	public void Init(IEnumerator coroutine, FootstepControl control)
	{
		_coroutine = coroutine;
		_control = control;
	}

	public void Stop(ICoRoutineManager coRoutineManager)
	{
		if (_coroutine != null)
		{
			coRoutineManager.StopCoRoutine(_coroutine);
		}
		if (_control != null)
		{
			_control.Stop();
		}
		Recircyle(this);
	}
}
