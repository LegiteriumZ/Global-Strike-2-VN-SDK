using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.UiFramework.Libs;
using SSJJBase.Singleton;
using Sources.Utils.Ui;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class MonsterSkillIconsRender : AbstractPlayerEffectRender
{
	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		GameObject gameObject = EffectObject.FindForeachByName("iconContainer");
		if (gameObject == null)
		{
			return;
		}
		Dictionary<int, string> config = SingletonInstance<MonsterSkillIconsConfigParser>.Instance.GetConfig();
		if (config == null)
		{
			return;
		}
		GameObject gameObject2 = null;
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			Transform child = gameObject.transform.GetChild(i);
			child.gameObject.SetActive(value: false);
			if (gameObject2 == null)
			{
				gameObject2 = child.gameObject;
			}
		}
		float num = 30f;
		List<string> list = new List<string>();
		foreach (KeyValuePair<int, string> item in config)
		{
			if (targetPlayer.skill.Status.ContainsKey(item.Key))
			{
				list.Add(item.Value);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (j >= gameObject.transform.childCount)
			{
				GameObject gameObject3 = Object.Instantiate(gameObject2);
				gameObject3.transform.parent = gameObject.transform;
				gameObject3.transform.localPosition = Vector3.zero;
			}
			float localX = (0f - num * (float)list.Count) / 2f + (float)j * num;
			Transform child2 = gameObject.transform.GetChild(j);
			updateIcon(child2.gameObject, list[j], localX);
			child2.gameObject.SetActive(value: true);
		}
	}

	private void updateIcon(GameObject obj, string icon, float localX)
	{
		if (!(obj == null))
		{
			Vector3 localPosition = obj.transform.localPosition;
			localPosition.x = localX;
			obj.transform.localPosition = localPosition;
			obj.transform.localEulerAngles = Vector3.zero;
			SpriteRenderer spriteRender = obj.GetComponentInChildren<SpriteRenderer>();
			AbstractModel.GetUiResourceLoader().RetriveSprite("ui/halfloadedres/monsterskillicons", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/monsterSkillIcons/" + icon + ".png", delegate(Sprite sprite)
			{
				spriteRender.sprite = sprite;
			});
		}
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		Transform bone = targetPlayer.thirdPersonUnityObjects.Animator.GetBone("bip01_head");
		if (bone != null)
		{
			Vector3 compenstatePos = targetPlayer.GetCompenstatePos(targetPlayer.fpos.Change.GetPosIndex());
			return new Vector3(0f, 0f, bone.position.y - compenstatePos.z + 50f);
		}
		return new Vector3(0f, 0f, GetHeight(targetPlayer) + 50f);
	}
}
