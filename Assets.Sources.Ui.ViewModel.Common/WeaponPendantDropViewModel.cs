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
public class WeaponPendantDropViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private CanvasGroup _oShowCanvasGroup;

	private GameObject _oScoreBack;

	private GameObject _oQuality;

	private Image _oQualityImage;

	private GameObject _oIcon;

	private Image _oIconImage;

	private GameObject _oCount;

	private Text _oCountText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "WeaponPendantDrop";

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

	public float ShowAlpha
	{
		get
		{
			if (_oShowCanvasGroup != null)
			{
				return _oShowCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (ShowAlpha != value && _oShowCanvasGroup != null)
			{
				_oShowCanvasGroup.alpha = value;
			}
		}
	}

	public bool ScoreBackShow
	{
		get
		{
			if (_oScoreBack != null)
			{
				return _oScoreBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ScoreBackShow != value && _oScoreBack != null)
			{
				_oScoreBack.SetObjectActive(value);
			}
		}
	}

	public bool QualityShow
	{
		get
		{
			if (_oQuality != null)
			{
				return _oQuality.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (QualityShow != value && _oQuality != null)
			{
				_oQuality.SetObjectActive(value);
			}
		}
	}

	public Sprite QualitySprite
	{
		get
		{
			if (_oQualityImage != null)
			{
				return _oQualityImage.sprite;
			}
			return null;
		}
		set
		{
			if (QualitySprite != value && _oQualityImage != null)
			{
				_oQualityImage.sprite = value;
			}
		}
	}

	public bool IconShow
	{
		get
		{
			if (_oIcon != null)
			{
				return _oIcon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow != value && _oIcon != null)
			{
				_oIcon.SetObjectActive(value);
			}
		}
	}

	public Sprite IconSprite
	{
		get
		{
			if (_oIconImage != null)
			{
				return _oIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite != value && _oIconImage != null)
			{
				_oIconImage.sprite = value;
			}
		}
	}

	public string CountString
	{
		get
		{
			if (_oCountText != null)
			{
				return _oCountText.text;
			}
			return null;
		}
		set
		{
			if (CountString != value && _oCountText != null)
			{
				_oCountText.text = value;
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
				_oShowCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "ScoreBack":
				_oScoreBack = transform.gameObject;
				break;
			case "Quality":
				_oQuality = transform.gameObject;
				_oQualityImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon":
				_oIcon = transform.gameObject;
				_oIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Count":
				_oCount = transform.gameObject;
				_oCountText = transform.gameObject.GetComponent<Text>();
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
