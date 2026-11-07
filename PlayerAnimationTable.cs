using System.Collections.Generic;
using C2TPro;

public class PlayerAnimationTable
{
	public class Row
	{
		public string CareerName;

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
			row.CareerName = array[i][0];
			row.AssetName = array[i][1];
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

	public Row Find_CareerName(string find)
	{
		return rowList.Find((Row x) => x.CareerName == find);
	}

	public List<Row> FindAll_CareerName(string find)
	{
		return rowList.FindAll((Row x) => x.CareerName == find);
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
