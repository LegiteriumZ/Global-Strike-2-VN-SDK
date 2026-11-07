using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RPGNanjiMarkViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRPGNanjiMark;

	private GameObject _opanel;

	private GameObject _oblock;

	private RectTransform _oblockRectTransform;

	private Image _oblockImage;

	private GameObject _viewGameObject;

	public const string panelName = "panel";

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RPGNanjiMark";

	public bool RPGNanjiMarkShow
	{
		get
		{
			if (_oRPGNanjiMark != null)
			{
				return _oRPGNanjiMark.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RPGNanjiMarkShow != value && _oRPGNanjiMark != null)
			{
				_oRPGNanjiMark.SetObjectActive(value);
			}
		}
	}

	public bool blockShow
	{
		get
		{
			if (_oblock != null)
			{
				return _oblock.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (blockShow != value && _oblock != null)
			{
				_oblock.SetObjectActive(value);
			}
		}
	}

	public Vector3 blockSize
	{
		get
		{
			if (_oblockRectTransform != null)
			{
				return _oblockRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (blockSize != value && _oblockRectTransform != null)
			{
				_oblockRectTransform.sizeDelta = value;
			}
		}
	}

	public Image.FillMethod blockFillmethod
	{
		get
		{
			if (_oblockImage != null)
			{
				return _oblockImage.fillMethod;
			}
			return Image.FillMethod.Horizontal;
		}
		set
		{
			if (blockFillmethod != value && _oblockImage != null)
			{
				_oblockImage.fillMethod = value;
			}
		}
	}

	public int blockFillorigin
	{
		get
		{
			if (_oblockImage != null)
			{
				return _oblockImage.fillOrigin;
			}
			return 0;
		}
		set
		{
			if (blockFillorigin != value && _oblockImage != null)
			{
				_oblockImage.fillOrigin = value;
			}
		}
	}

	public float blockFillamount
	{
		get
		{
			if (_oblockImage != null)
			{
				return _oblockImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (blockFillamount != value && _oblockImage != null)
			{
				_oblockImage.fillAmount = value;
			}
		}
	}

	public bool blockClockwise
	{
		get
		{
			if (_oblockImage != null)
			{
				return _oblockImage.fillClockwise;
			}
			return false;
		}
		set
		{
			if (blockClockwise != value && _oblockImage != null)
			{
				_oblockImage.fillClockwise = value;
			}
		}
	}

	public Color blockColor
	{
		get
		{
			if (_oblockImage != null)
			{
				return _oblockImage.color;
			}
			return Color.white;
		}
		set
		{
			if (blockColor != value && _oblockImage != null)
			{
				_oblockImage.color = value;
			}
		}
	}

	public Image blockImage
	{
		get
		{
			if (_oblockImage != null)
			{
				return _oblockImage;
			}
			return null;
		}
		set
		{
			if (blockImage != value && _oblockImage != null)
			{
				_oblockImage = value;
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
			case "RPGNanjiMark":
				_oRPGNanjiMark = transform.gameObject;
				break;
			case "panel":
				_opanel = transform.gameObject;
				break;
			case "block":
				_oblock = transform.gameObject;
				_oblockRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oblockImage = transform.gameObject.GetComponent<Image>();
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
