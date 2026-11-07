using System;
using System.Collections.Generic;
using UnityEngine;

public class GPUSkinningPlayer
{
	public delegate void OnAnimEvent(GPUSkinningPlayer player, int eventId);

	private GameObject go;

	private Transform transform;

	private MeshRenderer mr;

	private MeshFilter mf;

	private float time;

	private float timeDiff;

	private float crossFadeTime = -1f;

	private float crossFadeProgress;

	private float lastPlayedTime;

	private GPUSkinningClip lastPlayedClip;

	private int lastPlayingFrameIndex = -1;

	private GPUSkinningClip lastPlayingClip;

	private GPUSkinningClip playingClip;

	private GPUSkinningPlayerResources res;

	private MaterialPropertyBlock mpb;

	private int rootMotionFrameIndex = -1;

	private bool rootMotionEnabled;

	private GPUSKinningCullingMode cullingMode = GPUSKinningCullingMode.CullUpdateTransforms;

	private bool visible;

	private bool lodEnabled = true;

	private bool isPlaying;

	public string lastAnimName = "";

	private List<GPUSkinningPlayerJoint> joints;

	public bool RootMotionEnabled
	{
		get
		{
			return rootMotionEnabled;
		}
		set
		{
			rootMotionFrameIndex = -1;
			rootMotionEnabled = value;
		}
	}

	public GPUSKinningCullingMode CullingMode
	{
		get
		{
			if (!Application.isPlaying)
			{
				return GPUSKinningCullingMode.AlwaysAnimate;
			}
			return cullingMode;
		}
		set
		{
			cullingMode = value;
		}
	}

	public bool Visible
	{
		get
		{
			if (!Application.isPlaying)
			{
				return true;
			}
			return visible;
		}
		set
		{
			visible = value;
		}
	}

	public int LastPlayingFrameIndex
	{
		get
		{
			if (lastPlayingFrameIndex == -1)
			{
				return 0;
			}
			if (lastPlayingFrameIndex >= playingClip.frames.Length)
			{
				return 0;
			}
			return lastPlayingFrameIndex;
		}
	}

	public bool LODEnabled
	{
		get
		{
			return lodEnabled;
		}
		set
		{
			lodEnabled = value;
			res.LODSettingChanged(this);
		}
	}

	public bool IsPlaying => isPlaying;

	public GPUSkinningClip PlayerClip => playingClip;

	public string PlayingClipName
	{
		get
		{
			if (playingClip != null)
			{
				return playingClip.name;
			}
			return null;
		}
	}

	public Vector3 Position
	{
		get
		{
			if (!(transform == null))
			{
				return transform.position;
			}
			return Vector3.zero;
		}
	}

	public Vector3 LocalPosition
	{
		get
		{
			if (!(transform == null))
			{
				return transform.localPosition;
			}
			return Vector3.zero;
		}
	}

	public List<GPUSkinningPlayerJoint> Joints => joints;

	public GPUSkinningWrapMode WrapMode
	{
		get
		{
			if (playingClip != null)
			{
				return playingClip.wrapMode;
			}
			return GPUSkinningWrapMode.Once;
		}
	}

	public bool IsTimeAtTheEndOfLoop
	{
		get
		{
			if (playingClip == null)
			{
				return false;
			}
			return GetFrameIndex() == (int)(playingClip.length * (float)playingClip.fps) - 1;
		}
	}

	public float NormalizedTime
	{
		get
		{
			if (playingClip == null)
			{
				return 0f;
			}
			return (float)GetFrameIndex() / (float)((int)(playingClip.length * (float)playingClip.fps) - 1);
		}
		set
		{
			if (playingClip == null)
			{
				return;
			}
			float num = Mathf.Clamp01(value);
			if (WrapMode == GPUSkinningWrapMode.Once)
			{
				time = num * playingClip.length;
				return;
			}
			if (WrapMode == GPUSkinningWrapMode.Loop)
			{
				if (playingClip.individualDifferenceEnabled)
				{
					res.Time = playingClip.length + num * playingClip.length - timeDiff;
				}
				else
				{
					res.Time = num * playingClip.length;
				}
				return;
			}
			throw new NotImplementedException();
		}
	}

	public event OnAnimEvent onAnimEvent;

