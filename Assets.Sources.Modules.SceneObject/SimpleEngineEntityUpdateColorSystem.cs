using Assets.Sources.Components.SceneObject;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject;

public class SimpleEngineEntityUpdateColorSystem : IRenderSystem, IPlaybackSystem
{
	private TimeComponent _time;

	private IGroup<SceneObjectEntity> _group;

	public SimpleEngineEntityUpdateColorSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.UpdateColor, SceneObjectMatcher.UnityObjects).NoneOf(SceneObjectMatcher.Destroy));
		_time = contexts.time.time;
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			if (item.updateColor.Material == null)
			{
				MeshRenderer[] componentsInChildren = item.unityObjects.LoadResults[0].GameObject.GetComponentsInChildren<MeshRenderer>();
				if (componentsInChildren != null && componentsInChildren.Length != 0)
				{
					item.updateColor.Material = new Material[componentsInChildren.Length];
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						item.updateColor.Material[i] = componentsInChildren[i].material;
						if (item.updateColor.Material[i].shader.name == "SSJJ/UnityMap")
						{
							item.updateColor.Material[i].shader = Shader.Find("SSJJ/UnityMap/Color");
						}
						item.updateColor.Material[i].renderQueue = 3000;
					}
				}
			}
			if (item.updateColor.Material != null)
			{
				Material[] material = item.updateColor.Material;
				for (int j = 0; j < material.Length; j++)
				{
					material[j].color = item.updateColor.CurColor;
				}
			}
		}
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			UpdateColorComponent updateColor = item.updateColor;
			if (!(updateColor.OriginColor == updateColor.ToColor))
			{
				int num = _time.ClientRealTime % (updateColor.Time * 2);
				if (num > updateColor.Time)
				{
					num = updateColor.Time * 2 - num;
				}
				updateColor.CurColor = Color.Lerp(updateColor.OriginColor, updateColor.ToColor, (float)num / (float)updateColor.Time);
			}
		}
	}
}
