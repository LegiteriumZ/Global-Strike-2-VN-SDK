using System.Collections.Generic;
using C2TPro;
using UnityEngine;

public static class WeaponAnimationTestResultTable
{
	public class Row
	{
		public string Name;

		public string CodeName;

		public string WrongDes1;

		public string WrongDes2;

		public string WrongDes3;

		public string WrongDes4;

		public string WrongDes5;
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
			row.WrongDes1 = array[i][2];
			row.WrongDes2 = array[i][3];
			row.WrongDes3 = array[i][4];
			row.WrongDes4 = array[i][5];
			row.WrongDes5 = array[i][6];
			rowList.Add(row);
		}
		isLoaded = true;
	}

	public static void StaticLoad()
	{
		if (!isLoaded)
		{
			Load(Resources.Load<TextAsset>("Assets/Tests/PlayMode/Weapon/AutoTest/WeaponAnimationTestResult").text);
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

	public static Row Find_WrongDes1(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.WrongDes1 == find);
	}

	public static List<Row> FindAll_WrongDes1(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.WrongDes1 == find);
	}

	public static Row Find_WrongDes2(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.WrongDes2 == find);
	}

	public static List<Row> FindAll_WrongDes2(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.WrongDes2 == find);
	}

	public static Row Find_WrongDes3(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.WrongDes3 == find);
	}

	public static List<Row> FindAll_WrongDes3(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.WrongDes3 == find);
	}

	public static Row Find_WrongDes4(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.WrongDes4 == find);
	}

	public static List<Row> FindAll_WrongDes4(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.WrongDes4 == find);
	}

	public static Row Find_WrongDes5(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.WrongDes5 == find);
	}

	public static List<Row> FindAll_WrongDes5(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.WrongDes5 == find);
	}
}
