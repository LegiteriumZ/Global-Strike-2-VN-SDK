using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Time;
using SSJJAnim.Animator;
using SSJJAnim.Parser;
using SSJJAnim.Player;
using UnityEngine;

namespace Tests.AccessoryViewer;

public class AccessoryViewController : MonoBehaviour
{
	[SerializeField]
	public GameObject playerPrefab;

	public GameObject accessoryPrefab;

	public TextAsset animSource;

	public AccessoryGender accessoryGender;

	public AccessoryType accessoryType;

	private GameObject playerObj;

	private GameObject accessoryObj;

	private AccessoryParticleInstance instance;

	private TimeComponent _timeComponent;

	private List<string> stateName;

	private SJAnimationAsset asset;

	private SJAnimator animator;

	private void Awake()
	{
		TimeEntity timeEntity = Contexts.sharedInstance.time.CreateEntity();
		timeEntity.AddComponent(1, new TimeComponent());
		_timeComponent = timeEntity.time;
		if (playerPrefab != null)
		{
			playerObj = Object.Instantiate(playerPrefab);
		}
		if (accessoryPrefab != null)
		{
			accessoryObj = Object.Instantiate(accessoryPrefab);
			instance = accessoryObj.GetComponent<AccessoryParticleInstance>();
			AccessoryParticleInstance.MatrixData matrixData = instance.DataList[(int)accessoryGender];
			accessoryObj.transform.parent = GetBone(playerObj.transform, matrixData.JointName);
			if (accessoryType == AccessoryType.regular)
			{
				accessoryObj.transform.localPosition = matrixData.ConfigPosition;
				accessoryObj.transform.localRotation = matrixData.ConfigRotation;
				accessoryObj.transform.localScale = matrixData.ConfigScale;
			}
			else
			{
				accessoryObj.transform.localPosition = Vector3.zero;
				accessoryObj.transform.localRotation = Quaternion.identity;
				accessoryObj.transform.localScale = Vector3.one;
			}
		}
	}

	private void Start()
	{
		if (animSource != null)
		{
			stateName = new List<string>();
			asset = new SJAnimationAsset();
			asset.Clips = SJAnimationPaser.GenerateAnimations(animSource.bytes);
			for (int i = 0; i < asset.Clips.Count; i++)
			{
				stateName.Add((asset.Clips[i] as SJAnimationClip).StateName);
			}
			if (accessoryObj.GetComponent<SJAnimator>() == null)
			{
				accessoryObj.AddComponent<SJAnimator>();
			}
			animator = accessoryObj.GetComponent<SJAnimator>();
			if (asset != null)
			{
				animator.AddLayer(0, 1f);
				animator.AddAnimationClips(0, asset.Clips);
			}
		}
	}

	private void Update()
	{
		if (animSource != null)
		{
			int num = (int)(Time.deltaTime * 1000f);
			_timeComponent.RenderTime += num;
			animator.PlayAtFixedTime(0, stateName[0], (float)_timeComponent.RenderTime / 1000f, 1f, isLoop: true);
		}
	}

	private Transform GetBone(Transform tf, string name)
	{
		if (tf.name == name)
		{
			return tf;
		}
		if (tf.childCount == 0)
		{
			return null;
		}
		for (int i = 0; i < tf.childCount; i++)
		{
			Transform bone = GetBone(tf.GetChild(i), name);
			if (bone != null)
			{
				return bone;
			}
		}
		return null;
	}
}
