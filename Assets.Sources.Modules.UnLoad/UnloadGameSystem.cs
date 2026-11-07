using System.Diagnostics;
using Assets.Sources.Framework;
using Entitas;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Modules.UnLoad;

public class UnloadGameSystem : IPlaybackSystem
{
	private readonly IGroup<UnloadEntity> _unloads;

	private bool _isAlreadyKill;

	public UnloadGameSystem(Contexts contexts)
	{
		_unloads = contexts.unload.GetGroup(UnloadMatcher.AllOf(UnloadMatcher.UnloadGame));
	}

	public void OnPlayback()
	{
		if (_unloads.count > 0 && !_isAlreadyKill)
		{
			this.Info("Self Kill Game !!!");
			_isAlreadyKill = true;
			MonoBehaviourSingleton<GameExitManager>.Instance.ExitGame();
			ExecuteGG.CloseNPGameMon();
			if (!Application.isEditor)
			{
				Process.GetCurrentProcess().Kill();
			}
		}
	}
}
