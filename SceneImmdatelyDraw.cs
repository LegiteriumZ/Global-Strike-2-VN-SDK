using System;
using SSJJSceneLoader;
using UnityEngine;

public class SceneImmdatelyDraw : MonoBehaviour
{
	private int _drawFrameCount = 10;

	private bool _isFocus;

	private BaseSceneRender _render;

	private RenderTexture targetTexture;

	private void OnApplicationFocus(bool focus)
	{
		if (focus)
		{
			_isFocus = true;
			_drawFrameCount = 6;
			if ((bool)targetTexture)
			{
				UpdateBlankScreen(isBlank: true);
			}
		}
	}

	public void OnPostRender()
	{
		if (_isFocus)
		{
			Init();
			_render.DrawSceneImmdiately();
			_drawFrameCount--;
			if (_drawFrameCount <= 0)
			{
				_isFocus = false;
				UpdateBlankScreen(isBlank: false);
			}
		}
	}

	private void Init()
	{
		if (_render == null)
		{
			if (targetTexture == null)
			{
				targetTexture = new RenderTexture(1, 1, 0);
			}
			_render = UnityEngine.Object.FindObjectOfType<BaseSceneRender>();
		}
	}

	private void UpdateBlankScreen(bool isBlank)
	{
		try
		{
			Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.targetTexture = (isBlank ? targetTexture : null);
		}
		catch (Exception)
		{
			throw;
		}
	}
}
