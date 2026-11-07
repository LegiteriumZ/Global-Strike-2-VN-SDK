using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Npc;
using Assets.Sources.Config;
using Assets.Sources.Constant.Career;
using Assets.Sources.Info.Career;
using Assets.Sources.Info.CareerAnim;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils.Player;
using I2.Loc;
using NetData;
using SSJJAnim.AnimState;
using SSJJAnim.Animator;
using SSJJAnim.Parser;
using SSJJAsset.Asset;
using SSJJBase.Pool;
using SSJJMath;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Npc;

public abstract class AbstractBattlePetInfo : INpcInfo
{
	private class Anim
	{
		public string name;

		public bool repeat;

		public Anim(string name, bool repeat = true)
		{
			this.name = name;
			this.repeat = repeat;
		}
	}

	public NpcEffectConfig NpcEffectConfig;

	private Anim currentAnim;

	private float animFixedTime;

	public Dictionary<string, GameObject> effectObjs;

	protected GameObject _npcName;

	protected GameObject _npcNameText;

	protected GameObject _npcWrapper;

	protected DefaultCareerAnimInfo _legsAnimInfo;

	private Dictionary<int, Anim> IdAnimMap = new Dictionary<int, Anim>
	{
		{
			1,
			new Anim("run")
		},
		{
			11,
			new Anim("head", repeat: false)
		}
	};

	public virtual void LoadEntityResource(SceneObjectEntity npcEntity)
	{
		_ = npcEntity.npc.Current.Anim;
		string career = npcEntity.npc.Current.Career;
		string bundleName = "npc/" + career;
		LoadRequests loadRequests = new LoadRequests();
		loadRequests.Add("NpcModel", new LoadRequest(new AssetInfo(bundleName, "_model.prefab")));
		loadRequests.AddAsset("LegAnim", new AssetInfo(bundleName, "leg.anm.bytes", typeof(SJAnimationAsset)));
		loadRequests.AddAsset("NpcName", new AssetInfo("effectprefab/npcname", "NpcName"));
		loadRequests.AddAsset("NpcEffectConfig", new AssetInfo(bundleName, "npceffectconfig.xml", typeof(NpcEffectConfig), optional: true));
		npcEntity.AddLoadNpcResource(loadRequests, npcEntity.npc.Current.Id);
	}

	public virtual void InitEntityResource(SceneObjectEntity npcEntity)
	{
		LoadResults loadResults = npcEntity.npcResource.LoadResults;
		_npcWrapper = loadResults["NpcModel"].GameObject;
		GameObject gameObject = _npcWrapper.transform.GetChild(0).gameObject;
		npcEntity.AddUnityObjects(loadResults, npcEntity.entityId);
		SJAnimator sJAnimator = gameObject.GetComponent<SJAnimator>();
		if (sJAnimator == null)
		{
			sJAnimator = gameObject.AddComponent<SJAnimator>();
		}
		SJAnimationAsset sJAnimationAsset = loadResults["LegAnim"].Object as SJAnimationAsset;
		sJAnimator.AddLayer(0, 1f);
		sJAnimator.AddAnimationClips(0, sJAnimationAsset.Clips);
		effectObjs = new Dictionary<string, GameObject>();
		List<GameObject> allByName = gameObject.GetAllByName("npc_particle_effect");
		foreach (GameObject item in allByName)
		{
			if (item.transform.childCount > 0)
			{
				int childCount = item.transform.childCount;
				for (int i = 0; i < childCount; i++)
				{
					Transform child = item.transform.GetChild(i);
					effectObjs.Add(child.name.Replace("(Clone)", ""), child.gameObject);
					child.gameObject.SetObjectActive(isactive: false);
				}
			}
		}
		ListPool<GameObject>.Release(allByName);
		if (loadResults.ContainsKey("NpcEffectConfig"))
		{
			NpcEffectConfig = loadResults["NpcEffectConfig"].Object as NpcEffectConfig;
		}
		currentAnim = new Anim("");
		_npcName = loadResults["NpcName"].GameObject;
		if (_npcName != null)
		{
			_npcName.transform.parent = _npcWrapper.transform;
			_npcName.transform.localScale = Vector3.one;
			_npcName.transform.localEulerAngles = Vector3.zero;
			_npcName.transform.localPosition = Vector3.zero;
			_npcName.SetObjectActive(isactive: true);
			_npcNameText = _npcName.transform.Find("Canvas/NameText").gameObject;
			PlayerEntity playerByCid = PlayerUtility.GetPlayerByCid(npcEntity.npc.Current.Cid);
			if (playerByCid != null)
			{
				_npcName.transform.Find("Canvas/NameText").GetComponent<Text>().text = string.Format(ScriptLocalization.Get("vippet"), playerByCid.basicInfo.PlayerName);
				Vector3 localPosition = new Vector3(0f, 100f);
				_npcName.transform.localPosition = localPosition;
			}
		}
		_legsAnimInfo = loadResults["CareerAnimConfig"].Object as DefaultCareerAnimInfo;
	}

