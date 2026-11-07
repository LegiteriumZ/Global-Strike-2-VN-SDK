using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Weapon;
using Entitas;
using NetData;
using SSJJBase.Pool;
using SSJJBase.String;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerDrawVertexColorSystem : IRenderSystem
{
	private IGroup<PlayerEntity> _group;

	private TimeContext _timeContext;

	private StackObjectPool<MaterialPropertyBlock> _blockcache;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	private List<Material> _effectMaterials;

	private static readonly Color DefaultColor = new Color(1f, 1f, 1f, 1f);

	public PlayerDrawVertexColorSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
		_timeContext = contexts.time;
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_effectMaterials = new List<Material>();
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _group)
		{
			if (item.hasVisiable && !item.visiable.IsVisiable && !item.visiable.IsNear)
			{
				continue;
			}
			Color color = DefaultColor;
			float stealthAlpha = item.skill.getStealthAlpha();
			float stealthSelfAlpha = item.skill.getStealthSelfAlpha();
			if (item.HasStatus(PlayerInfoStatusConstant.ONLY_SEEN_BY_TEAMMATE.ID))
			{
				if (item.GetTeam() != _playerContext.cameraOwnerEntity.GetTeam())
				{
					item.thirdPersonUnityObjects.ThirdTran.RootContainer.SetActive(value: false);
				}
			}
			else if (item.HasStatus(PlayerInfoStatusConstant.HideBody.ID))
			{
				if (item.GetCurrentWeaponName() == "spirits_sword2")
				{
					item.thirdPersonUnityObjects.ThirdTran.RootContainer.SetActive(value: false);
				}
			}
			else if (InvincibleState(item))
			{
				float t = (float)(_timeContext.time.ClientRealTime % 500) / 500f;
				color = Color.Lerp(new Color(1f, 0f, 0f, 1f), new Color(1f, 1f, 1f, 1f), t);
			}
			else if (item.state.GetPlayerStateType(4))
			{
				float t2 = Mathf.PingPong((float)_timeContext.time.ClientRealTime / 2000f, 1f);
				color = Color.Lerp(new Color(0f, 1f, 0f, 1f), new Color(1f, 1f, 1f, 1f), t2);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.ACG_HIT_EFFECT.ID))
			{
				float t3 = (float)(_timeContext.time.ClientRealTime % 500) / 500f;
				color = Color.Lerp(new Color(0.95f, 0.5f, 0.5f, 1f), new Color(1f, 1f, 1f, 1f), t3);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.ACG_SERIOUS_INJURY_FLAG.ID))
			{
				if (stealthAlpha == 0.01f)
				{
					color = new Color(0f, 0f, 0f, 0f);
				}
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_BOSS23_FANSHANG.ID))
			{
				color = new Color(1f, 0.2f, 0.2f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.SHOTGUN_LASER_BEATTACK.ID))
			{
				color = new Color(1f, 0.157f, 0f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.SHIYANTI_X_KUANGBAO.ID))
			{
				color = new Color(1f, 0f, 0f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_PURIFY.ID))
			{
				color = new Color(1f, 0.725f, 0.5333f);
			}
			else if (item.GetPlayerInfo().Icebound)
			{
				color = new Color(0.5f, 0.75f, 1f);
			}
			else if (item.HasStatus(PlayerInfoStatusConstant.ELECTRIC_INTERACTION.ID))
			{
				color = new Color(0.8f, 0.4f, 0.2f, 1f);
			}
			else if (item.HasStatus(PlayerInfoStatusConstant.TRANS_MACHINEGUN_FAKER_FLASH.ID))
			{
				float t4 = (float)(_timeContext.time.ClientRealTime % 500) / 500f;
				color = Color.Lerp(new Color(44f / 51f, 4f / 51f, 0.23529412f, 1f), new Color(1f, 1f, 1f, 1f), t4);
			}
			else if (item.HasStatus(PlayerInfoStatusConstant.HAND_OF_ZEUS_GOAL.ID))
			{
				color = new Color(0f, 0.6f, 1f, 1f);
			}
			else if (item.HasStatus(PlayerInfoStatusConstant.MECH_KING_ON_FIRE.ID))
			{
				color = new Color(62f / 85f, 1f / 15f, 1f / 15f, 1f);
			}
			else if (item.HasStatus(PlayerInfoStatusConstant.BLOCK_DRAGOON_SHIELD_EFFECT.ID))
			{
				color = new Color(0.6784314f, 0.2f, 0.8392157f, 1f);
			}
			else if (LowHp(item))
			{
				float t5 = (float)(_timeContext.time.ClientRealTime % 500) / 500f;
				color = Color.Lerp(new Color(1f, 0f, 0f, 1f), new Color(1f, 1f, 1f, 1f), t5);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_PURIFY.ID))
			{
				color = new Color(1f, 0.725f, 0.5333f);
			}
			else if (item.GetPlayerInfo().SlowDown)
			{
				float timeSinceLevelLoad = Time.timeSinceLevelLoad;
				color.r = Mathf.PingPong(timeSinceLevelLoad, 0.45f) + 0.5f;
				color.g = Mathf.PingPong(timeSinceLevelLoad, 0.45f) * 0.9f + 0.5f;
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.TRICK_DAGGER_BOT.ID))
			{
				color = new Color(44f / 51f, 0.36862746f, 0.9843137f, 0.6f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.TWINS_LEGEND_BOT.ID))
			{
				color = new Color(37f / 51f, 0.1254902f, 0.07450981f, 0.5f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.TWINS_BOT.ID))
			{
				color = new Color(0.5882353f, 58f / 85f, 0.99607843f, 0.5f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.TWINS_BOT_GOLD.ID))
			{
				color = new Color(1f, 1f, 0f, 0.5f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.HYPER_REVOLVER_FIRE_TAG.ID))
			{
				color = new Color(1f, 0f, 0f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.NINTH_ANNIVERSARY_BATTLE_BADGE.ID))
			{
				color = new Color(1f, 46f / 51f, 0.5568628f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.HOLYROSARY_CHANGE_RPG.ID))
			{
				color = new Color(1f, 28f / 51f, 0f);
			}
			Vector3DData mulColor = item.basicInfo.Current.MulColor;
			if (mulColor != null)
			{
				color.r *= mulColor.X;
				color.g *= mulColor.Y;
				color.b *= mulColor.Z;
			}
			if (item.isThirdPersonView && item.IsMySelf())
			{
				if (stealthSelfAlpha < 1f)
				{
					color.a = stealthSelfAlpha;
				}
				if (stealthAlpha < 1f)
				{
					color.a = stealthAlpha;
				}
			}
			else
			{
				if (stealthAlpha < 1f)
				{
					color.a = stealthAlpha;
				}
				if (item.IsMySelf())
				{
					switch (item.GetCurrentWeaponName())
					{
					case "guqin_trans_sword":
					case "guqin_trans_sword1":
					case "guqin_trans_sword2":
					{
						WeaponEntity currentWeapon = WeaponUtility.GetCurrentWeapon(item);
						if (currentWeapon != null && currentWeapon.hasSpecial && currentWeapon.special.SpecialMode)
						{
							color.a *= 2f;
						}
						break;
					}
					}
				}
			}
			if (_gameRuleContext.currentRule.Rule.IsJump() && !item.isCameraOwner)
			{
				if (item.isMyPlayer)
				{
					color.a = 0f;
				}
				else if (Vector3.Distance(item.GetCompenstatePos(item.fpos.Change.GetPosIndex()), _playerContext.cameraOwnerEntity.GetCompenstatePos(_playerContext.cameraOwnerEntity.fpos.Change.GetPosIndex())) < 500f)
				{
					color.a = 0.2f;
				}
			}
			if (item.hasThirdPersonUnityObjects && !item.thirdPersonUnityObjects.RenderColor.CompareEqual(color))
			{
				item.thirdPersonUnityObjects.RenderColor.SetColor(ref item.thirdPersonUnityObjects.RenderColor, color);
				bool isTps = RuleUtilty.IsTpsMode() && item.IsMySelf();
				Renderer[] meshRenders = item.thirdPersonUnityObjects.MeshRenders;
				foreach (Renderer smr in meshRenders)
				{
					SetColor(color, smr, isTps);
				}
				SetColor(color, item.thirdPersonUnityObjects.Skins, isTps);
				SetColor(color, item.thirdPersonUnityObjects.WeaponSkinnedMeshRenders);
				SetColor(color, item.thirdPersonUnityObjects.WeaponParticles);
				SetColor(color, item.thirdPersonUnityObjects.PlayerParticles);
			}
			if (item.hasFirstPersonUnityObjects)
			{
				Color color2 = color;
				if ((double)color2.a <= 0.2)
				{
					color2 = new Color(color.r, color.g, color.b, 0.2f);
				}
				if (!item.firstPersonUnityObjects.RenderColor.CompareEqual(color2))
				{
					item.firstPersonUnityObjects.RenderColor.SetColor(ref item.firstPersonUnityObjects.RenderColor, color2);
					SetColor(color2, item.firstPersonUnityObjects.HandSkinnedMeshRenderers);
					SetColor(color2, item.firstPersonUnityObjects.WeaponSkinnedMeshRenderers);
					SetColor(color2, item.firstPersonUnityObjects.Patricles);
				}
			}
			if (item.hasBackAccessoryUnityObjects && !item.backAccessoryUnityObjects.Render.getRenderColor().CompareEqual(color))
			{
				item.backAccessoryUnityObjects.Render.setRenderColor(color);
				SetColor(color, item.backAccessoryUnityObjects.Render.getSkinRenders());
				SetColor(color, item.backAccessoryUnityObjects.Render.getMeshRenders());
				SetColor(color, item.backAccessoryUnityObjects.Render.getPatricles());
			}
			if (item.hasBackWeaponUnityObjects && !item.backWeaponUnityObjects.Render.getRenderColor().CompareEqual(color))
			{
				item.backWeaponUnityObjects.Render.setRenderColor(color);
				SetColor(color, item.backWeaponUnityObjects.Render.getSkinRenders());
				SetColor(color, item.backWeaponUnityObjects.Render.getMeshRenders());
				SetColor(color, item.backWeaponUnityObjects.Render.getPatricles());
			}
			if (!item.hasWaistJewelryAccessory)
			{
				continue;
			}
			for (int j = 0; j < item.waistJewelryAccessory.Renders.Count; j++)
			{
				IAccessoryRenderComponent accessoryRenderComponent = item.waistJewelryAccessory.Renders[j];
				if (!accessoryRenderComponent.getRenderColor().CompareEqual(color))
				{
					accessoryRenderComponent.setRenderColor(color);
					SetColor(color, accessoryRenderComponent.getSkinRenders());
					SetColor(color, accessoryRenderComponent.getMeshRenders());
					SetColor(color, accessoryRenderComponent.getPatricles());
					item.waistJewelryAccessory.Renders[j] = accessoryRenderComponent;
				}
			}
		}
	}

	private bool LowHp(PlayerEntity player)
	{
		if (_gameRuleContext.currentRule.Rule.IsShowLowHp(player.GetCareer(), player.basicInfo.Current.Hp))
		{
			return true;
		}
		return false;
	}

	private bool InvincibleState(PlayerEntity playerEntity)
	{
		if (playerEntity.basicInfo.CareerInfo.Name == "bossjy6001")
		{
			return false;
		}
		if (playerEntity.HasStatus(PlayerInfoStatusConstant.HERO_COLD_DEATH_SKILL.ID))
		{
			return false;
		}
		if (playerEntity.HasStatus(PlayerInfoStatusConstant.NO_WUDI_TEXIAO.ID))
		{
			return false;
		}
		if (playerEntity.HasState(1) || playerEntity.GetPlayerInfo().InFrantic)
		{
			return true;
		}
		return false;
	}

	private void SetColor(Color color, IPaticlePrefabInstancecs[] particles)
	{
		if (particles != null)
		{
			for (int i = 0; i < particles.Length; i++)
			{
				(particles[i] as PaticlePrefabInstancecs).SetAlpha(color.a);
			}
		}
	}

	private void SetColor(Color color, Dictionary<IParticleKey, IPaticlePrefabInstancecs> particles)
	{
		if (particles == null)
		{
			return;
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in particles)
		{
			(particle.Value as PaticlePrefabInstancecs).SetAlpha(color.a);
		}
	}

	private void SetColor(Color color, MeshRenderer[] list)
	{
		if (list != null)
		{
			foreach (MeshRenderer smr in list)
			{
				SetColor(color, smr);
			}
		}
	}

	private void SetColor(Color color, SkinnedMeshRenderer[] list)
	{
		if (list != null)
		{
			foreach (SkinnedMeshRenderer smr in list)
			{
				SetColor(color, smr);
			}
		}
	}

	private void SetColor(Color color, Dictionary<IgnoreCaseString, SkinnedMeshRenderer> list, bool isTps)
	{
		if (list == null)
		{
			return;
		}
		foreach (KeyValuePair<IgnoreCaseString, SkinnedMeshRenderer> item in list)
		{
			SetColor(color, item.Value, isTps);
		}
	}

	private void SetColor(Color color, Renderer smr, bool isTps = false)
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
				if (isTps)
				{
					smr.sharedMaterial.SetFloat("_CullMode", 2f);
					smr.sharedMaterial.SetFloat("_OutlineShow", 0f);
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
				if (isTps)
				{
					smr.sharedMaterial.SetFloat("_CullMode", 0f);
					smr.sharedMaterial.SetFloat("_OutlineShow", 1f);
				}
				material2.SetInt("_ZWrite", (color.a != 0f) ? 1 : 0);
			}
		}
		smr.SetPropertyBlock(materialPropertyBlock);
		_blockcache.Add(materialPropertyBlock);
	}
}
