using System.Collections.Generic;
using UnityEngine;

public class GPUSkinningAnimation : ScriptableObject
{
	public string guid;

	public new string name;

	public GPUSkinningBone[] bones;

	public int rootBoneIndex;

	public GPUSkinningClip[] clips;

	public Bounds bounds;

	public int textureWidth;

	public int textureHeight;

	public float[] lodDistances;

	public Mesh[] lodMeshes;

	public float sphereRadius = 1f;

	public int[] boneHitid;

	public Dictionary<string, int> boneName2id;

	public int BoneNameToId(string name)
	{
		if (boneName2id == null)
		{
			boneName2id = new Dictionary<string, int>(bones.Length);
			for (int i = 0; i < bones.Length; i++)
			{
				boneName2id.Add(bones[i].name, i);
			}
		}
		return boneName2id[name];
	}
}
