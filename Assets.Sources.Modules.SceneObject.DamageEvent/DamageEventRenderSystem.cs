using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.DamageEvent;

public class DamageEventRenderSystem : IRenderSystem
{
	private readonly TimeContext _timeContext;

	private IGroup<SceneObjectEntity> _group;

	private MaterialPropertyBlock _meshRenderblock;

	private MaterialPropertyBlock _spriteBlock;

	public DamageEventRenderSystem(Contexts contexts)
	{
		_spriteBlock = new MaterialPropertyBlock();
		_meshRenderblock = new MaterialPropertyBlock();
		_timeContext = contexts.time;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.DamageEvent, SceneObjectMatcher.UnityObjects).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		int num = _timeContext.time.FrameInterval;
		foreach (SceneObjectEntity item in _group)
		{
			if (item.damageEvent.StyleType == 0)
			{
				item.damageEvent.PosLerpTime -= num;
				float num2 = (float)item.damageEvent.PosLerpTime * 1f / (float)item.damageEvent.PosLerpAllTime;
				item.damageEvent.Parent.transform.position = item.damageEvent.StartPos + (item.damageEvent.EndPos - item.damageEvent.StartPos) * (1f - num2);
			}
			else
			{
				num = (int)((float)_timeContext.time.FrameInterval * 0.8f);
				float num3 = 300f;
				float num4 = item.damageEvent.PosLerpAllTime - item.damageEvent.PosLerpTime;
				float num5 = 1f;
				float num6 = 0.5f;
				if (item.damageEvent.IsCrit && (item.damageEvent.critType == 1 || item.damageEvent.critType == 2))
				{
					num6 = 1f;
				}
				if (num4 < num3)
				{
					item.damageEvent.PosLerpTime -= num;
					item.damageEvent.DelayTime = num + 1;
					num5 = 1f + num6 * num4 / num3;
				}
				else if (item.damageEvent.HighDelayTime > 0)
				{
					num = 0;
					item.damageEvent.HighDelayTime -= _timeContext.time.FrameInterval;
					item.damageEvent.DelayTime = num + 1;
					num5 = 1f + num6 * (1f - (num4 - num3) / num3);
				}
				else
				{
					item.damageEvent.PosLerpTime -= num;
					num5 = 1f + num6 * (1f - (num4 - num3) / num3);
				}
				if (item.damageEvent.IsCrit || item.damageEvent.HeadShoot)
				{
					item.damageEvent.Parent.transform.localScale = Vector3.one * num5;
				}
				float num7 = (float)(item.damageEvent.PosLerpAllTime - item.damageEvent.PosLerpTime) / 1000f;
				item.damageEvent.Parent.transform.position = item.damageEvent.StartPos + item.damageEvent.EndPos * num7 + 0.5f * new Vector3(0f, -1600f, 0f) * num7 * num7;
			}
			item.damageEvent.DelayTime -= num;
			if (item.damageEvent.DelayTime > 0)
			{
				continue;
			}
			List<GameObject> damageObjects = item.damageEvent.DamageObjects;
			GameObject suffixObject = item.damageEvent.SuffixObject;
			GameObject dotObject = item.damageEvent.DotObject;
			TextMesh textMesh = item.damageEvent.TextMesh;
			TextMesh digitTextMesh = item.damageEvent.DigitTextMesh;
			float num8 = (float)(item.damageEvent.ColorTime - num) * 1f / (float)item.damageEvent.ColorAllTime;
			item.damageEvent.ColorTime -= num;
			if (damageObjects != null && damageObjects.Count > 0 && item.damageEvent.DamageSpriteRenderers != null)
			{
				int count = item.damageEvent.DamageSpriteRenderers.Count;
				for (int i = 0; i < damageObjects.Count && i < count && !(item.damageEvent.DamageSpriteRenderers[i] == null); i++)
				{
					if (damageObjects[i] != null && damageObjects[i].activeSelf)
					{
						UpdateSpriteColor(item.damageEvent.DamageSpriteRenderers[i], num8);
					}
				}
			}
			if (suffixObject != null && suffixObject.activeSelf)
			{
				UpdateSpriteColor(item.damageEvent.SuffixObjectSpriteRenderer, num8);
			}
			if (dotObject != null && dotObject.activeSelf)
			{
				UpdateSpriteColor(item.damageEvent.DotObjectSpriteRenderer, num8);
			}
			if (textMesh != null)
			{
				UpdateMeshColor(item.damageEvent.TextMeshRenderer, num8);
			}
			if (digitTextMesh != null && digitTextMesh.gameObject.activeSelf)
			{
				UpdateMeshColor(item.damageEvent.DigitTextMeshRenderer, num8);
			}
			if (num8 <= 0f)
			{
				item.isDestroy = true;
			}
		}
	}

	public void UpdateSpriteColor(SpriteRenderer spriteRenderer, float alpha)
	{
		spriteRenderer.GetPropertyBlock(_spriteBlock);
		Color value = _spriteBlock.GetVector("_Color");
		value.a = alpha;
		_spriteBlock.SetColor("_Color", value);
		spriteRenderer.SetPropertyBlock(_spriteBlock);
	}

	public void UpdateMeshColor(MeshRenderer meshRenderer, float alpha)
	{
		meshRenderer.GetPropertyBlock(_meshRenderblock);
		Color value = _meshRenderblock.GetVector("_Color");
		value.a = alpha;
		_meshRenderblock.SetColor("_Color", value);
		meshRenderer.SetPropertyBlock(_meshRenderblock);
	}
}
