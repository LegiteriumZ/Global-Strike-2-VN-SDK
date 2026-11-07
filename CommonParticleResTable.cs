using System;
using System.Collections.Generic;
using C2TPro;

public class CommonParticleResTable
{
	public class Row
	{
		public string Name;

		public string AssetBundle;

		public string AssetPath;

		public string Type;

		public int PitchTrim;

		public int YawTrim;
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
			row.AssetBundle = array[i][1];
			row.AssetPath = array[i][2];
			row.Type = array[i][3];
			row.PitchTrim = ((!string.IsNullOrEmpty(array[i][4])) ? Convert.ToInt32(array[i][4]) : 0);
			row.YawTrim = ((!string.IsNullOrEmpty(array[i][5])) ? Convert.ToInt32(array[i][5]) : 0);
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

	public Row Find_AssetBundle(string find)
	{
		return rowList.Find((Row x) => x.AssetBundle == find);
	}

	public List<Row> FindAll_AssetBundle(string find)
	{
		return rowList.FindAll((Row x) => x.AssetBundle == find);
	}

	public Row Find_AssetPath(string find)
	{
		return rowList.Find((Row x) => x.AssetPath == find);
	}

	public List<Row> FindAll_AssetPath(string find)
	{
		return rowList.FindAll((Row x) => x.AssetPath == find);
	}

	public Row Find_Type(string find)
	{
		return rowList.Find((Row x) => x.Type == find);
	}

	public List<Row> FindAll_Type(string find)
	{
		return rowList.FindAll((Row x) => x.Type == find);
	}

	public Row Find_PitchTrim(int find)
	{
		return rowList.Find((Row x) => x.PitchTrim == find);
	}

	public List<Row> FindAll_PitchTrim(int find)
	{
		return rowList.FindAll((Row x) => x.PitchTrim == find);
	}

	public Row Find_YawTrim(int find)
	{
		return rowList.Find((Row x) => x.YawTrim == find);
	}

	public List<Row> FindAll_YawTrim(int find)
	{
		return rowList.FindAll((Row x) => x.YawTrim == find);
	}
}
