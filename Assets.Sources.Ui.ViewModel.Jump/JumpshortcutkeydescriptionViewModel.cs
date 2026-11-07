using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Jump;

[GameUiTest]
public class JumpshortcutkeydescriptionViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oDescriptionImage;

	private Image _oDescriptionImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/jump";

	private string _resourceAssetName = "Jumpshortcutkeydescription";

	public Sprite DescriptionImageSprite
	{
		get
		{
			if (_oDescriptionImageImage != null)
			{
				return _oDescriptionImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (DescriptionImageSprite != value && _oDescriptionImageImage != null)
			{
				_oDescriptionImageImage.sprite = value;
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
			if (text == "DescriptionImage")
			{
				_oDescriptionImage = transform.gameObject;
				_oDescriptionImageImage = transform.gameObject.GetComponent<Image>();
			}
		}
	}

	public void DescriptionImageNtvsize()
	{
		if (_oDescriptionImageImage != null)
		{
			_oDescriptionImageImage.SetNativeSize();
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
