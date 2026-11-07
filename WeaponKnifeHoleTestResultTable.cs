using System.Collections.Generic;
using C2TPro;
using UnityEngine;

public static class WeaponKnifeHoleTestResultTable
{
	public class Row
	{
		public string Name;

		public string CodeName;

		public string Client;

		public string Server;

		public string Des;
	}

	private static List<Row> rowList = new List<Row>();

	private static bool isLoaded = false;

	public static bool IsLoaded()
	{
		return isLoaded;
	}

	public static List<Row> GetRowList()
	{
		StaticLoad();
		return rowList;
	}

	public static void Load(string csv)
	{
		rowList.Clear();
		string[][] array = CsvParser.Parse(csv);
		for (int i = 1; i < array.Length; i++)
		{
			Row row = new Row();
			row.Name = array[i][0];
			row.CodeName = array[i][1];
			row.Client = array[i][2];
			row.Server = array[i][3];
			row.Des = array[i][4];
			rowList.Add(row);
		}
		isLoaded = true;
	}

	public static void StaticLoad()
	{
		if (!isLoaded)
		{
			Load(Resources.Load<TextAsset>("Assets/Tests/PlayMode/Weapon/AutoTest/WeaponKnifeHoleTestResult").text);
		}
	}

	public static int NumRows()
	{
		StaticLoad();
		return rowList.Count;
	}

	public static Row GetAt(int i)
	{
		StaticLoad();
		if (rowList.Count <= i)
		{
			return null;
		}
		return rowList[i];
	}

	public static Row Find_Name(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.Name == find);
	}

	public static List<Row> FindAll_Name(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.Name == find);
	}

	public static Row Find_CodeName(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.CodeName == find);
	}

	public static List<Row> FindAll_CodeName(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.CodeName == find);
	}

	public static Row Find_Client(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.Client == find);
	}

	public static List<Row> FindAll_Client(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.Client == find);
	}

	public static Row Find_Server(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.Server == find);
	}

	public static List<Row> FindAll_Server(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.Server == find);
	}

	public static Row Find_Des(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.Des == find);
	}

	public static List<Row> FindAll_Des(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.Des == find);
	}
}
