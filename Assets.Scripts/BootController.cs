using System.Collections;
using Assets.Sources.Config;
using UnityEngine;

namespace Assets.Scripts;

public class BootController : MonoBehaviour
{
	private IEnumerator Start()
	{
		yield return InitBootConfigFromCommand();
	}

	private IEnumerator InitBootConfigFromCommand()
	{
		while (!GameController.Instance.InitFinish)
		{
			yield return null;
		}
		if (TplManager.Instance.GetBootConfig().IsBootCmd)
		{
			ConnectToServerUtility.Connect();
		}
	}
}
