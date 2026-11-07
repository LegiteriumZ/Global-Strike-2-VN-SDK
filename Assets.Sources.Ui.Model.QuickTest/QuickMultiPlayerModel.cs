using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ForUiTest;
using Assets.Sources.Ui.ForUiTest.MultiPlayer;
using Assets.Sources.Ui.ViewModel.QuickTest;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Ui.Model.QuickTest;

[GameUiTest]
public class QuickMultiPlayerModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ICursorControl, ISetPlayerContext
{
	private QuickMultiPlayerViewModel _viewModel;

	private Camera _mainCamera;

	private Camera _screenCamera;

	private List<MultiPlayerBattleServer> _clientList = new List<MultiPlayerBattleServer>();

	private const int MaxCount = 16;

	private int _closeDelay;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay
	{
		get
		{
			return _closeDelay;
		}
		set
		{
			_closeDelay = value;
		}
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new QuickMultiPlayerViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		AbstractModel.InvokeUpdateHandler();
		UpdateChips();
		MultiPlayerServerManager.Update();
		if (!_viewModel.ScreenShow)
		{
			return;
		}
		List<int> connectSelected = MultiPlayerServerManager.ConnectSelected;
		if (connectSelected.Count > 0)
		{
			PlayerEntityData playerData = MultiPlayerServerManager.Get(connectSelected[0]).PlayerData;
			if (playerData != null)
			{
				PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(playerData.Id);
				Vector3 vector = entityWithEntityId?.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()) ?? new Vector3(playerData.X, playerData.Y, playerData.Z);
				Vector3 vector2 = AngleUtility.AnglesToVector(playerData.ViewYaw, playerData.ViewPitch) * -1f * 300f;
				int num = ((playerData.DuckState == 3) ? ViewHeight.GetNormalViewHeight(playerData.Career) : ViewHeight.GetDuckViewHeight(playerData.Career));
				_screenCamera.transform.position = VectorCoordConverter.SsjjToUnity(vector + vector2 + new Vector3(0f, 0f, num));
				_screenCamera.fieldOfView = FovUtility.SsjjFovToUnityFov(playerData.Fov, Screen.width, Screen.height);
				_screenCamera.transform.localEulerAngles = YawPitchUtility.SsjjYawPitchRollToUnityEularAngle(playerData.ViewYaw, playerData.ViewPitch, playerData.PunchRoll);
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ScreenShow = false;
		_viewModel.UIShow = false;
		_viewModel.PositionShow = false;
		_mainCamera = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera;
		_screenCamera = _viewModel.ScreenObj.transform.Find("Camera").GetComponent<Camera>();
		_viewModel.AddClicked.AddListener(delegate
		{
			MultiPlayerServerManager.Add();
		});
		_viewModel.MyselfClicked.AddListener(delegate
		{
			MultiPlayerServerManager.ConnectSelected.Clear();
		});
		_viewModel.AllSelectClicked.AddListener(delegate
		{
			MultiPlayerServerManager.ConnectSelected.Clear();
			foreach (MultiPlayerBattleServer item in MultiPlayerServerManager.GetList())
			{
				MultiPlayerServerManager.ConnectSelected.Add(item.ConnectionId);
			}
		});
		_viewModel.SimpleCopyTogglechanged.AddListener(delegate(bool isOn)
		{
			MultiPlayerServerManager.SimpleCopy = isOn;
		});
		_viewModel.SelfOperateTogglechanged.AddListener(delegate(bool isOn)
		{
			MultiPlayerServerManager.IsSelfMove = isOn;
		});
		_viewModel.ShowScreenClicked.AddListener(delegate
		{
			_viewModel.ScreenShow = !_viewModel.ScreenShow;
		});
		_viewModel.HideScreenClicked.AddListener(delegate
		{
			_viewModel.ScreenShow = false;
		});
		_viewModel.CloseBtnClicked.AddListener(delegate
		{
			_viewModel.UIShow = false;
		});
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(GetClientList);
		for (int j = 0; j < 16; j++)
		{
			_viewModel.SetPlayerShow(j + 1, value: false);
			_viewModel.SetSelectedShow(j + 1, value: false);
			_viewModel.SetPosShow(j + 1, value: false);
			_viewModel.SetFlagShow(j + 1, value: false);
			listNotify.AddEvent<MultiPlayerBattleServer, string>("PlayerName", GetPlayerName, SetPlayerName, j);
			listNotify.AddEvent<MultiPlayerBattleServer, bool>("Selected", GetSelected, SetSelected, j);
			listNotify.AddEvent<MultiPlayerBattleServer, Vector3>("Position", GetPos, SetPos, j);
			int i1 = j;
			_viewModel.GetLeaveClicked(j + 1).AddListener(delegate
			{
				if (i1 < _clientList.Count && _clientList[i1] != null)
				{
					MultiPlayerServerManager.Remove(_clientList[i1].ConnectionId);
				}
			});
			_viewModel.GetPlayerClicked(j + 1).AddListener(delegate
			{
				if (i1 < _clientList.Count && _clientList[i1] != null)
				{
					if (MultiPlayerServerManager.ConnectSelected.Contains(_clientList[i1].ConnectionId))
					{
						MultiPlayerServerManager.ConnectSelected.Remove(_clientList[i1].ConnectionId);
					}
					else
					{
						MultiPlayerServerManager.ConnectSelected.Add(_clientList[i1].ConnectionId);
					}
				}
			});
		}
	}

	private void SetPos(MultiPlayerBattleServer val, int idx, Vector3 oldfs, Vector3 newfs, ElementStatus status)
	{
		_viewModel.SetPosPosition(idx + 1, newfs);
	}

	private Vector3 GetPos(MultiPlayerBattleServer val, int idx)
	{
		if (val != null && val.PlayerData != null)
		{
			Vector3 vector = new Vector3(0f - val.PlayerData.Y, val.PlayerData.Z, val.PlayerData.X);
			Vector3 vector2 = (Vector3)RectTransformUtility.WorldToScreenPoint(_mainCamera, vector) - new Vector3(Screen.width, Screen.height) / 2f;
			float num = (float)(-Screen.width / 2) + _viewModel.GetPosSize(idx + 1).x / 2f;
			if (vector2.x < num)
			{
				vector2.x = num;
			}
			float num2 = (float)(Screen.width / 2) - _viewModel.GetPosSize(idx + 1).x / 2f;
			if (vector2.x > num2)
			{
				vector2.x = num2;
			}
			float num3 = (float)(Screen.height / 2) - _viewModel.GetPosSize(idx + 1).y / 2f;
			if (vector2.y > num3)
			{
				vector2.y = num3;
			}
			float num4 = (float)(-Screen.height / 2) + _viewModel.GetPosSize(idx + 1).y / 2f;
			if (vector2.y < num4)
			{
				vector2.y = num4;
			}
			if (!(Vector3.Dot(vector - _mainCamera.transform.position, _mainCamera.transform.forward) > 0f))
			{
				return new Vector3(-(int)vector2.x, (int)num4, (int)vector2.z);
			}
			return new Vector3((int)vector2.x, (int)vector2.y, (int)vector2.z);
		}
		return Vector3.zero;
	}

	private void SetSelected(MultiPlayerBattleServer val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		_viewModel.SetSelectedShow(idx + 1, newfs);
		_viewModel.SetFlagShow(idx + 1, newfs);
	}

	private bool GetSelected(MultiPlayerBattleServer val, int idx)
	{
		if (val != null)
		{
			return MultiPlayerServerManager.ConnectSelected.Contains(val.ConnectionId);
		}
		return false;
	}

	private void SetPlayerName(MultiPlayerBattleServer val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		if (string.IsNullOrEmpty(newfs))
		{
			_viewModel.SetPlayerShow(idx + 1, value: false);
			_viewModel.SetPosShow(idx + 1, value: false);
			return;
		}
		_viewModel.SetPlayerShow(idx + 1, value: true);
		_viewModel.SetNameTextString(idx + 1, newfs);
		_viewModel.SetPosString(idx + 1, newfs);
		_viewModel.SetPosShow(idx + 1, value: true);
		if (_playerContext.myPlayerEntity.GetTeam() == val.PlayerData.Team)
		{
			_viewModel.SetNameTextTextcolor(idx + 1, Color.blue);
			_viewModel.SetPosTextcolor(idx + 1, Color.blue);
		}
		else
		{
			_viewModel.SetNameTextTextcolor(idx + 1, Color.red);
			_viewModel.SetPosTextcolor(idx + 1, Color.red);
		}
	}

	private string GetPlayerName(MultiPlayerBattleServer val, int idx)
	{
		if (val != null && val.PlayerData != null)
		{
			return val.PlayerData.PlayerName;
		}
		return "";
	}

	private List<MultiPlayerBattleServer> GetClientList()
	{
		_clientList.Clear();
		_clientList.AddRange(MultiPlayerServerManager.GetList());
		while (_clientList.Count < 16)
		{
			_clientList.Add(null);
		}
		return _clientList;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (NetRecordManager.Playing)
		{
			return false;
		}
		if (key == KeyCode.F12)
		{
			_viewModel.UIShow = !_viewModel.UIShow;
			_viewModel.PositionShow = true;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public int GetCursorState()
	{
		if (!_viewModel.UIShow)
		{
			return 0;
		}
		return 1024;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
