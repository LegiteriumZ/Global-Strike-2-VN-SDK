using System;
using System.Collections.Generic;
using System.Xml;
using Assets.Sources.CsvLoader;
using SSJJAsset.AssetLoader.Xml;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.XmlAsset;

public class WeaponConfigXmlAsset : AbstractXmlAsset
{
	private Dictionary<string, bool> isLoadOver = new Dictionary<string, bool>();

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		if (!xmlDocument.FirstChild.HasChildNodes)
		{
			return;
		}
		string name = xmlDocument.FirstChild.Name;
		if (isLoadOver.ContainsKey(name))
		{
			return;
		}
		if (BattleSingletonInstance<WeaponInfoCache>.Instance.RowCaches.ContainsKey(name))
		{
			WeaponTable.Row row = BattleSingletonInstance<WeaponInfoCache>.Instance.RowCaches[name];
			foreach (XmlNode childNode in xmlDocument.FirstChild.ChildNodes)
			{
				if (childNode != null)
				{
					if (childNode.Name.Equals("WeaponType"))
					{
						row.WeaponType = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("StringName"))
					{
						row.StringName = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("AttackType"))
					{
						row.AttackType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("SpecialAttackType"))
					{
						row.SpecialAttackType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("InfoType"))
					{
						row.InfoType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("AttackInterval"))
					{
						row.AttackInterval = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("AccuracyDivisor"))
					{
						row.AccuracyDivisor = Convert.ToSingle(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("AccuracyOffset"))
					{
						row.AccuracyOffset = Convert.ToSingle(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("MaxClip"))
					{
						row.MaxClip = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("MaxCarryClip"))
					{
						row.MaxCarryClip = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("MaxClip2"))
					{
						row.MaxClip2 = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("MaxCarryClip2"))
					{
						row.MaxCarryClip2 = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("SceneWeaponName"))
					{
						row.SceneWeaponName = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("MaxInaccuracy"))
					{
						row.MaxInaccuracy = Convert.ToSingle(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("DefaultAccuracy"))
					{
						row.DefaultAccuracy = Convert.ToSingle(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("SpreadScaleY"))
					{
						row.SpreadScaleY = Convert.ToSingle(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("SlashSlashTime"))
					{
						row.SlashSlashTime = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("SlashStabTime"))
					{
						row.SlashStabTime = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("StabSlashTime"))
					{
						row.StabSlashTime = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("StabStabTime"))
					{
						row.StabStabTime = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("DelayAttackSlashTime"))
					{
						row.DelayAttackSlashTime = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("DelayAttackSlashTime2"))
					{
						row.DelayAttackSlashTime2 = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("DelayAttackStabTime"))
					{
						row.DelayAttackStabTime = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("IsMelee"))
					{
						row.IsMelee = Convert.ToBoolean(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("ClipCount"))
					{
						row.ClipCount = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("CrossType"))
					{
						row.CrossType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("ReloadType"))
					{
						row.ReloadType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("Attach"))
					{
						row.Attach = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("FireBullets"))
					{
						row.FireBullets = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("ClipPerShot"))
					{
						row.ClipPerShot = Convert.ToInt32(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("IsGold"))
					{
						row.IsGold = Convert.ToBoolean(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("RifleScopeParams"))
					{
						row.RifleScopeParams = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("ThirdAnimationType"))
					{
						row.ThirdAnimationType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("SpecialThirdAnimationType"))
					{
						row.SpecialThirdAnimationType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("AnimationWeaponName"))
					{
						row.AnimationWeaponName = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("EventType"))
					{
						row.EventType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("HideViewHand"))
					{
						row.HideViewHand = Convert.ToBoolean(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("HideThirdHand"))
					{
						row.HideThirdHand = Convert.ToBoolean(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("HasKnifeEffect"))
					{
						row.HasKnifeEffect = Convert.ToBoolean(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("HasDoubleAttack"))
					{
						row.HasDoubleAttack = Convert.ToBoolean(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("HasOtherFire"))
					{
						row.HasOtherFire = Convert.ToBoolean(childNode.FirstChild.Value);
					}
					else if (childNode.Name.Equals("MaxSpeedType"))
					{
						row.MaxSpeedType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("MaxSpeedParam"))
					{
						row.MaxSpeedParam = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("KickbackType"))
					{
						row.KickbackType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("KickbackParam"))
					{
						row.KickbackParam = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("SpreadType"))
					{
						row.SpreadType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("SpreadParam"))
					{
						row.SpreadParam = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("ShotDistType"))
					{
						row.ShotDistType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("ShotDistParam"))
					{
						row.ShotDistParam = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("AccuracyType"))
					{
						row.AccuracyType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("AccuracyParam"))
					{
						row.AccuracyParam = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("HoleType"))
					{
						row.HoleType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("HoleParam"))
					{
						row.HoleParam = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("RailType"))
					{
						row.RailType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("RailParam"))
					{
						row.RailParam = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("UiModels"))
					{
						row.UiModels = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("RaiseType"))
					{
						row.RaiseType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("ViewEffectModels"))
					{
						row.ViewEffectModels = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("ThirdEffectModels"))
					{
						row.ThirdEffectModels = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("ChangeWeapon"))
					{
						row.ChangeWeapon = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("LegsThirdAnimationType"))
					{
						row.LegsThirdAnimationType = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("CdTime"))
					{
						row.CdTime = childNode.FirstChild.Value;
					}
					else if (childNode.Name.Equals("CdTimePara"))
					{
						row.CdTimePara = childNode.FirstChild.Value;
					}
				}
			}
			BattleSingletonInstance<WeaponInfoCache>.Instance.LoadWeaponData(name);
		}
		else
		{
			Debug.LogError("weapom mame error:" + name);
		}
		isLoadOver.Add(name, value: true);
	}
}
