using System.Collections.Generic;
using Assets.Scripts.ResScripts.Refrenceless.DyVersion;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class ReportAlertCellViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oReportCell;

	private Image _oReportCellImage;

	private Button _oReportCellButton;

	private GameObject _oSelected;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oGou;

	private Image _oGouImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "ReportAlertCell";

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

	public bool ReportCellShow
	{
		get
		{
			if (_oReportCell != null)
			{
				return _oReportCell.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReportCellShow != value && _oReportCell != null)
			{
				_oReportCell.SetObjectActive(value);
			}
		}
	}

	public bool ReportCellEnabled
	{
		get
		{
			if (_oReportCellImage != null)
			{
				return _oReportCellImage.enabled;
			}
			return false;
		}
		set
		{
			if (ReportCellEnabled != value && _oReportCellImage != null)
			{
				_oReportCellImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public Button.ButtonClickedEvent ReportCellClicked
	{
		get
		{
			if (_oReportCellButton != null)
			{
				return _oReportCellButton.onClick;
			}
			return null;
		}
		set
		{
			if (ReportCellClicked != value && _oReportCellButton != null)
			{
				_oReportCellButton.onClick = value;
			}
		}
	}

	public bool SelectedShow
	{
		get
		{
			if (_oSelected != null)
			{
				return _oSelected.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedShow != value && _oSelected != null)
			{
				_oSelected.SetObjectActive(value);
			}
		}
	}

	public bool GouShow
	{
		get
		{
			if (_oGou != null)
			{
				return _oGou.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GouShow != value && _oGou != null)
			{
				_oGou.SetObjectActive(value);
			}
		}
	}

	public string PlayerNameString
	{
		get
		{
			if (_oPlayerNameText != null)
			{
				return _oPlayerNameText.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString != value && _oPlayerNameText != null)
			{
				_oPlayerNameText.text = value;
			}
		}
	}

	public Color PlayerNameTextcolor
	{
		get
		{
			if (_oPlayerNameText != null)
			{
				return _oPlayerNameText.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor != value && _oPlayerNameText != null)
			{
				_oPlayerNameText.color = value;
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
			case "ReportAlertCell":
				_oReportCell = transform.gameObject;
				_oReportCellImage = transform.gameObject.GetComponent<Image>();
				_oReportCellButton = transform.gameObject.GetComponent<Button>();
				break;
			case "Selected":
				_oSelected = transform.gameObject;
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "gou":
				_oGou = transform.gameObject;
				_oGouImage = transform.gameObject.GetComponent<Image>();
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