	public GPUSkinningPlayer(GameObject attachToThisGo, GPUSkinningPlayerResources res)
	{
		go = attachToThisGo;
		transform = go.transform;
		this.res = res;
		mr = go.GetComponent<MeshRenderer>();
		if (mr == null)
		{
			mr = go.AddComponent<MeshRenderer>();
		}
		mf = go.GetComponent<MeshFilter>();
		if (mf == null)
		{
			mf = go.AddComponent<MeshFilter>();
		}
		GPUSkinningMaterial currentMaterial = GetCurrentMaterial();
		mr.sharedMaterial = currentMaterial?.material;
		mf.sharedMesh = res.mesh;
		mpb = new MaterialPropertyBlock();
		ConstructJoints();
	}

	public void Play(string clipName, bool isloop)
	{
		if (lastAnimName == clipName)
		{
			return;
		}
		lastAnimName = clipName;
		GPUSkinningClip[] clips = res.anim.clips;
		int num = ((clips != null) ? clips.Length : 0);
		for (int i = 0; i < num; i++)
		{
			if (clips[i].name == clipName)
			{
				clips[i].wrapMode = (isloop ? GPUSkinningWrapMode.Loop : GPUSkinningWrapMode.Once);
				if (playingClip != clips[i] || (playingClip != null && playingClip.wrapMode == GPUSkinningWrapMode.Once && IsTimeAtTheEndOfLoop) || (playingClip != null && !isPlaying))
				{
					SetNewPlayingClip(clips[i]);
				}
				break;
			}
		}
	}

	public void CrossFade(string clipName, float fadeLength, bool isLoop)
	{
		if (playingClip == null)
		{
			Play(clipName, isLoop);
			return;
		}
		GPUSkinningClip[] clips = res.anim.clips;
		int num = ((clips != null) ? clips.Length : 0);
		for (int i = 0; i < num; i++)
		{
			if (clips[i].name == clipName)
			{
				clips[i].wrapMode = (isLoop ? GPUSkinningWrapMode.Loop : GPUSkinningWrapMode.Once);
				if (playingClip != clips[i])
				{
					crossFadeProgress = 0f;
					crossFadeTime = fadeLength;
					SetNewPlayingClip(clips[i]);
					break;
				}
				if ((playingClip != null && playingClip.wrapMode == GPUSkinningWrapMode.Once && IsTimeAtTheEndOfLoop) || (playingClip != null && !isPlaying))
				{
					SetNewPlayingClip(clips[i]);
					break;
				}
			}
		}
	}

	public void Stop()
	{
		isPlaying = false;
	}

	public void Resume()
	{
		if (playingClip != null)
		{
			isPlaying = true;
		}
	}

	public void SetLODMesh(Mesh mesh)
	{
		if (!LODEnabled)
		{
			mesh = res.mesh;
		}
		if (mf != null && mf.sharedMesh != mesh)
		{
			mf.sharedMesh = mesh;
		}
	}

	public void Update_Editor(float timeDelta)
	{
		Update_Internal(timeDelta);
	}

	public void Update(float timeDelta)
	{
		Update_Internal(timeDelta);
	}

	private void SetNewPlayingClip(GPUSkinningClip clip)
	{
		lastPlayedClip = playingClip;
		lastPlayedTime = GetCurrentTime();
		isPlaying = true;
		playingClip = clip;
		rootMotionFrameIndex = -1;
		time = 0f;
		timeDiff = UnityEngine.Random.Range(0f, playingClip.length);
	}

	private void Update_Internal(float timeDelta)
	{
		if (!isPlaying || playingClip == null)
		{
			return;
		}
		GPUSkinningMaterial currentMaterial = GetCurrentMaterial();
		if (currentMaterial == null)
		{
			return;
		}
		if (mr.sharedMaterial != currentMaterial.material)
		{
			mr.sharedMaterial = currentMaterial.material;
		}
		if (playingClip.wrapMode == GPUSkinningWrapMode.Loop)
		{
			UpdateMaterial(timeDelta, currentMaterial);
		}
		else
		{
			if (playingClip.wrapMode != 0)
			{
				throw new NotImplementedException();
			}
			if (time >= playingClip.length)
			{
				time = playingClip.length;
				UpdateMaterial(timeDelta, currentMaterial);
			}
			else
			{
				UpdateMaterial(timeDelta, currentMaterial);
				time += timeDelta;
				if (time > playingClip.length)
				{
					time = playingClip.length;
				}
			}
		}
		crossFadeProgress += timeDelta;
		lastPlayedTime += timeDelta;
	}

