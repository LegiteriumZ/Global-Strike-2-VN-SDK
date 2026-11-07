using System;
using System.Collections.Generic;
using UnityEngine;

public class TestScrollView : MonoBehaviour
{
	[Serializable]
	public class ChildContent
	{
		public Transform child;

		public int width;

		public int height = 50;
	}

	public class ScrollViewComponentData
	{
		public int BackGroundWidth = 200;

		public int BackGroundHeight = 400;

		public int ContentPosX = 10;

		public int ContentPosY = 10;

		public int ContentWidth = 522;

		public int ContentHeight = 490;

		public int ItemPadingLeft = 20;

		public int ItemPadingUp = 20;

		public int ItemDeltaX = 40;

		public int ItemDeltaY = 40;

		public int StartX;

		public int StartY;

		public int NewX;

		public int NewY;

		public int AllHeight;

		public int Line;

		public void Reset()
		{
			StartX = ItemPadingLeft;
			StartY = -ItemPadingUp;
			Line = 1;
		}

		public void AddItem(int width, int height)
		{
			NewX = StartX + width;
			if (ContentWidth - ItemPadingLeft < NewX)
			{
				StartX = ItemPadingLeft;
				StartY -= height + ItemDeltaY;
				Line++;
			}
			NewX = StartX + ItemDeltaX + width;
			NewY = StartY;
			AllHeight = Line * (height + ItemDeltaY) + ItemPadingUp;
		}

		public void AddOver()
		{
			StartX = NewX;
			StartY = NewY;
		}

		public override string ToString()
		{
			return "";
		}
	}

	public Transform Content;

	public List<ChildContent> ChildContents;

	private ScrollViewComponentData _data = new ScrollViewComponentData();

	private int index;

	private void Start()
	{
		RefreshView();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			index = 4;
			RefreshView();
		}
	}

	public void RefreshView()
	{
		_data.Reset();
		Transform[] componentsInChildren = Content.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform != Content)
			{
				transform.SetParent(null);
			}
		}
		List<Transform> list = new List<Transform>();
		for (int j = 0; j < 12; j++)
		{
			for (int k = index; k < index + 4; k++)
			{
				Transform transform2 = UnityEngine.Object.Instantiate(ChildContents[k].child);
				_data.AddItem(ChildContents[k].width, ChildContents[k].height);
				transform2.transform.localPosition = new Vector3(_data.StartX, _data.StartY, 0f);
				_data.AddOver();
				list.Add(transform2);
			}
		}
		Content.GetComponent<RectTransform>().sizeDelta = new Vector2(_data.ContentWidth, _data.AllHeight);
		foreach (Transform item in list)
		{
			Vector3 localPosition = item.transform.localPosition;
			item.transform.SetParent(Content);
			item.transform.localPosition = localPosition;
		}
	}
}
