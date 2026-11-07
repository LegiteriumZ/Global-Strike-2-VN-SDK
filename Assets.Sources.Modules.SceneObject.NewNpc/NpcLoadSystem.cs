using System.Collections.Generic;
using Assets.Scripts.Asset;
using Assets.Scripts.Effect.Level;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Config;
using Assets.Sources.Framework;
using Assets.Sources.Info.Career;
using Assets.Sources.Info.Npc;
using Assets.Sources.Particle;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Player;
using Entitas;
using I2.Loc;
using SSJJAnim.Parser;
using SSJJAsset.Asset;
using SSJJParticle;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Modules.SceneObject.NewNpc;

public class NpcLoadSystem : LoadAndInitResourceSystem<SceneObjectEntity>
{
	private IGroup<SceneObjectEntity> _loadGroup;

	private IGroup<SceneObjectEntity> _initGroup;

	private Transform _npcResources;

	public NpcLoadSystem(Contexts contexts)
	{
		_loadGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo).NoneOf(SceneObjectMatcher.LoadUnityObjects, SceneObjectMatcher.NpcUnityObjects, SceneObjectMatcher.Destroy));
		_initGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo, SceneObjectMatcher.UnityObjects).NoneOf(SceneObjectMatcher.NpcUnityObjects));
		_npcResources = new GameObject("npcResources").transform;
	}

	protected override IGroup<SceneObjectEntity> GetLoadGroup()
	{
		return _loadGroup;
	}

	protected override IGroup<SceneObjectEntity> GetInitGroup()
	{
		return _initGroup;
	}

	protected override void OnLoadEntityResource(SceneObjectEntity entity)
	{
		if (GameSetting.Config.ShowThirdWeapon != 0 || entity.npcBasicInfo.Current.Species != 0)
		{
			string career = entity.npcBasicInfo.Current.Career;
			bool showHpBar = entity.npcBasicInfo.Current.ShowHpBar;
			string bundleName = "npc/" + career;
			string text = "Assets/Res/Assets/npc/" + career + "/";
			LoadRequests loadRequests = new LoadRequests();
			loadRequests.Add("Model", new LoadRequest(new AssetInfo(bundleName, text + "model.prefab"), typeof(NpcCareerGameObject)));
			loadRequests.AddAsset("LegAnim", new AssetInfo(bundleName, "leg.anm.bytes", typeof(SJAnimationAsset)));
			loadRequests.AddAsset("NameLabel", new AssetInfo("effectprefab/npcname", "NpcName"));
			loadRequests.AddAsset("EffectConfig", new AssetInfo(bundleName, "npceffectconfig.xml", typeof(NpcEffectConfig), optional: true));
			if (showHpBar)
			{
				loadRequests.Add("NpcHp", new LoadRequest(new AssetInfo("effectprefab/npcHp", "npcHp", typeof(GameObject))));
			}
			switch (career)
			{
			case "turkey":
			case "weapon_chicken":
			case "weapon_pig":
			case "weapon_cat":
				loadRequests.Add("WeirdTransformPistol", new LoadRequest(new AssetInfo("playereffectprefab/weirdtransformpistol", "WeirdTransformPistol", typeof(GameObject)), typeof(ChickenReliveUI)));
				break;
			}
			ParticleManager.InitNpcParticleXmlLoadRequests(loadRequests, career);
			entity.AddLoadUnityObjects(loadRequests, entity.npcBasicInfo.Current.Id);
		}
	}

	protected override bool IsResourceMatch(SceneObjectEntity entity)
	{
		return true;
	}

	protected override void CleanResouceComponent(SceneObjectEntity entity)
	{
		entity.RemoveUnityObjects();
	}

	protected override void OnInitEntityResource(SceneObjectEntity entity)
	{
		string career = entity.npcBasicInfo.Current.Career;
		LoadResults loadResults = entity.unityObjects.LoadResults;
		GameObject gameObject = new GameObject(entity.npcBasicInfo.Current.Career);
		gameObject.transform.SetParent(_npcResources, worldPositionStays: false);
		GameObject gameObject2 = loadResults["Model"].GameObject;
		gameObject2.transform.SetParent(gameObject.transform);
		gameObject2.transform.localPosition = Vector3.zero;
		gameObject2.transform.localScale = Vector3.one;
		gameObject2.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
		SkinnedMeshRenderer[] componentsInChildren = gameObject2.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		SkinnedMeshRenderer newPrototype = null;
		SkinnedMeshRenderer[] array = componentsInChildren;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
		{
			if (skinnedMeshRenderer.enabled)
			{
				newPrototype = skinnedMeshRenderer;
				break;
			}
		}
		NpcCareerGameObject component = gameObject2.GetComponent<NpcCareerGameObject>();
		ISjAnimatior animator = component.Animator;
		SJAnimationAsset sJAnimationAsset = loadResults["LegAnim"].Object as SJAnimationAsset;
		animator.AddAnimationClips(0, sJAnimationAsset.Clips);
		GameObject gameObject3 = loadResults["NameLabel"].GameObject;
		gameObject3.transform.parent = gameObject.transform;
		gameObject3.transform.localPosition = new Vector3(0f, NpcCareerConstant.GetNpcNameHeight(entity.npcBasicInfo.Current.Career), 0f);
		gameObject3.transform.localScale = Vector3.one;
		PlayerEntity playerByCid = PlayerUtility.GetPlayerByCid(entity.npcBasicInfo.Current.Cid);
		Text component2 = gameObject3.transform.Find("Canvas/NameText").GetComponent<Text>();
		Text component3 = gameObject3.transform.Find("Canvas/DistanceText").GetComponent<Text>();
		bool newIsFriendly = false;
		bool newIsMyTeam = false;
		if (playerByCid != null)
		{
			component2.text = string.Format(ScriptLocalization.Get("vippet"), playerByCid.basicInfo.PlayerName);
			newIsFriendly = playerByCid.isFriendly;
			int teamId = Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Current.TeamId;
			newIsMyTeam = playerByCid.basicInfo.Current.TeamId == teamId && teamId != 0;
		}
		if (loadResults.ContainsKey("WeirdTransformPistol"))
		{
			GameObject gameObject4 = loadResults["WeirdTransformPistol"].GameObject;
			Transform transform = gameObject4.transform;
			ChickenReliveUI component4 = gameObject4.GetComponent<ChickenReliveUI>();
			transform.parent = gameObject.transform;
			transform.localScale = Vector3.one;
			transform.localPosition = new Vector3(0f, 100f, 0f);
			entity.AddChickenUnityObjects(component4.GetGameObject(), component4.ProgressImage, component4.TimeText);
		}
		if (loadResults.ContainsKey("NpcHp"))
		{
			GameObject gameObject5 = loadResults["NpcHp"].GameObject;
			Image component5 = gameObject5.transform.Find("WorldSpace/HpBack/HpProgress").GetComponent<Image>();
			entity.AddNpcHp(gameObject5, component5);
		}
		if (loadResults.ContainsKey("EffectConfig") && loadResults["EffectConfig"].Object is NpcEffectConfig npcEffectConfig)
		{
			foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> effectsGameObject in component.EffectsGameObjects)
			{
				if (!(effectsGameObject.Value.getInstance() != null))
				{
					continue;
				}
				SSJJParticleSystem component6 = effectsGameObject.Value.GetIns().GetComponent<SSJJParticleSystem>();
				if (component6 != null)
				{
					string key = effectsGameObject.Value.GetIns().name.Replace("(Clone)", "");
					if (npcEffectConfig.NpcParticleEffect.ContainsKey(key))
					{
						component6.autoPlay = npcEffectConfig.NpcParticleEffect[key].resetEffect;
					}
				}
			}
		}
		ParticleManager.InitNpcParticleXmlLoadResults(loadResults, career);
		entity.AddNpcUnityObjects(gameObject, newPrototype, new Color(0f, 0f, 0f, 0f), animator, component.EffectsGameObjects, component2, component3, 0, newIsFriendly, newIsMyTeam);
		SetNpcLod(gameObject2, entity, component.EffectsGameObjects);
		ParticleEffectUtility.InitNpcParticle(gameObject2, career);
	}

	private void SetNpcLod(GameObject model, SceneObjectEntity entity, Dictionary<IParticleKey, IPaticlePrefabInstancecs> particles)
	{
		LodUtility.AddMeshLod(entity, model);
		LodUtility.AddParticleLod(particles);
	}
}
