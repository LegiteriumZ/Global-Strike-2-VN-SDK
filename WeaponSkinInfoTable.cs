using System;
using System.Collections.Generic;
using C2TPro;

public class WeaponSkinInfoTable
{
	public class Row
	{
		public string Name;

		public bool HasBaseTexture;

		public bool HasSkinTexture;

		public bool HasViewModel;

		public bool HasViewAnim;

		public bool HasThirdModel;

		public bool HasSceneModel;

		public bool HasEffect;

		public bool HasEffectConfig;

		public string Weapon;

		public bool HasWeaponPath;

		public bool HasQuench;

		public string QuenchPara;

		public string Multiple;

		public string FirstLightDir;

		public string FollowLightDir;

		public bool HasKnifeEffect;

		public bool IsCarbon;

		public bool HasParticleLogic;

		public bool HasDyeingTexture;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	public bool IsLoaded()
	{
		return isLoaded;
	}

	public List<Row> GetRowList()
	{
		return rowList;
	}

	public void Load(string csv)
	{
		rowList.Clear();
		string[][] array = CsvParser.Parse(csv);
		for (int i = 1; i < array.Length; i++)
		{
			Row row = new Row();
			row.Name = array[i][0];
			row.HasBaseTexture = !string.IsNullOrEmpty(array[i][1]) && Convert.ToBoolean(array[i][1]);
			row.HasSkinTexture = !string.IsNullOrEmpty(array[i][2]) && Convert.ToBoolean(array[i][2]);
			row.HasViewModel = !string.IsNullOrEmpty(array[i][3]) && Convert.ToBoolean(array[i][3]);
			row.HasViewAnim = !string.IsNullOrEmpty(array[i][4]) && Convert.ToBoolean(array[i][4]);
			row.HasThirdModel = !string.IsNullOrEmpty(array[i][5]) && Convert.ToBoolean(array[i][5]);
			row.HasSceneModel = !string.IsNullOrEmpty(array[i][6]) && Convert.ToBoolean(array[i][6]);
			row.HasEffect = !string.IsNullOrEmpty(array[i][7]) && Convert.ToBoolean(array[i][7]);
			row.HasEffectConfig = !string.IsNullOrEmpty(array[i][8]) && Convert.ToBoolean(array[i][8]);
			row.Weapon = array[i][9];
			row.HasWeaponPath = !string.IsNullOrEmpty(array[i][10]) && Convert.ToBoolean(array[i][10]);
			row.HasQuench = !string.IsNullOrEmpty(array[i][11]) && Convert.ToBoolean(array[i][11]);
			row.QuenchPara = array[i][12];
			row.Multiple = array[i][13];
			row.FirstLightDir = array[i][14];
			row.FollowLightDir = array[i][15];
			row.HasKnifeEffect = !string.IsNullOrEmpty(array[i][16]) && Convert.ToBoolean(array[i][16]);
			row.IsCarbon = !string.IsNullOrEmpty(array[i][17]) && Convert.ToBoolean(array[i][17]);
			row.HasParticleLogic = !string.IsNullOrEmpty(array[i][18]) && Convert.ToBoolean(array[i][18]);
			row.HasDyeingTexture = !string.IsNullOrEmpty(array[i][18]) && Convert.ToBoolean(array[i][19]);
			rowList.Add(row);
		}
		isLoaded = true;
	}

	public int NumRows()
	{
		return rowList.Count;
	}

	public Row GetAt(int i)
	{
		if (rowList.Count <= i)
		{
			return null;
		}
		return rowList[i];
	}

	public Row Find_Name(string find)
	{
		return rowList.Find((Row x) => x.Name == find);
	}

	public List<Row> FindAll_Name(string find)
	{
		return rowList.FindAll((Row x) => x.Name == find);
	}

	public Row Find_HasBaseTexture(bool find)
	{
		return rowList.Find((Row x) => x.HasBaseTexture == find);
	}

	public List<Row> FindAll_HasBaseTexture(bool find)
	{
		return rowList.FindAll((Row x) => x.HasBaseTexture == find);
	}

	public Row Find_HasSkinTexture(bool find)
	{
		return rowList.Find((Row x) => x.HasSkinTexture == find);
	}

	public List<Row> FindAll_HasSkinTexture(bool find)
	{
		return rowList.FindAll((Row x) => x.HasSkinTexture == find);
	}

