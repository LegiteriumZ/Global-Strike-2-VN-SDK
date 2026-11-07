using Assets.Res.Assets.Scripts;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.NewNpc.Hp;

public class NpcHpEffectRenderSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	public NpcHpEffectRenderSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcUnityObjects, SceneObjectMatcher.NpcBasicInfo, SceneObjectMatcher.NpcHp));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			int height = PlayerCareerConstantUtility.GetHeight(item.npcBasicInfo.Current.Career);
			float x = item.scale.Scale.x;
			item.npcHp.Hp.transform.position = new Vector3(0f, x * (float)height, 0f) + VectorCoordConverter.SsjjToUnity(item.position.Origin);
			long hp = item.npcBasicInfo.Current.Hp;
			long maxHp = item.npcBasicInfo.Current.MaxHp;
			if (item.npcBasicInfo.Current.ShowHpBar && hp > 0 && maxHp > 0)
			{
				item.npcHp.Hp.SetActive(value: true);
				float num = (float)hp * 1f / (float)maxHp;
				item.npcHp.HpFillAmount.fillAmount = num;
				if (num > 0.7f)
				{
					item.npcHp.HpFillAmount.sprite = item.npcHp.Hp.GetComponent<SpriteList>().Sprites[0];
				}
				else if (num > 0.3f)
				{
					item.npcHp.HpFillAmount.sprite = item.npcHp.Hp.GetComponent<SpriteList>().Sprites[1];
				}
				else
				{
					item.npcHp.HpFillAmount.sprite = item.npcHp.Hp.GetComponent<SpriteList>().Sprites[2];
				}
			}
			else
			{
				item.npcHp.Hp.SetActive(value: false);
			}
		}
	}
}
