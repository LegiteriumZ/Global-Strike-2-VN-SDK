using System.Collections.Generic;
using UnityEngine;

public class GPUSkinningPlayerResources
{
	public enum MaterialState
	{
		RootOn_BlendOff,
		RootOn_BlendOn_CrossFadeRootOn,
		RootOn_BlendOn_CrossFadeRootOff,
		RootOff_BlendOff,
		RootOff_BlendOn_CrossFadeRootOn,
		RootOff_BlendOn_CrossFadeRootOff,
		Count
	}

	public GPUSkinningAnimation anim;

	public Mesh mesh;

	public Texture2D texture;

	public List<GPUSkinningPlayerMono> players = new List<GPUSkinningPlayerMono>();

	private CullingGroup cullingGroup;

	private GPUSkinningBetterList<BoundingSphere> cullingBounds = new GPUSkinningBetterList<BoundingSphere>(100);

	private GPUSkinningMaterial[] mtrls;

	private static string[] keywords = new string[6] { "ROOTON_BLENDOFF", "ROOTON_BLENDON_CROSSFADEROOTON", "ROOTON_BLENDON_CROSSFADEROOTOFF", "ROOTOFF_BLENDOFF", "ROOTOFF_BLENDON_CROSSFADEROOTON", "ROOTOFF_BLENDON_CROSSFADEROOTOFF" };

	private GPUSkinningExecuteOncePerFrame executeOncePerFrame = new GPUSkinningExecuteOncePerFrame();

	private float time;

	private static int shaderPropID_GPUSkinning_TextureMatrix = -1;

	private static int shaderPropID_GPUSkinning_TextureSize_NumPixelsPerFrame = 0;

	private static int shaderPorpID_GPUSkinning_FrameIndex_PixelSegmentation = 0;

	private static int shaderPropID_GPUSkinning_RootMotion = 0;

	private static int shaderPorpID_GPUSkinning_FrameIndex_PixelSegmentation_Blend_CrossFade = 0;

	private static int shaderPropID_GPUSkinning_RootMotion_CrossFade = 0;

	public float Time
	{
		get
		{
			return time;
		}
		set
		{
			time = value;
		}
	}

	public GPUSkinningPlayerResources()
	{
		if (shaderPropID_GPUSkinning_TextureMatrix == -1)
		{
			shaderPropID_GPUSkinning_TextureMatrix = Shader.PropertyToID("_GPUSkinning_TextureMatrix");
			shaderPropID_GPUSkinning_TextureSize_NumPixelsPerFrame = Shader.PropertyToID("_GPUSkinning_TextureSize_NumPixelsPerFrame");
			shaderPorpID_GPUSkinning_FrameIndex_PixelSegmentation = Shader.PropertyToID("_GPUSkinning_FrameIndex_PixelSegmentation");
			shaderPropID_GPUSkinning_RootMotion = Shader.PropertyToID("_GPUSkinning_RootMotion");
			shaderPorpID_GPUSkinning_FrameIndex_PixelSegmentation_Blend_CrossFade = Shader.PropertyToID("_GPUSkinning_FrameIndex_PixelSegmentation_Blend_CrossFade");
			shaderPropID_GPUSkinning_RootMotion_CrossFade = Shader.PropertyToID("_GPUSkinning_RootMotion_CrossFade");
		}
	}

	~GPUSkinningPlayerResources()
	{
		DestroyCullingGroup();
	}

	public void Destroy()
	{
		anim = null;
		mesh = null;
		if (cullingBounds != null)
		{
			cullingBounds.Release();
			cullingBounds = null;
		}
		DestroyCullingGroup();
		if (mtrls != null)
		{
			for (int i = 0; i < mtrls.Length; i++)
			{
				mtrls[i].Destroy();
				mtrls[i] = null;
			}
			mtrls = null;
		}
		if (texture != null)
		{
			Object.DestroyImmediate(texture);
			texture = null;
		}
		if (players != null)
		{
			players.Clear();
			players = null;
		}
	}

	public void AddCullingBounds()
	{
		if (cullingGroup == null)
		{
			cullingGroup = new CullingGroup();
			cullingGroup.targetCamera = Camera.main;
			cullingGroup.SetBoundingDistances(anim.lodDistances);
			cullingGroup.SetDistanceReferencePoint(Camera.main.transform);
			cullingGroup.onStateChanged = OnLodCullingGroupOnStateChangedHandler;
		}
		cullingBounds.Add(default(BoundingSphere));
		cullingGroup.SetBoundingSpheres(cullingBounds.buffer);
		cullingGroup.SetBoundingSphereCount(players.Count);
	}

	public void RemoveCullingBounds(int index)
	{
		cullingBounds.RemoveAt(index);
		cullingGroup.SetBoundingSpheres(cullingBounds.buffer);
		cullingGroup.SetBoundingSphereCount(players.Count);
	}

	public void LODSettingChanged(GPUSkinningPlayer player)
	{
		if (player.LODEnabled)
		{
			int count = players.Count;
			for (int i = 0; i < count; i++)
			{
				if (players[i].Player == player)
				{
					int distance = cullingGroup.GetDistance(i);
					SetLODMeshByDistanceIndex(distance, players[i].Player);
					break;
				}
			}
		}
		else
		{
			player.SetLODMesh(null);
		}
	}

