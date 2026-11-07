using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant.Weapon;
using SSJJAnim.AnimData;
using SSJJAnim.AnimState;
using SSJJAnim.CareerAnim;
using SSJJAsset.AssetLoader.Xml;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using share.constant;

namespace Assets.Sources.Info.CareerAnim;

public class DefaultCareerAnimInfo : AbstractXmlAsset, ICareerAnimInfo
{
	public AnimationArray LegsAnimationArray;

	public AnimationArray TorseAnimationArray;

	public List<int> TorsoWrapAnimations = new List<int>();

	public List<int> LegWrapAnimations = new List<int>();

	public Dictionary<string, AnimationWarpsData> AnimationWarps;

	public Hashtable TorsoAnimationHashtable;

	public Hashtable LegsAnimationHashtable;

	private static LoggerAdapter _logger = new LoggerAdapter(typeof(DefaultCareerAnimInfo));

	public bool HasLegWrapAnimationData(int stateid)
	{
		if (AnimationWarps != null && LegWrapAnimations != null)
		{
			return LegWrapAnimations.Contains(stateid);
		}
		return false;
	}

	public bool HasTorsoWrapAnimationData(int stateid)
	{
		if (AnimationWarps != null && TorseAnimationArray != null)
		{
			return TorsoWrapAnimations.Contains(stateid);
		}
		return false;
	}

	public AnimationWarpsData GetWrapAnimation(string weaponName, int animId)
	{
		if (!AnimationWarps.ContainsKey(weaponName))
		{
			return null;
		}
		return AnimationWarps[weaponName];
	}

	public int GetLegsAnimDuration(IEntitsWeaponInfo weaponInfo, int animId)
	{
		return GetPlayerLegsAnimation(weaponInfo, animId)?.TotalTime ?? 0;
	}

	public AnimationDesc GetPlayerLegsAnimation(IEntitsWeaponInfo weaponInfo, int animId)
	{
		if (LegsAnimationArray != null)
		{
			AnimationDesc animDesc = LegsAnimationArray.GetAnimDesc(animId);
			if (animDesc != null)
			{
				return animDesc;
			}
		}
		string key = WeaponConstant.GetWeaponAnimationWeaponName(weaponInfo.AnimationWeaponName);
		if (AnimationConstantUtility.IsBodyDriveWeapon(weaponInfo.LegsThirdAnimationType, animId))
		{
			key = weaponInfo.LegsThirdAnimationType;
		}
		AnimationArray animationArray = ((LegsAnimationHashtable != null) ? (LegsAnimationHashtable[key] as AnimationArray) : null);
		if (animationArray == null && LegsAnimationHashtable != null)
		{
			animationArray = LegsAnimationHashtable["common"] as AnimationArray;
		}
		return animationArray?.GetAnimDesc(animId);
	}

	public int GetTorsoAnimDuration(IEntitsWeaponInfo weaponInfo, int animId)
	{
		return GetPlayerTorsoAnimation(weaponInfo, animId)?.TotalTime ?? 0;
	}

