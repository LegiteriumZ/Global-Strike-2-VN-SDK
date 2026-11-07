using System;
using System.Collections.Generic;
using C2TPro;

public class PlayerSkinInfoTable
{
	public class Row
	{
		public string Name;

		public bool HasSkinTexture;

		public bool HasThirdModel;

		public bool HasEffect;

		public bool HasEffectConfig;

		public bool HasViewHandModel;

		public string Player;

		public bool HasTextureConfig;

		public bool HasHitBox;

		public bool HasDyeing;
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
			row.HasSkinTexture = !string.IsNullOrEmpty(array[i][1]) && Convert.ToBoolean(array[i][1]);
			row.HasThirdModel = !string.IsNullOrEmpty(array[i][2]) && Convert.ToBoolean(array[i][2]);
			row.HasEffect = !string.IsNullOrEmpty(array[i][3]) && Convert.ToBoolean(array[i][3]);
			row.HasEffectConfig = !string.IsNullOrEmpty(array[i][4]) && Convert.ToBoolean(array[i][4]);
			row.HasViewHandModel = !string.IsNullOrEmpty(array[i][5]) && Convert.ToBoolean(array[i][5]);
			row.Player = array[i][6];
			row.HasTextureConfig = !string.IsNullOrEmpty(array[i][7]) && Convert.ToBoolean(array[i][7]);
			row.HasHitBox = !string.IsNullOrEmpty(array[i][8]) && Convert.ToBoolean(array[i][8]);
			row.HasDyeing = !string.IsNullOrEmpty(array[i][9]) && Convert.ToBoolean(array[i][9]);
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

	public Row Find_HasSkinTexture(bool find)
	{
		return rowList.Find((Row x) => x.HasSkinTexture == find);
	}

	public List<Row> FindAll_HasSkinTexture(bool find)
	{
		return rowList.FindAll((Row x) => x.HasSkinTexture == find);
	}

	public Row Find_HasThirdModel(bool find)
	{
		return rowList.Find((Row x) => x.HasThirdModel == find);
	}

	public List<Row> FindAll_HasThirdModel(bool find)
	{
		return rowList.FindAll((Row x) => x.HasThirdModel == find);
	}

	public Row Find_HasEffect(bool find)
	{
		return rowList.Find((Row x) => x.HasEffect == find);
	}

	public List<Row> FindAll_HasEffect(bool find)
	{
		return rowList.FindAll((Row x) => x.HasEffect == find);
	}

	public Row Find_HasEffectConfig(bool find)
	{
		return rowList.Find((Row x) => x.HasEffectConfig == find);
	}

	public List<Row> FindAll_HasEffectConfig(bool find)
	{
		return rowList.FindAll((Row x) => x.HasEffectConfig == find);
	}

	public Row Find_HasViewHandModel(bool find)
	{
		return rowList.Find((Row x) => x.HasViewHandModel == find);
	}

	public List<Row> FindAll_HasViewHandModel(bool find)
	{
		return rowList.FindAll((Row x) => x.HasViewHandModel == find);
	}

	public Row Find_Player(string find)
	{
		return rowList.Find((Row x) => x.Player == find);
	}

	public List<Row> FindAll_Player(string find)
	{
		return rowList.FindAll((Row x) => x.Player == find);
	}

	public Row Find_HasTextureConfig(bool find)
	{
		return rowList.Find((Row x) => x.HasTextureConfig == find);
	}

	public List<Row> FindAll_HasTextureConfig(bool find)
	{
		return rowList.FindAll((Row x) => x.HasTextureConfig == find);
	}

	public Row Find_HasHitBox(bool find)
	{
		return rowList.Find((Row x) => x.HasHitBox == find);
	}

	public List<Row> FindAll_HasHitBox(bool find)
	{
		return rowList.FindAll((Row x) => x.HasHitBox == find);
	}
}
