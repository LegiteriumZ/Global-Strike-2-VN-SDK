using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Biochemical;

[GameUiTest]
public class BiochemicalstartgameViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oGameStartImage;

	private Image _oGameStartImageImage;

	private GameObject _oTimeText;

	private Text _oTimeTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical";

	private string _resourceAssetName = "Biochemicalstartgame";

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public Sprite GameStartImageSprite
	{
		get
		{
			if (_oGameStartImageImage != null)
			{
				return _oGameStartImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (GameStartImageSprite != value && _oGameStartImageImage != null)
			{
				_oGameStartImageImage.sprite = value;
			}
		}
	}

	public string TimeTextString
	{
		get
		{
			if (_oTimeTextText != null)
			{
				return _oTimeTextText.text;
			}
			return null;
		}
		set
		{
			if (TimeTextString != value && _oTimeTextText != null)
			{
				_oTimeTextText.text = value;
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "GameStartImage":
				_oGameStartImage = transform.gameObject;
				_oGameStartImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "TimeText":
				_oTimeText = transform.gameObject;
				_oTimeTextText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public void GameStartImageNtvsize()
	{
		if (_oGameStartImageImage != null)
		{
			_oGameStartImageImage.SetNativeSize();
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
