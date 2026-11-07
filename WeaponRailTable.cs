using System;
using System.Collections.Generic;
using C2TPro;

public class WeaponRailTable
{
	public class Row
	{
		public string ResName;

		public int ResId;

		public string BundleName;

		public string AssetName;
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
			row.ResName = array[i][0];
			row.ResId = ((!string.IsNullOrEmpty(array[i][1])) ? Convert.ToInt32(array[i][1]) : 0);
			row.BundleName = array[i][2];
			row.AssetName = array[i][3];
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

	public Row Find_ResName(string find)
	{
		return rowList.Find((Row x) => x.ResName == find);
	}

	public List<Row> FindAll_ResName(string find)
	{
		return rowList.FindAll((Row x) => x.ResName == find);
	}

	public Row Find_ResId(int find)
	{
		return rowList.Find((Row x) => x.ResId == find);
	}

	public List<Row> FindAll_ResId(int find)
	{
		return rowList.FindAll((Row x) => x.ResId == find);
	}

	public Row Find_BundleName(string find)
	{
		return rowList.Find((Row x) => x.BundleName == find);
	}

	public List<Row> FindAll_BundleName(string find)
	{
		return rowList.FindAll((Row x) => x.BundleName == find);
	}

	public Row Find_AssetName(string find)
	{
		return rowList.Find((Row x) => x.AssetName == find);
	}

	public List<Row> FindAll_AssetName(string find)
	{
		return rowList.FindAll((Row x) => x.AssetName == find);
	}
}
