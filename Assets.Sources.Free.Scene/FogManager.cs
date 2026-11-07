using System.Collections.Generic;
using Assets.Scripts.Fog;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.Scene;

public class FogManager : MonoBehaviourSingleton<FogManager>
{
	private Dictionary<int, FreeFog> fogs = new Dictionary<int, FreeFog>();

	public void Frame(int frameTime)
	{
		foreach (KeyValuePair<int, FreeFog> fog in fogs)
		{
			fog.Value.frame(frameTime);
		}
	}

	private void Update()
	{
		Frame((int)(Time.deltaTime * 1000f));
		if (fogs.Count > 0)
		{
			SSJJFog sSJJFog = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.GetComponent<SSJJFog>();
			if (sSJJFog == null)
			{
				sSJJFog = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.gameObject.AddComponent<SSJJFog>();
				sSJJFog.InitFogShader();
			}
			sSJJFog.Fogs.Clear();
			{
				foreach (KeyValuePair<int, FreeFog> fog in fogs)
				{
					sSJJFog.Fogs.Add(fog.Value.getFog());
				}
				return;
			}
		}
		SSJJFog component = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.GetComponent<SSJJFog>();
		if (component != null)
		{
			Object.Destroy(component);
		}
	}

	public FreeFog GetFog(int fogId)
	{
		FreeFog value = null;
		fogs.TryGetValue(fogId, out value);
		return value;
	}

	public void RemoveFog(int fogId)
	{
		fogs.Remove(fogId);
	}

	public void AddFog(int fogId, FreeFog fog)
	{
		fogs.Add(fogId, fog);
	}

	public void Clear()
	{
		fogs.Clear();
	}

	private void xx()
	{
	}
}
