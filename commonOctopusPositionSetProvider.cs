using Assets.Sources.Components.Time;
using UnityEngine;
using share.constant;

public class commonOctopusPositionSetProvider : IcommonOctopusPositionSetProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	private const float remainTime = 3000f;

	private float _showTime;

	private bool _showVisible;

	private float _posX;

	private float _posY;

	public commonOctopusPositionSetProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
		_showTime -= time.FrameInterval;
	}

	public bool getVisible()
	{
		if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.OCTOPUS_EFFECT_P1.ID))
		{
			if (!_showVisible)
			{
				_showVisible = true;
				_showTime = 3000f;
				_posX = Random.Range(0f, 1f) * (float)(Display.main.systemWidth - 200);
				_posY = Random.Range(0f, 1f) * (float)(Display.main.systemHeight - 226);
			}
			return _showTime > 0f;
		}
		_showVisible = false;
		return _showVisible;
	}

	public float setShowX()
	{
		return _posX;
	}

	public float setShowY()
	{
		return _posY;
	}

	public float setProgress()
	{
		return 1f - _showTime / 3000f;
	}

	public float setImageY()
	{
		return (1f - _showTime / 3000f) * 74f;
	}
}