	private void OnLodCullingGroupOnStateChangedHandler(CullingGroupEvent evt)
	{
		GPUSkinningPlayerMono gPUSkinningPlayerMono = players[evt.index];
		if (evt.isVisible)
		{
			SetLODMeshByDistanceIndex(evt.currentDistance, gPUSkinningPlayerMono.Player);
			gPUSkinningPlayerMono.Player.Visible = true;
		}
		else
		{
			gPUSkinningPlayerMono.Player.Visible = false;
		}
	}

	private void DestroyCullingGroup()
	{
		if (cullingGroup != null)
		{
			cullingGroup.Dispose();
			cullingGroup = null;
		}
	}

	private void SetLODMeshByDistanceIndex(int index, GPUSkinningPlayer player)
	{
		Mesh mesh = null;
		if (index == 0)
		{
			mesh = this.mesh;
		}
		else
		{
			Mesh[] lodMeshes = anim.lodMeshes;
			mesh = ((lodMeshes == null || lodMeshes.Length == 0) ? this.mesh : lodMeshes[Mathf.Min(index - 1, lodMeshes.Length - 1)]);
			if (mesh == null)
			{
				mesh = this.mesh;
			}
		}
		player.SetLODMesh(mesh);
	}

	private void UpdateCullingBounds()
	{
		int count = players.Count;
		for (int i = 0; i < count; i++)
		{
			GPUSkinningPlayerMono gPUSkinningPlayerMono = players[i];
			BoundingSphere value = cullingBounds[i];
			value.position = gPUSkinningPlayerMono.Player.Position;
			value.radius = anim.sphereRadius;
			cullingBounds[i] = value;
		}
	}

	public void Update(float deltaTime, GPUSkinningMaterial mtrl)
	{
		if (executeOncePerFrame.CanBeExecute())
		{
			executeOncePerFrame.MarkAsExecuted();
			time += deltaTime;
			UpdateCullingBounds();
		}
		if (mtrl.executeOncePerFrame.CanBeExecute())
		{
			mtrl.executeOncePerFrame.MarkAsExecuted();
			mtrl.material.SetTexture(shaderPropID_GPUSkinning_TextureMatrix, texture);
			mtrl.material.SetVector(shaderPropID_GPUSkinning_TextureSize_NumPixelsPerFrame, new Vector4(anim.textureWidth, anim.textureHeight, anim.bones.Length * 3, 0f));
		}
	}

	public void UpdatePlayingData(MaterialPropertyBlock mpb, GPUSkinningClip playingClip, int frameIndex, GPUSkinningFrame frame, bool rootMotionEnabled, GPUSkinningClip lastPlayedClip, int frameIndex_crossFade, float crossFadeTime, float crossFadeProgress)
	{
		mpb.SetVector(shaderPorpID_GPUSkinning_FrameIndex_PixelSegmentation, new Vector4(frameIndex, playingClip.pixelSegmentation, 0f, 0f));
		if (rootMotionEnabled)
		{
			Matrix4x4 value = frame.RootMotionInv(anim.rootBoneIndex);
			mpb.SetMatrix(shaderPropID_GPUSkinning_RootMotion, value);
		}
		if (IsCrossFadeBlending(lastPlayedClip, crossFadeTime, crossFadeProgress))
		{
			if (lastPlayedClip.rootMotionEnabled)
			{
				mpb.SetMatrix(shaderPropID_GPUSkinning_RootMotion_CrossFade, lastPlayedClip.frames[frameIndex_crossFade].RootMotionInv(anim.rootBoneIndex));
			}
			mpb.SetVector(shaderPorpID_GPUSkinning_FrameIndex_PixelSegmentation_Blend_CrossFade, new Vector4(frameIndex_crossFade, lastPlayedClip.pixelSegmentation, CrossFadeBlendFactor(crossFadeProgress, crossFadeTime)));
		}
	}

	public float CrossFadeBlendFactor(float crossFadeProgress, float crossFadeTime)
	{
		return Mathf.Clamp01(crossFadeProgress / crossFadeTime);
	}

	public bool IsCrossFadeBlending(GPUSkinningClip lastPlayedClip, float crossFadeTime, float crossFadeProgress)
	{
		if (lastPlayedClip != null && crossFadeTime > 0f)
		{
			return crossFadeProgress <= crossFadeTime;
		}
		return false;
	}

	public GPUSkinningMaterial GetMaterial(MaterialState state)
	{
		return mtrls[(int)state];
	}

	public void InitMaterial(Material originalMaterial, HideFlags hideFlags)
	{
		if (mtrls == null)
		{
			mtrls = new GPUSkinningMaterial[6];
			for (int i = 0; i < mtrls.Length; i++)
			{
				mtrls[i] = new GPUSkinningMaterial
				{
					material = new Material(originalMaterial)
				};
				mtrls[i].material.name = keywords[i];
				mtrls[i].material.hideFlags = hideFlags;
				mtrls[i].material.enableInstancing = true;
				EnableKeywords(i, mtrls[i]);
			}
		}
	}

	private void EnableKeywords(int ki, GPUSkinningMaterial mtrl)
	{
		for (int i = 0; i < mtrls.Length; i++)
		{
			if (i == ki)
			{
				mtrl.material.EnableKeyword(keywords[i]);
			}
			else
			{
				mtrl.material.DisableKeyword(keywords[i]);
			}
		}
	}
}
