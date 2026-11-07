using System;
using System.Collections.Generic;
using C2TPro;

public class ExplosionTable
{
	public class Row
	{
		public string EventIdPath;

		public int EventId;

		public int ResTypeId;

		public string AssetBundle;

		public string AssetPath;

		public int EffectTime;

		public string Ps;
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
			row.EventIdPath = array[i][0];
			row.EventId = ((!string.IsNullOrEmpty(array[i][1])) ? Convert.ToInt32(array[i][1]) : 0);
			row.ResTypeId = ((!string.IsNullOrEmpty(array[i][2])) ? Convert.ToInt32(array[i][2]) : 0);
			row.AssetBundle = array[i][3];
			row.AssetPath = array[i][4];
			row.EffectTime = ((!string.IsNullOrEmpty(array[i][5])) ? Convert.ToInt32(array[i][5]) : 0);
			row.Ps = array[i][6];
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

	public Row Find_EventIdPath(string find)
	{
		return rowList.Find((Row x) => x.EventIdPath == find);
	}

	public List<Row> FindAll_EventIdPath(string find)
	{
		return rowList.FindAll((Row x) => x.EventIdPath == find);
	}

	public Row Find_EventId(int find)
	{
		return rowList.Find((Row x) => x.EventId == find);
	}

	public List<Row> FindAll_EventId(int find)
	{
		return rowList.FindAll((Row x) => x.EventId == find);
	}

	public Row Find_ResTypeId(int find)
	{
		return rowList.Find((Row x) => x.ResTypeId == find);
	}

	public List<Row> FindAll_ResTypeId(int find)
	{
		return rowList.FindAll((Row x) => x.ResTypeId == find);
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

	public Row Find_EffectTime(int find)
	{
		return rowList.Find((Row x) => x.EffectTime == find);
	}

	public List<Row> FindAll_EffectTime(int find)
	{
		return rowList.FindAll((Row x) => x.EffectTime == find);
	}

	public Row Find_Ps(string find)
	{
		return rowList.Find((Row x) => x.Ps == find);
	}

	public List<Row> FindAll_Ps(string find)
	{
		return rowList.FindAll((Row x) => x.Ps == find);
	}
}
