using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using I2.Loc;
using SSJJBase.String;

public class freeRpg_107000ModelRankProvider : IfreeRpg_107000ModelRankProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	private const int YiSum = 100000000;

	private const int WangSum = 10000;

	public freeRpg_107000ModelRankProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.mystery.RankLeftTime > 0)
		{
			_gameRuleContext.mystery.RankLeftTime -= time.FrameInterval;
			if (_gameRuleContext.mystery.RankLeftTime < 0)
			{
				_gameRuleContext.mystery.RankLeftTime = 0;
			}
		}
	}

	public string GetAllDamage()
	{
		return GetRank(_gameRuleContext.mystery.RankSelfAllDamage);
	}

	public bool IsRankshow()
	{
		return _gameRuleContext.mystery.IsShowRank;
	}

	public string GetSecDamage()
	{
		return GetRank(_gameRuleContext.mystery.RankSelfSecDamage);
	}

	public string GetSelfName()
	{
		return UiIEventCondition.Get_cameraOwnerData_PlayerName();
	}

	public string GetRefreshTime()
	{
		return string.Concat(_gameRuleContext.mystery.RankLeftTime / 1000);
	}

	public bool IsRankShow(int index)
	{
		if (_gameRuleContext.mystery.OtherRankCids != null)
		{
			return _gameRuleContext.mystery.OtherRankCids.Count > index;
		}
		return false;
	}

	public string GetRankName(int index)
	{
		if (_gameRuleContext.mystery.OtherRankCids != null && _gameRuleContext.mystery.OtherRankCids.Count > index)
		{
			long num = _gameRuleContext.mystery.OtherRankCids[index];
			foreach (PlayerEntity item in _playerContext)
			{
				if (item.basicInfo.Cid == num)
				{
					return item.basicInfo.PlayerName;
				}
			}
		}
		return "";
	}

	public string GetRankTitle(int index)
	{
		return string.Concat(index + 1);
	}

	public string GetRankDamage(int index)
	{
		if (_gameRuleContext.mystery.OtherRankDamages != null && _gameRuleContext.mystery.OtherRankDamages.Count > index)
		{
			return GetRank(_gameRuleContext.mystery.OtherRankDamages[index]);
		}
		return "0";
	}

	private string GetRank(long value)
	{
		long num = value / 100000000;
		long num2 = value % 100000000 / 10000;
		int num3 = (int)(value % 100000000 % 10000);
		if (num > 0)
		{
			if (num2 > 0)
			{
				return string.Format(ScriptLocalization.Get("MY_MSTERY_LIGHT_YI_WANG"), num, num2);
			}
			return string.Format(ScriptLocalization.Get("MY_MSTERY_LIGHT_YI"), num);
		}
		if (num2 > 0)
		{
			if (num3 > 0)
			{
				return string.Format(ScriptLocalization.Get("MY_MSTERY_LIGHT_WANG_QIAN"), num2, num3);
			}
			return string.Format(ScriptLocalization.Get("MY_MSTERY_LIGHT_WANG"), num2);
		}
		return StringCache.IntToString(num3);
	}
}
