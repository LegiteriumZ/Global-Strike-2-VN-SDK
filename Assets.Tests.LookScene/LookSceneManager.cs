using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Tests.LookScene;

internal class LookSceneManager
{
	private static LookSceneManager _instance;

	public string chooseResFile;

	private string primaryStr;

	private byte[] _realModelBytesData;

	public byte[] ModelBytesData;

	private List<SceneTextureData> _pixtureList = new List<SceneTextureData>();

	public static LookSceneManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new LookSceneManager();
			}
			return _instance;
		}
	}

	public byte[] RealModelBytesData
	{
		get
		{
			if (_realModelBytesData != null)
			{
				return _realModelBytesData;
			}
			return GetBytes(primaryStr);
		}
	}

	public List<SceneTextureData> PixtureList
	{
		get
		{
			return _pixtureList;
		}
		private set
		{
		}
	}

	public IEnumerator OpenWindow()
	{
		IntPtr pidl = DllOpenFileDialog.SHBrowseForFolder(new OpenDialogDir
		{
			pszDisplayName = new string(new char[2000]),
			lpszTitle = "资源文件夹选择",
			ulFlags = 1u
		});
		char[] array = new char[2000];
		for (int i = 0; i < 2000; i++)
		{
			array[i] = '\0';
		}
		if (DllOpenFileDialog.SHGetPathFromIDList(pidl, array))
		{
			string text = new string(array);
			Debug.Log("路径" + (chooseResFile = text.Substring(0, text.IndexOf('\0'))));
		}
		bool isNull = string.IsNullOrEmpty(chooseResFile);
		while (isNull)
		{
			if (!isNull)
			{
				yield break;
			}
			yield return null;
		}
		yield return null;
	}

	public IEnumerator InitSceneData()
	{
		yield return BaseAsyncManager.Instance.StartCoroutine(OpenWindow());
		yield return BaseAsyncManager.Instance.StartCoroutine(CreateData());
	}

	private IEnumerator CreateData()
	{
		string[] fileName = Directory.GetFiles(chooseResFile);
		if (fileName.Length == 0)
		{
			yield return null;
		}
		for (int i = 0; i < fileName.Length; i++)
		{
			string extension = Path.GetExtension(fileName[i]);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName[i]);
			switch (extension)
			{
			case ".jpg":
			case ".png":
				_ = chooseResFile + "/" + fileNameWithoutExtension;
				BaseAsyncManager.Instance.StartCoroutine(LoadTexture(fileName[i], fileNameWithoutExtension));
				break;
			case ".sce":
			{
				bool flag = fileName[i].IndexOf("_u_v") != -1;
				bool flag2 = fileName[i].IndexOf("_u") != -1;
				if (flag2 || flag2)
				{
					if (flag)
					{
						primaryStr = fileName[i];
					}
					else if (primaryStr == null)
					{
						primaryStr = fileName[i];
					}
				}
				break;
			}
			case ".bytes":
				if (File.Exists(fileName[i]))
				{
					ModelBytesData = File.ReadAllBytes(fileName[i]);
				}
				break;
			}
		}
	}

	public byte[] GetBytes(string path)
	{
		if (File.Exists(path))
		{
			_realModelBytesData = File.ReadAllBytes(path);
			return _realModelBytesData;
		}
		return null;
	}

	private IEnumerator LoadTexture(string path, string name)
	{
		UnityWebRequest m_Request = UnityWebRequestTexture.GetTexture(path);
		yield return m_Request.Send();
		if (m_Request.isDone)
		{
			if (m_Request == null || m_Request.isNetworkError)
			{
				Debug.Log("加载失败");
				yield break;
			}
			Texture2D content = DownloadHandlerTexture.GetContent(m_Request);
			SceneTextureData sceneTextureData = new SceneTextureData();
			sceneTextureData.texture = content;
			sceneTextureData.name = name;
			_pixtureList.Add(sceneTextureData);
		}
	}
}