	public virtual void RenderEntity(SceneObjectEntity npcEntity)
	{
		GameObject gameObject = npcEntity.unityObjects.LoadResults["NpcModel"].GameObject;
		GameObject gameObject2 = gameObject.transform.GetChild(0).gameObject;
		NpcEntityData current = npcEntity.npc.Current;
		Vector3 position = VectorCoordConverter.SsjjToUnity(npcEntity.position.Origin);
		Vector3 localEulerAngles = new Vector3(0f, 0f - npcEntity.rotation.EulerAngles.y + 90f, 0f);
		gameObject.transform.position = position;
		gameObject.transform.localEulerAngles = localEulerAngles;
		if (effectObjs.ContainsKey("alert_effect"))
		{
			effectObjs["alert_effect"].SetObjectActive(current.Anim == AnimationConstantUtil.GetAnimation("LEGS_SKILL_START") || current.Anim == AnimationConstantUtil.GetAnimation("LEGS_SKILL_LOOP") || current.Anim == AnimationConstantUtil.GetAnimation("LEGS_SKILL_END"));
		}
		else if (NpcEffectConfig != null)
		{
			foreach (KeyValuePair<string, NpcEffectItem> item in NpcEffectConfig.NpcParticleEffect)
			{
				if (effectObjs.ContainsKey(item.Key))
				{
					bool flag = (npcEntity.npc.Current.EffectLevel & (1 << item.Value.visible - 1)) != 0;
					if (flag != effectObjs[item.Key].IsActiveSelf())
					{
						effectObjs[item.Key].SetObjectActive(flag);
					}
				}
			}
		}
		SJAnimator component = gameObject2.GetComponent<SJAnimator>();
		if (!IdAnimMap.ContainsKey(current.Anim))
		{
			IdAnimMap.Add(current.Anim, new Anim(GetAnimName(component.GetAnimations(), current.Anim, 0)));
		}
		if (IdAnimMap.ContainsKey(current.Anim))
		{
			if (IdAnimMap[current.Anim].name != currentAnim.name)
			{
				currentAnim = IdAnimMap[current.Anim];
				animFixedTime = 0f;
			}
			component.PlayAtFixedTime(0, IdAnimMap[current.Anim].name, animFixedTime);
			float animDuration = component.GetAnimDuration(0, currentAnim.name);
			if (animFixedTime >= animDuration && currentAnim.repeat)
			{
				animFixedTime = 0f;
			}
			else
			{
				animFixedTime += Time.deltaTime;
			}
		}
		if (_npcName != null)
		{
			PlayerEntity playerByCid = PlayerUtility.GetPlayerByCid(npcEntity.npc.Current.Cid);
			bool flag2 = playerByCid != null && playerByCid.GetTeam() == UiIEventCondition.Get_cameraOwnerData_Team() && !PlayerCareerConstantUtility.IsDoun(playerByCid.GetCareer()) && !PlayerCareerConstantUtility.IsEmpress(playerByCid.GetCareer()) && GameSetting.Config.SuggestFlag != 2;
			if (_npcName.IsActiveSelf() != flag2)
			{
				_npcName.SetObjectActive(flag2);
			}
		}
	}

