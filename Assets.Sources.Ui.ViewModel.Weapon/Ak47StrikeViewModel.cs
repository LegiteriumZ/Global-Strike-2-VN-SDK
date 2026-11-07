using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class Ak47StrikeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRightBottom;

	private GameObject _oCommonBackImage;

	private Image _oCommonBackImageImage;

	private GameObject _oBackImage;

	private Image _oBackImageImage;

	private GameObject _oIconImage;

	private RectTransform _oIconImageRectTransform;

	private Image _oIconImageImage;

	private GameObject _oProgressImage;

	private Image _oProgressImageImage;

	private GameObject _oKillCount;

	private Text _oKillCountText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Ak47Strike";

	public bool RightBottomShow
	{
		get
		{
			if (_oRightBottom != null)
			{
				return _oRightBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightBottomShow != value && _oRightBottom != null)
			{
				_oRightBottom.SetObjectActive(value);
			}
		}
	}

	public bool CommonBackImageShow
	{
		get
		{
			if (_oCommonBackImage != null)
			{
				return _oCommonBackImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CommonBackImageShow != value && _oCommonBackImage != null)
			{
				_oCommonBackImage.SetObjectActive(value);
			}
		}
	}

	public Sprite CommonBackImageSprite
	{
		get
		{
			if (_oCommonBackImageImage != null)
			{
				return _oCommonBackImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (CommonBackImageSprite != value && _oCommonBackImageImage != null)
			{
				_oCommonBackImageImage.sprite = value;
			}
		}
	}

	public bool BackImageShow
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackImageShow != value && _oBackImage != null)
			{
				_oBackImage.SetObjectActive(value);
			}
		}
	}

	public Sprite BackImageSprite
	{
		get
		{
			if (_oBackImageImage != null)
			{
				return _oBackImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackImageSprite != value && _oBackImageImage != null)
			{
				_oBackImageImage.sprite = value;
			}
		}
	}

	public bool IconImageShow
	{
		get
		{
			if (_oIconImage != null)
			{
				return _oIconImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconImageShow != value && _oIconImage != null)
			{
				_oIconImage.SetObjectActive(value);
			}
		}
	}

	public Vector3 IconImageScale
	{
		get
		{
			if (_oIconImageRectTransform != null)
			{
				return _oIconImageRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (IconImageScale != value && _oIconImageRectTransform != null)
			{
				_oIconImageRectTransform.localScale = value;
			}
		}
	}

	public Sprite IconImageSprite
	{
		get
		{
			if (_oIconImageImage != null)
			{
				return _oIconImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (IconImageSprite != value && _oIconImageImage != null)
			{
				_oIconImageImage.sprite = value;
			}
		}
	}

	public Sprite ProgressImageSprite
	{
		get
		{
			if (_oProgressImageImage != null)
			{
				return _oProgressImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressImageSprite != value && _oProgressImageImage != null)
			{
				_oProgressImageImage.sprite = value;
			}
		}
	}

	public float ProgressImageFillamount
	{
		get
		{
			if (_oProgressImageImage != null)
			{
				return _oProgressImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressImageFillamount != value && _oProgressImageImage != null)
			{
				_oProgressImageImage.fillAmount = value;
			}
		}
	}

	public bool KillCountShow
	{
		get
		{
			if (_oKillCount != null)
			{
				return _oKillCount.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillCountShow != value && _oKillCount != null)
			{
				_oKillCount.SetObjectActive(value);
			}
		}
	}

	public string KillCountString
	{
		get
		{
			if (_oKillCountText != null)
			{
				return _oKillCountText.text;
			}
			return null;
		}
		set
		{
			if (KillCountString != value && _oKillCountText != null)
			{
				_oKillCountText.text = value;
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
			case "RightBottom":
				_oRightBottom = transform.gameObject;
				break;
			case "CommonBackImage":
				_oCommonBackImage = transform.gameObject;
				_oCommonBackImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BackImage":
				_oBackImage = transform.gameObject;
				_oBackImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "IconImage":
				_oIconImage = transform.gameObject;
				_oIconImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oIconImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressImage":
				_oProgressImage = transform.gameObject;
				_oProgressImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "KillCount":
				_oKillCount = transform.gameObject;
				_oKillCountText = transform.gameObject.GetComponent<Text>();
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
