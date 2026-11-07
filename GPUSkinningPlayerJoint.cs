using UnityEngine;

[ExecuteInEditMode]
public class GPUSkinningPlayerJoint : MonoBehaviour
{
	[HideInInspector]
	[SerializeField]
	private int boneIndex;

	[HideInInspector]
	[SerializeField]
	private string boneGUID;

	private Transform bone;

	public int BoneIndex => boneIndex;

	public string BoneGUID => boneGUID;

	public Transform Transform => bone;

	private void Awake()
	{
		base.hideFlags = HideFlags.HideInInspector;
		bone = base.transform;
	}

	public void Init(int boneIndex, string boneGUID)
	{
		this.boneIndex = boneIndex;
		this.boneGUID = boneGUID;
	}
}
