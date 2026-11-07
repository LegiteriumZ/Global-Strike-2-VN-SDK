using System;
using System.Collections.Generic;
using C2TPro;

namespace Assets.Generated.Table;

public class ExplosionEffectTable
{
	public class Row
	{
		public int EventId;

		public bool HasBulletHole;

		public string SoundType;

		public string SoundSubType;

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
			row.EventId = ((!string.IsNullOrEmpty(array[i][0])) ? Convert.ToInt32(array[i][0]) : 0);
			row.HasBulletHole = !string.IsNullOrEmpty(array[i][1]) && Convert.ToBoolean(array[i][1]);
			row.SoundType = array[i][2];
			row.SoundSubType = array[i][3];
			row.Ps = array[i][4];
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

	public Row Find_EventId(int find)
	{
		return rowList.Find((Row x) => x.EventId == find);
	}

	public List<Row> FindAll_EventId(int find)
	{
		return rowList.FindAll((Row x) => x.EventId == find);
	}

	public Row Find_HasBulletHole(bool find)
	{
		return rowList.Find((Row x) => x.HasBulletHole == find);
	}

	public List<Row> FindAll_HasBulletHole(bool find)
	{
		return rowList.FindAll((Row x) => x.HasBulletHole == find);
	}

	public Row Find_SoundType(string find)
	{
		return rowList.Find((Row x) => x.SoundType == find);
	}

	public List<Row> FindAll_SoundType(string find)
	{
		return rowList.FindAll((Row x) => x.SoundType == find);
	}

	public Row Find_SoundSubType(string find)
	{
		return rowList.Find((Row x) => x.SoundSubType == find);
	}

	public List<Row> FindAll_SoundSubType(string find)
	{
		return rowList.FindAll((Row x) => x.SoundSubType == find);
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
