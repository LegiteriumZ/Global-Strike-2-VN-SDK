using System;
using System.Collections.Generic;
using C2TPro;
using UnityEngine;

public static class BulletHoleTestResultTable
{
	public class Row
	{
		public string Weapon;

		public int ClientCount;

		public int ServerCount;

		public int MisMatchCount;

		public float MisMatchRate;

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
			row.Weapon = array[i][0];
			row.ClientCount = ((!string.IsNullOrEmpty(array[i][1])) ? Convert.ToInt32(array[i][1]) : 0);
			row.ServerCount = ((!string.IsNullOrEmpty(array[i][2])) ? Convert.ToInt32(array[i][2]) : 0);
			row.MisMatchCount = ((!string.IsNullOrEmpty(array[i][3])) ? Convert.ToInt32(array[i][3]) : 0);
			row.MisMatchRate = (string.IsNullOrEmpty(array[i][4]) ? 0f : Convert.ToSingle(array[i][4]));
			row.Des = array[i][5];
			rowList.Add(row);
		}
		isLoaded = true;
	}

	public static void StaticLoad()
	{
		if (!isLoaded)
		{
			Load(Resources.Load<TextAsset>("Assets/Tests/PlayMode/Weapon/AutoTest/WeaponCommonAttackTestResult").text);
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

	public static Row Find_Weapon(string find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.Weapon == find);
	}

	public static List<Row> FindAll_Weapon(string find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.Weapon == find);
	}

	public static Row Find_ClientCount(int find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.ClientCount == find);
	}

	public static List<Row> FindAll_ClientCount(int find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.ClientCount == find);
	}

	public static Row Find_ServerCount(int find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.ServerCount == find);
	}

	public static List<Row> FindAll_ServerCount(int find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.ServerCount == find);
	}

	public static Row Find_MisMatchCount(int find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.MisMatchCount == find);
	}

	public static List<Row> FindAll_MisMatchCount(int find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.MisMatchCount == find);
	}

	public static Row Find_MisMatchRate(float find)
	{
		StaticLoad();
		return rowList.Find((Row x) => x.MisMatchRate == find);
	}

	public static List<Row> FindAll_MisMatchRate(float find)
	{
		StaticLoad();
		return rowList.FindAll((Row x) => x.MisMatchRate == find);
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
