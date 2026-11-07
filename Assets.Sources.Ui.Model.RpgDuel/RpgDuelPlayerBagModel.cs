using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgDuel;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.RpgDuel;

[GameUiTest]
public class RpgDuelPlayerBagModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ISetBattleServerContext, ICursorControl, IKeyboardResponder
{
	private RpgDuelPlayerBagViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private BattleServerContext _battleServerContext;

	private int _currentIndex;

	private AssetInfo _defaultSprite = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/default.png");

	private ActiveChip _bagTimeCounter;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgDuelPlayerBagViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void OnGameobjectInitialized()
	{
		base.OnGameobjectInitialized();
		_viewModel.SetSelectedSlotShow(1, value: false);
		_viewModel.SetSelectedSlotShow(2, value: false);
		_viewModel.SetSelectedSlotShow(3, value: false);
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers1, EventTriggerType.PointerEnter, delegate
		{
			PreviewBag(0);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers2, EventTriggerType.PointerEnter, delegate
		{
			PreviewBag(1);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers3, EventTriggerType.PointerEnter, delegate
		{
			PreviewBag(2);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers1, EventTriggerType.PointerUp, delegate
		{
			SelectBag(0);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers2, EventTriggerType.PointerUp, delegate
		{
			SelectBag(1);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SlotTriggers3, EventTriggerType.PointerUp, delegate
		{
			SelectBag(2);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers1, EventTriggerType.PointerEnter, delegate
		{
			PreviewBag(0);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers2, EventTriggerType.PointerEnter, delegate
		{
			PreviewBag(1);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers3, EventTriggerType.PointerEnter, delegate
		{
			PreviewBag(2);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers1, EventTriggerType.PointerUp, delegate
		{
			SelectBag(0);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers2, EventTriggerType.PointerUp, delegate
		{
			SelectBag(1);
		});
		_viewModel.CreateTriggerEntry(_viewModel.SelectedSlotTriggers3, EventTriggerType.PointerUp, delegate
		{
			SelectBag(2);
		});
	}

	private void PreviewBag(int index)
	{
		_currentIndex = index;
		SetButtons(index);
		if (_gameRuleContext.hasRpgDuel && _gameRuleContext.rpgDuel.BagData.Count > index)
		{
			RoleRecipeData roleRecipeData = _gameRuleContext.rpgDuel.BagData[index];
			if (string.IsNullOrEmpty(roleRecipeData.WeaponName) && string.IsNullOrEmpty(roleRecipeData.WeaponSkinName))
			{
				_viewModel.NoWeaponShow = true;
				this.GetLoader().RetriveSprite(_defaultSprite, delegate(Sprite sprite)
				{
					_viewModel.WeaponSprite = sprite;
					_viewModel.WeaponNtvsize();
				});
			}
			else
			{
				_viewModel.NoWeaponShow = false;
				this.GetLoader().RetriveSprite(GetWeaponSprite(roleRecipeData.WeaponName, roleRecipeData.WeaponSkinName), delegate(Sprite sprite)
				{
					_viewModel.WeaponSprite = sprite;
					_viewModel.WeaponNtvsize();
				});
			}
			if (string.IsNullOrEmpty(roleRecipeData.Career) && string.IsNullOrEmpty(roleRecipeData.CareerSkin))
			{
				_viewModel.NoPlayerCareerShow = true;
				this.GetLoader().RetriveSprite(_defaultSprite, delegate(Sprite sprite)
				{
					_viewModel.PlayerCareerSprite = sprite;
				});
			}
			else
			{
				_viewModel.NoPlayerCareerShow = false;
				this.GetLoader().RetriveSprite(GetPlayerCareer(roleRecipeData.Career, roleRecipeData.CareerSkin), delegate(Sprite sprite)
				{
					_viewModel.PlayerCareerSprite = sprite;
				});
			}
			if (string.IsNullOrEmpty(roleRecipeData.TacticalWeaponName) && string.IsNullOrEmpty(roleRecipeData.TacticalWeaponSkinName))
			{
				_viewModel.NoTacticalWeaponShow = true;
				this.GetLoader().RetriveSprite(_defaultSprite, delegate(Sprite sprite)
				{
					_viewModel.TacticalWeaponSprite = sprite;
					_viewModel.TacticalWeaponNtvsize();
				});
			}
			else
			{
				_viewModel.NoTacticalWeaponShow = false;
				this.GetLoader().RetriveSprite(GetWeaponSprite(roleRecipeData.TacticalWeaponName, roleRecipeData.TacticalWeaponSkinName), delegate(Sprite sprite)
				{
					_viewModel.TacticalWeaponSprite = sprite;
					_viewModel.TacticalWeaponNtvsize();
				});
			}
			if (string.IsNullOrEmpty(roleRecipeData.DragoonCodeName))
			{
				_viewModel.NoDragonShow = true;
				this.GetLoader().RetriveSprite(_defaultSprite, delegate(Sprite sprite)
				{
					_viewModel.DragonSprite = sprite;
				});
			}
			else
			{
				_viewModel.NoDragonShow = false;
				this.GetLoader().RetriveSprite(GetDragonSprite(roleRecipeData.DragoonCodeName), delegate(Sprite sprite)
				{
					_viewModel.DragonSprite = sprite;
				});
			}
		}
		else
		{
			_viewModel.NoWeaponShow = true;
			_viewModel.NoPlayerCareerShow = true;
			_viewModel.NoTacticalWeaponShow = true;
			_viewModel.NoDragonShow = true;
			this.GetLoader().RetriveSprite(_defaultSprite, delegate(Sprite sprite)
			{
				_viewModel.WeaponSprite = sprite;
			});
			this.GetLoader().RetriveSprite(_defaultSprite, delegate(Sprite sprite)
			{
				_viewModel.PlayerCareerSprite = sprite;
			});
			this.GetLoader().RetriveSprite(_defaultSprite, delegate(Sprite sprite)
			{
				_viewModel.TacticalWeaponSprite = sprite;
			});
			this.GetLoader().RetriveSprite(_defaultSprite, delegate(Sprite sprite)
			{
				_viewModel.DragonSprite = sprite;
			});
		}
	}

	private AssetInfo GetDragonSprite(string dragonName)
	{
		return new AssetInfo("ui/halfloadedres/dragon", $"Assets/Res/Assets/ui/GameGUIRes/halfloadedres/dragon/{dragonName}.png");
	}

	private AssetInfo GetPlayerCareer(string careerName, string careerSkinName)
	{
		if (!string.IsNullOrEmpty(careerSkinName))
		{
			return new AssetInfo("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfloadedres/pveplayerstate/{careerSkinName}.png");
		}
		return new AssetInfo("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfloadedres/pveplayerstate/{careerName}.png");
	}

	private AssetInfo GetWeaponSprite(string weaponName, string skinName)
	{
		if (!string.IsNullOrEmpty(skinName))
		{
			return new AssetInfo("weaponskin/" + skinName, string.Format("Assets/Res/Assets/weaponskin/{0}/ui/{0}.png", skinName));
		}
		return new AssetInfo("weapon/" + weaponName, string.Format("Assets/Res/Assets/weapon/{0}/ui/{0}.png", weaponName));
	}

	private void SelectBag(int index)
	{
		if (_gameRuleContext.hasRpgDuel && index < _gameRuleContext.rpgDuel.BagData.Count && !_gameRuleContext.rpgDuel.BagData[index].IsUsed)
		{
			ProtoIntData protoIntData = new ProtoIntData();
			protoIntData.Data = _gameRuleContext.rpgDuel.BagData[index].Id;
			_battleServerContext.battleServer.Server.SendTcpMessage(120, protoIntData);
			_bagTimeCounter.Time = 0;
			_gameRuleContext.rpgDuel.IsBagShow = false;
		}
	}

	private void SetButtons(int index)
	{
		switch (index)
		{
		case 0:
			_viewModel.SlotShow1 = false;
			_viewModel.SlotShow2 = true;
			_viewModel.SlotShow3 = true;
			_viewModel.SelectedSlotShow1 = true;
			_viewModel.SelectedSlotShow2 = false;
			_viewModel.SelectedSlotShow3 = false;
			break;
		case 1:
			_viewModel.SlotShow1 = true;
			_viewModel.SlotShow2 = false;
			_viewModel.SlotShow3 = true;
			_viewModel.SelectedSlotShow1 = false;
			_viewModel.SelectedSlotShow2 = true;
			_viewModel.SelectedSlotShow3 = false;
			break;
		case 2:
			_viewModel.SlotShow1 = true;
			_viewModel.SlotShow2 = true;
			_viewModel.SlotShow3 = false;
			_viewModel.SelectedSlotShow1 = false;
			_viewModel.SelectedSlotShow2 = false;
			_viewModel.SelectedSlotShow3 = true;
			break;
		}
		List<RoleRecipeData> bagData = _gameRuleContext.rpgDuel.BagData;
		if (bagData == null || bagData.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < bagData.Count; i++)
		{
			if (bagData[i].IsUsed)
			{
				_viewModel.SetDisabledSlotShow(i + 1, value: true);
				_viewModel.SetSlotShow(i + 1, value: false);
				_viewModel.SetSelectedSlotShow(i + 1, value: false);
			}
			else
			{
				_viewModel.SetDisabledSlotShow(i + 1, value: false);
			}
		}
		for (int j = bagData.Count; j < 3; j++)
		{
			_viewModel.SetDisabledSlotShow(j + 1, value: true);
			_viewModel.SetSlotShow(j + 1, value: false);
			_viewModel.SetSelectedSlotShow(j + 1, value: false);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(IsBagShow, SetBagShow, null, initinvoke: true);
	}

	private bool IsBagShow()
	{
		if (_gameRuleContext.hasRpgDuel)
		{
			return _gameRuleContext.rpgDuel.IsBagShow;
		}
		return false;
	}

	private void SetBagShow(bool oldVal, bool newVal)
	{
		_viewModel.ShowShow = newVal;
		if (!newVal || !_gameRuleContext.hasRpgDuel)
		{
			_bagTimeCounter.Time = 0;
			return;
		}
		_bagTimeCounter.Time = _gameRuleContext.rpgDuel.RemainTime;
		List<RoleRecipeData> bagData = _gameRuleContext.rpgDuel.BagData;
		if (bagData == null || bagData.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < bagData.Count; i++)
		{
			if (!bagData[i].IsUsed)
			{
				PreviewBag(i);
				SetButtons(i);
				break;
			}
		}
	}

	private void InitChips()
	{
		_bagTimeCounter = new ActiveChip();
	}

	private void UpdateChips()
	{
		if (_bagTimeCounter.Time > 0)
		{
			_gameRuleContext.rpgDuel.IsBagShow = _bagTimeCounter.Update(_timeComponent);
			_viewModel.ChangeCountString = (_bagTimeCounter.Time / 1000).ToString();
		}
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 4;
	}

	public int GetForbidButtons()
	{
		return 175;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (_battleRoomContext.roomData.Data.RaceType != 15012)
		{
			return false;
		}
		if (_bagTimeCounter.Time > 0)
		{
			if (key.CheckEqualKeyCode(KeyCode.Alpha1))
			{
				SelectBag(0);
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha2))
			{
				SelectBag(1);
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha3))
			{
				SelectBag(2);
			}
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
}
