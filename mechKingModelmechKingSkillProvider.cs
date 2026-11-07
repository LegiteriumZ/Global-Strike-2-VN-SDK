using Assets.Sources.Components.GameRule.MechKing;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant.Career;

public class mechKingModelmechKingSkillProvider : ImechKingModelmechKingSkillProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	protected WeaponContext _wpContext;

	private float _flyPower;

	private float _flyNowPower;

	private int _flyMaxPower;

	private float _flySpeed;

	public mechKingModelmechKingSkillProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_wpContext = contexts.weapon;
	}

	public void OnFrame(TimeComponent time)
	{
		updateFly(time);
	}

	private void updateFly(TimeComponent time)
	{
		DynamicProcessUIData byType = getByType(2);
		if (byType != null)
		{
			if (byType.resetrelive)
			{
				byType.resetrelive = false;
				_flyPower = byType._currentPower;
				_flyMaxPower = byType._maxPower;
				_flySpeed = byType._addPowerSpeed;
			}
			else if (_flyMaxPower > 0)
			{
				_flyPower += _flySpeed * (float)time.FrameInterval * 0.001f;
				_flyNowPower = _flyNowPower * 0.8f + _flyPower * 0.2f;
			}
		}
		else
		{
			_flyNowPower = 0f;
			_flyMaxPower = 0;
		}
	}

	private DynamicProcessUIData getByType(int type)
	{
		foreach (DynamicProcessUIData value in _gameRuleContext.reliveProcessData._allUIData.Values)
		{
			if (value._type == type)
			{
				return value;
			}
		}
		return null;
	}

	public string changeFImage()
	{
		string result = "/ui/GameGUIRes/mechKingModel/herogrowup/waitcover";
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		WeaponEntity currentWeaponEntity = _wpContext.currentWeaponEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.GetCareer() == "mechnear")
		{
			result = "/ui/GameGUIRes/mechKingModel/herogrowup/waitrush";
		}
		if (cameraOwnerEntity != null && currentWeaponEntity != null && currentWeaponEntity.hasPower && (cameraOwnerEntity.GetCurrentWeaponEffectLevel() & 0x10) == 0 && currentWeaponEntity.power.Power >= 50)
		{
			result = ((!(cameraOwnerEntity.GetCareer() == "mechnear")) ? "/ui/GameGUIRes/mechKingModel/herogrowup/cover" : "/ui/GameGUIRes/mechKingModel/herogrowup/rush");
		}
		return result;
	}

	public string changeImage()
	{
		string result = "/ui/GameGUIRes/mechKingModel/herogrowup/levelmech1";
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.GetCareer() == "mechnear")
		{
			result = "/ui/GameGUIRes/mechKingModel/herogrowup/levelmech1_1";
		}
		if (_gameRuleContext.mechKingData._Lv > 2)
		{
			result = "/ui/GameGUIRes/common/default";
		}
		else if (_gameRuleContext.mechKingData._Lv > 1)
		{
			result = "/ui/GameGUIRes/mechKingModel/herogrowup/levelmech2";
		}
		return result;
	}

	public float setProgress()
	{
		if (_gameRuleContext.mechKingData._maxexp > 0)
		{
			return (float)_gameRuleContext.mechKingData._exp / (float)_gameRuleContext.mechKingData._maxexp;
		}
		return 0f;
	}

	public float setRotationProgress()
	{
		WeaponEntity currentWeaponEntity = _wpContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower && currentWeaponEntity.power.MaxPower != 0)
		{
			return (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
		}
		return 0f;
	}

	public bool isShow()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null)
		{
			return PlayerCareerConstantUtility.IsMechKing(cameraOwnerEntity.GetCareer());
		}
		return false;
	}

	public float showExp()
	{
		return _gameRuleContext.mechKingData._exp;
	}

	public float showMaxExp()
	{
		return _gameRuleContext.mechKingData._maxexp;
	}

	public float showLv()
	{
		return _gameRuleContext.mechKingData._Lv;
	}

	public float showNumber()
	{
		WeaponEntity currentWeaponEntity = _wpContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			return currentWeaponEntity.power.Power;
		}
		return 0f;
	}

	public float setFlyProgress()
	{
		if (_flyMaxPower > 0)
		{
			return _flyNowPower / (float)_flyMaxPower;
		}
		return 0f;
	}
}
