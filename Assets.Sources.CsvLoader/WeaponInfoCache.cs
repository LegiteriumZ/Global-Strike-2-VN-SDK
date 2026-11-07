using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Info.Weapon.Logic;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using SSJJAnim.Weapon;
using SSJJBase.Logger;
using SSJJBase.Manager;
using Sharpen;

namespace Assets.Sources.CsvLoader;

public class WeaponInfoCache : BattleSingletonInstance<WeaponInfoCache>
{
	private readonly string _weaponInfoNamespace = "Assets.Sources.Info.Weapon.WeaponInfo.Info";

	private static WeaponInfoLoader _instance;

	public Dictionary<string, WeaponTable.Row> RowCaches = new Dictionary<string, WeaponTable.Row>();

	public string PredicationXml;

	public SplitBundleTable splitTable;

	private bool _hasLoadAll;

	public void InitXml(string xml)
	{
		PredicationXml = xml;
	}

	public void InitSplitBundleXml(string xml)
	{
		if (!string.IsNullOrEmpty(xml))
		{
			splitTable = new SplitBundleTable();
			splitTable.Load(xml);
		}
	}

	public void Init(string weaponName, WeaponTable.Row row)
	{
		RowCaches[weaponName] = row;
	}

	public void LoadAllWeapon()
	{
		if (_hasLoadAll)
		{
			return;
		}
		_hasLoadAll = true;
		foreach (KeyValuePair<string, WeaponTable.Row> rowCache in RowCaches)
		{
			LoadWeaponData(rowCache.Value, PredicationXml);
		}
	}

	public IWeaponInfo LoadWeaponData(string weaponName)
	{
		IWeaponInfo result = null;
		if (RowCaches.TryGetValue(weaponName, out var value))
		{
			result = LoadWeaponData(value, PredicationXml);
		}
		return result;
	}

