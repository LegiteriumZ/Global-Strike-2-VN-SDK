using Assets.Sources.Framework;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.Shake;

public class ShakeCreateSystem : IPlaybackInitSystem
{
	private readonly Contexts _contexts;

	private SceneObjectContext _sceneObjectContext;

	public ShakeCreateSystem(Contexts contexts)
	{
		_contexts = contexts;
		_sceneObjectContext = contexts.sceneObject;
	}

	public void OnPlaybackInit()
	{
		if (!_sceneObjectContext.hasShake)
		{
			_sceneObjectContext.CreateEntity().AddShake(0, Vector3.zero);
		}
	}
}
