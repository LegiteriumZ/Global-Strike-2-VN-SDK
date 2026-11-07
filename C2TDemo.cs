using UnityEngine;
using UnityEngine.UI;

public class C2TDemo : MonoBehaviour
{
	public TextAsset csv;

	public GridLayoutGroup grid;

	public GameObject itemPrefab;

	public void Start()
	{
		Refresh();
	}

	public void Refresh()
	{
		if (!(csv == null))
		{
			DemoTable demoTable = new DemoTable();
			demoTable.Load(csv.text);
			AddItem("Year", Color.gray);
			AddItem("Make", Color.gray);
			AddItem("Model", Color.gray);
			AddItem("Desc", Color.gray);
			AddItem("Price", Color.gray);
			DemoTable.Row at = demoTable.GetAt(0);
			AddItem(at.Year.GetType().ToString(), Color.gray);
			AddItem(at.Make.GetType().ToString(), Color.gray);
			AddItem(at.Model.GetType().ToString(), Color.gray);
			AddItem(at.Description.GetType().ToString(), Color.gray);
			AddItem(at.Price.GetType().ToString(), Color.gray);
			int num = demoTable.NumRows();
			for (int i = 0; i < num; i++)
			{
				AddItem(demoTable.GetAt(i).Year);
				AddItem(demoTable.GetAt(i).Make);
				AddItem(demoTable.GetAt(i).Model);
				AddItem(demoTable.GetAt(i).Description);
				AddItem(demoTable.GetAt(i).Price.ToString());
			}
		}
	}

	private Text AddItem(string item)
	{
		return AddItem(item, Color.white);
	}

	private Text AddItem(string item, Color color)
	{
		GameObject obj = Object.Instantiate(itemPrefab);
		obj.transform.SetParent(grid.transform);
		obj.GetComponent<Image>().color = color;
		Text componentInChildren = obj.GetComponentInChildren<Text>();
		componentInChildren.text = item;
		return componentInChildren;
	}
}
