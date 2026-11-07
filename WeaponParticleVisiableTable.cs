using System.Collections.Generic;
using C2TPro;

public class WeaponParticleVisiableTable
{
	public class Row
	{
		public string WeaponName;

		public string ParticleName;
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
			row.WeaponName = array[i][0];
			row.ParticleName = array[i][1];
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

	public Row Find_WeaponName(string find)
	{
		return rowList.Find((Row x) => x.WeaponName == find);
	}

	public List<Row> FindAll_WeaponName(string find)
	{
		return rowList.FindAll((Row x) => x.WeaponName == find);
	}

	public Row Find_ParticleName(string find)
	{
		return rowList.Find((Row x) => x.ParticleName == find);
	}

	public List<Row> FindAll_ParticleName(string find)
	{
		return rowList.FindAll((Row x) => x.ParticleName == find);
	}
}
