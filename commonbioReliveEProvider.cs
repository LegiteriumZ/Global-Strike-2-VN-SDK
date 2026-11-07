using Assets.Sources.Components.Time;
using share.constant;

public class commonbioReliveEProvider : IcommonbioReliveEProvider, IModuleProvider
{
	protected PlayerContext _playerContext;

	private bool _isShow;

	private int _remainTime;

	public commonbioReliveEProvider(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_isShow)
		{
			_remainTime += time.FrameInterval;
		}
	}

	public bool showTip()
	{
		if (_isShow && _remainTime >= 3000)
		{
			return true;
		}
		return false;
	}

	public bool isShow()
	{
		if (_playerContext.cameraOwnerEntity != null && Contexts.sharedInstance.gameRule.currentRule.Rule.IsBio())
		{
			if (_playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.BIO_FAKE_DEAD.ID))
			{
				if (!_isShow)
				{
					_remainTime = 0;
					_isShow = true;
				}
				return true;
			}
			_isShow = false;
		}
		return false;
	}
}
