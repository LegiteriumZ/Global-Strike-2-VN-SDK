using System.Collections.Generic;
using Assets.Sources.Info.WeaponAnim;
using Assets.Sources.XmlAsset;
using SSJJAnim.Parser;
using SSJJAsset.Asset;
using SSJJUIEditor.ParticleEditor;
using UnityEngine;

namespace Assets.Sources.Info.Weapon;

public class WeaponSkinInfo
{
	public string Name;

	public bool HasBaseTexture;

	public bool HasSkinTexture;

	public bool HasViewModel;

	public bool HasViewAnim;

	public bool HasThirdModel;

	public bool HasSceneModel;

	public bool HasEffect;

	public bool HasKnifeEffect;

	public bool HasEffectConfig;

	public string Weapon;

	public bool HasWeaponPath;

	public List<string> WeaponList;

	public bool HasQuench;

	public string QuenchPara;

	public string Multiple;

	public string FirstLightDir;

	public string FollowLightDiffDir;

	public bool IsCarbon;

	public bool HasParticleLogic;

	public bool HasDyeingTexture;

	public List<int> QuenchParaList;

	public List<string> MultipleStrs;

	public Vector3 FirstLightAngle;

	public Vector3 FollowLightDiffAngle;

	private List<AssetInfo> _baseTextureAssetList;

	private List<AssetInfo> _skinTextureAssetList;

	private readonly AssetInfo _skinFlashTextureAsset;

	private readonly AssetInfo _skinQuenchTextureAsset;

	private readonly AssetInfo _skinQuenchAlphaTextureAsset;

	private readonly AssetInfo _viewModelAsset;

	private readonly AssetInfo _knifeFirstAttackAsset;

	private readonly string _assetBundleName;

	private readonly AssetInfo _knifeThirdAttackAsset;

	private readonly AssetInfo _viewAnimAsset;

	private readonly AssetInfo _handAnimAsset;

	private readonly AssetInfo _handAnimConfigAsset;

	private readonly AssetInfo _sceneModelAsset;

	private readonly AssetInfo _thirdModelAsset;

	public List<AssetInfo> BaseTextureAssetList
	{
		get
		{
			if (_baseTextureAssetList == null)
			{
				_baseTextureAssetList = new List<AssetInfo>();
			}
			return _baseTextureAssetList;
		}
	}

	public List<AssetInfo> SkinTextureAssetList
	{
		get
		{
			if (_skinTextureAssetList == null)
			{
				_skinTextureAssetList = new List<AssetInfo>();
			}
			return _skinTextureAssetList;
		}
	}

	public AssetInfo SkinFlashTextureAsset => _skinFlashTextureAsset;

	public AssetInfo SkinQuenchTextureAsset => _skinQuenchTextureAsset;

	public AssetInfo SkinQuenchAlphaTextureAsset => _skinQuenchAlphaTextureAsset;

	public string AssetBundleName => _assetBundleName;

	public WeaponSkinInfo(string name, string multiple, string quenchPara, string firstLight, string followLight)
	{
		Name = name;
		Multiple = multiple;
		QuenchPara = quenchPara;
		_assetBundleName = $"weaponskin/{Name}";
		_skinFlashTextureAsset = new AssetInfo("weaponskin/" + Name, string.Format("Assets/Res/Assets/weaponskin/{0}/{0}_flash.png", Name), typeof(Texture2D), optional: true);
		_skinQuenchTextureAsset = new AssetInfo("weaponskin/" + Name, string.Format("Assets/Res/Assets/weaponskin/{0}/{0}_quench.png", Name), typeof(Texture2D), optional: true);
		_skinQuenchAlphaTextureAsset = new AssetInfo("weaponskin/" + Name, string.Format("Assets/Res/Assets/weaponskin/{0}/{0}_alpha_quench.png", Name), typeof(Texture2D), optional: true);
		_viewModelAsset = new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/view/gun.prefab", typeof(GameObject), optional: true);
		_knifeFirstAttackAsset = new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/knifeeffect/frist.prefab", typeof(GameObject), optional: true);
		_knifeThirdAttackAsset = new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/knifeeffect/third.prefab", typeof(GameObject), optional: true);
		_sceneModelAsset = new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/scene/model.prefab", typeof(GameObject), optional: true);
		_thirdModelAsset = new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/third/model.prefab", typeof(GameObject), optional: true);
		_viewAnimAsset = new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/view/gun.anm.bytes", typeof(SJAnimationAsset), optional: true);
		_handAnimAsset = new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/view/hand_man.anm.bytes", typeof(SJAnimationAsset), optional: true);
		_handAnimConfigAsset = new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/view/hand.DAE.action.xml", typeof(WeaponAnimAsset), optional: true);
		string[] array = Multiple.Split('|');
		MultipleStrs = new List<string>();
		_baseTextureAssetList = new List<AssetInfo>();
		_skinTextureAssetList = new List<AssetInfo>();
		string[] array2 = array;
		foreach (string text in array2)
		{
			MultipleStrs.Add(text);
			if (string.IsNullOrEmpty(text))
			{
				AssetInfo item = new AssetInfo("weaponskin/" + Name, string.Format("Assets/Res/Assets/weaponskin/{0}/{0}{1}_base.png", Name, text), typeof(Texture2D), optional: true);
				_baseTextureAssetList.Add(item);
				AssetInfo item2 = new AssetInfo("weaponskin/" + Name, string.Format("Assets/Res/Assets/weaponskin/{0}/{0}{1}.png", Name, text), typeof(Texture2D), optional: true);
				_skinTextureAssetList.Add(item2);
			}
			else
			{
				AssetInfo item3 = new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{text}_base.png", typeof(Texture2D), optional: true);
				_baseTextureAssetList.Add(item3);
				AssetInfo item4 = new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{text}.png", typeof(Texture2D), optional: true);
				_skinTextureAssetList.Add(item4);
			}
		}
		QuenchParaList = new List<int>();
		if (!string.IsNullOrEmpty(QuenchPara))
		{
			array2 = QuenchPara.Split(',');
			foreach (string s in array2)
			{
				QuenchParaList.Add(int.Parse(s));
			}
		}
		if (!string.IsNullOrEmpty(firstLight))
		{
			string[] array3 = firstLight.Split(',');
			if (array3.Length == 3)
			{
				FirstLightAngle = new Vector3(float.Parse(array3[0]), float.Parse(array3[1]), float.Parse(array3[2]));
			}
		}
		if (!string.IsNullOrEmpty(followLight))
		{
			string[] array4 = followLight.Split(',');
			if (array4.Length == 3)
			{
				FollowLightDiffAngle = new Vector3(float.Parse(array4[0]), float.Parse(array4[1]), float.Parse(array4[2]));
			}
		}
	}

