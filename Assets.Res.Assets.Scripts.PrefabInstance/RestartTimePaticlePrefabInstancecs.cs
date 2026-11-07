using UnityEngine;

namespace Assets.Res.Assets.Scripts.PrefabInstance;

public class RestartTimePaticlePrefabInstancecs : PaticlePrefabInstancecs
{
	public int restartTime;

	private int restartCountdown;

	public void Update()
	{
		if (restartTime <= 0)
		{
			return;
		}
		if (restartCountdown <= 0)
		{
			if (restartCountdown < 0)
			{
				StopAndRestart();
			}
			restartCountdown = restartTime;
		}
		else
		{
			restartCountdown -= (int)(Time.deltaTime * 1000f);
		}
	}

	public void OnDisable()
	{
		restartCountdown = 0;
	}
}
