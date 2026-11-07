using System;
using System.Collections;
using RenderHeads.Media.AVProMovieCapture;
using UnityEngine;

namespace Assets.Sources.Utils.MoviePro;

public class MovieCaptureSsjj : CaptureBase
{
	[SerializeField]
	private bool _captureMouseCursor;

	[SerializeField]
	private MouseCursor _mouseCursor;

	public bool CaptureMouseCursor
	{
		get
		{
			return _captureMouseCursor;
		}
		set
		{
			_captureMouseCursor = value;
		}
	}

	public MouseCursor MouseCursor
	{
		get
		{
			return _mouseCursor;
		}
		set
		{
			_mouseCursor = value;
		}
	}

	public override bool PrepareCapture()
	{
		if (_capturing)
		{
			return false;
		}
		if (SystemInfo.graphicsDeviceVersion.StartsWith("Direct3D 9"))
		{
			throw new Exception("[AVProMovieCapture] Direct3D9 not yet supported, please use Direct3D11 instead.");
		}
		if (SystemInfo.graphicsDeviceVersion.StartsWith("OpenGL") && !SystemInfo.graphicsDeviceVersion.Contains("emulated"))
		{
			throw new Exception("[AVProMovieCapture] OpenGL not yet supported for CaptureFromScreen component, please use Direct3D11 instead. You may need to switch your build platform to Windows.");
		}
		if (_mouseCursor != null)
		{
			_mouseCursor.enabled = _captureMouseCursor;
		}
		SelectRecordingResolution(Screen.width, Screen.height);
		_pixelFormat = NativePlugin.PixelFormat.RGBA32;
		if (SystemInfo.graphicsDeviceVersion.StartsWith("OpenGL") && !SystemInfo.graphicsDeviceVersion.Contains("emulated"))
		{
			_pixelFormat = NativePlugin.PixelFormat.BGRA32;
			_isTopDown = true;
		}
		else
		{
			_isTopDown = false;
			if (_isDirectX11)
			{
				_isTopDown = false;
			}
		}
		GenerateFilename();
		return base.PrepareCapture();
	}

	public override void UnprepareCapture()
	{
		if (_mouseCursor != null)
		{
			_mouseCursor.enabled = false;
		}
		base.UnprepareCapture();
	}

	private IEnumerator FinalRenderCapture()
	{
		yield return _waitForEndOfFrame;
		EncodeUnityAudio();
		RenderThreadEvent(NativePlugin.PluginEvent.CaptureFrameBuffer);
		GL.InvalidateState();
		UpdateFPS();
	}

	public override void UpdateFrame()
	{
		if (_capturing && !_paused)
		{
			TickFrameTimer();
			if (CanOutputFrame())
			{
				StartCoroutine(FinalRenderCapture());
			}
			RenormTimer();
		}
		base.UpdateFrame();
	}
}