	public bool HasFlashTexture()
	{
		return IsCarbon;
	}

	public static List<string> GetWeaponList(string weapon)
	{
		List<string> list = new List<string>();
		if (!string.IsNullOrEmpty(weapon))
		{
			string[] array = weapon.Split(':');
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
		}
		return list;
	}

	private void SetWeaponName(ref string weaponName)
	{
		if (WeaponList == null && !string.IsNullOrEmpty(Weapon))
		{
			WeaponList = GetWeaponList(Weapon);
		}
		if (WeaponList != null && WeaponList.Count > 0 && !WeaponList.Contains(weaponName))
		{
			weaponName = WeaponList[0];
		}
	}

	public AssetInfo GetViewModelAsset(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/view/gun.prefab", typeof(GameObject), optional: true);
		}
		return _viewModelAsset;
	}

	public AssetInfo GetKnifeFirstAttackAsset(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/knifeeffect/frist.prefab", typeof(GameObject), optional: true);
		}
		return _knifeFirstAttackAsset;
	}

	public AssetInfo GetKnifeThirdAttackAsset(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/knifeeffect/third.prefab", typeof(GameObject), optional: true);
		}
		return _knifeThirdAttackAsset;
	}

	public AssetInfo GetViewAnimAsset(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/view/gun.anm.bytes", typeof(SJAnimationAsset), optional: true);
		}
		return _viewAnimAsset;
	}

	public AssetInfo GetHandAnimAsset(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/view/hand_man.anm.bytes", typeof(SJAnimationAsset), optional: true);
		}
		return _handAnimAsset;
	}

	public AssetInfo GetHandAnimConfigAsset(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/view/hand.DAE.action.xml", typeof(WeaponAnimAsset), optional: true);
		}
		return _handAnimConfigAsset;
	}

	public AssetInfo GetSceneModelAsset(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/scene/model.prefab", typeof(GameObject), optional: true);
		}
		return _sceneModelAsset;
	}

	public AssetInfo GetThirdModelAsset(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/third/model.prefab", typeof(GameObject), optional: true);
		}
		return _thirdModelAsset;
	}

	public AssetInfo GetParticleEffectAssetInfo(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/effect/particleEffectConfig.xml", typeof(ParticleXmlAsset), optional: true);
		}
		return default(AssetInfo);
	}

	public AssetInfo GetParticleLogicAssetInfo(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/effect/particle_logic.xml", typeof(ParticleEditorLogicAsset), optional: true);
		}
		return default(AssetInfo);
	}

	public AssetInfo GetEffectConfigAssetInfo(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return new AssetInfo("weaponskin/" + Name, $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/effect/effectConfig.xml", typeof(EffectXmlAsset), optional: true);
		}
		return default(AssetInfo);
	}

	public string GetEffectPath(string weaponName)
	{
		SetWeaponName(ref weaponName);
		if (HasWeaponPath)
		{
			return $"Assets/Res/Assets/weaponskin/{Name}/{weaponName}/effect";
		}
		return $"Assets/Res/Assets/weaponskin/{Name}/effect";
	}

	public List<AssetInfo> GetUnloadAssetInfos(string weaponName)
	{
		List<AssetInfo> list = new List<AssetInfo>();
		list.Add(GetSceneModelAsset(weaponName));
		list.Add(GetViewModelAsset(weaponName));
		list.Add(GetThirdModelAsset(weaponName));
		list.Add(GetHandAnimConfigAsset(weaponName));
		list.Add(GetHandAnimAsset(weaponName));
		list.Add(GetViewAnimAsset(weaponName));
		list.Add(GetKnifeFirstAttackAsset(weaponName));
		list.Add(GetKnifeThirdAttackAsset(weaponName));
		for (int i = 0; i < MultipleStrs.Count; i++)
		{
			list.Add(SkinTextureAssetList[i]);
			list.Add(BaseTextureAssetList[i]);
		}
		list.Add(SkinQuenchTextureAsset);
		list.Add(SkinQuenchAlphaTextureAsset);
		list.Add(SkinFlashTextureAsset);
		return list;
	}
}
