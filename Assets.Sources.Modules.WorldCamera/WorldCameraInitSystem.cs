using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Assets.Sources.Utils.ComponentInit;
using SSJJBase.Singleton;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Assets.Sources.Modules.WorldCamera;

public class WorldCameraInitSystem : IModuleInitSystem
{
	private readonly WorldCameraContext _context;

	private int _raceType;

	public WorldCameraInitSystem(Contexts contexts)
	{
		_context = contexts.worldCamera;
		_raceType = contexts.battleRoom.roomData.Data.RaceType;
	}

	public void OnInitModule()
	{
		WorldCameraEntityUtility.InitCameraLogic(_context);
		WorldCameraEntityUtility.InitCameraTransform(_context);
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("MyPlayer"));
		Object.DontDestroyOnLoad(gameObject);
		GameObject gameObject2 = gameObject.transform.Find("Body").gameObject.transform.Find("Eye").gameObject;
		if (MonoBehaviourSingleton<ScreenShotManager>.Instance.IsExclusiveWindowMode)
		{
			gameObject2.AddComponent<SceneImmdatelyDraw>();
		}
		Camera component = gameObject2.GetComponent<Camera>();
		GameObject gameObject3 = GameObject.Find("UnitySceneRoot/SceneCamera");
		if (gameObject3 != null)
		{
			PostProcessLayer postProcessLayer = gameObject2.AddComponent<PostProcessLayer>();
			PostProcessLayer component2 = gameObject3.GetComponent<PostProcessLayer>();
			LayerMask volumeLayer = component2.volumeLayer;
			PostProcessLayer.Antialiasing antialiasingMode = component2.antialiasingMode;
			FastApproximateAntialiasing fastApproximateAntialiasing = component2.fastApproximateAntialiasing;
			Camera component3 = gameObject3.GetComponent<Camera>();
			bool useOcclusionCulling = component3.useOcclusionCulling;
			bool allowHDR = component3.allowHDR;
			CameraClearFlags clearFlags = component3.clearFlags;
			Object.Destroy(gameObject3);
			if ((bool)postProcessLayer)
			{
				postProcessLayer.antialiasingMode = antialiasingMode;
				postProcessLayer.fastApproximateAntialiasing = fastApproximateAntialiasing;
				postProcessLayer.volumeLayer = volumeLayer;
				postProcessLayer.volumeTrigger = postProcessLayer.transform;
			}
			component.allowHDR = allowHDR;
			component.useOcclusionCulling = useOcclusionCulling;
			component.clearFlags = clearFlags;
		}
		gameObject2.tag = "MainCamera";
		_context.SetUnityObjects(gameObject2, component);
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (RuleUtilty.IsUltimateChallenge())
		{
			component.nearClipPlane = 30f;
		}
		else if (RuleUtilty.IsTpsMode())
		{
			component.nearClipPlane = 8f;
		}
		else if (RuleUtilty.IsPve(raceType))
		{
			component.nearClipPlane = 3.5f;
		}
		else
		{
			component.nearClipPlane = 1.2f;
		}
	}
}