	private IWeaponInfo LoadWeaponData(WeaponTable.Row rowData, string xml)
	{
		IWeaponInfo weaponInfo = null;
		try
		{
			string infoType = rowData.InfoType;
			string text = $"{_weaponInfoNamespace}.{infoType}WeaponInfo";
			Type type = Type.GetType(text);
			if (type == null)
			{
				throw new ArgumentNullException($"{rowData}.{text}");
			}
			string name = rowData.Name;
			bool flag = false;
			if (PredicationConfigFactory.Instance.GetPredicationConfig(name) != null)
			{
				flag = true;
			}
			weaponInfo = Activator.CreateInstance(type, rowData.Name, rowData.AttackType, rowData.SpecialAttackType, flag) as IWeaponInfo;
			weaponInfo.SplitAssetBundleName = weaponInfo.AssetBundleName + "$2";
			weaponInfo.SharedPredication = flag;
			FieldInfo[] fields = rowData.GetType().GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				if (string.IsNullOrEmpty(fieldInfo.Name) || fieldInfo.Name.Equals("Name") || fieldInfo.Name.Equals("AttackType") || fieldInfo.Name.Equals("UiModels") || fieldInfo.Name.Equals("SpecialAttackType"))
				{
					continue;
				}
				PropertyInfo property = type.GetProperty(fieldInfo.Name);
				if (!(property != null))
				{
					continue;
				}
				if (property.CanWrite && property.PropertyType == fieldInfo.FieldType)
				{
					try
					{
						property.SetValue(weaponInfo, fieldInfo.GetValue(rowData), null);
					}
					catch (Exception)
					{
						this.LogErrorFormat("Can Write Property {0} of Weapon {1}", property.Name, rowData.Name);
						throw;
					}
				}
				else
				{
					this.LogErrorFormat("Can Write Property {0} of Weapon {1}", fieldInfo.Name, rowData.Name);
				}
			}
			LoadWeaponInfoDataFromXml(weaponInfo, xml);
			weaponInfo.ThirdAnimations = LoadThirdAnimationTypeList(rowData.ThirdAnimationType);
			LoadSpecialThirdAnimationTypeDict(weaponInfo.SpecialThirdAnimationTypeDict, rowData.SpecialThirdAnimationType);
			loadLegsThirdAnimationType(weaponInfo, rowData.LegsThirdAnimationType);
			if (!weaponInfo.SharedPredication)
			{
				ParseLogicParam(type, weaponInfo, "MaxSpeedLogic", typeof(IMaxSpeedLogic), "Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic", "MaxSpeedLogic", rowData.MaxSpeedType, rowData.MaxSpeedParam);
				ParseLogicParam(type, weaponInfo, "KickbackLogic", typeof(IKickbackLogic), "Assets.Sources.Info.Weapon.Logic.KickbackLogic", "KickbackLogic", rowData.KickbackType, rowData.KickbackParam);
				ParseLogicParam(type, weaponInfo, "SpreadLogic", typeof(ISpreadLogic), "Assets.Sources.Info.Weapon.Logic.SpreadLogic", "SpreadLogic", rowData.SpreadType, rowData.SpreadParam);
				ParseLogicParam(type, weaponInfo, "ShotDistanceLogic", typeof(IShotDistanceLogic), "Assets.Sources.Info.Weapon.Logic.ShotDistanceLogic", "ShotDistanceLogic", rowData.ShotDistType, rowData.ShotDistParam);
				ParseLogicParam(type, weaponInfo, "AccuracyLogic", typeof(IAccuracyLogic), "Assets.Sources.Info.Weapon.Logic.AccuracyLogic", "AccuracyLogic", rowData.AccuracyType, rowData.AccuracyParam);
			}
			ParseLogicParam(type, weaponInfo, "RailLogic", typeof(IRailLogic), "Assets.Sources.Info.Weapon.Logic.RailLogic", "RailLogic", rowData.RailType, rowData.RailParam);
			ParseLogicParam(type, weaponInfo, "CdTimeLogic", typeof(ICdTimeLogic), "Assets.Sources.Info.Weapon.Logic.CdTimeLogic", "CdTimeLogic", rowData.CdTime, rowData.CdTimePara);
			ParseLogicParam(type, weaponInfo, "HoleLogic", typeof(IHoleLogic), "Assets.Sources.Info.Weapon.Logic.HoleLogic", "HoleLogic", rowData.HoleType, rowData.HoleParam);
			ParseLogicParam(type, weaponInfo, "ChangeWeaponLogic", typeof(IChangeWeapon), "Assets.Sources.Info.Weapon.Logic.ChangeWeapon", "ChangeWeapon", rowData.ChangeWeapon);
			ParseLogicParam(type, weaponInfo, "EventLogic", typeof(IEventLogic), "Assets.Sources.Info.Weapon.Logic.EventLogic", "EventLogic", rowData.EventType);
			weaponInfo.AttachFactory = new WeaponAttachFactory().WithAttach(rowData.Attach);
			if (!string.IsNullOrEmpty(rowData.UiModels))
			{
				weaponInfo.UiModels = rowData.UiModels.Split(',');
			}
			if (weaponInfo is RifleScopeWeaponInfo)
			{
				(weaponInfo as RifleScopeWeaponInfo).Parse(rowData);
			}
			WeaponInfoFactory.Instance.Add(weaponInfo);
			weaponInfo.ViewWeaponEffectLogics = CreateViewWeaponEffectModel(rowData.ViewEffectModels.Split(','));
			weaponInfo.ThirdWeaponEffectLogics = CreatThirdWeaponEffectModel(rowData.ThirdEffectModels.Split(','));
		}
		catch (Exception arg)
		{
			this.LogErrorFormat("weapon: {4}, error load weapon file {0} {1} {2}", arg, rowData.Name, rowData.InfoType, rowData.AttackType, rowData.Name);
		}
		return weaponInfo;
	}

	private void LoadWeaponInfoDataFromXml(object rowData, string xml)
	{
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode documentElement = xmlDocument.DocumentElement;
			PropertyInfo[] properties = rowData.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			for (int i = 0; i < documentElement.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = documentElement.ChildNodes[i];
				bool flag = false;
				for (int j = 0; j < xmlNode.ChildNodes.Count; j++)
				{
					if (xmlNode.ChildNodes[j].Name.Equals("weaponKey") && xmlNode.ChildNodes[j].InnerText.Equals(((IWeaponInfo)rowData).Name, StringComparison.CurrentCultureIgnoreCase))
					{
						flag = true;
					}
				}
				if (flag)
				{
					SetObjectValueFromXml(xmlNode, rowData, properties);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			this.LogErrorFormat("Weapon {0} LoadWeaponInfoDataFromXml Error {1}", ((IWeaponInfo)rowData).Name, ex.ToString());
		}
	}

	private void SetObjectValueFromXml(XmlNode node, object obj, PropertyInfo[] properties)
	{
		for (int i = 0; i < node.ChildNodes.Count; i++)
		{
			string name = node.ChildNodes[i].Name;
			string innerText = node.ChildNodes[i].InnerText;
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!propertyInfo.Name.Equals("AttackType") && propertyInfo.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					Type propertyType = propertyInfo.PropertyType;
					if (propertyType.ToString().ToLower().Contains("int"))
					{
						propertyInfo.SetValue(obj, int.Parse(innerText), null);
					}
					else if (propertyType.ToString().ToLower().Contains("float") || propertyType.ToString().ToLower().Contains("single"))
					{
						propertyInfo.SetValue(obj, float.Parse(innerText), null);
					}
					else if (propertyType.ToString().ToLower().Contains("bool"))
					{
						propertyInfo.SetValue(obj, bool.Parse(innerText), null);
					}
					else
					{
						propertyInfo.SetValue(obj, innerText, null);
					}
				}
			}
		}
	}

	private void loadLegsThirdAnimationType(IWeaponInfo weaponInfo, string rowDataLegsThirdAnimationType)
	{
		weaponInfo.LegsThirdAnimationType = (string.IsNullOrEmpty(rowDataLegsThirdAnimationType) ? null : rowDataLegsThirdAnimationType);
	}

	private List<IViewWeaponEffectLogic> CreateViewWeaponEffectModel(string[] modelNames)
	{
		List<IViewWeaponEffectLogic> list = new AList<IViewWeaponEffectLogic>();
		if (modelNames != null)
		{
			foreach (string text in modelNames)
			{
				if (text.Length != 0)
				{
					Type type = Type.GetType(string.Format("{0}.{1}", "Assets.Sources.Info.Weapon.Logic.ViewEffectLogic", text));
					if (type != null)
					{
						list.Add((IViewWeaponEffectLogic)Activator.CreateInstance(type));
					}
				}
			}
		}
		return list;
	}

	private List<IThirdWeaponEffectLogic> CreatThirdWeaponEffectModel(string[] modelNames)
	{
		List<IThirdWeaponEffectLogic> list = new AList<IThirdWeaponEffectLogic>();
		if (modelNames != null)
		{
			foreach (string text in modelNames)
			{
				if (text.Length != 0)
				{
					Type type = Type.GetType(string.Format("{0}.{1}", "Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic", text));
					if (type != null)
					{
						list.Add((IThirdWeaponEffectLogic)Activator.CreateInstance(type));
					}
				}
			}
		}
		return list;
	}

	private List<string> LoadThirdAnimationTypeList(string thirdAnimationType)
	{
		List<string> list = new List<string>();
		string[] array = thirdAnimationType.Split('|');
		foreach (string item in array)
		{
			list.Add(item);
		}
		return list;
	}

	private void LoadSpecialThirdAnimationTypeDict(Dictionary<int, string> dict, string specialThirdAnimationTypeDict)
	{
		string[] array = specialThirdAnimationTypeDict.Split(",");
		foreach (string str in array)
		{
			int key = int.Parse(str.Split(":")[0]);
			string value = str.Split(":")[1];
			dict[key] = value;
		}
	}

	private void ParseLogicParam(Type weaponInfoType, object weaponInfo, string propertyName, Type propertyType, string _namespace, string classSuffix, string type)
	{
		if (string.IsNullOrEmpty(type))
		{
			return;
		}
		PropertyInfo property = weaponInfoType.GetProperty(propertyName);
		if (!(property != null) || !property.CanWrite || !(property.PropertyType == propertyType))
		{
			return;
		}
		string text = $"{_namespace}.{type}{classSuffix}";
		Type type2 = Type.GetType(text);
		if (type2 == null)
		{
			this.LogErrorFormat("not found class :{0}", text);
			return;
		}
		object value = Activator.CreateInstance(type2);
		try
		{
			property.SetValue(weaponInfo, value, null);
		}
		catch (Exception)
		{
			this.LogErrorFormat("Cant propertyName {0} ", type);
		}
	}

	private void ParseLogicParam(Type weaponInfoType, object weaponInfo, string propertyName, Type propertyType, string _namespace, string classSuffix, string type, string param)
	{
		if (string.IsNullOrEmpty(type))
		{
			return;
		}
		PropertyInfo property = weaponInfoType.GetProperty(propertyName);
		if (!(property != null) || !property.CanWrite || !(property.PropertyType == propertyType))
		{
			return;
		}
		string text = $"{_namespace}.{type}{classSuffix}";
		Type type2 = Type.GetType(text);
		if (type2 == null)
		{
			this.LogErrorFormat("not found class :{0}", text);
			return;
		}
		object obj = Activator.CreateInstance(type2);
		if (obj is IParamParse)
		{
			(obj as IParamParse).Parse(param);
		}
		try
		{
			property.SetValue(weaponInfo, obj, null);
		}
		catch (Exception ex)
		{
			this.LogErrorFormat("Can propertyName {0}  {1} {2}", type, param, ex.ToString());
		}
	}

	public override void Clear()
	{
		RowCaches.Clear();
	}
}
