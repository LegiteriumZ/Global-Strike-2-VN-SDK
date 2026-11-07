using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Sources.Utils;

public class SystemProfiler : MonoBehaviour
{
	private string _currentProfileName;

	private bool _collectThisFrame;

	private readonly List<KeyValuePair<string, int>> _profileList = new List<KeyValuePair<string, int>>();

	private readonly Stopwatch _stopwatch = new Stopwatch();

	public static SystemProfiler Instance;

	private void Awake()
	{
		if (Instance != null)
		{
			Object.Destroy(this);
			return;
		}
		Object.DontDestroyOnLoad(base.gameObject);
		Instance = this;
	}

	public void ProfileThisFrame()
	{
		_collectThisFrame = true;
	}

	public void BeginSample(string formatStr)
	{
	}

	public void BeginSample<T>(string formatStr, T arg1)
	{
	}

	public void BeginSample<T1, T2>(string formatStr, T1 arg1, T2 arg2)
	{
	}

	private void BeginSampleInner(string formatStr, params object[] args)
	{
	}

	public void EndSample()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}
}
