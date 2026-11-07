using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Components.SceneObject.Npc;
using Assets.Sources.Config;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils.Player;
using Entitas;
using NetData;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Modules.SceneObject.NewNpc;

public class NpcNameAndEffectDisplaySystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	private PlayerContext _playerContext;

	private IGameRule GameRule;

	private readonly HashSet<string> _dragoonSet = new HashSet<string>
	{
		"dragoon01", "dragoon01_a1", "dragoon02", "dragoon02_a1", "dragoon02_a2", "dragoon03_a", "dragoon03_b", "dragoon03_c", "jiguan_bird01", "jiguan_bird02",
		"jiguan_bird03", "jiguan_deer01", "jiguan_deer02", "jiguan_deer03", "jiguan_long01", "jiguan_long02", "jiguan_long03"
	};

	private Dictionary<long, PlayerEntity> _npcPlayerDic = new Dictionary<long, PlayerEntity>();

	public NpcNameAndEffectDisplaySystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo, SceneObjectMatcher.NpcUnityObjects));
		_playerContext = contexts.player;
		GameRule = contexts.gameRule.currentRule.Rule;
	}

	private int GetDistance(Vector3 position)
	{
		return (int)(Vector3.Distance(UiIEventCondition.Get_cameraOwnerData_Position(), position) * 0.01f);
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			NpcEntityData current2 = item.npcBasicInfo.Current;
			NpcUnityObjects npcUnityObjects = item.npcUnityObjects;
			PlayerEntity value = null;
			if (item.npcBasicInfo.Current.Cid != 0L)
			{
				if (!_npcPlayerDic.TryGetValue(item.npcBasicInfo.Current.Cid, out value))
				{
					value = PlayerUtility.GetPlayerByCid(item.npcBasicInfo.Current.Cid);
					_npcPlayerDic[item.npcBasicInfo.Current.Cid] = value;
				}
				else if (value == null)
				{
					value = PlayerUtility.GetPlayerByCid(item.npcBasicInfo.Current.Cid);
					_npcPlayerDic[item.npcBasicInfo.Current.Cid] = value;
				}
			}
			bool flag = value != null && _playerContext.cameraOwnerEntity != null && value.GetTeam() == _playerContext.cameraOwnerEntity.GetTeam() && !PlayerCareerConstantUtility.IsDoun(value.GetCareer()) && !PlayerCareerConstantUtility.IsEmpress(value.GetCareer()) && GameSetting.Config.SuggestFlag != 2;
			if (flag && GameRule.IsBioEvolution() && GetDistance(item.position.Origin) > 30)
			{
				flag = false;
			}
			if (npcUnityObjects.NameText.gameObject.IsActiveSelf() != flag)
			{
				npcUnityObjects.NameText.gameObject.SetObjectActive(flag);
			}
			if (flag)
			{
				if (value.basicInfo.IsDead)
				{
					if (npcUnityObjects.NameColor != 1)
					{
						npcUnityObjects.NameColor = 1;
						npcUnityObjects.NameText.color = new Color(0.816f, 0.816f, 0.816f);
						npcUnityObjects.NameText.GetComponent<Outline>().effectColor = new Color(0.278f, 0.278f, 0.278f, 0.745f);
					}
				}
				else if (npcUnityObjects.IsMyTeam)
				{
					if (npcUnityObjects.NameColor != 2)
					{
						npcUnityObjects.NameColor = 2;
						npcUnityObjects.NameText.color = new Color(0f, 0.398f, 1f);
						npcUnityObjects.NameText.GetComponent<Outline>().effectColor = new Color(0.278f, 0.278f, 0.278f, 0.745f);
					}
				}
				else if (npcUnityObjects.IsFriendly)
				{
					if (npcUnityObjects.NameColor != 3)
					{
						npcUnityObjects.NameColor = 3;
						npcUnityObjects.NameText.color = new Color(0f, 0.797f, 1f);
						npcUnityObjects.NameText.GetComponent<Outline>().effectColor = new Color(0.278f, 0.278f, 0.278f, 0.745f);
					}
				}
				else if (npcUnityObjects.NameColor != 4)
				{
					npcUnityObjects.NameColor = 4;
					npcUnityObjects.NameText.color = Color.green;
					npcUnityObjects.NameText.GetComponent<Outline>().effectColor = new Color(3f / 85f, 0.4862745f, 0f, 38f / 51f);
				}
			}
			bool flag2 = flag && GameSetting.Config.SuggestFlag == 1;
			if (npcUnityObjects.DistanceText.gameObject.IsActiveSelf() != flag2)
			{
				npcUnityObjects.DistanceText.gameObject.SetObjectActive(flag2);
			}
			if (flag2)
			{
				npcUnityObjects.DistanceText.text = StringCache.IntToString(GetDistance(item.position.Origin));
			}
			foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> effectGameObject in npcUnityObjects.EffectGameObjects)
			{
				if (effectGameObject.Key.PatricleName.Equals("alert_effect"))
				{
					int anim = current2.Anim;
					bool flag3 = anim == 51 || anim == 52 || anim == 53;
					effectGameObject.Value.SetInsActive(flag3);
					continue;
				}
				IPaticlePrefabInstancecs value2 = effectGameObject.Value;
				bool flag4 = true;
				int anim2 = item.npcBasicInfo.Current.Anim;
				if (!value2.getAnimationEffectConfig().IsRangeNpc(anim2, 0))
				{
					flag4 = false;
				}
				if (value2.getVisibleState() == 0)
				{
					value2.SetInsActive(flag4);
					continue;
				}
				value2.InitVisibleState();
				bool flag5 = false;
				for (int i = 0; i < value2.getVisibleStateList().Count; i++)
				{
					uint num = value2.getVisibleStateList()[i];
					if ((current2.EffectLevel & (1 << (int)(num - 1))) > 0 || (current2.EffectLevel == 0 && num == 0))
					{
						flag5 = true;
						break;
					}
				}
				value2.SetInsActive(flag5 && flag4);
			}
			if (_dragoonSet.Contains(current2.Career))
			{
				bool flag6 = (current2.EffectLevel & 1) > 0;
				if (npcUnityObjects.Prototype.gameObject.IsActiveSelf() != !flag6)
				{
					npcUnityObjects.Prototype.gameObject.SetObjectActive(!flag6);
				}
			}
		}
	}
}
