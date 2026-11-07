using System;
using UnityEngine;

[Serializable]
public class GPUSkinningFrame
{
	public Matrix4x4[] matrices;

	public Matrix4x4[] bonemMatrices;

	public Quaternion rootMotionDeltaPositionQ;

	public float rootMotionDeltaPositionL;

	public Quaternion rootMotionDeltaRotation;

	[NonSerialized]
	private bool rootMotionInvInit;

	[NonSerialized]
	private Matrix4x4 rootMotionInv;

	public Matrix4x4 RootMotionInv(int rootBoneIndex)
	{
		if (!rootMotionInvInit)
		{
			rootMotionInv = matrices[rootBoneIndex].inverse;
			rootMotionInvInit = true;
		}
		return rootMotionInv;
	}
}
