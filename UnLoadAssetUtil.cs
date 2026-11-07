using System;
using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Libs.UiEditor.RunTime;
using Assets.Libs.UiEditor.RunTime.RunTimeLogic.RunTimeNode;
using Assets.Scripts.QuickRuntimeConsole;
using Assets.Scripts.Utility;
using Assets.Scripts.Utility.Pool;
using Assets.Scripts.Utility.Sound;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework.System;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Scene;
using Assets.Sources.Info.CareerAnim;
using Assets.Sources.Info.Effect.PlayerHpBar;
using Assets.Sources.Info.Tps;
using Assets.Sources.Modules.Player.Attack;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Snapshots;
using Assets.Sources.Utils;
using Assets.Sources.Utils.AssetManager;
using Entitas;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using NotifyEvent;
using SSJJAnim.Parser;
using SSJJAnim.Player;
using SSJJAsset.Asset;
using SSJJAsset.AssetBundle;
using SSJJAsset.AssetLoader.Sound;
using SSJJBase.Manager;
using SSJJBase.Pool;
using SSJJBase.Singleton;
using UnityEngine;

public class UnLoadAssetUtil : MonoBehaviour
{
	public static bool isUnload;

	public static void UnLoadAsset()
	{
		ForceUnloadResUtility.UnloadRes();
		SingletonInstance<AssetPool>.Instance.GetFailedTasks().Clear();
		foreach (KeyValuePair<AssetInfo, object> poolObj in SingletonInstance<AssetPool>.Instance.GetPoolObjs())
		{
			object value = poolObj.Value;
			if (value == null)
			{
				continue;
			}
			if (value is SJAnimationAsset)
			{
				for (int i = 0; i < ((SJAnimationAsset)value).Clips.Count; i++)
				{
					foreach (SJAnimationCurve value2 in ((SJAnimationClip)((SJAnimationAsset)value).Clips[i]).Curves.Values)
					{
						value2.Clear();
					}
					((SJAnimationClip)((SJAnimationAsset)value).Clips[i]).Curves.Clear();
				}
				((SJAnimationAsset)value).Clips.Clear();
			}
			if (value is GameObject)
			{
				UnityEngine.Object.DestroyImmediate((GameObject)value, allowDestroyingAssets: true);
			}
			if (value is Texture)
			{
				UnityEngine.Object.DestroyImmediate((Texture)value, allowDestroyingAssets: true);
			}
			if (value is Sprite)
			{
				UnityEngine.Object.DestroyImmediate((Sprite)value, allowDestroyingAssets: true);
			}
		}
		SingletonInstance<AssetPool>.Instance.GetPoolObjs().Clear();
		SingletonInstance<AssetPool>.Instance.GetPendingTasks().Clear();
		AutoClientValue.roomInfo.Clear();
		CommandFactory.Clear();
		SimpleNotify.Clear();
		NotifyManager.Clear();
		CareerData.Clear();
		SoundAssetCache.Clear();
		NotifyGroup.Clear();
		MonoBehaviourSingleton<ScreenShotManager>.Instance.GetCaptureSnapshot().DestoryThread();
		UiMessageTipManager.Instance = null;
		if (UiModeDelegate.Instance != null)
		{
			UiModeDelegate.Instance.Clear();
		}
		if (GameModuleFeature.Instance != null)
		{
			GameModuleFeature.Instance.Clear();
		}
		PlayerHpBarEffectInfo.Instance.Clear();
		MonoBehaviourSingleton<TpsIkInfoLoader>.Instance.TpsIkInfos.Clear();
		foreach (LoadedAssetBundle value3 in AssetBundleManager.m_LoadedAssetBundles.Values)
		{
			value3.m_AssetBundle.Unload(unloadAllLoadedObjects: true);
		}
		AssetBundleManager.m_LoadedAssetBundles.Clear();
		AssetBundleManager.AssetBundleManifest = null;
		foreach (StackObjectPool<GameObject> value4 in MonoBehaviourSingleton<UnityGameObjectPool>.Instance.Poos.Values)
		{
			value4.Clear();
		}
		PredicationErrorCollector.Instance.Clear();
		MonoBehaviourSingleton<UnityGameObjectPool>.Instance.Poos.Clear();
		AccessoryConfigLoader.Instance.Clear();
		MonoBehaviourSingleton<BgmSoundManager>.Instance.Clear();
		BattleSingletonInstance<DataProviderManager>.Instance.Methods.Clear();
		BattleSingletonInstance<DataProviderManager>.Instance.ModeProviders.Clear();
		BattleSingletonInstance<DataProviderManager>.Instance.WeaponExtraDefineProviders.Clear();
		RunTimeBindingManager.Instance.Clear();
		new BindingServiceBundle(Context.GetApplicationContext().GetContainer()).Stop();
		UiIEventCondition.Clear();
		SnapshotFactory.Instance.Clear();
		MonoBehaviourSingleton<TpsIkInfoLoader>.Instance.TpsIkInfos.Clear();
		PlayerWeaponRaisePredicationSystem.SubSystems.Clear();
		MonoBehaviourSingleton<FogManager>.Instance.Clear();
		UnityEngine.Object.DestroyImmediate(MonoBehaviourSingleton<FogManager>.Instance, allowDestroyingAssets: true);
		GameController.Instance._systems.Clear();
		GameController.Instance = null;
		IContext[] allContexts = Contexts.sharedInstance.allContexts;
		for (int j = 0; j < allContexts.Length; j++)
		{
			allContexts[j].DestroyAllEntities();
			allContexts[j].ClearComponentPools();
			allContexts[j] = null;
		}
		Contexts.sharedInstance = null;
		UnityEngine.Object.Destroy(GameObject.Find("GameController"));
		UnityEngine.Object.Destroy(GameObject.Find("MyPlayer(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("AssetBundleManager"));
		UnityEngine.Object.Destroy(GameObject.Find("UiEditorParentManager"));
		UnityEngine.Object.Destroy(GameObject.Find("EventSystem"));
		UnityEngine.Object.Destroy(GameObject.Find("FogManager"));
		Resources.UnloadUnusedAssets();
		GC.Collect();
		isUnload = true;
	}
}
