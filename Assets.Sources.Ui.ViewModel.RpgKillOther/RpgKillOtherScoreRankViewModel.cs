using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.RpgKillOther;

[GameUiTest]
public class RpgKillOtherScoreRankViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oTime;

	private Text _oTimeText;

	private GameObject _oRank;

	private Text _oRankText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpgkillother";

	private string _resourceAssetName = "RpgKillOtherScoreRank";

	public GameObject ViewGameObject => _viewGameObject;

	public bool ViewGameObjectShow
	{
		get
		{
			if (_viewGameObject != null)
			{
				return _viewGameObject.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ViewGameObjectShow != value && _viewGameObject != null)
			{
				_viewGameObject.SetObjectActive(value);
			}
		}
	}

	public bool ShowShow
	{
		get
		{
			if (_oShow != null)
			{
				return _oShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _oShow != null)
			{
				_oShow.SetObjectActive(value);
			}
		}
	}

	public bool TimeShow
	{
		get
		{
			if (_oTime != null)
			{
				return _oTime.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TimeShow != value && _oTime != null)
			{
				_oTime.SetObjectActive(value);
			}
		}
	}

	public string TimeString
	{
		get
		{
			if (_oTimeText != null)
			{
				return _oTimeText.text;
			}
			return null;
		}
		set
		{
			if (TimeString != value && _oTimeText != null)
			{
				_oTimeText.text = value;
			}
		}
	}

	public string RankString
	{
		get
		{
			if (_oRankText != null)
			{
				return _oRankText.text;
			}
			return null;
		}
		set
		{
			if (RankString != value && _oRankText != null)
			{
				_oRankText.text = value;
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
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "Time":
				_oTime = transform.gameObject;
				_oTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "Rank":
				_oRank = transform.gameObject;
				_oRankText = transform.gameObject.GetComponent<Text>();
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
