using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PathGuide;

public class PathGuideUpdateSystem : IPlaybackSystem
{
	private SceneObjectContext _sceneObjectContext;

	private IGroup<SceneObjectEntity> _group;

	public PathGuideUpdateSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_group = _sceneObjectContext.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PathGuide, SceneObjectMatcher.UnityObjects).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			GameObject gameObject = item.unityObjects.LoadResults[0].GameObject;
			Texture texture = item.unityObjects.LoadResults[1].Object as Texture;
			int contentHashCode = GetContentHashCode(item.pathGuide.paths);
			if (contentHashCode != item.pathGuide.pathHashCode)
			{
				PathGuideRender.Render(gameObject, item.pathGuide.paths, texture);
				item.ReplacePathGuide(item.pathGuide.paths, contentHashCode);
			}
		}
	}

	public int GetContentHashCode(List<Vector3> list)
	{
		if (list == null)
		{
			return 0;
		}
		int num = 17;
		foreach (Vector3 item in list)
		{
			num = num * 23 + item.GetHashCode();
		}
		return num;
	}
}
