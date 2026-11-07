using System.Collections;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Utils.Threading;

public class AsyncManager : BaseAsyncManager, ICoRoutineManager
{
	public override void SendEditorCommand(string cmd)
	{
		base.SendEditorCommand(cmd);
	}

	public override Coroutine StartCoRoutine(IEnumerator enumerator)
	{
		return base.StartCoRoutine(enumerator);
	}

	public override void StopCoRoutine(IEnumerator enumerator)
	{
		base.StopCoRoutine(enumerator);
	}

	public override void Start()
	{
		base.Start();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}
}
