using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility;

public class FollowTransform2Sum : MonoBehaviour
{
	public class FollowC
	{
		public bool IsModel;

		public Transform FollowTran;

		public Transform TargetTran;

		public int Level;
	}

	private readonly List<FollowC> _followCs = new List<FollowC>();

	public List<FollowC> GetTargets()
	{
		return _followCs;
	}

	public void Clear()
	{
		_followCs.Clear();
	}

	private FollowC CheckIn(Transform follower)
	{
		foreach (FollowC followC in _followCs)
		{
			if (followC.FollowTran == follower)
			{
				return followC;
			}
		}
		return null;
	}

	public void Follow(Transform follower, Transform target, int level, bool isModel = true)
	{
		FollowC followC = CheckIn(follower);
		if (followC == null)
		{
			followC = new FollowC
			{
				FollowTran = follower,
				TargetTran = target,
				IsModel = isModel,
				Level = level
			};
			_followCs.Add(followC);
		}
		else
		{
			followC.TargetTran = target;
			followC.IsModel = isModel;
			followC.Level = level;
		}
		UppdateFollow(follower, target);
	}

	public void Sort()
	{
		_followCs.Sort(delegate(FollowC x, FollowC y)
		{
			if (!x.IsModel && y.IsModel)
			{
				return 1;
			}
			return (x.IsModel && !y.IsModel) ? (-1) : 0;
		});
		_followCs.Sort(delegate(FollowC x, FollowC y)
		{
			if (x.Level > y.Level)
			{
				return 1;
			}
			return (x.Level < y.Level) ? (-1) : 0;
		});
	}

	public void UppdateFollow(Transform follower, Transform target)
	{
		if (target != null)
		{
			follower.position = target.position;
			follower.rotation = target.rotation;
		}
	}

	private void LateUpdate()
	{
		foreach (FollowC followC in _followCs)
		{
			UppdateFollow(followC.FollowTran, followC.TargetTran);
		}
	}
}
