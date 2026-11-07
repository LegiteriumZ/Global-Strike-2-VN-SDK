using System;
using System.Collections.Generic;
using C2TPro;

public class DemoTable
{
	public class Row
	{
		public string Year;

		public string Make;

		public string Model;

		public string Description;

		public float Price;
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
			row.Year = array[i][0];
			row.Make = array[i][1];
			row.Model = array[i][2];
			row.Description = array[i][3];
			row.Price = (string.IsNullOrEmpty(array[i][4]) ? 0f : Convert.ToSingle(array[i][4]));
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

	public Row Find_Year(string find)
	{
		return rowList.Find((Row x) => x.Year == find);
	}

	public List<Row> FindAll_Year(string find)
	{
		return rowList.FindAll((Row x) => x.Year == find);
	}

	public Row Find_Make(string find)
	{
		return rowList.Find((Row x) => x.Make == find);
	}

	public List<Row> FindAll_Make(string find)
	{
		return rowList.FindAll((Row x) => x.Make == find);
	}

	public Row Find_Model(string find)
	{
		return rowList.Find((Row x) => x.Model == find);
	}

	public List<Row> FindAll_Model(string find)
	{
		return rowList.FindAll((Row x) => x.Model == find);
	}

	public Row Find_Description(string find)
	{
		return rowList.Find((Row x) => x.Description == find);
	}

	public List<Row> FindAll_Description(string find)
	{
		return rowList.FindAll((Row x) => x.Description == find);
	}

	public Row Find_Price(float find)
	{
		return rowList.Find((Row x) => x.Price == find);
	}

	public List<Row> FindAll_Price(float find)
	{
		return rowList.FindAll((Row x) => x.Price == find);
	}
}
