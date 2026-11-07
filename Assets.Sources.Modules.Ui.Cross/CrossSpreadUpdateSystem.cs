using Assets.Sources.Components.Time;
using Assets.Sources.Config;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Ui.Cross;

public class CrossSpreadUpdateSystem : IPlaybackSystem
{
	private CrossContext _crossContext;

	private PlayerContext _playerContext;

	private WeaponContext _weaponContext;

	private TimeComponent _time;

	private WeaponEntity _weaponEntity;

	private PlayerEntity _cameraOwner;

	public CrossSpreadUpdateSystem(Contexts contexts)
	{
		_crossContext = contexts.cross;
		_playerContext = contexts.player;
		_weaponContext = contexts.weapon;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (_playerContext.isCameraOwner && _weaponContext.isCurrentWeapon)
		{
			_weaponEntity = _weaponContext.currentWeaponEntity;
			if (_weaponEntity.hasBasicInfo)
			{
				_cameraOwner = _playerContext.cameraOwnerEntity;
				ProcessSpread();
			}
		}
	}

	public void ProcessSpread()
	{
		_crossContext.crossSpread.UpdateFrameInterval += _time.FrameInterval;
		if (_crossContext.crossSpread.UpdateFrameInterval < 30)
		{
			return;
		}
		_crossContext.crossSpread.UpdateFrameInterval = 0;
		float num = 3f;
		float num2 = 0f;
		if (GameSetting.Config.StaticCross == 1)
		{
			_crossContext.crossSpread.RendSpread = num;
			UpdateSpread();
			return;
		}
		string weaponName = _weaponEntity.basicInfo.Data.WeaponName;
		if (weaponName == "deagle")
		{
			num += 3f;
		}
		if (_cameraOwner.move.Moving)
		{
			num2 = 5f;
		}
		if (!_cameraOwner.move.OnGround)
		{
			num2 += 5f;
		}
		if (_cameraOwner.move.DuckState == 0 || _cameraOwner.move.DuckState == 1)
		{
			num2 -= 2f;
		}
		num += _cameraOwner.punchOrientation.PunchPitch * 2.5f + num2;
		num = ((num > 40f) ? 40f : num);
		num *= GetDurableAccurate(_weaponEntity.basicInfo.Data.Durable);
		_crossContext.crossSpread.RendSpread -= (_crossContext.crossSpread.RendSpread - num) * 0.618f;
		UpdateSpread();
	}

	private void UpdateSpread()
	{
		int num = (int)_crossContext.crossSpread.RendSpread;
		_crossContext.crossSpread.Left = -num - 2;
		_crossContext.crossSpread.Right = -_crossContext.crossSpread.Left;
		_crossContext.crossSpread.Up = num + 2;
		_crossContext.crossSpread.Down = -_crossContext.crossSpread.Up;
		_crossContext.crossSpread.Scale = 1f * (float)(20 + num) / 46f;
	}

	public float GetDurableAccurate(int durable)
	{
		return durable switch
		{
			2 => 1.1f, 
			3 => 1.25f, 
			_ => 1f, 
		};
	}
}
