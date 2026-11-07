using System;
using System.Collections;
using System.Reflection;
using System.Xml;
using Assets.Sources.Info.Weapon;
using SSJJAsset.AssetManager;
using SSJJBase.Logger;
using SSJJBase.Manager;
using UnityEngine;
using weapon.predicateSystem;

namespace Assets.Sources.CsvLoader;

public class WeaponInfoLoader
{
	private static WeaponInfoLoader _instance;

	public static WeaponInfoLoader Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new WeaponInfoLoader();
			}
			return _instance;
		}
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> xmlLoader = new AssetAsyncLoader<TextAsset>();
		yield return xmlLoader.LoadAsync("weapon/default", "Assets/Res/Assets/weapon/predicableConfig.xml");
		LoadWeaponPredicationConfig(xmlLoader.Result.text);
		AssetAsyncLoader<TextAsset> listloader = new AssetAsyncLoader<TextAsset>();
		yield return listloader.LoadAsync("tables", "SplitBundleList");
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "Weapon");
		WeaponTable weaponTable = new WeaponTable();
		weaponTable.Load(loader.Result.text);
		BattleSingletonInstance<WeaponInfoCache>.Instance.InitXml(xmlLoader.Result.text);
		BattleSingletonInstance<WeaponInfoCache>.Instance.InitSplitBundleXml((listloader.Result != null) ? listloader.Result.text : "");
		foreach (WeaponTable.Row row in weaponTable.GetRowList())
		{
			BattleSingletonInstance<WeaponInfoCache>.Instance.Init(row.Name, row);
		}
	}

	private void SetObjectValueFromXml(XmlNode node, object obj, FieldInfo[] fields)
	{
		for (int i = 0; i < node.ChildNodes.Count; i++)
		{
			string name = node.ChildNodes[i].Name;
			string innerText = node.ChildNodes[i].InnerText;
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					Type fieldType = fieldInfo.FieldType;
					if (fieldType.ToString().ToLower().Contains("int"))
					{
						fieldInfo.SetValue(obj, int.Parse(innerText));
					}
					else if (fieldType.ToString().ToLower().Contains("float") || fieldType.ToString().ToLower().Contains("single"))
					{
						fieldInfo.SetValue(obj, float.Parse(innerText));
					}
					else if (fieldType.ToString().ToLower().Contains("bool"))
					{
						fieldInfo.SetValue(obj, bool.Parse(innerText));
					}
					else
					{
						fieldInfo.SetValue(obj, innerText);
					}
				}
			}
		}
	}

	private void LoadWeaponPredicationConfig(string xml)
	{
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode documentElement = xmlDocument.DocumentElement;
			FieldInfo[] fields = typeof(PredicationConfig).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			for (int i = 0; i < documentElement.ChildNodes.Count; i++)
			{
				XmlNode node = documentElement.ChildNodes[i];
				PredicationConfig predicationConfig = new PredicationConfig();
				SetObjectValueFromXml(node, predicationConfig, fields);
				PredicationConfigFactory.Instance.Add(predicationConfig, predicationConfig.GetWeaponKey());
			}
		}
		catch (Exception ex)
		{
			this.LogErrorFormat("LoadWeaponPredicationConfig Error {0}", ex.ToString());
		}
	}
}
