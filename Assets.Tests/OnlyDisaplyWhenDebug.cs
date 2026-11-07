using System.IO;
using UnityEngine;

namespace Assets.Tests;

public class OnlyDisaplyWhenDebug : MonoBehaviour
{
	internal void Awake()
	{
		if (!File.Exists("OpenDebug.txt"))
		{
			base.gameObject.SetObjectActive(isactive: false);
		}
	}
}