	public AnimationDesc GetPlayerTorsoAnimation(IEntitsWeaponInfo weaponInfo, int animId)
	{
		if (TorseAnimationArray != null)
		{
			AnimationDesc animDesc = TorseAnimationArray.GetAnimDesc(animId);
			if (animDesc != null)
			{
				return animDesc;
			}
		}
		string weaponAnimationWeaponName = WeaponConstant.GetWeaponAnimationWeaponName(weaponInfo.AnimationWeaponName);
		return ((TorsoAnimationHashtable != null) ? (TorsoAnimationHashtable[weaponAnimationWeaponName] as AnimationArray) : null)?.GetAnimDesc(animId);
	}

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		LegsAnimationArray = new AnimationArray();
		TorseAnimationArray = new AnimationArray();
		TorsoAnimationHashtable = new Hashtable();
		LegsAnimationHashtable = new Hashtable();
		ReadXmlActionData(text, LegsAnimationArray, TorseAnimationArray, TorsoAnimationHashtable, LegsAnimationHashtable, ref AnimationWarps, LegWrapAnimations, TorsoWrapAnimations);
	}

	private static void ReadXmlActionData(string data, AnimationArray legsAnimationArray, AnimationArray torseAnimationArray, Hashtable torsoAnimationHashtable, Hashtable legsAnimationHashtable, ref Dictionary<string, AnimationWarpsData> animationWrap, List<int> wrapLegAnimations, List<int> wrapTorsoAnimations)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(data);
		foreach (XmlElement childNode in xmlDocument.SelectSingleNode("actions").ChildNodes)
		{
			if (childNode.Name == "legs_action")
			{
				AnimationDesc animationDesc = new AnimationDesc(int.Parse(childNode.GetAttribute("end")) - int.Parse(childNode.GetAttribute("start")) + 1, AnimationDataMapper.MappedBoolString(childNode.GetAttribute("loop")), AnimationDataMapper.MappedBoolString(childNode.GetAttribute("reverse")));
				if (childNode.HasAttribute("torsoNoMask"))
				{
					string[] array = childNode.GetAttribute("torsoNoMask").Split('|');
					foreach (string animId in array)
					{
						animationDesc.TorsoNoMaskList.Add(AnimationConstantUtil.GetAnimation(animId));
					}
				}
				legsAnimationArray.AddAnim(AnimationConstantUtil.GetAnimation(childNode.GetAttribute("name")), animationDesc);
				animationDesc.SetAnimationPosition(AnimationDataMapper.MappedBoolString(childNode.GetAttribute("animPosition")));
			}
			else if (childNode.Name == "torso_action")
			{
				torseAnimationArray.AddAnim(AnimationConstantUtil.GetAnimation(childNode.GetAttribute("name")), new AnimationDesc(int.Parse(childNode.GetAttribute("end")) - int.Parse(childNode.GetAttribute("start")) + 1, AnimationDataMapper.MappedBoolString(childNode.GetAttribute("loop")), AnimationDataMapper.MappedBoolString(childNode.GetAttribute("reverse"))));
			}
			else if (childNode.Name == "weapon_torso_actions")
			{
				foreach (XmlElement childNode2 in childNode.ChildNodes)
				{
					string attribute = childNode2.GetAttribute("name");
					AnimationArray animationArray = new AnimationArray();
					foreach (XmlElement childNode3 in childNode2.ChildNodes)
					{
						AnimationDesc animationDesc2 = new AnimationDesc(int.Parse(childNode3.GetAttribute("end")) - int.Parse(childNode3.GetAttribute("start")) + 1, AnimationDataMapper.MappedBoolString(childNode3.GetAttribute("loop")), AnimationDataMapper.MappedBoolString(childNode3.GetAttribute("reverse")));
						animationDesc2.SetAnimationPosition(AnimationDataMapper.MappedBoolString(childNode3.GetAttribute("animPosition")));
						if (childNode3.HasAttribute("torsoNoMask"))
						{
							string[] array = childNode3.GetAttribute("torsoNoMask").Split('|');
							foreach (string animId2 in array)
							{
								animationDesc2.TorsoNoMaskList.Add(AnimationConstantUtil.GetAnimation(animId2));
							}
						}
						animationArray.AddAnim(AnimationConstantUtil.GetAnimation(childNode3.GetAttribute("name")), animationDesc2);
					}
					torsoAnimationHashtable.Add(attribute, animationArray);
				}
			}
			else if (childNode.Name == "weapon_legs_actions")
			{
				foreach (XmlElement childNode4 in childNode.ChildNodes)
				{
					string attribute2 = childNode4.GetAttribute("name");
					AnimationArray animationArray2 = new AnimationArray();
					foreach (XmlElement childNode5 in childNode4.ChildNodes)
					{
						AnimationDesc animationDesc3 = new AnimationDesc(int.Parse(childNode5.GetAttribute("end")) - int.Parse(childNode5.GetAttribute("start")) + 1, AnimationDataMapper.MappedBoolString(childNode5.GetAttribute("loop")), AnimationDataMapper.MappedBoolString(childNode5.GetAttribute("reverse")));
						animationDesc3.SetAnimationPosition(AnimationDataMapper.MappedBoolString(childNode5.GetAttribute("animPosition")));
						if (childNode5.HasAttribute("torsoNoMask"))
						{
							string[] array = childNode5.GetAttribute("torsoNoMask").Split('|');
							foreach (string animId3 in array)
							{
								animationDesc3.TorsoNoMaskList.Add(AnimationConstantUtil.GetAnimation(animId3));
							}
						}
						animationArray2.AddAnim(AnimationConstantUtil.GetAnimation(childNode5.GetAttribute("name")), animationDesc3);
					}
					legsAnimationHashtable.Add(attribute2, animationArray2);
				}
			}
			else if (childNode.Name == "weapon_body_actions")
			{
				foreach (XmlElement childNode6 in childNode.ChildNodes)
				{
					string attribute3 = childNode6.GetAttribute("name");
					AnimationArray animationArray3 = new AnimationArray();
					foreach (XmlElement childNode7 in childNode6.ChildNodes)
					{
						AnimationDesc animationDesc4 = new AnimationDesc(int.Parse(childNode7.GetAttribute("end")) - int.Parse(childNode7.GetAttribute("start")) + 1, AnimationDataMapper.MappedBoolString(childNode7.GetAttribute("loop")), AnimationDataMapper.MappedBoolString(childNode7.GetAttribute("reverse")));
						animationDesc4.SetAnimationPosition(AnimationDataMapper.MappedBoolString(childNode7.GetAttribute("animPosition")));
						animationArray3.AddAnim(AnimationConstantUtil.GetAnimation(childNode7.GetAttribute("name")), animationDesc4);
					}
					legsAnimationHashtable.Add(attribute3, animationArray3);
				}
			}
			else
			{
				if (!(childNode.Name == "animWarps"))
				{
					continue;
				}
				if (animationWrap == null)
				{
					animationWrap = new Dictionary<string, AnimationWarpsData>();
				}
				string attribute4 = childNode.GetAttribute("weapon");
				AnimationWarpsData animationWarpsData = new AnimationWarpsData();
				animationWrap.Add(attribute4, animationWarpsData);
				_logger.InfoFormat("WrapData weaponName : {0}", attribute4);
				animationWarpsData.LegUnits = new List<LegAnimationWrapUnit>();
				animationWarpsData.TorsoUnits = new List<TorsoAnimationWrapUnit>();
				foreach (XmlElement childNode8 in childNode.ChildNodes)
				{
					if (childNode8.GetAttribute("type").Equals("legs"))
					{
						foreach (XmlElement item in childNode8)
						{
							LegAnimationWrapUnit legAnimationWrapUnit = new LegAnimationWrapUnit();
							animationWarpsData.LegUnits.Add(legAnimationWrapUnit);
							legAnimationWrapUnit.AnimName = item.Read("name");
							if (item.HasAttribute("clipName"))
							{
								legAnimationWrapUnit.ClipName = item.Read("clipName") + "_" + attribute4;
							}
							string[] array = item.GetAttribute("animList").Split('|');
							foreach (string text in array)
							{
								legAnimationWrapUnit.AnimationStrList.Add(text);
								legAnimationWrapUnit.AnimationIntList.Add(AnimationConstantUtil.GetAnimation(text));
								wrapLegAnimations.Add(AnimationConstantUtil.GetAnimation(text));
							}
							if (item.HasAttribute("loop"))
							{
								legAnimationWrapUnit.IsLoop = bool.Parse(item.GetAttribute("loop"));
							}
							legAnimationWrapUnit.Para.ParName1 = item.Read("parName1");
							legAnimationWrapUnit.Para.RunSpeed = item.Read("speedPar");
							legAnimationWrapUnit.Para.SelfSpeed = item.Read("selfSpeed", 0f);
							foreach (XmlElement item2 in item)
							{
								WrapTransition wrapTransition = new WrapTransition();
								wrapTransition.PosX = item2.Read("posX", 0f);
								wrapTransition.PosY = item2.Read("posY", 0f);
								wrapTransition.ParName1 = item2.Read("parName1");
								wrapTransition.clipName = item2.Read("clipName") + "_" + attribute4;
								legAnimationWrapUnit.Transitions.Add(wrapTransition);
								foreach (XmlElement item3 in item2)
								{
									SubWrapTransition subWrapTransition = new SubWrapTransition();
									wrapTransition.SubTrans.Add(subWrapTransition);
									subWrapTransition.PosX = item3.Read("posX", 0f);
									subWrapTransition.PosY = item3.Read("posY", 0f);
									subWrapTransition.Index = item3.Read("index", 0);
									foreach (XmlElement item4 in item3)
									{
										item4.Read("clipName");
										string text2 = item4.Read("aliasWeapon");
										if (!string.IsNullOrEmpty(text2))
										{
											subWrapTransition.ClipName = item4.Read("clipName") + "_" + text2;
										}
										else
										{
											subWrapTransition.ClipName = item4.Read("clipName") + "_" + attribute4;
										}
									}
								}
							}
						}
						continue;
					}
					foreach (XmlElement item5 in childNode8)
					{
						TorsoAnimationWrapUnit torsoAnimationWrapUnit = new TorsoAnimationWrapUnit();
						animationWarpsData.TorsoUnits.Add(torsoAnimationWrapUnit);
						torsoAnimationWrapUnit.AnimName = item5.GetAttribute("name");
						if (item5.HasAttribute("clipName"))
						{
							torsoAnimationWrapUnit.ClipName = item5.Read("clipName") + "_" + attribute4;
						}
						string[] array = item5.GetAttribute("animList").Split('|');
						foreach (string text3 in array)
						{
							torsoAnimationWrapUnit.AnimationStrList.Add(text3);
							torsoAnimationWrapUnit.AnimationIntList.Add(AnimationConstantUtil.GetAnimation(text3));
							wrapTorsoAnimations.Add(AnimationConstantUtil.GetAnimation(text3));
						}
						if (item5.HasAttribute("loop"))
						{
							torsoAnimationWrapUnit.IsLoop = bool.Parse(item5.GetAttribute("loop"));
						}
						torsoAnimationWrapUnit.Para.ParName1 = item5.Read("parName1");
						foreach (XmlElement item6 in item5)
						{
							SubWrapTransition subWrapTransition2 = new SubWrapTransition();
							torsoAnimationWrapUnit.SubTrans.Add(subWrapTransition2);
							string text4 = item6.Read("aliasWeapon");
							if (!string.IsNullOrEmpty(text4))
							{
								subWrapTransition2.ClipName = item6.Read("clipName") + "_" + text4;
							}
							else
							{
								subWrapTransition2.ClipName = item6.Read("clipName") + "_" + attribute4;
							}
							subWrapTransition2.PosX = item6.Read("posX", 0f);
							subWrapTransition2.PosY = item6.Read("posY", 0f);
							subWrapTransition2.Index = item6.Read("index", 0);
							subWrapTransition2.Type = item6.Read("type", 0);
						}
					}
				}
			}
		}
	}
}
