using System;
using System.Collections.Generic;
using C2TPro;

public class MoveEntityTailTable
{
	public class Row
	{
		public string Name;

		public string AssetBundle;

		public string AssetPath;

		public int Width;

		public float TrailTime;

		public int RemainTime;

		public int ResIndex;

		public int DestinationFactor;

		public float FadeStart;
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
			row.Width = ((!string.IsNullOrEmpty(array[i][3])) ? Convert.ToInt32(array[i][3]) : 0);
			row.TrailTime = (string.IsNullOrEmpty(array[i][4]) ? 0f : Convert.ToSingle(array[i][4]));
			row.RemainTime = ((!string.IsNullOrEmpty(array[i][5])) ? Convert.ToInt32(array[i][5]) : 0);
			row.ResIndex = ((!string.IsNullOrEmpty(array[i][6])) ? Convert.ToInt32(array[i][6]) : 0);
			row.DestinationFactor = ((!string.IsNullOrEmpty(array[i][7])) ? Convert.ToInt32(array[i][7]) : 0);
			row.FadeStart = (string.IsNullOrEmpty(array[i][8]) ? 0f : Convert.ToSingle(array[i][8]));
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

	public Row Find_Width(int find)
	{
		return rowList.Find((Row x) => x.Width == find);
	}

	public List<Row> FindAll_Width(int find)
	{
		return rowList.FindAll((Row x) => x.Width == find);
	}

	public Row Find_TrailTime(float find)
	{
		return rowList.Find((Row x) => x.TrailTime == find);
	}

	public List<Row> FindAll_TrailTime(float find)
	{
		return rowList.FindAll((Row x) => x.TrailTime == find);
	}

	public Row Find_RemainTime(int find)
	{
		return rowList.Find((Row x) => x.RemainTime == find);
	}

	public List<Row> FindAll_RemainTime(int find)
	{
		return rowList.FindAll((Row x) => x.RemainTime == find);
	}

	public Row Find_ResIndex(int find)
	{
		return rowList.Find((Row x) => x.ResIndex == find);
	}

	public List<Row> FindAll_ResIndex(int find)
	{
		return rowList.FindAll((Row x) => x.ResIndex == find);
	}

	public Row Find_DestinationFactor(int find)
	{
		return rowList.Find((Row x) => x.DestinationFactor == find);
	}

	public List<Row> FindAll_DestinationFactor(int find)
	{
		return rowList.FindAll((Row x) => x.DestinationFactor == find);
	}

	public Row Find_FadeStart(float find)
	{
		return rowList.Find((Row x) => x.FadeStart == find);
	}

	public List<Row> FindAll_FadeStart(float find)
	{
		return rowList.FindAll((Row x) => x.FadeStart == find);
	}
}
