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
public class RpgExploreTargetViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRewardText;

	private Text _oRewardTextText;

	private GameObject _oTips;

	private Image _oTipsImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgExploreTarget";

	public string RewardTextString
	{
		get
		{
			if (_oRewardTextText != null)
			{
				return _oRewardTextText.text;
			}
			return null;
		}
		set
		{
			if (RewardTextString != value && _oRewardTextText != null)
			{
				_oRewardTextText.text = value;
			}
		}
	}

	public Sprite TipsSprite
	{
		get
		{
			if (_oTipsImage != null)
			{
				return _oTipsImage.sprite;
			}
			return null;
		}
		set
		{
			if (TipsSprite != value && _oTipsImage != null)
			{
				_oTipsImage.sprite = value;
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
			if (!(text == "RewardText"))
			{
				if (text == "Tips")
				{
					_oTips = transform.gameObject;
					_oTipsImage = transform.gameObject.GetComponent<Image>();
				}
			}
			else
			{
				_oRewardText = transform.gameObject;
				_oRewardTextText = transform.gameObject.GetComponent<Text>();
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
