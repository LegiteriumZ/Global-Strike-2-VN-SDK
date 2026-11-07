using System.Collections.Generic;
using Assets.Scripts.Utility;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Framework.System;
using Entitas;
using SSJJBase.String;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.DamageEvent;

public class DamageEventResourceInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	internal class DamageStruct
	{
		public TextMesh NormaMeshTxt;

		public TextMesh DamageAddMeshTxt;

		public TextMesh TreatmentMeshTxt;

		public TextMesh ReduceMeshTxt;

		public TextMesh HeadShotMeshTxt;

		public TextMesh MeshNormalMeshTxt;

		public TextMesh MeshSpecialMeshTxt;

		public TextMesh SnowMeshTxt;

		public TextMesh Type1MeshTxt;

		public TextMesh Type2MeshTxt;

		public TextMesh Type3MeshTxt;

		public TextMesh WanLargeNumberTxt;

		public TextMesh WanDigitNumberTxt;

		public TextMesh YiLargeNumberTxt;

		public TextMesh YiDigitNumberTxt;

		public TextMesh WhiteNumberText;

		public TextMesh AcgText;

		public TextMesh AcgCritText;

		public GameObject ImmuneObj;

		public GameObject ImmuneObj2;

		public GameObject ImmuneObj3;

		public GameObject CirtObj;

		public GameObject CirtObj2;

		public GameObject BruteCritObj;

		public GameObject SuperCritObj;

		public GameObject ReduceObj;

		public GameObject SnowObj;

		public GameObject HeadShotObj;

		public GameObject DamageAddonObj;

		public GameObject WanObj;

		public GameObject YiObj;

		public GameObject WanDotObj;

		public GameObject YiDotObj;

		public GameObject WanContainer;

		public GameObject YiContainer;

		public Font font980;

		public Font font740;

		public override string ToString()
		{
			return NormaMeshTxt.GetInstanceID() + "|" + DamageAddMeshTxt.GetInstanceID();
		}

		public void Reset()
		{
			if (NormaMeshTxt != null)
			{
				NormaMeshTxt.SetObjectActive(isactive: false);
			}
			if (DamageAddMeshTxt != null)
			{
				DamageAddMeshTxt.SetObjectActive(isactive: false);
			}
			if (TreatmentMeshTxt != null)
			{
				TreatmentMeshTxt.SetObjectActive(isactive: false);
			}
			if (ReduceMeshTxt != null)
			{
				ReduceMeshTxt.SetObjectActive(isactive: false);
			}
			if (HeadShotMeshTxt != null)
			{
				HeadShotMeshTxt.SetObjectActive(isactive: false);
			}
			if (MeshNormalMeshTxt != null)
			{
				MeshNormalMeshTxt.SetObjectActive(isactive: false);
			}
			if (MeshSpecialMeshTxt != null)
			{
				MeshSpecialMeshTxt.SetObjectActive(isactive: false);
			}
			if (SnowMeshTxt != null)
			{
				SnowMeshTxt.SetObjectActive(isactive: false);
			}
			if (Type1MeshTxt != null)
			{
				Type1MeshTxt.SetObjectActive(isactive: false);
			}
			if (Type2MeshTxt != null)
			{
				Type2MeshTxt.SetObjectActive(isactive: false);
			}
			if (Type3MeshTxt != null)
			{
				Type3MeshTxt.SetObjectActive(isactive: false);
			}
			if (WanLargeNumberTxt != null)
			{
				WanLargeNumberTxt.SetObjectActive(isactive: false);
			}
			if (WanDigitNumberTxt != null)
			{
				WanDigitNumberTxt.SetObjectActive(isactive: false);
			}
			if (YiLargeNumberTxt != null)
			{
				YiLargeNumberTxt.SetObjectActive(isactive: false);
			}
			if (YiDigitNumberTxt != null)
			{
				YiDigitNumberTxt.SetObjectActive(isactive: false);
			}
			if (WhiteNumberText != null)
			{
				WhiteNumberText.SetObjectActive(isactive: false);
			}
			if (AcgText != null)
			{
				AcgText.SetObjectActive(isactive: false);
			}
			if (AcgCritText != null)
			{
				AcgCritText.SetObjectActive(isactive: false);
			}
			if (ImmuneObj != null)
			{
				ImmuneObj.SetObjectActive(isactive: false);
			}
			if (ImmuneObj2 != null)
			{
				ImmuneObj2.SetObjectActive(isactive: false);
			}
			if (ImmuneObj3 != null)
			{
				ImmuneObj3.SetObjectActive(isactive: false);
			}
			if (CirtObj != null)
			{
				CirtObj.SetObjectActive(isactive: false);
			}
			if (CirtObj2 != null)
			{
				CirtObj2.SetObjectActive(isactive: false);
			}
			if (BruteCritObj != null)
			{
				BruteCritObj.SetObjectActive(isactive: false);
			}
			if (SuperCritObj != null)
			{
				SuperCritObj.SetObjectActive(isactive: false);
			}
			if (ReduceObj != null)
			{
				ReduceObj.SetObjectActive(isactive: false);
			}
			if (SnowObj != null)
			{
				SnowObj.SetObjectActive(isactive: false);
			}
			if (HeadShotObj != null)
			{
				HeadShotObj.SetObjectActive(isactive: false);
			}
			if (DamageAddonObj != null)
			{
				DamageAddonObj.SetObjectActive(isactive: false);
			}
			if (WanObj != null)
			{
				WanObj.SetObjectActive(isactive: false);
			}
			if (YiObj != null)
			{
				YiObj.SetObjectActive(isactive: false);
			}
			if (WanDotObj != null)
			{
				WanDotObj.SetObjectActive(isactive: false);
			}
			if (YiDotObj != null)
			{
				YiDotObj.SetObjectActive(isactive: false);
			}
		}
	}

	private MaterialPropertyBlock _spriteBlock;

	private MaterialPropertyBlock _MeshRenderBlock;

	private BattleRoomContext _battleRoomContext;

	private readonly PlayerContext _playerContext;

	private GameRuleContext _gameRuleContext;

	private readonly Dictionary<GameObject, DamageStruct> _dictionaryDamage;

	public DamageEventResourceInitSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
		_playerContext = contexts.player;
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
		_dictionaryDamage = new Dictionary<GameObject, DamageStruct>();
		_spriteBlock = new MaterialPropertyBlock();
		_MeshRenderBlock = new MaterialPropertyBlock();
	}

	private DamageStruct InitDamageHitText(GameObject damageHintText)
	{
		if (!_dictionaryDamage.TryGetValue(damageHintText, out var value))
		{
			value = new DamageStruct();
			value.NormaMeshTxt = damageHintText.transform.Find("GameObject/NormalText").GetComponent<TextMesh>();
			value.ImmuneObj = damageHintText.transform.Find("GameObject/Immune").gameObject;
			value.ImmuneObj2 = damageHintText.transform.Find("GameObject/Immune2").gameObject;
			value.ImmuneObj3 = damageHintText.transform.Find("GameObject/Immune3").gameObject;
			value.CirtObj = damageHintText.transform.Find("GameObject/Crit").gameObject;
			value.CirtObj2 = damageHintText.transform.Find("GameObject/Crit2").gameObject;
			value.BruteCritObj = damageHintText.transform.Find("GameObject/BruteCrit").gameObject;
			value.SuperCritObj = damageHintText.transform.Find("GameObject/SuperCrit").gameObject;
			value.ReduceObj = damageHintText.transform.Find("GameObject/DamageReduce").gameObject;
			value.SnowObj = damageHintText.transform.Find("GameObject/Snow").gameObject;
			value.HeadShotObj = damageHintText.transform.Find("GameObject/HeadShot").gameObject;
			value.DamageAddonObj = damageHintText.transform.Find("GameObject/DamageAddon").gameObject;
			value.WanObj = damageHintText.transform.Find("GameObject/WanObject/Wan").gameObject;
			value.YiObj = damageHintText.transform.Find("GameObject/YiObject/Yi").gameObject;
			value.WanDotObj = damageHintText.transform.Find("GameObject/WanObject/Dot").gameObject;
			value.YiDotObj = damageHintText.transform.Find("GameObject/YiObject/Dot").gameObject;
			value.WanContainer = damageHintText.transform.Find("GameObject/WanObject").gameObject;
			value.YiContainer = damageHintText.transform.Find("GameObject/YiObject").gameObject;
			value.TreatmentMeshTxt = damageHintText.transform.Find("GameObject/TreatmentText").GetComponent<TextMesh>();
			value.ReduceMeshTxt = damageHintText.transform.Find("GameObject/ReduceText").GetComponent<TextMesh>();
			value.HeadShotMeshTxt = damageHintText.transform.Find("GameObject/HeadShotText").GetComponent<TextMesh>();
			value.DamageAddMeshTxt = damageHintText.transform.Find("GameObject/NormalText").GetComponent<TextMesh>();
			value.MeshNormalMeshTxt = damageHintText.transform.Find("GameObject/MechNormalText").GetComponent<TextMesh>();
			value.MeshSpecialMeshTxt = damageHintText.transform.Find("GameObject/MechSpecialText").GetComponent<TextMesh>();
			value.WhiteNumberText = damageHintText.transform.Find("GameObject/WhiteText").GetComponent<TextMesh>();
			value.SnowMeshTxt = damageHintText.transform.Find("GameObject/SnowText").GetComponent<TextMesh>();
			value.Type1MeshTxt = damageHintText.transform.Find("GameObject/Type1Text").GetComponent<TextMesh>();
			value.Type2MeshTxt = damageHintText.transform.Find("GameObject/Type2Text").GetComponent<TextMesh>();
			value.Type3MeshTxt = damageHintText.transform.Find("GameObject/Type3Text").GetComponent<TextMesh>();
			value.WanLargeNumberTxt = damageHintText.transform.Find("GameObject/WanObject/LargeNumberText").GetComponent<TextMesh>();
			value.WanDigitNumberTxt = damageHintText.transform.Find("GameObject/WanObject/DigitNumberText").GetComponent<TextMesh>();
			value.YiLargeNumberTxt = damageHintText.transform.Find("GameObject/YiObject/LargeNumberText").GetComponent<TextMesh>();
			value.YiDigitNumberTxt = damageHintText.transform.Find("GameObject/YiObject/DigitNumberText").GetComponent<TextMesh>();
			value.AcgText = damageHintText.transform.Find("GameObject/AcgText").GetComponent<TextMesh>();
			value.AcgCritText = damageHintText.transform.Find("GameObject/AcgCritText").GetComponent<TextMesh>();
			value.font980 = damageHintText.transform.Find("GameObject/Font980").GetComponent<TextMesh>().font;
			value.font740 = value.WanLargeNumberTxt.font;
			_dictionaryDamage[damageHintText] = value;
			if (RuleUtilty.isFogMode(_battleRoomContext.roomData.Data.RaceType))
			{
				MeshRenderer component = value.WanLargeNumberTxt.GetComponent<MeshRenderer>();
				component.material.renderQueue = 2000;
				component.material.SetFloat("_ZWrite", 1f);
				MeshRenderer component2 = value.WanDigitNumberTxt.GetComponent<MeshRenderer>();
				component2.material.renderQueue = 2000;
				component2.material.SetFloat("_ZWrite", 1f);
				SpriteRenderer component3 = value.WanDotObj.GetComponent<SpriteRenderer>();
				component3.material.renderQueue = 2000;
				component3.material.SetFloat("_ZWrite", 1f);
				SpriteRenderer component4 = value.WanObj.GetComponent<SpriteRenderer>();
				component4.material.renderQueue = 2000;
				component4.material.SetFloat("_ZWrite", 1f);
				SpriteRenderer component5 = value.ReduceObj.GetComponent<SpriteRenderer>();
				component5.material.renderQueue = 2000;
				component5.material.SetFloat("_ZWrite", 1f);
			}
		}
		value.Reset();
		return value;
	}

	private void LoadDamageEventResource(SceneObjectEntity entity)
	{
		if (GameSetting.Config.DamageShowLevel == 2)
		{
			entity.isDestroy = true;
			return;
		}
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(entity.damageEvent.TargetId);
		if (entityWithEntityId != null && GameSetting.Config.DamageShowLevel == 1 && entityWithEntityId.basicInfo.Current.BotQuality < 3)
		{
			entity.isDestroy = true;
			return;
		}
		Vector3 position = VectorCoordConverter.SsjjToUnity(entity.position.Origin);
		if (CheckIsMechEffect(entity))
		{
			position += new Vector3(Random.Range(-90, 90), Random.Range(-50, -30), Random.Range(-30, 30));
		}
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		gameObject.transform.position = position;
		DamageStruct damageStruct = InitDamageHitText(gameObject);
		if (_gameRuleContext.currentRule.Rule.IsAcg())
		{
			damageStruct.Reset();
			entity.damageEvent.Parent = gameObject;
			entity.damageEvent.TextMesh = (entity.damageEvent.IsCrit ? damageStruct.AcgCritText : damageStruct.AcgText);
			entity.damageEvent.TextMesh.text = ((entity.damageEvent.Elemental == "Water") ? "a" : ((entity.damageEvent.Elemental == "Dark") ? "b" : ((entity.damageEvent.Elemental == "Light") ? "c" : ((entity.damageEvent.Elemental == "Wood") ? "d" : "e"))));
			entity.damageEvent.TextMesh.text += StringCache.LongToString(entity.damageEvent.Damage);
			entity.damageEvent.TextMesh.gameObject.SetObjectActive(isactive: true);
			entity.damageEvent.ColorTime = (entity.damageEvent.ColorAllTime = 800);
			entity.damageEvent.DelayTime = 100;
			SetMeshRenderer(entity.damageEvent.TextMesh, Color.white, ref entity.damageEvent.TextMeshRenderer, 0);
		}
		else
		{
			TextMesh textMesh = damageStruct.NormaMeshTxt;
			TextMesh textMesh2 = damageStruct.WanDigitNumberTxt;
			List<GameObject> list = new List<GameObject>();
			GameObject suffixObject = null;
			GameObject dotObject = null;
			Color color = new Color(1f, 0.616f, 0.114f, 1f);
			if ((_gameRuleContext.currentRule.Rule.IsPve() || GameSetting.Config.PVPHitTextShow == 1) && entity.damageEvent.ShowType == 0)
			{
				entity.damageEvent.StyleType = 1;
			}
			double num = entity.damageEvent.Damage;
			int num2 = 0;
			if (entity.damageEvent.DamageReduce)
			{
				list.Add(damageStruct.ReduceObj);
				color = Color.white;
			}
			if (entity.damageEvent.ShowType == 1)
			{
				list.Add(damageStruct.SnowObj);
				color = new Color(0.02f, 0.725f, 0.875f, 1f);
				textMesh = damageStruct.SnowMeshTxt;
			}
			if (entity.damageEvent.ShowType == 101)
			{
				color = new Color(0.424f, 0.812f, 0.925f, 1f);
				textMesh = damageStruct.WhiteNumberText;
				num2 = -1;
			}
			if (entity.damageEvent.ShowType == 102)
			{
				color = new Color(0.49f, 0.333f, 0.953f, 1f);
				textMesh = damageStruct.WhiteNumberText;
				num2 = -1;
			}
			if (entity.damageEvent.ShowType == 7)
			{
				color = new Color(0.854f, 0.349f, 1f, 1f);
				textMesh = damageStruct.WhiteNumberText;
				num2 = -1;
			}
			if (entity.damageEvent.ShowType == 10)
			{
				color = new Color(0.662f, 0.345f, 0.949f, 1f);
				textMesh = damageStruct.WhiteNumberText;
				num2 = -1;
			}
			if (entity.damageEvent.ShowType == 11)
			{
				color = new Color(1f, 0.769f, 0f, 1f);
				textMesh = damageStruct.WhiteNumberText;
				num2 = -1;
			}
			if (entity.damageEvent.DamageAdd)
			{
				list.Add(damageStruct.DamageAddonObj);
				color = new Color(1f, 0.616f, 0.114f, 1f);
				textMesh = damageStruct.DamageAddMeshTxt;
			}
			if (entity.damageEvent.IsCrit)
			{
				if (entity.damageEvent.StyleType == 1)
				{
					if (entity.damageEvent.critType == 1)
					{
						list.Add(damageStruct.BruteCritObj);
					}
					else if (entity.damageEvent.critType == 2)
					{
						list.Add(damageStruct.SuperCritObj);
					}
					else
					{
						list.Add(damageStruct.CirtObj);
					}
				}
				else
				{
					list.Add(damageStruct.CirtObj2);
					color = new Color(1f, 0.616f, 0.114f, 1f);
					num2 = 2;
				}
			}
			if (entity.damageEvent.HeadShoot)
			{
				list.Add(damageStruct.HeadShotObj);
				textMesh = damageStruct.HeadShotMeshTxt;
			}
			if (entity.damageEvent.Immune)
			{
				switch (GetHPType(entityWithEntityId))
				{
				case 2:
					list.Add(damageStruct.ImmuneObj2);
					break;
				case 3:
					list.Add(damageStruct.ImmuneObj3);
					break;
				default:
					list.Add(damageStruct.ImmuneObj);
					break;
				}
			}
			else if (entity.damageEvent.ShowType == 2)
			{
				textMesh = damageStruct.Type1MeshTxt;
			}
			else if (entity.damageEvent.ShowType == 3)
			{
				textMesh = damageStruct.Type2MeshTxt;
			}
			else if (entity.damageEvent.ShowType == 4)
			{
				textMesh = damageStruct.Type3MeshTxt;
			}
			else if (entity.damageEvent.DamageReduce)
			{
				textMesh = damageStruct.ReduceMeshTxt;
			}
			else if (entity.damageEvent.IsTreatment)
			{
				textMesh = damageStruct.TreatmentMeshTxt;
			}
			else if (entity.damageEvent.MeshNormal)
			{
				textMesh = damageStruct.MeshNormalMeshTxt;
			}
			else if (entity.damageEvent.MeshSpecial)
			{
				textMesh = damageStruct.MeshSpecialMeshTxt;
			}
			if (num >= 100000000.0)
			{
				num /= 100000000.0;
				textMesh = damageStruct.YiLargeNumberTxt;
				textMesh2 = damageStruct.YiDigitNumberTxt;
				suffixObject = damageStruct.YiObj;
				dotObject = damageStruct.YiDotObj;
				num2 = 2;
			}
			else if (num >= 10000.0)
			{
				num /= 10000.0;
				textMesh = damageStruct.WanLargeNumberTxt;
				textMesh2 = damageStruct.WanDigitNumberTxt;
				suffixObject = damageStruct.WanObj;
				dotObject = damageStruct.WanDotObj;
				num2 = 1;
			}
			damageStruct.Reset();
			entity.damageEvent.Parent = gameObject;
			entity.damageEvent.TextMesh = textMesh;
			entity.damageEvent.DigitTextMesh = textMesh2;
			entity.damageEvent.DigitTextMesh.gameObject.SetObjectActive(num2 > 0);
			entity.damageEvent.ColorTime = (entity.damageEvent.ColorAllTime = 1600);
			entity.damageEvent.DelayTime = 100;
			entity.damageEvent.HighDelayTime = 250;
			entity.damageEvent.DamageObjects = list;
			foreach (GameObject damageObject in entity.damageEvent.DamageObjects)
			{
				damageObject.SetObjectActive(num2 > 0);
			}
			entity.damageEvent.SuffixObject = suffixObject;
			entity.damageEvent.SuffixObject.SetObjectActive(num2 > 0);
			entity.damageEvent.DotObject = dotObject;
			entity.damageEvent.DotObject.SetObjectActive(num2 > 0);
			Color color2 = color;
			if (entity.damageEvent.StyleType == 1 && !entity.damageEvent.IsCrit && !entity.damageEvent.HeadShoot)
			{
				color2 = new Color(0.95686275f, 37f / 51f, 11f / 51f);
			}
			if (entity.damageEvent.StyleType == 1 && (entity.damageEvent.IsCrit || entity.damageEvent.HeadShoot))
			{
				color2 = new Color(0.6156863f, 0f, 0.007843138f);
				if (entity.damageEvent.IsCrit)
				{
					if (entity.damageEvent.critType == 1)
					{
						color2 = new Color(0.85490197f, 0.4392157f, 0.8392157f);
					}
					else if (entity.damageEvent.critType == 2)
					{
						color2 = new Color(46f / 85f, 0.16862746f, 0.8862745f);
					}
				}
			}
			if (entity.damageEvent.TextMesh != null)
			{
				if (entity.damageEvent.StyleType == 1)
				{
					SetMeshRenderer(entity.damageEvent.TextMesh, color2, ref entity.damageEvent.TextMeshRenderer, 1);
				}
				else
				{
					SetMeshRenderer(entity.damageEvent.TextMesh, color2, ref entity.damageEvent.TextMeshRenderer, num2);
				}
			}
			if (num2 > 0)
			{
				entity.damageEvent.DamageSpriteRenderers = new List<SpriteRenderer>();
				foreach (GameObject damageObject2 in entity.damageEvent.DamageObjects)
				{
					SetSpriteRenderers(damageObject2, color2, ref entity.damageEvent.DamageSpriteRenderers);
				}
				if (entity.damageEvent.SuffixObject != null)
				{
					SetSpriteRenderer(entity.damageEvent.SuffixObject, color2, ref entity.damageEvent.SuffixObjectSpriteRenderer);
				}
				if (entity.damageEvent.DotObject != null)
				{
					SetSpriteRenderer(entity.damageEvent.DotObject, color2, ref entity.damageEvent.DotObjectSpriteRenderer);
				}
				if (entity.damageEvent.DigitTextMesh != null)
				{
					SetMeshRenderer(entity.damageEvent.DigitTextMesh, color2, ref entity.damageEvent.DigitTextMeshRenderer, num2);
				}
			}
			if (!entity.damageEvent.Immune)
			{
				textMesh.gameObject.SetObjectActive(isactive: true);
			}
			else
			{
				switch (GetHPType(entityWithEntityId))
				{
				case 2:
					damageStruct.ImmuneObj2.SetObjectActive(isactive: true);
					break;
				case 3:
					damageStruct.ImmuneObj3.SetObjectActive(isactive: true);
					break;
				default:
					damageStruct.ImmuneObj.SetObjectActive(isactive: true);
					break;
				}
			}
			if (entity.damageEvent.Damage < 10000)
			{
				textMesh.text = StringCache.LongToString(entity.damageEvent.Damage);
			}
			else
			{
				long value = (long)num;
				int num3 = (int)((num - (double)(long)num) * 10.0);
				textMesh.text = StringCache.LongToString(value);
				textMesh2.text = StringCache.IntToString(num3);
				float num4 = 62f;
				float num5 = ((num2 >= 1) ? 21f : 31f);
				float num6 = ((num2 >= 1) ? (-15f) : (-30f));
				bool flag = true;
				if (num3 == 0)
				{
					num6 = ((num2 >= 1) ? 0f : (-15f));
					flag = false;
					entity.damageEvent.DigitTextMesh.gameObject.SetObjectActive(isactive: false);
					entity.damageEvent.DotObject.SetObjectActive(isactive: false);
				}
				int count = entity.damageEvent.DamageObjects.Count;
				if (count > 0)
				{
					for (int i = 0; i < count; i++)
					{
						float offset = num6 - (float)(textMesh.text.Length - 1) * num5 - (float)(i + 1) * num4;
						SetPosition(entity.damageEvent.DamageObjects[i].transform, offset);
					}
				}
				if (entity.damageEvent.SuffixObject != null)
				{
					switch (num2)
					{
					case 1:
					{
						SetPosition(damageStruct.WanContainer.transform, num6 - (float)(textMesh.text.Length - 1) * num5);
						float num8 = (flag ? 100f : 70f);
						num8 = ((entity.damageEvent.StyleType != 1) ? (num8 + (float)(textMesh.text.Length * 23)) : (num8 + (float)(textMesh.text.Length * 29)));
						if (flag)
						{
							SetPosition(entity.damageEvent.DotObject.transform, num8 - 121f);
							SetPosition(entity.damageEvent.DigitTextMesh.transform, num8 - 115f);
						}
						SetPosition(entity.damageEvent.SuffixObject.transform, num8 - 75f);
						break;
					}
					case 2:
					{
						SetPosition(damageStruct.YiContainer.transform, num6 - (float)(textMesh.text.Length - 1) * num5);
						float num7 = (flag ? 100f : 70f);
						num7 = ((entity.damageEvent.StyleType != 1) ? (num7 + (float)(textMesh.text.Length * 23)) : (num7 + (float)(textMesh.text.Length * 29)));
						if (flag)
						{
							SetPosition(entity.damageEvent.DotObject.transform, num7 - 121f);
							SetPosition(entity.damageEvent.DigitTextMesh.transform, num7 - 115f);
						}
						SetPosition(entity.damageEvent.SuffixObject.transform, num7 - 75f);
						break;
					}
					}
				}
			}
			if (entity.damageEvent.ShowType == 0)
			{
				if (entity.damageEvent.StyleType == 1)
				{
					UpdateFont(entity, damageStruct.font980, 5.8f);
				}
				else
				{
					UpdateFont(entity, damageStruct.font740, 16f);
				}
			}
		}
		float num9 = 70f;
		float max = 40f;
		float num10 = 0.3f;
		int posLerpTime = 600;
		if (_gameRuleContext.currentRule.Rule.IsAcg())
		{
			num9 = 100f;
			max = 50f;
			posLerpTime = 400;
		}
		float num11 = ((entity.damageEvent.DamageObjects != null) ? (1f - (float)entity.damageEvent.DamageObjects.Count * 0.2f) : 1f);
		Vector3 vector = new Vector3(Random.Range((0f - num9) * num11, num9), Random.Range(-25f, max), 0f);
		entity.damageEvent.StartPos = gameObject.transform.position + vector;
		entity.damageEvent.EndPos = entity.damageEvent.StartPos + new Vector3(vector.x * num10, 140f, 0f);
		entity.damageEvent.PosLerpTime = posLerpTime;
		if (entity.damageEvent.StyleType == 1)
		{
			entity.damageEvent.ColorTime = (entity.damageEvent.ColorAllTime = 100);
			entity.damageEvent.StartPos = gameObject.transform.position;
			entity.damageEvent.EndPos = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f) * new Vector3(Random.Range(-500, 500), Random.Range(0, 500), 0f);
			if (entity.damageEvent.IsCrit && (entity.damageEvent.critType == 1 || entity.damageEvent.critType == 2))
			{
				entity.damageEvent.EndPos *= 1.5f;
			}
		}
		if (CheckIsMechEffect(entity))
		{
			entity.damageEvent.PosLerpTime /= 2;
			entity.damageEvent.EndPos = entity.damageEvent.StartPos + new Vector3(vector.x * num10, 200f, 0f);
		}
		entity.damageEvent.PosLerpAllTime = entity.damageEvent.PosLerpTime;
		if (entity.unityObjects.LoadResults.Count > 1)
		{
			entityWithEntityId = _playerContext.GetEntityWithEntityId(entity.damageEvent.TargetId);
			GameObject gameObject2 = entity.unityObjects.LoadResults[1].GameObject;
			if (entityWithEntityId != null && entityWithEntityId.hasThirdPersonUnityObjects)
			{
				FollowTransform.Follow(gameObject2.transform, entityWithEntityId.thirdPersonUnityObjects.ThirdTran.BodyTransform, useMatrixOnBegin: true);
			}
		}
	}

	private void UpdateFont(SceneObjectEntity entity, Font font, float size)
	{
		if (entity.damageEvent.DigitTextMesh != null)
		{
			entity.damageEvent.DigitTextMesh.font = font;
			entity.damageEvent.DigitTextMesh.characterSize = size;
			entity.damageEvent.DigitTextMesh.GetComponent<MeshRenderer>().material = font.material;
		}
		if (entity.damageEvent.TextMesh != null)
		{
			entity.damageEvent.TextMesh.font = font;
			entity.damageEvent.TextMesh.characterSize = size;
			entity.damageEvent.TextMesh.GetComponent<MeshRenderer>().material = font.material;
		}
	}

	private int GetHPType(PlayerEntity entity)
	{
		if (entity == null)
		{
			return 1;
		}
		if (entity.basicInfo.Current.LifeBarSeq.Count > entity.basicInfo.Current.CurrentLifeBarSeq)
		{
			return entity.basicInfo.Current.LifeBarSeq[entity.basicInfo.Current.CurrentLifeBarSeq];
		}
		return 0;
	}

	private bool CheckIsMechEffect(SceneObjectEntity entity)
	{
		if (entity.damageEvent.MeshNormal || entity.damageEvent.MeshSpecial)
		{
			return true;
		}
		return false;
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		return entity.hasDamageEvent;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			LoadDamageEventResource(entity);
		}
	}

	public void SetPosition(Transform transform, float offset)
	{
		Vector3 localPosition = transform.localPosition;
		localPosition.x = offset;
		transform.localPosition = localPosition;
	}

	private void SetSpriteRenderer(GameObject gameObject, Color color, ref SpriteRenderer spriteRenderer)
	{
		SpriteRenderer component = gameObject.GetComponent<SpriteRenderer>();
		component.GetPropertyBlock(_spriteBlock);
		_spriteBlock.SetColor("_Color", color);
		component.SetPropertyBlock(_spriteBlock);
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	private void SetSpriteRenderers(GameObject gameObject, Color color, ref List<SpriteRenderer> spriteRenderers)
	{
		SpriteRenderer component = gameObject.GetComponent<SpriteRenderer>();
		component.GetPropertyBlock(_spriteBlock);
		_spriteBlock.SetColor("_Color", color);
		component.SetPropertyBlock(_spriteBlock);
		spriteRenderers.Add(gameObject.GetComponent<SpriteRenderer>());
	}

	private void SetMeshRenderer(TextMesh textMesh, Color color, ref MeshRenderer meshRenderer, int isLargeNumber)
	{
		Color value = ((isLargeNumber != 0) ? color : Color.white);
		MeshRenderer component = textMesh.GetComponent<MeshRenderer>();
		component.GetPropertyBlock(_MeshRenderBlock);
		_MeshRenderBlock.SetColor("_Color", value);
		component.SetPropertyBlock(_MeshRenderBlock);
		meshRenderer = textMesh.GetComponent<MeshRenderer>();
	}
}
