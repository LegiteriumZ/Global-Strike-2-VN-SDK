using CommonUtils;
using UnityEngine;

namespace Assets.Tests;

public class MonoBehaviourTest : MonoBehaviour
{
	private void Start()
	{
		DebugLogger.Log("On Start");
	}

	private void OnEnable()
	{
		DebugLogger.Log("On Enable");
	}

	private void OnDisable()
	{
		DebugLogger.Log("On Disable");
	}

	private void OnDestroy()
	{
		DebugLogger.Log("On Destroy");
	}

	private void Update()
	{
	}
}
