using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgPowerUpWindowModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ICursorControl
{
	private AcgPowerUpWindowViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private BattleServerContext _battleServerContext;

	private int _index;

	private string _commonpuAffix;

	private string _weaponpuAffix;

	private string _characterpuAffix;

	private string _powerUpFull;

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

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
		_battleServerContext = Contexts.sharedInstance.battleServer;
		_viewModel.ShowShow = false;
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgPowerUpWindowViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowShow = false;
		_commonpuAffix = ScriptLocalization.Get("ACG_COMMONPU_AFFIX");
		_weaponpuAffix = ScriptLocalization.Get("ACG_WEAPONPU_AFFIX");
		_characterpuAffix = ScriptLocalization.Get("ACG_CHARACTERPU_AFFIX");
		_powerUpFull = ScriptLocalization.Get("ACG_POWERUP_FULL");
		for (_index = 0; _index < 3; _index++)
		{
			int _indexTmp = _index;
			_viewModel.CreateTriggerEntry(_viewModel.GetPowerUpTriggers(_index), EventTriggerType.PointerEnter, delegate
			{
				_viewModel.SelectedFrameShow = true;
				_viewModel.SelectedFrameAnchoredposition = new Vector2(-380 + 380 * _indexTmp, 50f);
				_viewModel.CallPowerUpNtvsize(_indexTmp);
			});
			_viewModel.CreateTriggerEntry(_viewModel.GetPowerUpTriggers(_index), EventTriggerType.PointerExit, delegate
			{
				_viewModel.CallPowerUpNtvsize(_indexTmp);
			});
			_viewModel.CreateTriggerEntry(_viewModel.GetPowerUpTriggers(_index), EventTriggerType.PointerClick, delegate
			{
				if (_gameRuleContext.hasAcgPowerUp && _gameRuleContext.acgPowerUp.Ids[_indexTmp] != -1)
				{
					ChooseSkillRequest message = new ChooseSkillRequest
					{
						SkillId = _gameRuleContext.acgPowerUp.Ids[_indexTmp]
					};
					_battleServerContext.battleServer.Server.SendTcpMessage(131, message);
					_viewModel.ShowShow = false;
				}
			});
		}
		NotifyManager.MakeNotify(103, GetAcgPowerUp, SetAcgPowerUp);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_CameraOwner_AcgPlayerCommonPU, SetCommonPUNum, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_CameraOwner_AcgPlayerCharacterPU, SetCharacterPUNum, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_CameraOwner_AcgPlayerWeaponPU, SetWeaponPUNum, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetWindowShow, SetWindowShow);
	}

	private bool GetWindowShow()
	{
		return _gameRuleContext.acgPowerUp.CanShow;
	}

	private void SetWindowShow(bool oldBool, bool newBool)
	{
		if (!newBool)
		{
			_viewModel.ShowShow = false;
		}
	}

	private void SetAcgPowerUp(int oldInt, int newInt)
	{
		if (!_gameRuleContext.hasAcgPowerUp)
		{
			return;
		}
		for (_index = 0; _index < _gameRuleContext.acgPowerUp.Ids.Length; _index++)
		{
			int _indexTmp = _index;
			if (_gameRuleContext.acgPowerUp.Ids[_index] == -1)
			{
				base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/TabWindow/PowerUpCommonIcon.png", delegate(Sprite sprite)
				{
					_viewModel.SetIconSprite(_indexTmp, sprite);
				});
				_viewModel.SetNameString(_index, "");
				_viewModel.SetDiscriptionString(_index, _powerUpFull);
				base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PowerUpWindow/Gray.png", delegate(Sprite sprite)
				{
					_viewModel.GetPowerUpImage(_indexTmp).sprite = sprite;
				});
				base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PowerUpWindow/GrayHighlight.png", delegate(Sprite sprite)
				{
					SpriteState spriteState4 = _viewModel.GetPowerUpButton(_indexTmp).spriteState;
					spriteState4.highlightedSprite = sprite;
					_viewModel.GetPowerUpButton(_indexTmp).spriteState = spriteState4;
				});
			}
			else
			{
				base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PowerUpIcon/Large/" + _gameRuleContext.acgPowerUp.Ids[_index] + ".png", delegate(Sprite sprite)
				{
					_viewModel.SetIconSprite(_indexTmp, sprite);
				});
				AcgPowerUpsTable.Row row = AcgInfoLoader.Instance.AcgPowerUpsTable.Find_Id(_gameRuleContext.acgPowerUp.Ids[_index]);
				_viewModel.SetNameString(_index, row.Name);
				_viewModel.SetDiscriptionString(_index, row.Discription);
				switch (row.Type)
				{
				case AcgPowerUpsTable.AcgPowerUpType.Common:
					base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PowerUpWindow/Gray.png", delegate(Sprite sprite)
					{
						_viewModel.GetPowerUpImage(_indexTmp).sprite = sprite;
					});
					base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PowerUpWindow/GrayHighlight.png", delegate(Sprite sprite)
					{
						SpriteState spriteState = _viewModel.GetPowerUpButton(_indexTmp).spriteState;
						spriteState.highlightedSprite = sprite;
						_viewModel.GetPowerUpButton(_indexTmp).spriteState = spriteState;
					});
					break;
				case AcgPowerUpsTable.AcgPowerUpType.Weapon:
					base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PowerUpWindow/Blue.png", delegate(Sprite sprite)
					{
						_viewModel.GetPowerUpImage(_indexTmp).sprite = sprite;
					});
					base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PowerUpWindow/BlueHighlight.png", delegate(Sprite sprite)
					{
						SpriteState spriteState2 = _viewModel.GetPowerUpButton(_indexTmp).spriteState;
						spriteState2.highlightedSprite = sprite;
						_viewModel.GetPowerUpButton(_indexTmp).spriteState = spriteState2;
					});
					break;
				case AcgPowerUpsTable.AcgPowerUpType.Character:
					base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PowerUpWindow/Orange.png", delegate(Sprite sprite)
					{
						_viewModel.GetPowerUpImage(_indexTmp).sprite = sprite;
					});
					base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PowerUpWindow/OrangeHighlight.png", delegate(Sprite sprite)
					{
						SpriteState spriteState3 = _viewModel.GetPowerUpButton(_indexTmp).spriteState;
						spriteState3.highlightedSprite = sprite;
						_viewModel.GetPowerUpButton(_indexTmp).spriteState = spriteState3;
					});
					break;
				}
			}
		}
		_viewModel.ShowShow = true;
	}

	private void SetCommonPUNum(int oldInt, int newInt)
	{
		_viewModel.CommonTextString = _commonpuAffix + newInt;
	}

	private void SetCharacterPUNum(int oldInt, int newInt)
	{
		_viewModel.CharacterTextString = _characterpuAffix + newInt;
	}

	private void SetWeaponPUNum(int oldInt, int newInt)
	{
		_viewModel.WeaponTextString = _weaponpuAffix + newInt;
	}

	private int GetAcgPowerUp()
	{
		return 0;
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow && CloseDelay <= 0)
		{
			return 0;
		}
		return 1;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
