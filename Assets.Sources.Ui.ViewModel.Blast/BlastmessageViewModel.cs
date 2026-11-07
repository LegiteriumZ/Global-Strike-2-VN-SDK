using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Blast;

[GameUiTest]
public class BlastmessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oC4StateBackImage;

	private GameObject _oC4StateImage;

	private CanvasGroup _oC4StateImageCanvasGroup;

	private Image _oC4StateImageImage;

	private GameObject _oC4MessageText;

	private Text _oC4MessageTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/blast";

	private string _resourceAssetName = "Blastmessage";

	public bool C4StateBackImageShow
	{
		get
		{
			if (_oC4StateBackImage != null)
			{
				return _oC4StateBackImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (C4StateBackImageShow != value && _oC4StateBackImage != null)
			{
				_oC4StateBackImage.SetObjectActive(value);
			}
		}
	}

	public bool C4StateImageShow
	{
		get
		{
			if (_oC4StateImage != null)
			{
				return _oC4StateImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (C4StateImageShow != value && _oC4StateImage != null)
			{
				_oC4StateImage.SetObjectActive(value);
			}
		}
	}

	public float C4StateImageAlpha
	{
		get
		{
			if (_oC4StateImageCanvasGroup != null)
			{
				return _oC4StateImageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (C4StateImageAlpha != value && _oC4StateImageCanvasGroup != null)
			{
				_oC4StateImageCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite C4StateImageSprite
	{
		get
		{
			if (_oC4StateImageImage != null)
			{
				return _oC4StateImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (C4StateImageSprite != value && _oC4StateImageImage != null)
			{
				_oC4StateImageImage.sprite = value;
			}
		}
	}

	public bool C4MessageTextShow
	{
		get
		{
			if (_oC4MessageText != null)
			{
				return _oC4MessageText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (C4MessageTextShow != value && _oC4MessageText != null)
			{
				_oC4MessageText.SetObjectActive(value);
			}
		}
	}

	public string C4MessageTextString
	{
		get
		{
			if (_oC4MessageTextText != null)
			{
				return _oC4MessageTextText.text;
			}
			return null;
		}
		set
		{
			if (C4MessageTextString != value && _oC4MessageTextText != null)
			{
				_oC4MessageTextText.text = value;
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
			case "C4StateBackImage":
				_oC4StateBackImage = transform.gameObject;
				break;
			case "C4StateImage":
				_oC4StateImage = transform.gameObject;
				_oC4StateImageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				_oC4StateImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "C4MessageText":
				_oC4MessageText = transform.gameObject;
				_oC4MessageTextText = transform.gameObject.GetComponent<Text>();
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
