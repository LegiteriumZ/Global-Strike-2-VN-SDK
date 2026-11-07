using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using agora_gaming_rtc;

public class VideoSurface : MonoBehaviour
{
	public delegate void SetTransformDelegate(uint uid, string objName, ref Transform transform);

	private IntPtr data = Marshal.AllocHGlobal(8294400);

	private int defWidth;

	private int defHeight;

	private Texture2D nativeTexture;

	public SetTransformDelegate mAdjustTransfrom;

	private uint mUid;

	private bool mEnable = true;

	private void Start()
	{
	}

	private void Update()
	{
		IRtcEngine rtcEngine = IRtcEngine.QueryEngine();
		if (rtcEngine == null)
		{
			return;
		}
		Renderer component = GetComponent<Renderer>();
		uint uid = mUid;
		if (mEnable)
		{
			if (component.material.mainTexture == null)
			{
				if (rtcEngine.UpdateTexture(0, uid, data, ref defWidth, ref defHeight) != -1 && defWidth > 0 && defHeight > 0)
				{
					nativeTexture = new Texture2D(defWidth, defHeight, TextureFormat.RGBA32, mipChain: false);
					component.material.mainTexture = nativeTexture;
					nativeTexture.LoadRawTextureData(data, defWidth * defHeight * 4);
					nativeTexture.Apply();
				}
			}
			else
			{
				if (!(component.material.mainTexture != null) || !(component.material.mainTexture is Texture2D))
				{
					return;
				}
				int width = 0;
				int height = 0;
				if (rtcEngine.UpdateTexture(0, uid, data, ref width, ref height) != -1)
				{
					if (width == defWidth && height == defHeight)
					{
						nativeTexture.LoadRawTextureData(data, width * height * 4);
						nativeTexture.Apply();
						return;
					}
					defWidth = width;
					defHeight = height;
					nativeTexture = null;
					nativeTexture = new Texture2D(defWidth, defHeight, TextureFormat.RGBA32, mipChain: false);
					component.material.mainTexture = nativeTexture;
					nativeTexture.LoadRawTextureData(data, defWidth * defHeight);
					nativeTexture.Apply();
				}
			}
		}
		else if (component.material.mainTexture != null && component.material.mainTexture is Texture2D)
		{
			component.material.mainTexture = null;
		}
	}

	private void OnDestroy()
	{
		Marshal.FreeHGlobal(data);
		WriteLog("VideoSurface  onDestory");
	}

	public void WriteLog(string info)
	{
		FileInfo fileInfo = new FileInfo(Application.dataPath + "//UnityC# log.txt");
		StreamWriter streamWriter = (fileInfo.Exists ? fileInfo.AppendText() : fileInfo.CreateText());
		streamWriter.WriteLine(info);
		streamWriter.Close();
		streamWriter.Dispose();
	}

	public void SetForUser(uint uid)
	{
		mUid = uid;
		Debug.Log("Set uid " + uid + " for " + base.gameObject.name);
	}

	public void SetEnable(bool enable)
	{
		mEnable = enable;
	}
}
