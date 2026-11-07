using Assets.Sources.Components.Time;
using NetData;
using NotifyEvent;
using share.constant;

public class commonwingflyProvider : IcommonwingflyProvider, IModuleProvider
{
	private WeaponContext _weaponContext;

	private WeaponEntity _currentWeapon;

	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	private int showTime;

	private int skillId;

	public commonwingflyProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_weaponContext = contexts.weapon;
		NotifyManager.MakeNotifyClass(155, Getskill, SetSkill);
	}

	public SkillInfoData Getskill()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.hasSkill && cameraOwnerEntity.skill.Skills != null)
		{
			cameraOwnerEntity.skill.Skills.TryGetValue(137, out var value);
			if (value != null && value.SkillName == 29999)
			{
				return value;
			}
		}
		return null;
	}

	public void SetSkill(SkillInfoData ov, SkillInfoData infoDatas)
	{
		if (infoDatas != null)
		{
			showTime = infoDatas.CurrentCdTime;
			skillId = infoDatas.SkillName;
		}
	}

	public void OnFrame(TimeComponent time)
	{
		_currentWeapon = _weaponContext.currentWeaponEntity;
		if (showTime > 0)
		{
			showTime -= time.FrameInterval;
		}
	}

	public bool showVisible()
	{
		if (skillId == 29999)
		{
			return true;
		}
		return false;
	}

	public bool showWing()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity.move.wingSpeedEN >= cameraOwnerEntity.move.wingMaxSpeedEN)
		{
			return false;
		}
		if (skillId == 29999)
		{
			return true;
		}
		return false;
	}

	public bool showCtrl()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (skillId == 29999 && showTime <= 0 && !cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.keepfly_skill_flying.ID))
		{
			return true;
		}
		return false;
	}

	public bool showS()
	{
		if (_playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.keepfly_skill_flying.ID))
		{
			return true;
		}
		return false;
	}

	public float showProgress()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity.move.wingMaxSpeedEN > 0)
		{
			return (float)cameraOwnerEntity.move.wingSpeedEN / (float)cameraOwnerEntity.move.wingMaxSpeedEN;
		}
		return 0f;
	}
}
