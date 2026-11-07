using System.Collections.Generic;
using C2TPro;

public class MoveEntityTable
{
	public class Row
	{
		public string Name;

		public string AssetBundle;

		public string AssetPath;

		public string Class;
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
			row.Class = array[i][3];
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

	public Row Find_Class(string find)
	{
		return rowList.Find((Row x) => x.Class == find);
	}

	public List<Row> FindAll_Class(string find)
	{
		return rowList.FindAll((Row x) => x.Class == find);
	}
}