	public Row Find_HasViewModel(bool find)
	{
		return rowList.Find((Row x) => x.HasViewModel == find);
	}

	public List<Row> FindAll_HasViewModel(bool find)
	{
		return rowList.FindAll((Row x) => x.HasViewModel == find);
	}

	public Row Find_HasViewAnim(bool find)
	{
		return rowList.Find((Row x) => x.HasViewAnim == find);
	}

	public List<Row> FindAll_HasViewAnim(bool find)
	{
		return rowList.FindAll((Row x) => x.HasViewAnim == find);
	}

	public Row Find_HasThirdModel(bool find)
	{
		return rowList.Find((Row x) => x.HasThirdModel == find);
	}

	public List<Row> FindAll_HasThirdModel(bool find)
	{
		return rowList.FindAll((Row x) => x.HasThirdModel == find);
	}

	public Row Find_HasSceneModel(bool find)
	{
		return rowList.Find((Row x) => x.HasSceneModel == find);
	}

	public List<Row> FindAll_HasSceneModel(bool find)
	{
		return rowList.FindAll((Row x) => x.HasSceneModel == find);
	}

	public Row Find_HasEffect(bool find)
	{
		return rowList.Find((Row x) => x.HasEffect == find);
	}

	public List<Row> FindAll_HasEffect(bool find)
	{
		return rowList.FindAll((Row x) => x.HasEffect == find);
	}

	public Row Find_HasEffectConfig(bool find)
	{
		return rowList.Find((Row x) => x.HasEffectConfig == find);
	}

	public List<Row> FindAll_HasEffectConfig(bool find)
	{
		return rowList.FindAll((Row x) => x.HasEffectConfig == find);
	}

	public Row Find_Weapon(string find)
	{
		return rowList.Find((Row x) => x.Weapon == find);
	}

	public List<Row> FindAll_Weapon(string find)
	{
		return rowList.FindAll((Row x) => x.Weapon == find);
	}

	public Row Find_HasWeaponPath(bool find)
	{
		return rowList.Find((Row x) => x.HasWeaponPath == find);
	}

	public List<Row> FindAll_HasWeaponPath(bool find)
	{
		return rowList.FindAll((Row x) => x.HasWeaponPath == find);
	}

	public Row Find_HasQuench(bool find)
	{
		return rowList.Find((Row x) => x.HasQuench == find);
	}

	public List<Row> FindAll_HasQuench(bool find)
	{
		return rowList.FindAll((Row x) => x.HasQuench == find);
	}

	public Row Find_QuenchPara(string find)
	{
		return rowList.Find((Row x) => x.QuenchPara == find);
	}

	public List<Row> FindAll_QuenchPara(string find)
	{
		return rowList.FindAll((Row x) => x.QuenchPara == find);
	}

	public Row Find_Multiple(string find)
	{
		return rowList.Find((Row x) => x.Multiple == find);
	}

	public List<Row> FindAll_Multiple(string find)
	{
		return rowList.FindAll((Row x) => x.Multiple == find);
	}

	public Row Find_FirstLightDir(string find)
	{
		return rowList.Find((Row x) => x.FirstLightDir == find);
	}

	public List<Row> FindAll_FirstLightDir(string find)
	{
		return rowList.FindAll((Row x) => x.FirstLightDir == find);
	}

	public Row Find_FollowLightDir(string find)
	{
		return rowList.Find((Row x) => x.FollowLightDir == find);
	}

	public List<Row> FindAll_FollowLightDir(string find)
	{
		return rowList.FindAll((Row x) => x.FollowLightDir == find);
	}

	public Row Find_HasKnifeEffect(bool find)
	{
		return rowList.Find((Row x) => x.HasKnifeEffect == find);
	}

	public List<Row> FindAll_HasKnifeEffect(bool find)
	{
		return rowList.FindAll((Row x) => x.HasKnifeEffect == find);
	}

	public Row Find_IsCarbon(bool find)
	{
		return rowList.Find((Row x) => x.IsCarbon == find);
	}

	public List<Row> FindAll_IsCarbon(bool find)
	{
		return rowList.FindAll((Row x) => x.IsCarbon == find);
	}

	public Row Find_HasParticleLogic(bool find)
	{
		return rowList.Find((Row x) => x.HasParticleLogic == find);
	}

	public List<Row> FindAll_HasParticleLogic(bool find)
	{
		return rowList.FindAll((Row x) => x.HasParticleLogic == find);
	}
}
