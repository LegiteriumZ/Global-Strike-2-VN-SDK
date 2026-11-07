using System.Collections.Generic;
using C2TPro;

public class SplitBundleTable
{
	public class Row
	{
		public string CodeName;

		public ResType ResType;

		public string BundleName;
	}

	public enum ResType
	{
		Weapon,
		WeaponSkin,
		Player,
		PlayerSkin,
		UI
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
			row.CodeName = array[i][0];
			row.ResType = ((!string.IsNullOrEmpty(array[i][1])) ? ((ResType)int.Parse(array[i][1])) : ResType.Weapon);
			row.BundleName = array[i][2];
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

	public List<Row> FindAll_ResType(ResType find)
	{
		return rowList.FindAll((Row x) => x.ResType == find);
	}

	public Row Find_CodeNameAndType(string codename, ResType type)
	{
		return rowList.Find((Row x) => x.CodeName == codename && x.ResType == type);
	}
}
