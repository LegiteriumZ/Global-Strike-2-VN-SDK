using System.Collections.Generic;
using Assets.Sources.Components.Snapshot;
using Assets.Sources.Framework;

namespace Assets.Sources.Utils;

public class PredicationErrorCollector
{
	public struct PredicationArgs
	{
		public IPredicationInitSystem Predication;

		public int CmdSeq;

		public SnapshotsComponent SnapshotsComponent;

		public float UnityTime;
	}

	private static PredicationErrorCollector _instance;

	public List<PredicationArgs> Errors = new List<PredicationArgs>();

	public static PredicationErrorCollector Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new PredicationErrorCollector();
			}
			return _instance;
		}
	}

	public void AddError(IPredicationInitSystem predication, int seq, SnapshotsComponent snapshotComponent, float unityTime)
	{
		Errors.Add(new PredicationArgs
		{
			Predication = predication,
			CmdSeq = seq,
			SnapshotsComponent = snapshotComponent,
			UnityTime = unityTime
		});
	}

	public void ClearError()
	{
		Errors.Clear();
	}

	public void Clear()
	{
		ClearError();
		_instance = null;
	}
}