	private void UpdateMaterial(float deltaTime, GPUSkinningMaterial currMtrl)
	{
		int frameIndex = GetFrameIndex();
		if (lastPlayingClip == playingClip && lastPlayingFrameIndex == frameIndex)
		{
			res.Update(deltaTime, currMtrl);
			return;
		}
		lastPlayingClip = playingClip;
		lastPlayingFrameIndex = frameIndex;
		float num = 1f;
		int num2 = -1;
		GPUSkinningFrame frame = null;
		if (res.IsCrossFadeBlending(lastPlayedClip, crossFadeTime, crossFadeProgress))
		{
			num2 = GetCrossFadeFrameIndex();
			frame = lastPlayedClip.frames[num2];
			num = res.CrossFadeBlendFactor(crossFadeProgress, crossFadeTime);
		}
		GPUSkinningFrame frame2 = playingClip.frames[frameIndex];
		if (Visible || CullingMode == GPUSKinningCullingMode.AlwaysAnimate)
		{
			mr.GetPropertyBlock(mpb);
			res.Update(deltaTime, currMtrl);
			res.UpdatePlayingData(mpb, playingClip, frameIndex, frame2, playingClip.rootMotionEnabled && rootMotionEnabled, lastPlayedClip, GetCrossFadeFrameIndex(), crossFadeTime, crossFadeProgress);
			mr.SetPropertyBlock(mpb);
			UpdateJoints(frame2);
		}
		if (playingClip.rootMotionEnabled && rootMotionEnabled && frameIndex != rootMotionFrameIndex && CullingMode != GPUSKinningCullingMode.CullCompletely)
		{
			rootMotionFrameIndex = frameIndex;
			DoRootMotion(frame, 1f - num, doRotate: false);
			DoRootMotion(frame2, num, doRotate: true);
		}
	}

	private GPUSkinningMaterial GetCurrentMaterial()
	{
		if (res == null)
		{
			return null;
		}
		if (playingClip == null)
		{
			return res.GetMaterial(GPUSkinningPlayerResources.MaterialState.RootOff_BlendOff);
		}
		if (playingClip.rootMotionEnabled && rootMotionEnabled)
		{
			if (res.IsCrossFadeBlending(lastPlayedClip, crossFadeTime, crossFadeProgress))
			{
				if (lastPlayedClip.rootMotionEnabled)
				{
					return res.GetMaterial(GPUSkinningPlayerResources.MaterialState.RootOn_BlendOn_CrossFadeRootOn);
				}
				return res.GetMaterial(GPUSkinningPlayerResources.MaterialState.RootOn_BlendOn_CrossFadeRootOff);
			}
			return res.GetMaterial(GPUSkinningPlayerResources.MaterialState.RootOn_BlendOff);
		}
		if (res.IsCrossFadeBlending(lastPlayedClip, crossFadeTime, crossFadeProgress))
		{
			if (lastPlayedClip.rootMotionEnabled)
			{
				return res.GetMaterial(GPUSkinningPlayerResources.MaterialState.RootOff_BlendOn_CrossFadeRootOn);
			}
			return res.GetMaterial(GPUSkinningPlayerResources.MaterialState.RootOff_BlendOn_CrossFadeRootOff);
		}
		return res.GetMaterial(GPUSkinningPlayerResources.MaterialState.RootOff_BlendOff);
	}

	private void DoRootMotion(GPUSkinningFrame frame, float blend, bool doRotate)
	{
		if (frame != null)
		{
			Vector3 translation = frame.rootMotionDeltaPositionQ * transform.forward * frame.rootMotionDeltaPositionL * blend;
			transform.Translate(translation, Space.World);
			if (doRotate)
			{
				transform.rotation *= frame.rootMotionDeltaRotation;
			}
		}
	}

	private float GetCurrentTime()
	{
		float num = 0f;
		if (WrapMode == GPUSkinningWrapMode.Once)
		{
			return time;
		}
		if (WrapMode == GPUSkinningWrapMode.Loop)
		{
			return res.Time + (playingClip.individualDifferenceEnabled ? timeDiff : 0f);
		}
		throw new NotImplementedException();
	}

	private int GetFrameIndex()
	{
		float currentTime = GetCurrentTime();
		if (playingClip.length == currentTime)
		{
			return GetTheLastFrameIndex_WrapMode_Once(playingClip);
		}
		return GetFrameIndex_WrapMode_Loop(playingClip, currentTime);
	}

	private int GetCrossFadeFrameIndex()
	{
		if (lastPlayedClip == null)
		{
			return 0;
		}
		if (lastPlayedClip.wrapMode == GPUSkinningWrapMode.Once)
		{
			if (lastPlayedTime >= lastPlayedClip.length)
			{
				return GetTheLastFrameIndex_WrapMode_Once(lastPlayedClip);
			}
			return GetFrameIndex_WrapMode_Loop(lastPlayedClip, lastPlayedTime);
		}
		if (lastPlayedClip.wrapMode == GPUSkinningWrapMode.Loop)
		{
			return GetFrameIndex_WrapMode_Loop(lastPlayedClip, lastPlayedTime);
		}
		throw new NotImplementedException();
	}

