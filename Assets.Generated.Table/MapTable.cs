using System;
using System.Collections.Generic;
using C2TPro;

namespace Assets.Generated.Table;

public class MapTable
{
	public class Row
	{
		public int Id;

		public string Name;

		public int DataType;
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
			row.Id = ((!string.IsNullOrEmpty(array[i][0])) ? Convert.ToInt32(array[i][0]) : 0);
			row.Name = array[i][1];
			row.DataType = ((!string.IsNullOrEmpty(array[i][2])) ? Convert.ToInt32(array[i][2]) : 0);
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

	public Row Find_Id(int find)
	{
		return rowList.Find((Row x) => x.Id == find);
	}

	public List<Row> FindAll_Id(int find)
	{
		return rowList.FindAll((Row x) => x.Id == find);
	}

	public Row Find_Name(string find)
	{
		return rowList.Find((Row x) => x.Name == find);
	}

	public List<Row> FindAll_Name(string find)
	{
		return rowList.FindAll((Row x) => x.Name == find);
	}

	public Row Find_DataType(int find)
	{
		return rowList.Find((Row x) => x.DataType == find);
	}

	public List<Row> FindAll_DataType(int find)
	{
		return rowList.FindAll((Row x) => x.DataType == find);
	}
}
