using System.Collections;
using UnityEngine;

namespace CommonUtils;

public class CoroutineTask
{
	private static IEnumerator YiledNull()
	{
		yield return null;
	}

	public static void NextCoFrame(object jobId)
	{
		if (Application.isPlaying)
		{
			if (jobId != null && jobId is MonoBehaviour)
			{
				(jobId as MonoBehaviour).StartCoroutine(YiledNull());
			}
			else
			{
				Debug.LogError("In Playing Mode, Job Runner Error");
			}
		}
		else if (jobId != null)
		{
			Debug.LogError("Cant Run Coroutine");
		}
		else
		{
			Debug.LogError("In Editor Mode, Job Runner is Null");
		}
	}

	public static void NextCoTask(object jobId, IEnumerator co)
	{
		if (Application.isPlaying)
		{
			if (jobId != null && jobId is MonoBehaviour)
			{
				(jobId as MonoBehaviour).StartCoroutine(co);
			}
			else
			{
				Debug.LogError("In Playing Mode, Job Runner Error");
			}
		}
		else if (jobId != null)
		{
			Debug.LogError("Cant Run Coroutine");
		}
		else
		{
			Debug.LogError("In Editor Mode, Job Runner is Null");
		}
	}
}