	private int GetTheLastFrameIndex_WrapMode_Once(GPUSkinningClip clip)
	{
		return (int)(clip.length * (float)clip.fps) - 1;
	}

	private int GetFrameIndex_WrapMode_Loop(GPUSkinningClip clip, float time)
	{
		if (clip.wrapMode == GPUSkinningWrapMode.Loop)
		{
			return (int)(time * (float)clip.fps) % (int)(clip.length * (float)clip.fps);
		}
		return (int)(time * (float)clip.fps);
	}

	private void UpdateJoints(GPUSkinningFrame frame)
	{
		if (joints == null)
		{
			return;
		}
		_ = frame.matrices;
		GPUSkinningBone[] bones = res.anim.bones;
		int num = joints.Count;
		for (int i = 0; i < num; i++)
		{
			GPUSkinningPlayerJoint gPUSkinningPlayerJoint = joints[i];
			Transform transform = (Application.isPlaying ? gPUSkinningPlayerJoint.Transform : gPUSkinningPlayerJoint.transform);
			if (transform != null)
			{
				Matrix4x4 matrix4x = frame.matrices[gPUSkinningPlayerJoint.BoneIndex] * bones[gPUSkinningPlayerJoint.BoneIndex].BindposeInv;
				if (playingClip.rootMotionEnabled && rootMotionEnabled)
				{
					matrix4x = frame.RootMotionInv(res.anim.rootBoneIndex) * matrix4x;
				}
				transform.localPosition = matrix4x.MultiplyPoint(Vector3.zero);
				Vector3 toDirection = matrix4x.MultiplyVector(Vector3.right);
				Quaternion localRotation = Quaternion.FromToRotation(Vector3.right, toDirection);
				transform.localRotation = localRotation;
			}
			else
			{
				joints.RemoveAt(i);
				i--;
				num--;
			}
		}
	}

	private void ConstructJoints()
	{
		if (joints != null)
		{
			return;
		}
		GPUSkinningPlayerJoint[] componentsInChildren = go.GetComponentsInChildren<GPUSkinningPlayerJoint>();
		GPUSkinningBone[] bones = res.anim.bones;
		int num = ((bones != null) ? bones.Length : 0);
		for (int i = 0; i < num; i++)
		{
			GPUSkinningBone gPUSkinningBone = bones[i];
			if (!gPUSkinningBone.isExposed)
			{
				continue;
			}
			if (joints == null)
			{
				joints = new List<GPUSkinningPlayerJoint>();
			}
			bool flag = false;
			if (componentsInChildren != null)
			{
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					if (componentsInChildren[j] != null && componentsInChildren[j].BoneGUID == gPUSkinningBone.guid)
					{
						if (componentsInChildren[j].BoneIndex != i)
						{
							componentsInChildren[j].Init(i, gPUSkinningBone.guid);
							GPUSkinningUtil.MarkAllScenesDirty();
						}
						joints.Add(componentsInChildren[j]);
						componentsInChildren[j] = null;
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				GameObject gameObject = new GameObject(gPUSkinningBone.name);
				gameObject.transform.parent = go.transform;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = Vector3.one;
				GPUSkinningPlayerJoint gPUSkinningPlayerJoint = gameObject.AddComponent<GPUSkinningPlayerJoint>();
				joints.Add(gPUSkinningPlayerJoint);
				gPUSkinningPlayerJoint.Init(i, gPUSkinningBone.guid);
				GPUSkinningUtil.MarkAllScenesDirty();
			}
		}
		if (Application.isPlaying)
		{
			DeleteInvalidJoints(componentsInChildren);
		}
	}

	private void DeleteInvalidJoints(GPUSkinningPlayerJoint[] joints)
	{
		if (joints == null)
		{
			return;
		}
		for (int i = 0; i < joints.Length; i++)
		{
			if (joints[i] != null)
			{
				for (int j = 0; j < joints[i].transform.childCount; j++)
				{
					Transform child = joints[i].transform.GetChild(j);
					child.parent = go.transform;
					child.localPosition = Vector3.zero;
				}
				UnityEngine.Object.DestroyImmediate(joints[i].transform.gameObject);
				GPUSkinningUtil.MarkAllScenesDirty();
			}
		}
	}
}
