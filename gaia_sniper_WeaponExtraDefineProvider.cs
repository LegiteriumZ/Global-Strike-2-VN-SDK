using Assets.Sources.Components.Time;

public class gaia_sniper_WeaponExtraDefineProvider : Abstractgaia_sniper_WeaponExtraDefineProvider
{
	private WeaponEntity _weapon;

	private PlayerEntity _player;

	private int showTime;

	private bool lastState;

	public override void OnFrame(TimeComponent time)
	{
		_player = _playerContext.cameraOwnerEntity;
		if (_player != null)
		{
			bool flag = (_player.GetCurrentWeaponEffectLevel() & 0x200) > 0;
			if (lastState != flag)
			{
				lastState = flag;
				showTime = 3000;
			}
		}
		if (showTime > 0)
		{
			showTime -= time.FrameInterval;
		}
	}

	public override bool updateSkillEShow()
	{
		return showTime > 0;
	}
}
