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
public class KillStateViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oKillStateBg;

	private Image _oKillStateBgImage;

	private GameObject _oEffectBg;

	private CanvasGroup _oEffectBgCanvasGroup;

	private Image _oEffectBgImage;

	private GameObject _oKillStateBgGreat;

	private Image _oKillStateBgGreatImage;

	private GameObject _oCool;

	private RectTransform _oCoolRectTransform;

	private GameObject _oBottomKillNum;

	private RectTransform _oBottomKillNumRectTransform;

	private Text _oBottomKillNumText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "KillState";

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

	public bool KillStateBgShow
	{
		get
		{
			if (_oKillStateBg != null)
			{
				return _oKillStateBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillStateBgShow != value && _oKillStateBg != null)
			{
				_oKillStateBg.SetObjectActive(value);
			}
		}
	}

	public Sprite KillStateBgSprite
	{
		get
		{
			if (_oKillStateBgImage != null)
			{
				return _oKillStateBgImage.sprite;
			}
			return null;
		}
		set
		{
			if (KillStateBgSprite != value && _oKillStateBgImage != null)
			{
				_oKillStateBgImage.sprite = value;
			}
		}
	}

	public bool EffectBgShow
	{
		get
		{
			if (_oEffectBg != null)
			{
				return _oEffectBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectBgShow != value && _oEffectBg != null)
			{
				_oEffectBg.SetObjectActive(value);
			}
		}
	}

	public float EffectBgAlpha
	{
		get
		{
			if (_oEffectBgCanvasGroup != null)
			{
				return _oEffectBgCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (EffectBgAlpha != value && _oEffectBgCanvasGroup != null)
			{
				_oEffectBgCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite EffectBgSprite
	{
		get
		{
			if (_oEffectBgImage != null)
			{
				return _oEffectBgImage.sprite;
			}
			return null;
		}
		set
		{
			if (EffectBgSprite != value && _oEffectBgImage != null)
			{
				_oEffectBgImage.sprite = value;
			}
		}
	}

	public Sprite KillStateBgGreatSprite
	{
		get
		{
			if (_oKillStateBgGreatImage != null)
			{
				return _oKillStateBgGreatImage.sprite;
			}
			return null;
		}
		set
		{
			if (KillStateBgGreatSprite != value && _oKillStateBgGreatImage != null)
			{
				_oKillStateBgGreatImage.sprite = value;
			}
		}
	}

	public bool CoolShow
	{
		get
		{
			if (_oCool != null)
			{
				return _oCool.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CoolShow != value && _oCool != null)
			{
				_oCool.SetObjectActive(value);
			}
		}
	}

	public Vector3 CoolScale
	{
		get
		{
			if (_oCoolRectTransform != null)
			{
				return _oCoolRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CoolScale != value && _oCoolRectTransform != null)
			{
				_oCoolRectTransform.localScale = value;
			}
		}
	}

	public Vector3 BottomKillNumScale
	{
		get
		{
			if (_oBottomKillNumRectTransform != null)
			{
				return _oBottomKillNumRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (BottomKillNumScale != value && _oBottomKillNumRectTransform != null)
			{
				_oBottomKillNumRectTransform.localScale = value;
			}
		}
	}

	public string BottomKillNumString
	{
		get
		{
			if (_oBottomKillNumText != null)
			{
				return _oBottomKillNumText.text;
			}
			return null;
		}
		set
		{
			if (BottomKillNumString != value && _oBottomKillNumText != null)
			{
				_oBottomKillNumText.text = value;
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
			case "KillStateBg":
				_oKillStateBg = transform.gameObject;
				_oKillStateBgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EffectBg":
				_oEffectBg = transform.gameObject;
				_oEffectBgCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				_oEffectBgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "KillStateBgGreat":
				_oKillStateBgGreat = transform.gameObject;
				_oKillStateBgGreatImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Cool":
				_oCool = transform.gameObject;
				_oCoolRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "BottomKillNum":
				_oBottomKillNum = transform.gameObject;
				_oBottomKillNumRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oBottomKillNumText = transform.gameObject.GetComponent<Text>();
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
