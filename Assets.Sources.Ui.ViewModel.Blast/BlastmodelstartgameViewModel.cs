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
public class BlastmodelstartgameViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private CanvasGroup _oPanelCanvasGroup;

	private GameObject _oGameStartImage;

	private Image _oGameStartImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/blast";

	private string _resourceAssetName = "Blastmodelstartgame";

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

	public float PanelAlpha
	{
		get
		{
			if (_oPanelCanvasGroup != null)
			{
				return _oPanelCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (PanelAlpha != value && _oPanelCanvasGroup != null)
			{
				_oPanelCanvasGroup.alpha = value;
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
			string text = transform.name.Replace("(Clone)", "");
			if (!(text == "Panel"))
			{
				if (text == "GameStartImage")
				{
					_oGameStartImage = transform.gameObject;
					_oGameStartImageImage = transform.gameObject.GetComponent<Image>();
				}
			}
			else
			{
				_oPanel = transform.gameObject;
				_oPanelCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
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
