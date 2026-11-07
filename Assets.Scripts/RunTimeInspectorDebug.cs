using Assets.Sources.Utils;
using UnityEngine;

namespace Assets.Scripts;

public class RunTimeInspectorDebug : MonoBehaviour
{
	private GameObject _runTimeObj;

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.F2) && SpecailDebug.Instance.RunTimeDebug)
		{
			if (_runTimeObj == null)
			{
				_runTimeObj = Object.Instantiate(Resources.Load<GameObject>("RunTimeInspectorDebug"));
				Object.DontDestroyOnLoad(_runTimeObj);
			}
			if (_runTimeObj != null)
			{
				_runTimeObj.SetActive(value: true);
			}
		}
		if (UnityEngine.Input.GetKeyDown(KeyCode.F3) && SpecailDebug.Instance.RunTimeDebug && _runTimeObj != null)
		{
			_runTimeObj.SetActive(value: false);
		}
	}
}
