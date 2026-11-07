using Assets.Sources.Components.Time;
using share.constant;

public class rpgModelrpglongqibingbufferProvider : IrpgModelrpglongqibingbufferProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerEntity;

	public rpgModelrpglongqibingbufferProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerEntity = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool Show(int index)
	{
		if (index <= 1)
		{
			return _playerEntity.myPlayerEntity.HasPlayerInfo(PlayerInfoStatusConstant.dragooon_a_130_buff.ID);
		}
		return _playerEntity.myPlayerEntity.HasPlayerInfo(PlayerInfoStatusConstant.dragooon_a_134_buff.ID);
	}

	public string GetLevel(int index)
	{
		if (index == 0)
		{
			if (_playerEntity.myPlayerEntity.HasPlayerInfo(PlayerInfoStatusConstant.dragooon_a_130_buff.ID))
			{
				return _playerEntity.myPlayerEntity.skill.Status[PlayerInfoStatusConstant.dragooon_a_130_buff.ID].Number.ToString();
			}
		}
		else if (_playerEntity.myPlayerEntity.HasPlayerInfo(PlayerInfoStatusConstant.dragooon_a_134_buff.ID))
		{
			return _playerEntity.myPlayerEntity.skill.Status[PlayerInfoStatusConstant.dragooon_a_134_buff.ID].Number.ToString();
		}
		return "";
	}
}
