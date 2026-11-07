using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class PlayerrebornViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oProgress;

	private GameObject _oCountDownSlider;

	private Slider _oCountDownSliderSlider;

	private GameObject _oCountDownNum;

	private Text _oCountDownNumText;

	private GameObject _oReliveMessage;

	private GameObject _oReportR;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Playerreborn";

	public bool ReportRShow
	{
		get
		{
			if (_oReportR != null)
			{
				return _oReportR.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReportRShow != value && _oReportR != null)
			{
				_oReportR.SetObjectActive(value);
			}
		}
	}

	public bool ProgressShow
	{
		get
		{
			if (_oProgress != null)
			{
				return _oProgress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressShow != value && _oProgress != null)
			{
				_oProgress.SetObjectActive(value);
			}
		}
	}

	public float CountDownSliderSlidervalue
	{
		get
		{
			if (_oCountDownSliderSlider != null)
			{
				return _oCountDownSliderSlider.value;
			}
			return 0f;
		}
		set
		{
			if (CountDownSliderSlidervalue != value && _oCountDownSliderSlider != null)
			{
				_oCountDownSliderSlider.value = value;
			}
		}
	}

	public string CountDownNumString
	{
		get
		{
			if (_oCountDownNumText != null)
			{
				return _oCountDownNumText.text;
			}
			return null;
		}
		set
		{
			if (CountDownNumString != value && _oCountDownNumText != null)
			{
				_oCountDownNumText.text = value;
			}
		}
	}

	public bool ReliveMessageShow
	{
		get
		{
			if (_oReliveMessage != null)
			{
				return _oReliveMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReliveMessageShow != value && _oReliveMessage != null)
			{
				_oReliveMessage.SetObjectActive(value);
			}
		}
	}

	public string ResourceBundleName
	{
		get
		{
			return _resourceBundleName;
		}
		set
		{
			_resourceBundleName = value;
		}
	}

	public string ResourceAssetName
	{
		get
		{
			return _resourceAssetName;
		}
		set
		{
			_resourceAssetName = value;
		}
	}

	public string ConfigBundleName => "";

	public string ConfigAssetName => "";

	public bool IsInited => _viewGameObject != null;

	public void CreateBinding(GameObject instance)
	{
		_viewGameObject = instance;
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "Progress":
				_oProgress = transform.gameObject;
				break;
			case "CountDownSlider":
				_oCountDownSlider = transform.gameObject;
				_oCountDownSliderSlider = transform.gameObject.GetComponent<Slider>();
				break;
			case "CountDownNum":
				_oCountDownNum = transform.gameObject;
				_oCountDownNumText = transform.gameObject.GetComponent<Text>();
				break;
			case "ReliveMessage":
				_oReliveMessage = transform.gameObject;
				break;
			case "reportR":
				_oReportR = transform.gameObject;
				break;
			}
		}
	}

	public bool IsPropertyExist(string name)
	{
		return true;
	}

	public Transform GetParentLinkNode()
	{
		return null;
	}

	public Transform GetChildLinkNode()
	{
		return null;
	}

	public void Destory()
	{
		if (_viewGameObject != null)
		{
			Object.Destroy(_viewGameObject);
		}
	}

	public void Visible(bool isVisible)
	{
		if (_viewGameObject != null)
		{
			_viewGameObject.SetObjectActive(isVisible);
		}
	}

	public EventTrigger.Entry CreateTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		EventTrigger.Entry entry = new EventTrigger.Entry
		{
			callback = new EventTrigger.TriggerEvent(),
			eventID = eventId
		};
		entry.callback.AddListener(callback);
		triggers?.Add(entry);
		return entry;
	}

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
