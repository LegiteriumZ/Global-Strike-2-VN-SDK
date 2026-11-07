using System.Collections.Generic;
using Assets.Sources.Components.SceneObject.Npc;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Player;
using Entitas;
using NetData;
using SSJJBase.Pool;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.SceneObject.NewNpc;

public class NpcDrawColorSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	private PlayerContext _playerContext;

	private GameRuleContext _gameRuleContext;

	private List<Material> _effectMaterials;

	private StackObjectPool<MaterialPropertyBlock> _blockcache;

	private static readonly Color DefaultColor = new Color(1f, 1f, 1f, 1f);

	public NpcDrawColorSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo, SceneObjectMatcher.NpcUnityObjects));
		_playerContext = contexts.player;
		_gameRuleContext = contexts.gameRule;
		_effectMaterials = new List<Material>();
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			Color defaultColor = DefaultColor;
			NpcEntityData current2 = item.npcBasicInfo.Current;
			NpcUnityObjects npcUnityObjects = item.npcUnityObjects;
			PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
			PlayerEntity playerByCid = PlayerUtility.GetPlayerByCid(item.npcBasicInfo.Current.Cid);
			int num = current2.Alpha;
			if (playerByCid != null && playerByCid.HasStatus(PlayerInfoStatusConstant.THUNDER_LEGEND_SHADOW.ID))
			{
				num = ((!_gameRuleContext.currentRule.Rule.IsBio() && !_gameRuleContext.currentRule.Rule.IsBio2() && !_gameRuleContext.currentRule.Rule.IsBio3() && !_gameRuleContext.currentRule.Rule.IsBioEvolution() && !_gameRuleContext.currentRule.Rule.IsBioEvolutionChallengeMode()) ? 40 : ((cameraOwnerEntity.basicInfo.Current.Team != playerByCid.basicInfo.Current.Team) ? 1 : 40));
			}
			else if (playerByCid != null && playerByCid.HasStatus(PlayerInfoStatusConstant.PLAYER_STEALTH4_FLAG.ID))
			{
				num = ((cameraOwnerEntity.basicInfo.Current.Team != playerByCid.basicInfo.Current.Team) ? 1 : 40);
			}
			if (!npcUnityObjects.RenderColor.CompareAlpha((float)num / 100f))
			{
				npcUnityObjects.RenderColor.SetColorAlpha(ref npcUnityObjects.RenderColor, (float)num / 100f);
				defaultColor.a = (float)num / 100f;
				SetColor(defaultColor, npcUnityObjects.Prototype);
			}
		}
	}

	private void SetColor(Color color, Renderer smr)
	{
		if (smr == null)
		{
			return;
		}
		if (_blockcache == null)
		{
			_blockcache = new StackObjectPool<MaterialPropertyBlock>();
		}
		MaterialPropertyBlock materialPropertyBlock = _blockcache.GetOrNull();
		if (materialPropertyBlock == null)
		{
			materialPropertyBlock = new MaterialPropertyBlock();
		}
		smr.GetPropertyBlock(materialPropertyBlock);
		materialPropertyBlock.SetColor("_Color", color);
		if (smr.gameObject.GetComponent<MaterialCache>() == null)
		{
			smr.gameObject.AddComponent<MaterialCache>().GetCache();
		}
		if (color.a < 1f)
		{
			for (int i = 0; i < smr.sharedMaterials.Length; i++)
			{
				Material material = smr.sharedMaterials[i];
				if (material == null)
				{
					break;
				}
				if (material.renderQueue < 3000 && !_effectMaterials.Contains(material))
				{
					material.renderQueue += 1200;
					_effectMaterials.Add(material);
				}
				material.SetInt("_ZWrite", (color.a != 0f) ? 1 : 0);
			}
		}
		else
		{
			for (int j = 0; j < smr.sharedMaterials.Length; j++)
			{
				Material material2 = smr.sharedMaterials[j];
				if (material2 == null)
				{
					break;
				}
				if (material2.renderQueue > 3000 && _effectMaterials.Contains(material2))
				{
					_effectMaterials.Remove(material2);
					material2.renderQueue -= 1200;
				}
			}
		}
		smr.SetPropertyBlock(materialPropertyBlock);
		_blockcache.Add(materialPropertyBlock);
	}
}