	public static string GetAnimName(ICollection<string> legAnimSet, int legsAnim, int duckState)
	{
		string result = "idle1";
		switch (legsAnim)
		{
		case 1:
			result = "run";
			break;
		case 2:
			result = ((!legAnimSet.Contains("runb")) ? "run" : "runb");
			break;
		case 4:
			result = ((!legAnimSet.Contains("walkb")) ? ((!legAnimSet.Contains("walk")) ? "run" : "walk") : "walkb");
			break;
		case 10:
			result = ((!legAnimSet.Contains("crouchrun")) ? "run" : "crouchrun");
			break;
		case 3:
			result = ((!legAnimSet.Contains("walk")) ? "run" : "walk");
			break;
		case 8:
			result = "crouch_idle";
			break;
		case 9:
			result = ((!legAnimSet.Contains("crouchrun")) ? "run" : "crouchrun");
			break;
		case 5:
			result = "jump";
			break;
		case 11:
			result = ((!legAnimSet.Contains("head")) ? "idle1" : "head");
			break;
		case 42:
			result = "headshot";
			break;
		case 43:
			result = "headshot_f";
			break;
		case 27:
			result = "skill";
			break;
		case 67:
			result = "fly";
			break;
		case 45:
			result = "legs_attack";
			break;
		case 49:
			result = "legs_attack2";
			break;
		case 50:
			result = "skill2";
			break;
		case 51:
			result = "skill_start";
			break;
		case 52:
			result = "skill_loop";
			break;
		case 53:
			result = "skill_end";
			break;
		case 54:
			result = "skill3";
			break;
		case 57:
			result = "skill4";
			break;
		case 58:
			result = "chuchang";
			break;
		case 56:
			result = "weapon_flash";
			break;
		case 59:
			result = "die_b";
			break;
		case 60:
			result = "die_f";
			break;
		case 61:
			result = "die_l";
			break;
		case 62:
			result = "die_r";
			break;
		case 68:
			result = "skill5";
			break;
		case 73:
			result = "paqiang";
			break;
		case 74:
			result = "skill_start1";
			break;
		case 82:
			result = "xp_skill_1";
			break;
		case 75:
			result = "skill_loop1";
			break;
		case 76:
			result = "skill_end1";
			break;
		case 77:
			result = "skill_start2";
			break;
		case 78:
			result = "skill_loop2";
			break;
		case 79:
			result = "skill_end2";
			break;
		case 80:
			result = "ghost_rider_skill";
			break;
		case 83:
			result = "skill_start3";
			break;
		case 84:
			result = "skill_loop3";
			break;
		case 95:
			result = "legs_yunxuan";
			break;
		case 97:
			result = "legs_skill_2";
			break;
		case 85:
			result = "skill_end3";
			break;
		case 91:
			result = "m60_attack";
			break;
		case 89:
			result = "m60_down";
			break;
		case 90:
			result = "m60_up";
			break;
		case 92:
			result = "m60_idle";
			break;
		case 138:
			result = "m60_move";
			break;
		case 156:
			result = "m60_move_back";
			break;
		case 157:
			result = "m60_move_left";
			break;
		case 158:
			result = "m60_move_right";
			break;
		case 101:
			result = "gatling_down_attack";
			break;
		case 99:
			result = "gatling_down";
			break;
		case 100:
			result = "gatling_up";
			break;
		case 102:
			result = "gatling_down_idle";
			break;
		case 98:
			result = "saber_skill";
			break;
		case 93:
			result = "hero_cold_skill";
			break;
		case 105:
			result = "legs_xp_skill_3";
			break;
		case 145:
			result = "legs_role_skill_start_1";
			break;
		case 164:
			result = "legs_role_skill_start_4";
			break;
		case 152:
			result = "legs_role_skill2";
			break;
		case 154:
			result = "legs_role_skill3";
			break;
		case 159:
			result = "legs_fukong";
			break;
		case 146:
			result = "legs_role_skill_loop_1";
			break;
		case 147:
			result = "legs_role_skill_end_1";
			break;
		case 165:
			result = "legs_role_skill_loop_4";
			break;
		case 166:
			result = "legs_role_skill_end_4";
			break;
		case 107:
			result = "legs_debug1";
			break;
		case 108:
			result = "legs_debug2";
			break;
		case 109:
			result = "legs_debug3";
			break;
		case 110:
			result = "legs_debug4";
			break;
		case 111:
			result = "legs_debug5";
			break;
		case 112:
			result = "legs_debug6";
			break;
		case 113:
			result = "legs_debug7";
			break;
		case 114:
			result = "legs_debug8";
			break;
		case 115:
			result = "legs_debug9";
			break;
		case 116:
			result = "legs_debug10";
			break;
		case 120:
			result = "dodge_left";
			break;
		case 121:
			result = "dodge_right";
			break;
		case 119:
			result = "dodge_front";
			break;
		case 118:
			result = "dodge_back";
			break;
		case 127:
			result = "hitground";
			break;
		case 128:
			result = "avatar_jump";
			break;
		case 129:
			result = "avatar_jumping";
			break;
		case 130:
			result = "avatar_fall";
			break;
		case 139:
			result = "sprint_start";
			break;
		case 140:
			result = "sprint_loop";
			break;
		case 141:
			result = "sprint_end";
			break;
		case 131:
			result = "summon";
			break;
		case 134:
			result = "shengdianqishi_idle";
			break;
		case 133:
			result = "destroyrider_idle";
			break;
		default:
			result = ((duckState != 0) ? "idle1" : "crouch_idle");
			break;
		case 6:
			break;
		}
		return result;
	}
}
