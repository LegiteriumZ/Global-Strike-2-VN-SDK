using System.IO;
using UnityEngine;

namespace Assets.Tests;

internal class LookSceneDebug : MonoBehaviour
{
	public void Awake()
	{
		Init();
	}

	private void Init()
	{
		GameObject.Find("GameController");
		if (!File.Exists("LookSceneDebug.txt"))
		{
			base.gameObject.SetObjectActive(isactive: false);
		}
	}
}
