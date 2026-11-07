using Assets.Tests.LookScene;
using SSJJBase.Thread;
using UnityEngine;

namespace SSJJ.UI.Buttons.Battle;

public class TestBattleServer : MonoBehaviour
{
	public static bool IsLookScene;

	public void OnClickConnect()
	{
		if (GameController.Instance.InitFinish)
		{
			ConnectToServerUtility.Connect();
			base.gameObject.SetActive(value: false);
		}
	}

	public void OnClickConnectOffline()
	{
		OfflineGameController component = GameObject.Find("GameController").GetComponent<OfflineGameController>();
		if (component != null)
		{
			component.InitOfflineData();
		}
		base.gameObject.SetActive(value: false);
	}

	public void OnClickConnectOfflineLookScene()
	{
		GameObject obj = GameObject.Find("GameController");
		obj.GetComponent<GameController>().enabled = false;
		LookSceneManager instance = LookSceneManager.Instance;
		BaseAsyncManager.Instance.StartCoroutine(instance.InitSceneData());
		IsLookScene = true;
		obj.AddComponent<OfflineGameSetting>();
		OfflineGameController component = obj.GetComponent<OfflineGameController>();
		OfflineGameSetting component2 = obj.GetComponent<OfflineGameSetting>();
		component2.TurnOn = true;
		component2.SceneId = 0;
		component2.Player = "police";
		component2.Hand = "man";
		component2.Weapon = "dagger";
		component2.X = (component2.Y = (component2.Z = 0f));
		if (component != null)
		{
			component.InitOfflineData();
		}
		base.gameObject.SetActive(value: false);
	}
}
