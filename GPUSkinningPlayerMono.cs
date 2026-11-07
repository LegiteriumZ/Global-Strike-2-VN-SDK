using Assets.Sources.Components.Interface;
using UnityEngine;

[ExecuteInEditMode]
public class GPUSkinningPlayerMono : MonoBehaviour, IGPUSkinningPlayerMono
{
	[HideInInspector]
	[SerializeField]
	public GPUSkinningAnimation anim;

	[HideInInspector]
	[SerializeField]
	public Mesh mesh;

	[HideInInspector]
	[SerializeField]
	public Material mtrl;

	[HideInInspector]
	[SerializeField]
	public TextAsset textureRawData;

	[HideInInspector]
	[SerializeField]
	private int defaultPlayingClipIndex;

	[HideInInspector]
	[SerializeField]
	private bool rootMotionEnabled;

	[HideInInspector]
	[SerializeField]
	private bool lodEnabled;

	[HideInInspector]
	[SerializeField]
	private GPUSKinningCullingMode cullingMode;

	private static GPUSkinningPlayerMonoManager playerManager = new GPUSkinningPlayerMonoManager();

	private GPUSkinningPlayer player;

	public float deltaTime = 0.02f;

	public GPUSkinningPlayer Player => player;

	public void PlayerAnim(string animName, bool isloop)
	{
		if (player != null)
		{
			player.Play(animName, isloop);
		}
	}

	public void Init(GPUSkinningAnimation anim, Mesh mesh, Material mtrl, TextAsset textureRawData)
	{
		if (player == null)
		{
			this.anim = anim;
			this.mesh = mesh;
			this.mtrl = mtrl;
			this.textureRawData = textureRawData;
			Init();
		}
	}

	public void Init()
	{
		if (player == null && anim != null && mesh != null && mtrl != null && textureRawData != null)
		{
			GPUSkinningPlayerResources resources = null;
			if (Application.isPlaying)
			{
				playerManager.Register(anim, mesh, mtrl, textureRawData, this, out resources);
			}
			else
			{
				resources = new GPUSkinningPlayerResources();
				resources.anim = anim;
				resources.mesh = mesh;
				resources.InitMaterial(mtrl, HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild);
				resources.texture = GPUSkinningUtil.CreateTexture2D(textureRawData, anim);
				resources.texture.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
			}
			player = new GPUSkinningPlayer(base.gameObject, resources);
			player.RootMotionEnabled = Application.isPlaying && rootMotionEnabled;
			player.LODEnabled = Application.isPlaying && lodEnabled;
			player.CullingMode = cullingMode;
			if (anim != null && anim.clips != null && anim.clips.Length != 0)
			{
				player.Play(anim.clips[Mathf.Clamp(defaultPlayingClipIndex, 0, anim.clips.Length)].name, isloop: false);
			}
		}
	}

	public void DeletePlayer()
	{
		player = null;
	}

	public void Update_Editor(float deltaTime)
	{
		if (player != null && !Application.isPlaying)
		{
			player.Update_Editor(this.deltaTime);
		}
	}

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			Init();
			Update_Editor(0f);
		}
	}

	private void Start()
	{
		Init();
	}

	private void Update()
	{
		if (player != null)
		{
			player.Update(Time.deltaTime);
		}
	}

	private void OnDestroy()
	{
		player = null;
		anim = null;
		mesh = null;
		mtrl = null;
		textureRawData = null;
		if (Application.isPlaying)
		{
			playerManager.Unregister(this);
		}
	}

	public bool HasAnimName(string name)
	{
		for (int i = 0; i < anim.clips.Length; i++)
		{
			if (anim.clips[i].name == name)
			{
				return true;
			}
		}
		return false;
	}

	private void OnDrawGizmos()
	{
	}
}
