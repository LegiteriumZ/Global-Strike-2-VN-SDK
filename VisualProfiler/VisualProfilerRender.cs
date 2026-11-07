using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VisualProfiler;

public class VisualProfilerRender
{
	private GameObject _uiRoot;

	private Text _topUi;

	private Text _downUi;

	private Image _ptemplate;

	private List<Image> _cloneList = new List<Image>();

	private RectTransform _scrollroot;

	private Text _scrollText;

	public bool Enable => _uiRoot != null;

	public void BuildReference(GameObject root)
	{
		_uiRoot = root;
		_topUi = root.transform.Find("CommonRoot/TopText").GetComponent<Text>();
		_downUi = root.transform.Find("CommonRoot/DownText").GetComponent<Text>();
		_ptemplate = root.transform.Find("CommonRoot/CenterRoot/img1").GetComponent<Image>();
		_scrollText = root.transform.Find("Scroll View/Viewport/Content/Text").GetComponent<Text>();
		_scrollroot = root.transform.Find("Scroll View") as RectTransform;
	}

	public void ShowRoot(bool show)
	{
		_uiRoot.SetActive(show);
	}

	public void ShowDetailInfo(bool show)
	{
		_scrollroot.gameObject.SetActive(show);
	}

	public Text GetDetailText()
	{
		return _scrollText;
	}

	public Text GetTopText()
	{
		return _topUi;
	}

	public Text GetDownText()
	{
		return _downUi;
	}

	public void UpdateDetailSize(Vector2 size)
	{
		_scrollroot.sizeDelta = size;
	}

	public void SetProgressUiCount(int cnt, Color defaultColor)
	{
		foreach (Image clone in _cloneList)
		{
			Object.Destroy(clone.gameObject);
		}
		_cloneList.Clear();
		for (int i = 0; i < cnt; i++)
		{
			GameObject gameObject = Object.Instantiate(_ptemplate.gameObject);
			gameObject.transform.parent = _ptemplate.transform.parent;
			Image component = gameObject.GetComponent<Image>();
			component.color = defaultColor;
			_cloneList.Add(component);
		}
	}

	public void UpdateLastestProgressColor(Color color)
	{
		for (int i = 0; i < _cloneList.Count; i++)
		{
			Image image = _cloneList[i];
			Image image2 = ((i == 0) ? _ptemplate : _cloneList[i - 1]);
			if ((bool)image2 && (bool)image)
			{
				image2.color = image.color;
			}
		}
		_cloneList[_cloneList.Count - 1].color = color;
	}

	public void Destroy()
	{
		Object.Destroy(_uiRoot);
	}
}
